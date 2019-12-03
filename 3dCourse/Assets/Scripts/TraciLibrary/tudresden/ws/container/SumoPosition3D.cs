using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoPosition3D
    {
        public double x;
        public double y;
        public double z;
        public SumoPosition3D()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public SumoPosition3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public new string ToString()
        {
            return this.x + "," + this.y + "," + this.z;
        }
    }
}