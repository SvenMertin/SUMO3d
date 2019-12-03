using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Log
{
    public interface ILog
    {
        void Write(string input, int priority);
        void Txt_output(bool txt_output);
    }
}