using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Vehicletype
    {
        public static SumoCommand GetAccel(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_ACCEL, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetColor(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_COLOR, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_COLOR);
        }

        public static SumoCommand GetDecel(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_DECEL, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetEmissionClass(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_EMISSIONCLASS, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetImperfection(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_IMPERFECTION, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLength(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_LENGTH, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetMaxSpeed(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_MAXSPEED, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetMinGap(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_MINGAP, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetShapeClass(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_SHAPECLASS, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetSpeedDeviation(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_SPEED_DEVIATION, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetSpeedFactor(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_SPEED_FACTOR, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetTau(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_TAU, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetVehicleClass(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_VEHICLECLASS, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetWidth(string typeID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLETYPE_VARIABLE, Constants.VAR_WIDTH, typeID, Constants.RESPONSE_GET_VEHICLETYPE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand SetAccel(string typeID, double accel)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_ACCEL, typeID, accel);
        }

        public static SumoCommand SetColor(string typeID, SumoColor color)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_COLOR, typeID, color);
        }

        public static SumoCommand SetDecel(string typeID, double decel)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_DECEL, typeID, decel);
        }

        public static SumoCommand SetEmissionClass(string typeID, string clazz)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_EMISSIONCLASS, typeID, clazz);
        }

        public static SumoCommand SetImperfection(string typeID, double imperfection)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_IMPERFECTION, typeID, imperfection);
        }

        public static SumoCommand SetLength(string typeID, double length)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_LENGTH, typeID, length);
        }

        public static SumoCommand SetMaxSpeed(string typeID, double speed)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_MAXSPEED, typeID, speed);
        }

        public static SumoCommand SetMinGap(string typeID, double minGap)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_MINGAP, typeID, minGap);
        }

        public static SumoCommand SetShapeClass(string typeID, string clazz)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_SHAPECLASS, typeID, clazz);
        }

        public static SumoCommand SetSpeedDeviation(string typeID, double deviation)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_SPEED_DEVIATION, typeID, deviation);
        }

        public static SumoCommand SetSpeedFactor(string typeID, double factor)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_SPEED_FACTOR, typeID, factor);
        }

        public static SumoCommand SetTau(string typeID, double tau)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_TAU, typeID, tau);
        }

        public static SumoCommand SetVehicleClass(string typeID, string clazz)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_VEHICLECLASS, typeID, clazz);
        }

        public static SumoCommand SetWidth(string typeID, double width)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLETYPE_VARIABLE, Constants.VAR_WIDTH, typeID, width);
        }
    }
}