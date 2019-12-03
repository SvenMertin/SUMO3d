using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TraciConnector.Protocol;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector
{
    public class CloseQuery : Query
    {
        public CloseQuery(Socket sock): base (sock)
        {
        }

        public virtual void DoExitSUMOCommand()
        {
            Command req = new Command(Constants.CMD_CLOSE);
            QueryAndVerifySingle(req);
        }
    }
}