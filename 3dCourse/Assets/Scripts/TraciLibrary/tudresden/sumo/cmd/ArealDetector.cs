using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class ArealDetector
    {
        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_AREAL_DETECTOR_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_AREAL_DETECTOR_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_AREAL_DETECTOR_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_AREAL_DETECTOR_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetJamLengthVehicle(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_AREAL_DETECTOR_VARIABLE, Constants.JAM_LENGTH_VEHICLE, loopID, Constants.RESPONSE_GET_AREAL_DETECTOR_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetJamLengthMeters(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_AREAL_DETECTOR_VARIABLE, Constants.JAM_LENGTH_METERS, loopID, Constants.RESPONSE_GET_AREAL_DETECTOR_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepMeanSpeed(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_AREAL_DETECTOR_VARIABLE, Constants.LAST_STEP_MEAN_SPEED, loopID, Constants.RESPONSE_GET_AREAL_DETECTOR_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepOccupancy(string loopID)
        {
            return new SumoCommand(Constants.CMD_GET_AREAL_DETECTOR_VARIABLE, Constants.LAST_STEP_OCCUPANCY, loopID, Constants.RESPONSE_GET_AREAL_DETECTOR_VARIABLE, Constants.TYPE_DOUBLE);
        }
    }
}