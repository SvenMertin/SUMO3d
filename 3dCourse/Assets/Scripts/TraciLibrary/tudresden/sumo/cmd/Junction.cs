using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Junction
    {
        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_JUNCTION_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_JUNCTION_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_JUNCTION_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_JUNCTION_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetPosition(string junctionID)
        {
            return new SumoCommand(Constants.CMD_GET_JUNCTION_VARIABLE, Constants.VAR_POSITION, junctionID, Constants.RESPONSE_GET_JUNCTION_VARIABLE, Constants.POSITION_2D);
        }

        public static SumoCommand GetShape(string junctionID)
        {
            return new SumoCommand(Constants.CMD_GET_JUNCTION_VARIABLE, Constants.VAR_SHAPE, junctionID, Constants.RESPONSE_GET_JUNCTION_VARIABLE, Constants.TYPE_POLYGON);
        }
    }
}