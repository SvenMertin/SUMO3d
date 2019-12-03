using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Inductionloop
    {
        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLaneID(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.VAR_LANE_ID, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetLastStepMeanLength(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_LENGTH, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepMeanSpeed(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_MEAN_SPEED, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepOccupancy(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_OCCUPANCY, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepVehicleIDs(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_VEHICLE_ID_LIST, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLastStepVehicleNumber(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_VEHICLE_NUMBER, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetPosition(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.VAR_POSITION, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetTimeSinceDetection(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_TIME_SINCE_DETECTION, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetVehicleData(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_INDUCTIONLOOP_VARIABLE, Constants.LAST_STEP_VEHICLE_DATA, loopID, Constants.RESPONSE_GET_INDUCTIONLOOP_VARIABLE, Constants.TYPE_INTEGER);
        }
    }
}