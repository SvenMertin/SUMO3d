using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Route
    {
        public static SumoCommand GetEdges(string routeID)
        {
            return new SumoCommand(Constants.CMD_GET_ROUTE_VARIABLE, Constants.VAR_EDGES, routeID, Constants.RESPONSE_GET_ROUTE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_ROUTE_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_ROUTE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_ROUTE_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_ROUTE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand Add(string routeID, SumoStringList edges)
        {
            return new SumoCommand(Constants.CMD_SET_ROUTE_VARIABLE, Constants.ADD, routeID, edges);
        }
    }
}