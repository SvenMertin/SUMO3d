using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Conf;
using TraciConnector.Tudresden.Ws.Log;

namespace TraciConnector.Tudresden.Ws
{
    public class Service_Impl : Traci, IService
    {
        ILog logger;
        Config conf;
        TraciConnector.Tudresden.Sumo.Util.Sumo sumo;
        ConvertHelper helper;
        public Service_Impl(Config conf)
        {
            this.conf = conf;
            this.logger = conf.logger;
            this.conf.Refresh_actiontime();
            this.helper = new ConvertHelper();
        }

        public virtual string Start(string user)
        {
            string output = "failed";
            if (!this.conf.running)
            {
                conf.running = true;
                logger.Write("Benutzer " + user + " startet den " + conf.name + " Service", 1);
                sumo = new TraciConnector.Tudresden.Sumo.Util.Sumo(this.conf);
                sumo.Start_ws();
                base.Init(sumo, helper);
                this.conf.Refresh_actiontime();
                output = "success";
            }

            return output;
        }

        public virtual string Stop(string user)
        {
            sumo.Stop_instance();
            conf.running = false;
            return "success";
        }

        public virtual string Get_Status(string user)
        {
            this.conf.Refresh_actiontime();
            return "Running: " + conf.running;
        }

        public virtual string LastActionTime()
        {
            return conf.Get_actiontime();
        }

        public virtual string Version()
        {
            return conf.version;
        }

        public virtual string TXT_output(bool input)
        {
            logger.Txt_output(input);
            return "success";
        }

        public virtual void AddOption(string name, string value)
        {
            if (!conf.running)
            {
                this.conf.sumo_output.Add(name, value);
            }
        }

        public virtual void DoTimestep()
        {
            if (conf.running)
            {
                this.sumo.Do_timestep();
            }
        }

        public virtual void SetConfig(string filename)
        {
            if (!this.conf.running)
            {
                this.conf.config_file = filename;
            }
        }

        public virtual void SetSumoBinary(string filename)
        {
            if (!this.conf.running)
            {
                this.conf.sumo_bin = filename;
            }
        }
    }
}