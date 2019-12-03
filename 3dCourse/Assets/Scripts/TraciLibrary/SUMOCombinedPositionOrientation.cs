using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Ws.Container;

namespace Assets.Traci
{
    class SUMOCombinedPositionOrientation
    {
        public string id;
        public SumoPosition3D position;
        public double orientation;
        
        public SUMOCombinedPositionOrientation(string id, SumoPosition3D position, double orientation)
        {
            this.id = id;
            this.position = position;
            this.orientation = orientation;
        }

    }
}
