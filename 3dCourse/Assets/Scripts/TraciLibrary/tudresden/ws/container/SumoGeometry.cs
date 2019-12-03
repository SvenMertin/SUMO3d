using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{
    public class SumoGeometry
    {
        public LinkedList<SumoPosition2D> coords;
        public SumoGeometry()
        {
            this.coords = new LinkedList<SumoPosition2D>();
        }

        public virtual void Add(SumoPosition2D pos)
        {
            this.coords.AddLast(pos);
        }

        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SumoPosition2D pos in coords)
            {
                sb.Append(pos.x + ",");
                sb.Append(pos.y + " ");
            }

            return sb.ToString().Trim();
        }

        public virtual void FromString(string shape)
        {
            String[] arr = shape.Split(' ');
            foreach (string s in arr)
            {
                String[] tmp = s.Split(',');
                double x = Double.Parse(tmp[0]);
                double y = Double.Parse(tmp[1]);
                this.Add(new SumoPosition2D(x, y));
            }
        }
    }
}