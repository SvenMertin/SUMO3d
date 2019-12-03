using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Edge
    {
        public static SumoCommand GetAdaptedTraveltime(string edgeID, int time)
        {
            Object[] array = new Object[]{time};
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_EDGE_TRAVELTIME, edgeID, array, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetCO2Emission(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_CO2EMISSION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetCOEmission(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_COEMISSION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetEffort(string edgeID, int time)
        {
            Object[] array = new Object[]{time};
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_EDGE_EFFORT, edgeID, array, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetFuelConsumption(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_FUELCONSUMPTION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetHCEmission(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_HCEMISSION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLastStepHaltingNumber(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.LAST_STEP_VEHICLE_HALTING_NUMBER, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLastStepLength(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.LAST_STEP_LENGTH, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepMeanSpeed(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.LAST_STEP_MEAN_SPEED, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepOccupancy(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.LAST_STEP_OCCUPANCY, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepVehicleIDs(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.LAST_STEP_VEHICLE_ID_LIST, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLastStepVehicleNumber(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.LAST_STEP_VEHICLE_NUMBER, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetNOxEmission(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_NOXEMISSION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetNoiseEmission(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_NOISEEMISSION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetPMxEmission(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_PMXEMISSION, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetTraveltime(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_CURRENT_TRAVELTIME, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetWaitingTime(string edgeID)
        {
            return new SumoCommand(Constants.CMD_GET_EDGE_VARIABLE, Constants.VAR_WAITING_TIME, edgeID, Constants.RESPONSE_GET_EDGE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand AdaptTraveltime(string edgeID, int time)
        {
            return new SumoCommand(Constants.CMD_SET_EDGE_VARIABLE, Constants.VAR_EDGE_TRAVELTIME, edgeID, time);
        }

        public static SumoCommand SetEffort(string edgeID, double effort)
        {
            return new SumoCommand(Constants.CMD_SET_EDGE_VARIABLE, Constants.VAR_EDGE_EFFORT, edgeID, effort);
        }

        public static SumoCommand SetMaxSpeed(string edgeID, double speed)
        {
            return new SumoCommand(Constants.CMD_SET_EDGE_VARIABLE, Constants.VAR_MAXSPEED, edgeID, speed);
        }
    }
}