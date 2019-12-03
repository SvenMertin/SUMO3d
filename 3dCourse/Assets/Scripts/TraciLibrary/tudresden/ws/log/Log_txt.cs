using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Log
{
    public class Log_txt : ILog
    {
        private bool txt_output = false;
        
        public void Write(string input, int priority)
        {
            if (priority == 1)
            {
                //System.out_renamed.Println(input);
            }

            if (txt_output)
            {
                /*
                try
                {
                    FileWriter fw = new FileWriter("output.txt", true);
                    fw.Write(Get_message(input));
                    fw.Flush();
                    fw.Close();
                }
                catch (Exception e)
                {
                    //System.out_renamed.Println(e);
                }
                */
            }
        }

        /*
        public virtual void Write(StackTraceElement[] el)
        {
            for (int i = el.Length - 1; i >= 0; i--)
            {
                //System.err.Println(el[i].ToString());
            }
        }
        */
        public virtual void Txt_output(bool txt_output)
        {
            this.txt_output = txt_output;
        }

        private string Get_message(string input)
        {
            return new DateTime().ToString("hh:mm:ss dd.MM.yyyy") + " - " + input + "\\n";
        }
    }
}