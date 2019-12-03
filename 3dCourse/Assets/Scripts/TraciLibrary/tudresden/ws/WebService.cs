using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Ws.Conf;
using TraciConnector.Tudresden.Ws.Log;

namespace TraciConnector.Tudresden.Ws
{
    public class WebService
    {
        static Config conf;
        static ILog logger;
        /*
        public static void Main(string[] args)
        {
            conf = new Config();
            if (args.Length == 1)
                conf.Read_config(args[0]);
            logger = conf.logger;
            logger.Write(conf.name + " is going to start", 1);
            IService server = new Service_Impl(conf);
            logger.Write("The webservice (Version " + server.Version() + ") is available under " + conf.Get_url(), 1);
            Endpoint endpoint = Endpoint.Publish(conf.Get_url(), server);
            ShutdownHook shutdownHook = new ShutdownHook();
            Runtime.GetRuntime().AddShutdownHook(shutdownHook);
            while (shutdownHook.Isshutdown() != true)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    logger.Write(e.GetStackTrace());
                }
            }

            try
            {
                endpoint.Stop();
            }
            catch (Exception e)
            {
                logger.Write(e.GetStackTrace());
            }

            logger.Write(conf.name + " finished successfully.", 1);
        }*/
    }
    
}