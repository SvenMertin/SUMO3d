using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Multientryexit
    {
        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLastStepHaltingNumber(string detID)
        {
            return new SumoCommand(Constants.CMD_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.LAST_STEP_VEHICLE_HALTING_NUMBER, detID, Constants.RESPONSE_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLastStepMeanSpeed(string detID)
        {
            return new SumoCommand(Constants.CMD_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.LAST_STEP_MEAN_SPEED, detID, Constants.RESPONSE_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepVehicleIDs(string detID)
        {
            return new SumoCommand(Constants.CMD_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.LAST_STEP_VEHICLE_ID_LIST, detID, Constants.RESPONSE_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLastStepVehicleNumber(string detID)
        {
            return new SumoCommand(Constants.CMD_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.LAST_STEP_VEHICLE_NUMBER, detID, Constants.RESPONSE_GET_MULTI_ENTRY_EXIT_DETECTOR_VARIABLE, Constants.TYPE_INTEGER);
        }
    }
}