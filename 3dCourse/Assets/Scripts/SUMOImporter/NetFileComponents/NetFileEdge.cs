#if (UNITY_EDITOR) 
using System;
using System.Collections.Generic;

namespace Assets.Scripts.SUMOImporter.NetFileComponents
{
    public class NetFileEdge
    {
        string id;
        NetFileJunction from;
        NetFileJunction to;
        int priority;
        List<NetFileLane> lanes;        

        public NetFileEdge(string id, string from, string to, string priority, string shape)
        {
            this.id = id;
            this.priority = Convert.ToInt32(priority);

            this.lanes = new List<NetFileLane>();

            this.from = ImportAndGenerate.junctions[from];
            this.to = ImportAndGenerate.junctions[to];
        }

        public int getPriority()
        {
            return this.priority;
        }

        public void addLane(string id, string index, float speed, float length, string shape)
        {
            NetFileLane lane = ImportAndGenerate.lanes[id];
            lane.update(Convert.ToInt32(index), Convert.ToDouble(speed), Convert.ToDouble(length), shape);
            this.lanes.Add(new NetFileLane(id, Convert.ToInt32(index), speed, length, shape));
        }

        public List<NetFileLane> getLanes()
        {
            return this.lanes;
        }

        public NetFileJunction getFrom()
        {
            return this.from;
        }

        public NetFileJunction getTo()
        {
            return this.to;
        }

        public string getId()
        {
            return this.id;
        }
    }

    
}
#endif