using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Polygon
    {
        public static SumoCommand GetColor(string polygonID)
        {
            return new SumoCommand(Constants.CMD_GET_POLYGON_VARIABLE, Constants.VAR_COLOR, polygonID, Constants.RESPONSE_GET_POLYGON_VARIABLE, Constants.TYPE_COLOR);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_POLYGON_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_POLYGON_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_POLYGON_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_POLYGON_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetShape(string polygonID)
        {
            return new SumoCommand(Constants.CMD_GET_POLYGON_VARIABLE, Constants.VAR_SHAPE, polygonID, Constants.RESPONSE_GET_POLYGON_VARIABLE, Constants.TYPE_POLYGON);
        }

        public static SumoCommand GetType(string polygonID)
        {
            return new SumoCommand(Constants.CMD_GET_POLYGON_VARIABLE, Constants.VAR_TYPE, polygonID, Constants.RESPONSE_GET_POLYGON_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand Add(string polygonID, SumoGeometry shape, SumoColor color, bool fill, string polygonType, int layer)
        {
            Object[] array = new Object[]{shape, color, fill, polygonType, layer};
            return new SumoCommand(Constants.CMD_SET_POLYGON_VARIABLE, Constants.ADD, polygonID, array);
        }

        public static SumoCommand Remove(string polygonID, int layer)
        {
            return new SumoCommand(Constants.CMD_SET_POLYGON_VARIABLE, Constants.REMOVE, polygonID, layer);
        }

        public static SumoCommand SetColor(string polygonID, SumoColor color)
        {
            return new SumoCommand(Constants.CMD_SET_POLYGON_VARIABLE, Constants.VAR_COLOR, polygonID, color);
        }

        public static SumoCommand SetShape(string polygonID, SumoStringList shape)
        {
            return new SumoCommand(Constants.CMD_SET_POLYGON_VARIABLE, Constants.VAR_SHAPE, polygonID, shape);
        }

        public static SumoCommand SetType(string polygonID, string polygonType)
        {
            return new SumoCommand(Constants.CMD_SET_POLYGON_VARIABLE, Constants.VAR_TYPE, polygonID, polygonType);
        }
    }
}