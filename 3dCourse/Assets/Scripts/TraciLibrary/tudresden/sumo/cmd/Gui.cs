using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Gui
    {
        public static SumoCommand GetBoundary(string viewID)
        {
            return new SumoCommand(Constants.CMD_GET_GUI_VARIABLE, Constants.VAR_VIEW_BOUNDARY, viewID, Constants.RESPONSE_GET_GUI_VARIABLE, Constants.TYPE_BOUNDINGBOX);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_GUI_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_GUI_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetOffset(string viewID)
        {
            return new SumoCommand(Constants.CMD_GET_GUI_VARIABLE, Constants.VAR_VIEW_OFFSET, viewID, Constants.RESPONSE_GET_GUI_VARIABLE, Constants.POSITION_2D);
        }

        public static SumoCommand GetSchema(string viewID)
        {
            return new SumoCommand(Constants.CMD_GET_GUI_VARIABLE, Constants.VAR_VIEW_SCHEMA, viewID, Constants.RESPONSE_GET_GUI_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetZoom(string viewID)
        {
            return new SumoCommand(Constants.CMD_GET_GUI_VARIABLE, Constants.VAR_VIEW_ZOOM, viewID, Constants.RESPONSE_GET_GUI_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand Screenshot(string viewID, string filename)
        {
            return new SumoCommand(Constants.CMD_SET_GUI_VARIABLE, Constants.VAR_SCREENSHOT, viewID, filename);
        }

        public static SumoCommand SetBoundary(string viewID, double xmin, double ymin, double xmax, double ymax)
        {
            Object[] array = new Object[]{xmin, ymin, xmax, ymax};
            return new SumoCommand(Constants.CMD_SET_GUI_VARIABLE, Constants.VAR_VIEW_BOUNDARY, viewID, array);
        }

        public static SumoCommand SetOffset(string viewID, double x, double y)
        {
            Object[] array = new Object[]{x, y};
            return new SumoCommand(Constants.CMD_SET_GUI_VARIABLE, Constants.VAR_VIEW_OFFSET, viewID, array);
        }

        public static SumoCommand SetSchema(string viewID, string schemeName)
        {
            return new SumoCommand(Constants.CMD_SET_GUI_VARIABLE, Constants.VAR_VIEW_SCHEMA, viewID, schemeName);
        }

        public static SumoCommand SetZoom(string viewID, double zoom)
        {
            return new SumoCommand(Constants.CMD_SET_GUI_VARIABLE, Constants.VAR_VIEW_ZOOM, viewID, zoom);
        }

        public static SumoCommand TrackVehicle(string viewID, string vehID)
        {
            return new SumoCommand(Constants.CMD_SET_GUI_VARIABLE, Constants.VAR_TRACK_VEHICLE, viewID, vehID);
        }
    }
}