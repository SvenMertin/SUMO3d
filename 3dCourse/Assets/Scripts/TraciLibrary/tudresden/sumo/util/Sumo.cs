using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Ws.Log;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Ws.Conf;
using UnityEngine;

namespace TraciConnector.Tudresden.Sumo.Util
{
    public class Sumo
    {
        ILog logger;
        Config conf;
        public SumoTraciConnection conn;
        bool running = false;
        public Sumo()
        {
        }

        public Sumo(Config conf)
        {
            this.conf = conf;
        }

        public virtual void Start(string sumo_bin, string configFile)
        {
            conn = new SumoTraciConnection(sumo_bin, configFile);
            try
            {
                conn.RunServer("127.0.0.1",0);
                this.running = true;
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
                this.running = false;
            }
        }

        public virtual void Start(string sumo_bin, string net_file, string route_file)
        {
            conn = new SumoTraciConnection(sumo_bin, net_file, route_file);
            try
            {
                conn.RunServer("127.0.0.1", 0);
                this.running = true;
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
                this.running = false;
            }
        }

        public virtual bool Set_cmd(System.Object in_renamed)
        {
            bool output = false;
            if (this.running)
            {
                try
                {
                    this.conn.Do_job_set((SumoCommand)in_renamed);
                    output = true;
                }
                catch (Exception ex)
                {
                    MonoBehaviour.print(ex.GetBaseException());
                }
            }

            return output;
        }

        public virtual System.Object Get_cmd(SumoCommand cmd)
        {
            System.Object obj = -1;
            if (this.running)
            {
                try
                {
                    obj = conn.Do_job_get(cmd);
                }
                catch (Exception ex)
                {
                    MonoBehaviour.print(ex.GetBaseException());
                }
            }

            return obj;
        }

        public virtual void Do_timestep()
        {
            try
            {
                conn.Do_timestep();
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }
        }

        public virtual void Start_ws()
        {
            conn = new SumoTraciConnection(conf.sumo_bin, conf.config_file);
            //this.Add_options();
            try
            {
                conn.RunServer("127.0.0.1",0);
                this.running = true;
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
                this.running = false;
            }
        }
        /*
        private void Add_options()
        {
            Set<Entry<String, String>> set = this.conf.sumo_output.EntrySet();
            Iterator<Entry<String, String>> it = set.Iterator();
            while (it.HasNext())
            {
                Entry<String, String> option = it.Next();
                conn.AddOption(option.GetKey(), option.GetValue());
            }
        }
        */
        public virtual void Stop_instance()
        {
            try
            {
                conn.Close(false);
                this.running = false;
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }
        }
    }
}