using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoColor
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
        public SumoColor()
        {
            this.r = (byte)100;
            this.g = (byte)100;
            this.b = (byte)100;
            this.a = (byte)100;
        }

        public SumoColor(int r, int g, int b, int a)
        {
            this.r = (byte)r;
            this.g = (byte)g;
            this.b = (byte)b;
            this.a = (byte)a;
        }

        public new string ToString()
        {
            return r + "#" + g + "#" + b + "#" + a;
        }
    }
}