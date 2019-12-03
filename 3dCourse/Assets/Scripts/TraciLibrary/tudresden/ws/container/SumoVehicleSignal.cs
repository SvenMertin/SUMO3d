using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoVehicleSignal
    {
        LinkedList<int> ll_states;
        public SumoVehicleSignal(int code)
        {
            string s1 = this.GetDual(code);
            String[] tmp = s1.Split(("").ToCharArray());
            this.ll_states = new LinkedList<int>();
            for (int i = 0; i < 14; i++)
            {
                this.ll_states.AddLast(0);
            }

            for (int i = tmp.Length - 1; i > 0; i--)
            {
                int pos = tmp.Length - i - 1;
                
                this.ll_states.Find(this.ll_states.ElementAt(pos)).Value= int.Parse(tmp[i]);
            }
        }

        public bool GetState(SumoVehicleSignalState s)
        {
            bool out_renamed = false;
            if (Convert.ToBoolean(this.ll_states.ElementAt(Convert.ToInt32(s.getPos() == 1))))
            {
                out_renamed = true;
            }

            return out_renamed;
        }

        private string GetDual(int code)
        {
            if (code < 2)
            {
                return "" + code;
            }
            else
            {
                return GetDual(code / 2) + code % 2;
            }
        }
    }
}