using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Vehicle
    {
        public static SumoCommand GetAccel(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_ACCEL, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetAdaptedTraveltime(string vehID, int time, string edgeID)
        {
            Object[] array = new Object[]{time, edgeID};
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_EDGE_TRAVELTIME, vehID, array, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetAngle(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_ANGLE, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetAllowedSpeed(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_ALLOWED_SPEED, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLeader(string vehID, double dist)
        {
            Object[] array = new Object[]{dist};
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_LEADER, vehID, array, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_COMPOUND);
        }

        public static SumoCommand GetPersonNumber(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_PERSON_NUMBER, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetBestLanes(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_BEST_LANES, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_COMPOUND);
        }

        public static SumoCommand GetCO2Emission(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_CO2EMISSION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetCOEmission(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_COEMISSION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetColor(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_COLOR, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_COLOR);
        }

        public static SumoCommand GetDecel(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_DECEL, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetDrivingDistance(string vehID, string edgeID, double pos, int laneID)
        {
            Object[] array = new Object[]{edgeID, pos, laneID};
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.DISTANCE_REQUEST, vehID, array, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetDrivingDistance2D(string vehID, double x, double y)
        {
            Object[] array = new Object[]{x, y};
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.DISTANCE_REQUEST, vehID, array, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetDistance(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_DISTANCE, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetEffort(string vehID, int time, string edgeID)
        {
            Object[] array = new Object[]{time, edgeID};
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_EDGE_EFFORT, vehID, array, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetEmissionClass(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_EMISSIONCLASS, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetFuelConsumption(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_FUELCONSUMPTION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetHCEmission(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_HCEMISSION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetImperfection(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_IMPERFECTION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLaneID(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_LANE_ID, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetLaneIndex(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_LANE_INDEX, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLanePosition(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_LANEPOSITION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetLength(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_LENGTH, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetMaxSpeed(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_MAXSPEED, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetMinGap(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_MINGAP, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetNOxEmission(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_NOXEMISSION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetNoiseEmission(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_NOISEEMISSION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetPMxEmission(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_PMXEMISSION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetPosition(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_POSITION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.POSITION_2D);
        }

        public static SumoCommand GetPosition3D(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_POSITION3D, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.POSITION_3D);
        }

        public static SumoCommand GetRoadID(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_ROAD_ID, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetRoute(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_EDGES, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetRouteID(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_ROUTE_ID, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetShapeClass(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_SHAPECLASS, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetSignals(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_SIGNALS, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetSpeed(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_SPEED, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetSpeedDeviation(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_SPEED_DEVIATION, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetSpeedFactor(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_SPEED_FACTOR, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetSpeedWithoutTraCI(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_SPEED_WITHOUT_TRACI, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetTau(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_TAU, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetWaitingTime(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_WAITING_TIME, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetTypeID(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_TYPE, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetVehicleClass(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_VEHICLECLASS, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetWidth(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_WIDTH, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand IsRouteValid(string vehID)
        {
            return new SumoCommand(Constants.CMD_GET_VEHICLE_VARIABLE, Constants.VAR_ROUTE_VALID, vehID, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_UBYTE);
        }

        public static SumoCommand SlowDown(string vehID, double speed, int duration)
        {
            Object[] array = new Object[]{speed, duration};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_SLOWDOWN, vehID, array, Constants.RESPONSE_GET_VEHICLE_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand Add(string vehID, string typeID, string routeID, int depart, double pos, double speed, byte lane)
        {
            Object[] array = new Object[]{typeID, routeID, depart, pos, speed, lane};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.ADD, vehID, array);
        }

        public static SumoCommand ChangeLane(string vehID, byte laneIndex, int duration)
        {
            Object[] array = new Object[]{laneIndex, duration};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_CHANGELANE, vehID, array);
        }

        public static SumoCommand ChangeTarget(string vehID, string edgeID)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_CHANGETARGET, vehID, edgeID);
        }

        public static SumoCommand MoveTo(string vehID, string laneID, double pos)
        {
            Object[] array = new Object[]{laneID, pos};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_MOVE_TO, vehID, array);
        }

        public static SumoCommand MoveToVTD(string vehID, string edgeID, int lane, double x, double y, double angle, Byte keepRoute)
        {
            Object[] array = new Object[]{ edgeID, lane, x, y, angle, keepRoute};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_MOVE_TO_VTD, vehID, array);
        }

        public static SumoCommand Remove(string vehID, byte reason)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.REMOVE, vehID, reason);
        }

        public static SumoCommand RerouteEffort(string vehID)
        {
            Object[] array = new Object[]{vehID};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_REROUTE_EFFORT, vehID, array);
        }

        public static SumoCommand RerouteTraveltime(string vehID)
        {
            Object[] array = new Object[]{vehID};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_REROUTE_TRAVELTIME, vehID, array);
        }

        public static SumoCommand SetAccel(string vehID, double accel)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_ACCEL, vehID, accel);
        }

        public static SumoCommand SetAdaptedTraveltime(string vehID, int begTime, int endTime, string edgeID, double time)
        {
            Object[] array = new Object[]{begTime, endTime, edgeID, time};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_EDGE_TRAVELTIME, vehID, array);
        }

        public static SumoCommand SetColor(string vehID, SumoColor color)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_COLOR, vehID, color);
        }

        public static SumoCommand SetDecel(string vehID, double decel)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_DECEL, vehID, decel);
        }

        public static SumoCommand SetLaneChangeMode(string vehID, int lcm)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_LANECHANGE_MODE, vehID, lcm);
        }

        public static SumoCommand SetRoute(string vehID, SumoStringList edgeList)
        {
            Object[] array = new Object[]{edgeList};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_ROUTE, vehID, array);
        }

        public static SumoCommand SetType(string vehID, string typeID)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_TYPE, vehID, typeID);
        }

        public static SumoCommand SetEffort(string vehID, int begTime, int endTime, string edgeID, double effort)
        {
            Object[] array = new Object[]{begTime, endTime, edgeID, effort};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_EDGE_EFFORT, vehID, array);
        }

        public static SumoCommand SetEmissionClass(string vehID, string clazz)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_EMISSIONCLASS, vehID, clazz);
        }

        public static SumoCommand SetImperfection(string vehID, double imperfection)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_IMPERFECTION, vehID, imperfection);
        }

        public static SumoCommand SetLength(string vehID, double length)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_LENGTH, vehID, length);
        }

        public static SumoCommand SetMaxSpeed(string vehID, double speed)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_MAXSPEED, vehID, speed);
        }

        public static SumoCommand SetMinGap(string vehID, double minGap)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_MINGAP, vehID, minGap);
        }

        public static SumoCommand SetRouteID(string vehID, string routeID)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_ROUTE_ID, vehID, routeID);
        }

        public static SumoCommand SetShapeClass(string vehID, string clazz)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_SHAPECLASS, vehID, clazz);
        }

        public static SumoCommand SetSignals(string vehID, string signals)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_SIGNALS, vehID, signals);
        }

        public static SumoCommand SetSpeed(string vehID, double speed)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_SPEED, vehID, speed);
        }

        public static SumoCommand SetSpeedDeviation(string vehID, double deviation)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_SPEED_DEVIATION, vehID, deviation);
        }

        public static SumoCommand SetSpeedFactor(string vehID, double factor)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_SPEED_FACTOR, vehID, factor);
        }

        public static SumoCommand SetSpeedMode(string vehID, int sm)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_SPEEDSETMODE, vehID, sm);
        }

        public static SumoCommand SetStop(string vehID, string edgeID, double pos, byte laneIndex, int duration, byte stopType)
        {
            Object[] array = new Object[]{edgeID, pos, laneIndex, duration, stopType};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_STOP, vehID, array);
        }

        public static SumoCommand Resume(string vehID)
        {
            Object[] array = new Object[]{vehID};
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_RESUME, vehID, array);
        }

        public static SumoCommand SetTau(string vehID, double tau)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_TAU, vehID, tau);
        }

        public static SumoCommand SetVehicleClass(string vehID, string clazz)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_VEHICLECLASS, vehID, clazz);
        }

        public static SumoCommand SetWidth(string vehID, double width)
        {
            return new SumoCommand(Constants.CMD_SET_VEHICLE_VARIABLE, Constants.VAR_WIDTH, vehID, width);
        }
    }
}