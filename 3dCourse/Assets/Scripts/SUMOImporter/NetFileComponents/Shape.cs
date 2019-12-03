using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.SUMOImporter.NetFileComponents
{
    public class Shape
    {
        private List<double[]> coordPairs = new List<double[]>();

        public Shape()
        {
            this.coordPairs.Clear();
        }

        public void addCoordPair(double x, double y)
        {
            this.coordPairs.Add(new double[] { x, y });
        }

        public void removeLastCoordPairAndFixOrder()
        {
            this.coordPairs.RemoveAt(this.coordPairs.Count - 1);

            this.coordPairs.OrderBy(x => Math.Atan2(x[0], x[1])).ToList();
        }

        public List<double[]> getAllcoordPairs()
        {
            return this.coordPairs;
        }

    }
}
