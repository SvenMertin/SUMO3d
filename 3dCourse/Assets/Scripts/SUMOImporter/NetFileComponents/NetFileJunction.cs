#if (UNITY_EDITOR) 
using System;
using System.Collections.Generic;

namespace Assets.Scripts.SUMOImporter.NetFileComponents
{
    public class NetFileJunction
    {
        public string id;
        public junctionTypeType type;
        public float x;
        public float y;
        public float z;

        public List<NetFileLane> incLanes;
        public List<double[]> shape;

        public NetFileJunction(string id, junctionTypeType type, float x, float y, float z, string incLanes, string shape)
        {
            this.id = id;
            this.type = type;
            this.x = x;
            this.y = y;
            this.z = z;

            // Get incoming Lanes
            this.incLanes= new List<NetFileLane>();
            foreach(string stringPiece in incLanes.Split(' '))
            {
                NetFileLane l = new NetFileLane(stringPiece);
                this.incLanes.Add(l);

                // Add to global list
                if(!ImportAndGenerate.lanes.ContainsKey(l.id))
                    ImportAndGenerate.lanes.Add(l.id, l);
            }

            // Get shape coordinates as List of tuple-arrays
            this.shape = new List<double[]>();
            foreach(string stringPiece in shape.Split(' '))
            {
                double xC = Convert.ToDouble(stringPiece.Split(',')[0]);
                double yC = Convert.ToDouble(stringPiece.Split(',')[1]);
                this.shape.Add(new double[] { xC, yC });
            }
        }
    }
}
#endif