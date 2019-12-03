using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws
{
    public interface IService
    {
        string Start(string user);
        string Stop(string user);
        void AddOption(string name, string value);
        void DoTimestep();
        void SetConfig(string filename);
        void SetSumoBinary(string filename);
        string Get_Status(string user);
        string LastActionTime();
        string Version();
        string TXT_output(bool input);
    }
}