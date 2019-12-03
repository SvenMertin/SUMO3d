using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoTLSLogic
    {
        public string subID;
        public int type;
        public int subParameter;
        public int currentPhaseIndex;
        public LinkedList<SumoTLSPhase> phases;
        public SumoTLSLogic()
        {
            this.subID = "unkown";
            this.type = -1;
            this.subParameter = -1;
            this.currentPhaseIndex = -1;
            this.phases = new LinkedList<SumoTLSPhase>();
        }

        public SumoTLSLogic(string subID, int type, int subParameter, int currentPhaseIndex)
        {
            this.subID = subID;
            this.type = type;
            this.subParameter = subParameter;
            this.currentPhaseIndex = currentPhaseIndex;
            this.phases = new LinkedList<SumoTLSPhase>();
        }

        public virtual void Add(SumoTLSPhase phase)
        {
            this.phases.AddLast(phase);
        }

        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.subID + "#");
            sb.Append(this.type + "#");
            sb.Append(this.subParameter + "#");
            sb.Append(this.currentPhaseIndex + "#");
            foreach (SumoTLSPhase sp in this.phases)
            {
                sb.Append(sp.ToString() + "#");
            }

            return sb.ToString();
        }
    }
}