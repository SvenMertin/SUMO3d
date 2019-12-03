using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoTLSPhase
    {
        public int duration;
        public int duration1;
        public int duration2;
        public string phasedef;
        public SumoTLSPhase()
        {
            this.duration = 0;
            this.duration1 = 0;
            this.duration2 = 0;
            this.phasedef = "r";
        }

        public SumoTLSPhase(int duration, int duration1, int duration2, string phasedef)
        {
            this.duration = duration;
            this.duration1 = duration1;
            this.duration2 = duration2;
            this.phasedef = phasedef;
        }

        public SumoTLSPhase(int duration, string phasedef)
        {
            this.duration = duration;
            this.duration1 = duration;
            this.duration2 = duration;
            this.phasedef = phasedef;
        }

        public new string ToString()
        {
            return this.phasedef + "#" + this.duration + "#" + this.duration1 + "#" + this.duration2;
        }
    }
}