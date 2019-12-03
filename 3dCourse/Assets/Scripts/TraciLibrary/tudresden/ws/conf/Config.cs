using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Ws.Log;

namespace TraciConnector.Tudresden.Ws.Conf
{
    public class Config
    {


        public bool running = false;
        public static string host = "127.0.0.1";
        public static string port = "4223";
        public static string url = "SUMO";
        public string name = "Sumo Webservice";
        public  string sumo_bin = "f:/Programme/sumo-svn/bin/sumo-gui64.exe";
        public  string config_file = "simulation/lsa/config.sumo.cfg";
        public Dictionary<String, String> sumo_output = new Dictionary<String, String>();
        public DateTime lastactiontime;
        public string version = "1.1";
        public ILog logger;
        public Config()
        {
            logger = new Log_txt();
            Refresh_actiontime();
        }

        public virtual bool Read_config(string filename)
        {
            //bool valid = false;
            //try
            //{
            //    File file = new File(filename);
            //    if (file.Exists())
            //    {
            //        try
            //        {
            //            SAXParserFactory factory = SAXParserFactory.NewInstance();
            //            SAXParser saxParser = factory.NewSAXParser();
            //            saxParser.Parse(file, Get_handler());
            //        }
            //        catch (Exception ex)
            //        {
            //            ex.PrintStackTrace();
            //        }
            //    }
            //    else
            //    {
            //        System.out_renamed.Println("The file " + file.GetAbsolutePath() + " does not exist.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.PrintStackTrace();
            //}

            // return valid;

            return true;
        }

        public virtual string Get_url()
        {
            string out_renamed = "http://" + host + ":" + port + "/" + url;
            return out_renamed;
        }

        public virtual void Refresh_actiontime()
        {
            this.lastactiontime = new DateTime();
        }

        public virtual string Get_actiontime()
        {
            return this.lastactiontime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /*
        private static DefaultHandler Get_handler()
        {
            DefaultHandler handler = new AnonymousDefaultHandler(this);
            return handler;
        }
        
    
        private sealed class AnonymousDefaultHandler
        {
            public AnonymousDefaultHandler(Config parent)
            {
                this.parent = parent;
            }

            private readonly Config parent;
            public void StartElement(string uri, string localName, string qName, Attributes attributes)
            {
                if (qName.Equals("host"))
                {
                    host = attributes.GetValue("value");
                }

                if (qName.Equals("port"))
                {
                    port = attributes.GetValue("value");
                }

                if (qName.Equals("name"))
                {
                    url = attributes.GetValue("value");
                }

                if (qName.Equals("sumo_bin"))
                {
                    sumo_bin = attributes.GetValue("value");
                }

                if (qName.Equals("config_file"))
                {
                    config_file = attributes.GetValue("value");
                }
            }

            public void EndElement(string uri, string localName, string qName)
            {
            }

            public void Characters(char[] ch, int start, int length)
            {
            }
        }
        */
    }
}