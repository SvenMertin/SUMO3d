using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Poi
    {
        public static SumoCommand Add(string poiID, double x, double y, SumoColor color, string poiType, int layer)
        {
            Object[] array = new Object[]{x, y, color, poiType, layer};
            return new SumoCommand(Constants.CMD_SET_POI_VARIABLE, Constants.ADD, poiID, array);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_POI_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_POI_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetColor(string poiID)
        {
            return new SumoCommand(Constants.CMD_GET_POI_VARIABLE, Constants.VAR_COLOR, poiID, Constants.RESPONSE_GET_POI_VARIABLE, Constants.TYPE_COLOR);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_POI_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_POI_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetPosition(string poiID)
        {
            return new SumoCommand(Constants.CMD_GET_POI_VARIABLE, Constants.VAR_POSITION, poiID, Constants.RESPONSE_GET_POI_VARIABLE, Constants.POSITION_2D);
        }

        public static SumoCommand GetType(string poiID)
        {
            return new SumoCommand(Constants.CMD_GET_POI_VARIABLE, Constants.VAR_TYPE, poiID, Constants.RESPONSE_GET_POI_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand Remove(string poiID, int layer)
        {
            return new SumoCommand(Constants.CMD_SET_POI_VARIABLE, Constants.REMOVE, poiID, layer);
        }

        public static SumoCommand SetColor(string poiID, SumoColor color)
        {
            return new SumoCommand(Constants.CMD_SET_POI_VARIABLE, Constants.VAR_COLOR, poiID, color);
        }

        public static SumoCommand SetPosition(string poiID, double x, double y)
        {
            Object[] array = new Object[]{x, y};
            return new SumoCommand(Constants.CMD_SET_POI_VARIABLE, Constants.VAR_POSITION, poiID, array);
        }

        public static SumoCommand SetType(string poiID, string poiType)
        {
            return new SumoCommand(Constants.CMD_SET_POI_VARIABLE, Constants.VAR_TYPE, poiID, poiType);
        }
    }
}