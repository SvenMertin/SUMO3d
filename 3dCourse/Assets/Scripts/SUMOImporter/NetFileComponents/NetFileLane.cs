#if (UNITY_EDITOR) 
using System;
using System.Collections.Generic;

namespace Assets.Scripts.SUMOImporter.NetFileComponents
{
    public class NetFileLane
    {
        public string id;
        public int index;
        public double speed;
        public double length;
        public List<double[]> shape;
        
        public NetFileLane(string id)
        {
            this.id = id;
        }

        public NetFileLane(string id, int index, double speed, double length, string shape)
        {
            this.id = id;
            this.index = index;
            this.speed = speed;
            this.length = length;

            addShapeCoordinates(shape);
        }

        private void addShapeCoordinates(string shape)
        {
            // Get shape coordinates as List of tuple-arrays
            this.shape = new List<double[]>();
            foreach (string stringPiece in shape.Split(' '))
            {
                double xC = Convert.ToDouble(stringPiece.Split(',')[0]);
                double yC = Convert.ToDouble(stringPiece.Split(',')[1]);
                this.shape.Add(new double[] { xC, yC });
            }
        }

        internal void update(int index, double speed, double length, string shape)
        {
            this.index = index;
            this.speed = speed;
            this.length = length;

            addShapeCoordinates(shape);
        }
    }
}
#endif