using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoPosition2D
    {
        public double x;
        public double y;
        public SumoPosition2D()
        {
            this.x = 0;
            this.y = 0;
        }

        public SumoPosition2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public new string ToString()
        {
            return this.x + "," + this.y;
        }
    }
}