using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Simulation
    {
        public static SumoCommand Convert2D(string edgeID, double pos, byte laneIndex, string toGeo)
        {
            Object[] array = new Object[]{pos, laneIndex, toGeo};
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.POSITION_CONVERSION, edgeID, array, Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand Convert3D(string edgeID, double pos, byte laneIndex, string toGeo)
        {
            Object[] array = new Object[]{pos, laneIndex, toGeo};
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.POSITION_CONVERSION, edgeID, array, Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand ConvertGeo(double x, double y, string fromGeo)
        {
            Object[] array = new Object[]{y, fromGeo};
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.POSITION_CONVERSION, x, array, Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand ConvertRoad(double x, double y, string isGeo)
        {
            Object[] array = new Object[]{y, isGeo};
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_POSITION, x, array, Constants.RESPONSE_GET_SIM_VARIABLE, Constants.POSITION_2D);
        }

        public static SumoCommand GetArrivedIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_ARRIVED_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetArrivedNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_ARRIVED_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetBusStopWaiting()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_BUS_STOP_WAITING, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetParkingEndingVehiclesIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_PARKING_ENDING_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetParkingEndingVehiclesNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_PARKING_ENDING_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetParkingStartingVehiclesIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_PARKING_STARTING_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetParkingStartingVehiclesNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_PARKING_STARTING_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetStopEndingVehiclesIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_STOP_ENDING_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetStopEndingVehiclesNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_STOP_ENDING_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetStopStartingVehiclesIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_STOP_STARTING_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetStopStartingVehiclesNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_STOP_STARTING_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetCurrentTime()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_TIME_STEP, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetDeltaT()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_DELTA_T, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetDepartedIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_DEPARTED_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetDepartedNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_DEPARTED_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetDistance2D(double x1, double y1, double x2, double y2, string isGeo, string isDriving)
        {
            Object[] array = new Object[]{y1, x2, y2, isGeo, isDriving};
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.POSITION_LON_LAT, x1, array, Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetDistanceRoad(string edgeID1, double pos1, string edgeID2, double pos2, string isDriving)
        {
            Object[] array = new Object[]{pos1, edgeID2, pos2, isDriving};
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.REQUEST_DRIVINGDIST, edgeID1, array, Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetEndingTeleportIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_TELEPORT_ENDING_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetEndingTeleportNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_TELEPORT_ENDING_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLoadedIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_LOADED_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLoadedNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_LOADED_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetMinExpectedNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_MIN_EXPECTED_VEHICLES, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetNetBoundary()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_NET_BOUNDING_BOX, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_BOUNDINGBOX);
        }

        public static SumoCommand GetStartingTeleportIDList()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_TELEPORT_STARTING_VEHICLES_IDS, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetStartingTeleportNumber()
        {
            return new SumoCommand(Constants.CMD_GET_SIM_VARIABLE, Constants.VAR_TELEPORT_STARTING_VEHICLES_NUMBER, "", Constants.RESPONSE_GET_SIM_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand ClearPending(string routeID)
        {
            return new SumoCommand(Constants.CMD_SET_SIM_VARIABLE, Constants.CMD_CLEAR_PENDING_VEHICLES, "", routeID);
        }
    }
}