using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TraciConnector.Uniluebeck.Itm.Tcpip;
using System.Security.Cryptography;
using System.Threading;

namespace TraciConnector.Protocol
{
    public class RequestMessage
    {
        private  List<Command> commands = new List<Command>();
        public  void Append(Command c)
        {
            if (c == null)
                throw new Exception("the command can't be null");
            commands.Add(c);
        }

       public  void WriteTo(NetworkStream dos)
        {
            int totalLen = 32 / 8;
            foreach (Command cmd in commands)
            {
                totalLen += cmd.RawSize();
            }

            byte[] value = BitConverter.GetBytes(totalLen);
            Array.Reverse(value, 0, value.Length);
            dos.Write(value, 0, value.Length);
                        
            foreach (Command cmd in commands)
            {
                Storage s = new Storage();
                cmd.WriteRawTo(s);
                WriteStorage(s, dos);
            }
        }


        private void WriteStorage(Storage storage, NetworkStream os)
        {
            byte[] buf = new byte[storage.GetStorageList().Count()];
            int n = 0;
            foreach (Byte b in storage.GetStorageList())
            {
                buf[n] = b;
                n++;
            }

            os.Write(buf,0,buf.Length);
        }

        public  List<Command> Commands()
        {
            return new List<Command>(commands);
        }
    }
}