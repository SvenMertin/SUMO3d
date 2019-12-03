using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Lane
    {
        public static SumoCommand GetAllowed(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LANE_ALLOWED, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetCO2Emission(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_CO2EMISSION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetCOEmission(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_COEMISSION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetDisallowed(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LANE_DISALLOWED, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetEdgeID(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LANE_EDGE_ID, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetFuelConsumption(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_FUELCONSUMPTION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetHCEmission(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_HCEMISSION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLastStepHaltingNumber(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LAST_STEP_VEHICLE_HALTING_NUMBER, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLastStepLength(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LAST_STEP_LENGTH, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepMeanSpeed(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LAST_STEP_MEAN_SPEED, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepOccupancy(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LAST_STEP_OCCUPANCY, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLastStepVehicleIDs(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LAST_STEP_VEHICLE_ID_LIST, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetLastStepVehicleNumber(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LAST_STEP_VEHICLE_NUMBER, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLength(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_LENGTH, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLinkNumber(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LANE_LINK_NUMBER, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_UBYTE);
        }

        public static SumoCommand GetLinks(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.LANE_LINKS, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_COMPOUND);
        }

        public static SumoCommand GetMaxSpeed(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_MAXSPEED, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetNOxEmission(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_NOXEMISSION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetNoiseEmission(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_NOISEEMISSION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetPMxEmission(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_PMXEMISSION, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetShape(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_SHAPE, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_POLYGON);
        }

        public static SumoCommand GetTraveltime(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_CURRENT_TRAVELTIME, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetWidth(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_WIDTH, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetWaitingTime(string laneID)
        {
            return new SumoCommand(Constants.CMD_GET_LANE_VARIABLE, Constants.VAR_WAITING_TIME, laneID, Constants.RESPONSE_GET_LANE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand SetAllowed(string laneID, SumoStringList allowedClasses)
        {
            return new SumoCommand(Constants.CMD_SET_LANE_VARIABLE, Constants.LANE_ALLOWED, laneID, allowedClasses);
        }

        public static SumoCommand SetDisallowed(string laneID, SumoStringList disallowedClasses)
        {
            return new SumoCommand(Constants.CMD_SET_LANE_VARIABLE, Constants.LANE_DISALLOWED, laneID, disallowedClasses);
        }

        public static SumoCommand SetLength(string laneID, double length)
        {
            return new SumoCommand(Constants.CMD_SET_LANE_VARIABLE, Constants.VAR_LENGTH, laneID, length);
        }

        public static SumoCommand SetMaxSpeed(string laneID, double speed)
        {
            return new SumoCommand(Constants.CMD_SET_LANE_VARIABLE, Constants.VAR_MAXSPEED, laneID, speed);
        }
    }
}