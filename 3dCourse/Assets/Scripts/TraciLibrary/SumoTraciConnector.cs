using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Sumo.Conf;
using System.IO;
using TraciConnector.Tudresden.Sumo.Cmd;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TraciConnector
{
    public class SumoTraciConnection
    {
        private string configFile;
        private int randomSeed;
        private int remotePort;
        private Socket socket;
        private NetworkStream stream;
        private string net_file;
        private string route_file;
        string sumoEXE = "/opt/sumo/sumo-0.15.0/bin/sumo";
        private CommandProcessor cp;
        private System.Diagnostics.Process sumoProcess;
        private static readonly int CONNECT_RETRIES = 3;
        //private CloseQuery closeQuery;
        private List<String> args = new List<String>();
        private bool remote = false;
        public SumoTraciConnection(string sumo_bin, string net_file, string route_file)
        {
            this.sumoEXE = sumo_bin;
            this.net_file = net_file;
            this.route_file = route_file;
        }

        public SumoTraciConnection(string sumo_bin, string configFile)
        {
            this.sumoEXE = sumo_bin;
            this.configFile = configFile;
        }

        public SumoTraciConnection(string configFile, int randomSeed, bool useGeoOffset)
        {
            this.randomSeed = randomSeed;
            this.configFile = configFile;
        }

       

        public void AddOption(string option, string value)
        {
            args.Add("--" + option);
            if (value != null)
                args.Add(value);
        }

        public virtual void RunServer(string ipAddress, int remotePort)
        {
            this.remotePort = remotePort;
            if (!this.remote)
            {
                if(remotePort==0)
                    FindAvailablePort();
                RunSUMO();
                int waitTime = 500;
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    for (int i = 0; i < CONNECT_RETRIES; i++)
                    {
                        socket.NoDelay = true;
                        try
                        {
                            socket.Connect(ipAddress, remotePort);                               
                            break;
                        }
                        catch (Exception ce)
                        {
                            MonoBehaviour.print(ce.GetBaseException());
                            Thread.Sleep(waitTime);
                            waitTime *= 2;
                        }
                    }

                    if (!socket.Connected)
                    {
                        throw new Exception("can't connect to SUMO server");
                    }
                    else
                    {
                        this.cp = new CommandProcessor(socket);
                    }
                }
                catch (Exception ex)
                {
                    MonoBehaviour.print(ex.GetBaseException());
                }

                new CloseQuery(socket);
            }
        }

        private void RunSUMO()
        {
            //args.Insert(0, sumoEXE);
            if (this.configFile != null)
            {
                args.Add("-c");
                args.Add(configFile);
            }
            else
            {
                args.Add("--net-file");
                args.Add(this.net_file);
                args.Add("--route-files");
                args.Add(this.route_file);
            }

            args.Add("--remote-port");
            args.Add(remotePort.ToString());
            if (randomSeed != -1)
            {
                args.Add("--seed");
                args.Add(randomSeed.ToString());
            }

            System.Diagnostics.Process.Start(@sumoEXE,String.Join(" ",args.ToArray()));            
            
            
        }

        private void FindAvailablePort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            remotePort = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
        }

        public virtual void Close(bool closeSumo)
        {
            try {
                socket.Close();
                if (closeSumo)
                {
                    sumoProcess.Kill();                   
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }
        }

        private void CloseAndDontCareAboutInterruptedException()
        {
            Close(false);
        }

        public virtual bool IsClosed()
        {
            return socket == null || !socket.Connected;
        }

        public virtual void Do_job_set(SumoCommand cmd)
        {
            lock (this)
            {
                if (IsClosed())
                    throw new InvalidOperationException("connection is closed");
                try
                {
                    this.cp.Do_job_set(cmd);
                }
                catch (Exception e)
                {
                    CloseAndDontCareAboutInterruptedException();
                    throw e;
                }
            }
        }

        public virtual System.Object Do_job_get(SumoCommand cmd)
        {
            lock (this)
            {
                System.Object output = null;
                if (IsClosed())
                    throw new InvalidOperationException("connection is closed");
                try
                {
                    output = this.cp.Do_job_get(cmd);
                }
                catch (Exception e)
                {
                    CloseAndDontCareAboutInterruptedException();
                    throw e;
                }

                return output;
            }
        }

        public virtual void Do_timestep()
        {
            lock (this)
            {
                if (IsClosed())
                    throw new InvalidOperationException("connection is closed");
                try
                {
                    this.cp.Do_job_set(new SumoCommand(Constants.CMD_SIMSTEP2, 0));
                }
                catch (Exception e)
                {
                    CloseAndDontCareAboutInterruptedException();
                    throw e;
                }
            }
        }
    }
}