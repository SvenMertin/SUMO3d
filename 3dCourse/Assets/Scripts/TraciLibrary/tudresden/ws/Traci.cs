using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Cmd;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;
using TraciConnector.Tudresden.Ws.Log;

namespace TraciConnector.Tudresden.Ws
{
    public class Traci
    {
        TraciConnector.Tudresden.Sumo.Util.Sumo sumo;        
        ConvertHelper helper;
        public  void Init(TraciConnector.Tudresden.Sumo.Util.Sumo sumo, ConvertHelper helper)
        {
            this.sumo = sumo;
            this.helper = helper;
        }

        public  void Edge_adaptTraveltime(string edgeID, int time)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.AdaptTraveltime(edgeID, time));
        }

        public  void Edge_setEffort(string edgeID, double effort)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.SetEffort(edgeID, effort));
        }

        public  void Edge_setMaxSpeed(string edgeID, double speed)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.SetMaxSpeed(edgeID, speed));
        }

        public  void Vehicle_add(string vehID, string typeID, string routeID, int depart, double pos, double speed, byte lane)
        {
            this.sumo.Set_cmd(Vehicle.Add(vehID, typeID, routeID, depart, pos, speed, lane));
        }

        public  void Vehicle_changeLane(string vehID, byte laneIndex, int duration)
        {
            this.sumo.Set_cmd(Vehicle.ChangeLane(vehID, laneIndex, duration));
        }

        public  void Vehicle_changeTarget(string vehID, string edgeID)
        {
            this.sumo.Set_cmd(Vehicle.ChangeTarget(vehID, edgeID));
        }

        public  void Vehicle_moveTo(string vehID, string laneID, double pos)
        {
            this.sumo.Set_cmd(Vehicle.MoveTo(vehID, laneID, pos));
        }

        public  void Vehicle_moveToVTD(string vehID, string edgeID, int lane, double x, double y, double angle, Byte keepRoute)
        {
            this.sumo.Set_cmd(Vehicle.MoveToVTD(vehID, edgeID, lane, x, y,angle,keepRoute));
        }

        public  void Vehicle_remove(string vehID, byte reason)
        {
            this.sumo.Set_cmd(Vehicle.Remove(vehID, reason));
        }

        public  void Vehicle_rerouteEffort(string vehID)
        {
            this.sumo.Set_cmd(Vehicle.RerouteEffort(vehID));
        }

        public  void Vehicle_rerouteTraveltime(string vehID)
        {
            this.sumo.Set_cmd(Vehicle.RerouteTraveltime(vehID));
        }

        public  void Vehicle_setAccel(string vehID, double accel)
        {
            this.sumo.Set_cmd(Vehicle.SetAccel(vehID, accel));
        }

        public  void Vehicle_setAdaptedTraveltime(string vehID, int begTime, int endTime, string edgeID, double time)
        {
            this.sumo.Set_cmd(Vehicle.SetAdaptedTraveltime(vehID, begTime, endTime, edgeID, time));
        }

        public  void Vehicle_setColor(string vehID, SumoColor color)
        {
            this.sumo.Set_cmd(Vehicle.SetColor(vehID, color));
        }

        public  void Vehicle_setDecel(string vehID, double decel)
        {
            this.sumo.Set_cmd(Vehicle.SetDecel(vehID, decel));
        }

        public  void Vehicle_setEffort(string vehID, int begTime, int endTime, string edgeID, double effort)
        {
            this.sumo.Set_cmd(Vehicle.SetEffort(vehID, begTime, endTime, edgeID, effort));
        }

        public  void Vehicle_setEmissionClass(string vehID, string clazz)
        {
            this.sumo.Set_cmd(Vehicle.SetEmissionClass(vehID, clazz));
        }

        public  void Vehicle_setImperfection(string vehID, double imperfection)
        {
            this.sumo.Set_cmd(Vehicle.SetImperfection(vehID, imperfection));
        }

        public  void Vehicle_setLength(string vehID, double length)
        {
            this.sumo.Set_cmd(Vehicle.SetLength(vehID, length));
        }

        public  void Vehicle_setMaxSpeed(string vehID, double speed)
        {
            this.sumo.Set_cmd(Vehicle.SetMaxSpeed(vehID, speed));
        }

        public  void Vehicle_setMinGap(string vehID, double minGap)
        {
            this.sumo.Set_cmd(Vehicle.SetMinGap(vehID, minGap));
        }

        public  void Vehicle_setRouteID(string vehID, string routeID)
        {
            this.sumo.Set_cmd(Vehicle.SetRouteID(vehID, routeID));
        }

        public  void Vehicle_setShapeClass(string vehID, string clazz)
        {
            this.sumo.Set_cmd(Vehicle.SetShapeClass(vehID, clazz));
        }

        public  void Vehicle_setSignals(string vehID, string signals)
        {
            this.sumo.Set_cmd(Vehicle.SetSignals(vehID, signals));
        }

        public  void Vehicle_setSpeed(string vehID, double speed)
        {
            this.sumo.Set_cmd(Vehicle.SetSpeed(vehID, speed));
        }

        public  void Vehicle_setSpeedDeviation(string vehID, double deviation)
        {
            this.sumo.Set_cmd(Vehicle.SetSpeedDeviation(vehID, deviation));
        }

        public  void Vehicle_setSpeedFactor(string vehID, double factor)
        {
            this.sumo.Set_cmd(Vehicle.SetSpeedFactor(vehID, factor));
        }

        public  void Vehicle_setStop(string vehID, string edgeID, double pos, byte laneIndex, int duration, byte stopType)
        {
            this.sumo.Set_cmd(Vehicle.SetStop(vehID, edgeID, pos, laneIndex, duration, stopType));
        }

        public  void Vehicle_resume(string vehID)
        {
            this.sumo.Set_cmd(Vehicle.Resume(vehID));
        }

        public  void Vehicle_setTau(string vehID, double tau)
        {
            this.sumo.Set_cmd(Vehicle.SetTau(vehID, tau));
        }

        public  void Vehicle_setVehicleClass(string vehID, string clazz)
        {
            this.sumo.Set_cmd(Vehicle.SetVehicleClass(vehID, clazz));
        }

        public  void Vehicle_setWidth(string vehID, double width)
        {
            this.sumo.Set_cmd(Vehicle.SetWidth(vehID, width));
        }

        public  void Trafficlights_setCompleteRedYellowGreenDefinition(string tlsID, SumoTLSLogic tls)
        {
            this.sumo.Set_cmd(Trafficlights.SetCompleteRedYellowGreenDefinition(tlsID, tls));
        }

        public  void Trafficlights_setPhase(string tlsID, int index)
        {
            this.sumo.Set_cmd(Trafficlights.SetPhase(tlsID, index));
        }

        public  void Trafficlights_setPhaseDuration(string tlsID, int phaseDuration)
        {
            this.sumo.Set_cmd(Trafficlights.SetPhaseDuration(tlsID, phaseDuration));
        }

        public  void Trafficlights_setProgram(string tlsID, string programID)
        {
            this.sumo.Set_cmd(Trafficlights.SetProgram(tlsID, programID));
        }

        public  void Trafficlights_setRedYellowGreenState(string tlsID, string state)
        {
            this.sumo.Set_cmd(Trafficlights.SetRedYellowGreenState(tlsID, state));
        }

        public  void Vehicletype_setAccel(string typeID, double accel)
        {
            this.sumo.Set_cmd(Vehicletype.SetAccel(typeID, accel));
        }

        public  void Vehicletype_setColor(string typeID, SumoColor color)
        {
            this.sumo.Set_cmd(Vehicletype.SetColor(typeID, color));
        }

        public  void Vehicletype_setDecel(string typeID, double decel)
        {
            this.sumo.Set_cmd(Vehicletype.SetDecel(typeID, decel));
        }

        public  void Vehicletype_setEmissionClass(string typeID, string clazz)
        {
            this.sumo.Set_cmd(Vehicletype.SetEmissionClass(typeID, clazz));
        }

        public  void Vehicletype_setImperfection(string typeID, double imperfection)
        {
            this.sumo.Set_cmd(Vehicletype.SetImperfection(typeID, imperfection));
        }

        public  void Vehicletype_setLength(string typeID, double length)
        {
            this.sumo.Set_cmd(Vehicletype.SetLength(typeID, length));
        }

        public  void Vehicletype_setMaxSpeed(string typeID, double speed)
        {
            this.sumo.Set_cmd(Vehicletype.SetMaxSpeed(typeID, speed));
        }

        public  void Vehicletype_setMinGap(string typeID, double minGap)
        {
            this.sumo.Set_cmd(Vehicletype.SetMinGap(typeID, minGap));
        }

        public  void Vehicletype_setShapeClass(string typeID, string clazz)
        {
            this.sumo.Set_cmd(Vehicletype.SetShapeClass(typeID, clazz));
        }

        public  void Vehicletype_setSpeedDeviation(string typeID, double deviation)
        {
            this.sumo.Set_cmd(Vehicletype.SetSpeedDeviation(typeID, deviation));
        }

        public  void Vehicletype_setSpeedFactor(string typeID, double factor)
        {
            this.sumo.Set_cmd(Vehicletype.SetSpeedFactor(typeID, factor));
        }

        public  void Vehicletype_setTau(string typeID, double tau)
        {
            this.sumo.Set_cmd(Vehicletype.SetTau(typeID, tau));
        }

        public  void Vehicletype_setVehicleClass(string typeID, string clazz)
        {
            this.sumo.Set_cmd(Vehicletype.SetVehicleClass(typeID, clazz));
        }

        public  void Vehicletype_setWidth(string typeID, double width)
        {
            this.sumo.Set_cmd(Vehicletype.SetWidth(typeID, width));
        }

        public  void Lane_setAllowed(string laneID, SumoStringList allowedClasses)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.SetAllowed(laneID, allowedClasses));
        }

        public  void Lane_setDisallowed(string laneID, SumoStringList disallowedClasses)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.SetDisallowed(laneID, disallowedClasses));
        }

        public  void Lane_setLength(string laneID, double length)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.SetLength(laneID, length));
        }

        public  void Lane_setMaxSpeed(string laneID, double speed)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.SetMaxSpeed(laneID, speed));
        }

        public  void Polygon_add(string polygonID, SumoGeometry shape, SumoColor color, bool fill, string polygonType, int layer)
        {
            this.sumo.Set_cmd(Polygon.Add(polygonID, shape, color, fill, polygonType, layer));
        }

        public  void Polygon_remove(string polygonID, int layer)
        {
            this.sumo.Set_cmd(Polygon.Remove(polygonID, layer));
        }

        public  void Polygon_setColor(string polygonID, SumoColor color)
        {
            this.sumo.Set_cmd(Polygon.SetColor(polygonID, color));
        }

        public  void Polygon_setShape(string polygonID, SumoStringList shape)
        {
            this.sumo.Set_cmd(Polygon.SetShape(polygonID, shape));
        }

        public  void Polygon_setType(string polygonID, string polygonType)
        {
            this.sumo.Set_cmd(Polygon.SetType(polygonID, polygonType));
        }

        public  void Poi_remove(string poiID, int layer)
        {
            this.sumo.Set_cmd(Poi.Remove(poiID, layer));
        }

        public  void Poi_setColor(string poiID, SumoColor color)
        {
            this.sumo.Set_cmd(Poi.SetColor(poiID, color));
        }

        public  void Poi_setPosition(string poiID, double x, double y)
        {
            this.sumo.Set_cmd(Poi.SetPosition(poiID, x, y));
        }

        public  void Poi_setType(string poiID, string poiType)
        {
            this.sumo.Set_cmd(Poi.SetType(poiID, poiType));
        }

        public  void GUI_screenshot(string viewID, string filename)
        {
            this.sumo.Set_cmd(Gui.Screenshot(viewID, filename));
        }

        public  void GUI_setBoundary(string viewID, double xmin, double ymin, double xmax, double ymax)
        {
            this.sumo.Set_cmd(Gui.SetBoundary(viewID, xmin, ymin, xmax, ymax));
        }

        public  void GUI_setOffset(string viewID, double x, double y)
        {
            this.sumo.Set_cmd(Gui.SetOffset(viewID, x, y));
        }

        public  void GUI_setSchema(string viewID, string schemeName)
        {
            this.sumo.Set_cmd(Gui.SetSchema(viewID, schemeName));
        }

        public  void GUI_setZoom(string viewID, double zoom)
        {
            this.sumo.Set_cmd(Gui.SetZoom(viewID, zoom));
        }

        public  void GUI_trackVehicle(string viewID, string vehID)
        {
            this.sumo.Set_cmd(Gui.TrackVehicle(viewID, vehID));
        }

        public  void Route_add(string routeID, SumoStringList edges)
        {
            this.sumo.Set_cmd(TraciConnector.Tudresden.Sumo.Cmd.Route.Add(routeID, edges));
        }

        public  SumoStringList Multientryexit_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Multientryexit.GetIDList()));
        }

        public  int Multientryexit_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Multientryexit.GetIDCount()));
        }

        public  int Multientryexit_getLastStepHaltingNumber(string detID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Multientryexit.GetLastStepHaltingNumber(detID)));
        }

        public  double Multientryexit_getLastStepMeanSpeed(string detID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Multientryexit.GetLastStepMeanSpeed(detID)));
        }

        public  SumoStringList Multientryexit_getLastStepVehicleIDs(string detID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Multientryexit.GetLastStepVehicleIDs(detID)));
        }

        public  int Multientryexit_getLastStepVehicleNumber(string detID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Multientryexit.GetLastStepVehicleNumber(detID)));
        }

        public  double Edge_getAdaptedTraveltime(string edgeID, int time)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetAdaptedTraveltime(edgeID, time)));
        }

        public  double Edge_getCO2Emission(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetCO2Emission(edgeID)));
        }

        public  double Edge_getCOEmission(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetCOEmission(edgeID)));
        }

        public  double Edge_getEffort(string edgeID, int time)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetEffort(edgeID, time)));
        }

        public  double Edge_getFuelConsumption(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetFuelConsumption(edgeID)));
        }

        public  double Edge_getHCEmission(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetHCEmission(edgeID)));
        }

        public  int Edge_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetIDCount()));
        }

        public  SumoStringList Edge_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetIDList()));
        }

        public  int Edge_getLastStepHaltingNumber(string edgeID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetLastStepHaltingNumber(edgeID)));
        }

        public  double Edge_getLastStepLength(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetLastStepLength(edgeID)));
        }

        public  double Edge_getLastStepMeanSpeed(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetLastStepMeanSpeed(edgeID)));
        }

        public  double Edge_getLastStepOccupancy(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetLastStepOccupancy(edgeID)));
        }

        public  SumoStringList Edge_getLastStepVehicleIDs(string edgeID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetLastStepVehicleIDs(edgeID)));
        }

        public  int Edge_getLastStepVehicleNumber(string edgeID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetLastStepVehicleNumber(edgeID)));
        }

        public  double Edge_getNOxEmission(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetNOxEmission(edgeID)));
        }

        public  double Edge_getNoiseEmission(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetNoiseEmission(edgeID)));
        }

        public  double Edge_getPMxEmission(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetPMxEmission(edgeID)));
        }

        public  double Edge_getTraveltime(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetTraveltime(edgeID)));
        }

        public  double Edge_getWaitingTime(string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Edge.GetWaitingTime(edgeID)));
        }

        public  SumoStringList ArealDetector_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(ArealDetector.GetIDList()));
        }

        public  int ArealDetector_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(ArealDetector.GetIDCount()));
        }

        public  int ArealDetector_getJamLengthVehicle(string loopID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(ArealDetector.GetJamLengthVehicle(loopID)));
        }

        public  double ArealDetector_getJamLengthMeters(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(ArealDetector.GetJamLengthMeters(loopID)));
        }

        public  double ArealDetector_getLastStepMeanSpeed(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(ArealDetector.GetLastStepMeanSpeed(loopID)));
        }

        public  double ArealDetector_getLastStepOccupancy(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(ArealDetector.GetLastStepOccupancy(loopID)));
        }

        public  SumoStringList Person_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Person.GetIDList()));
        }

        public  int Person_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Person.GetIDCount()));
        }

        public  double Person_getSpeed(string personID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Person.GetSpeed(personID)));
        }

        public  SumoPosition2D Person_getPosition(string personID)
        {
            return this.helper.GetPosition2D(this.sumo.Get_cmd(Person.GetPosition(personID)));
        }

        public  SumoPosition3D Person_getPosition3D(string personID)
        {
            return this.helper.GetPosition3D(this.sumo.Get_cmd(Person.GetPosition3D(personID)));
        }

        public  int Person_getAngle(string personID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Person.GetAngle(personID)));
        }

        public  string Person_getRoadID(string personID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Person.GetRoadID(personID)));
        }

        public  string Person_getTypeID(string personID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Person.GetTypeID(personID)));
        }

        public  double Person_getLanePosition(string personID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Person.GetLanePosition(personID)));
        }

        public  SumoColor Person_getColor(string personID)
        {
            return this.helper.GetColor(this.sumo.Get_cmd(Person.GetColor(personID)));
        }

        public  int Person_getPersonNumber(string personID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Person.GetPersonNumber(personID)));
        }

        public  double Person_getLength(string personID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Person.GetLength(personID)));
        }

        public  double Person_getWaitingTime(string personID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Person.GetWaitingTime(personID)));
        }

        public  double Person_getWidth(string personID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Person.GetWidth(personID)));
        }

        public  double Person_getMinGap(string personID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Person.GetMinGap(personID)));
        }

        public  double Vehicle_getAccel(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetAccel(vehID)));
        }

        public  double Vehicle_getAdaptedTraveltime(string vehID, int time, string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetAdaptedTraveltime(vehID, time, edgeID)));
        }

        public  double Vehicle_getAngle(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetAngle(vehID)));
        }

        public  SumoStringList Vehicle_getBestLanes(string vehID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Vehicle.GetBestLanes(vehID)));
        }

        public  double Vehicle_getCO2Emission(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetCO2Emission(vehID)));
        }

        public  double Vehicle_getCOEmission(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetCOEmission(vehID)));
        }

        public  SumoColor Vehicle_getColor(string vehID)
        {
            return this.helper.GetColor(this.sumo.Get_cmd(Vehicle.GetColor(vehID)));
        }

        public  double Vehicle_getDecel(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetDecel(vehID)));
        }

        public  double Vehicle_getDrivingDistance(string vehID, string edgeID, double pos, int laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetDrivingDistance(vehID, edgeID, pos, laneID)));
        }

        public  double Vehicle_getDrivingDistance2D(string vehID, double x, double y)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetDrivingDistance2D(vehID, x, y)));
        }

        public  double Vehicle_getEffort(string vehID, int time, string edgeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetEffort(vehID, time, edgeID)));
        }

        public  string Vehicle_getEmissionClass(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetEmissionClass(vehID)));
        }

        public  double Vehicle_getFuelConsumption(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetFuelConsumption(vehID)));
        }

        public  double Vehicle_getHCEmission(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetHCEmission(vehID)));
        }

        public  SumoStringList Vehicle_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Vehicle.GetIDList()));
        }

        public  int Vehicle_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Vehicle.GetIDCount()));
        }

        public  double Vehicle_getImperfection(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetImperfection(vehID)));
        }

        public  double Vehicle_getAllowedSpeed(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetAllowedSpeed(vehID)));
        }

        public  int Vehicle_getPersonNumber(string vehID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Vehicle.GetPersonNumber(vehID)));
        }

        public  double Vehicle_getDistance(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetDistance(vehID)));
        }

        public  double Vehicle_getWaitingTime(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetWaitingTime(vehID)));
        }

        public  string Vehicle_getLaneID(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetLaneID(vehID)));
        }

        public  int Vehicle_getLaneIndex(string vehID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Vehicle.GetLaneIndex(vehID)));
        }

        public  double Vehicle_getLanePosition(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetLanePosition(vehID)));
        }

        public  string Vehicle_getLeader(string vehID, double dist)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetLeader(vehID, dist)));
        }

        public  double Vehicle_getLength(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetLength(vehID)));
        }

        public  double Vehicle_getMaxSpeed(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetMaxSpeed(vehID)));
        }

        public  double Vehicle_getMinGap(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetMinGap(vehID)));
        }

        public  double Vehicle_getNOxEmission(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetNOxEmission(vehID)));
        }

        public  double Vehicle_getNoiseEmission(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetNoiseEmission(vehID)));
        }

        public  double Vehicle_getPMxEmission(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetPMxEmission(vehID)));
        }

        public  SumoPosition2D Vehicle_getPosition(string vehID)
        {
            return this.helper.GetPosition2D(this.sumo.Get_cmd(Vehicle.GetPosition(vehID)));
        }

        public  SumoPosition3D Vehicle_getPosition3D(string vehID)
        {
            return this.helper.GetPosition3D(this.sumo.Get_cmd(Vehicle.GetPosition3D(vehID)));
        }

        public  string Vehicle_getRoadID(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetRoadID(vehID)));
        }

        public  SumoStringList Vehicle_getRoute(string vehID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Vehicle.GetRoute(vehID)));
        }

        public  string Vehicle_getRouteID(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetRouteID(vehID)));
        }

        public  string Vehicle_getShapeClass(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetShapeClass(vehID)));
        }

        public  int Vehicle_getSignals(string vehID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Vehicle.GetSignals(vehID)));
        }

        public  double Vehicle_getSpeed(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetSpeed(vehID)));
        }

        public  double Vehicle_getSpeedDeviation(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetSpeedDeviation(vehID)));
        }

        public  double Vehicle_getSpeedFactor(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetSpeedFactor(vehID)));
        }

        public  double Vehicle_getSpeedWithoutTraCI(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetSpeedWithoutTraCI(vehID)));
        }

        public  double Vehicle_getTau(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetTau(vehID)));
        }

        public  string Vehicle_getTypeID(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetTypeID(vehID)));
        }

        public  string Vehicle_getVehicleClass(string vehID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicle.GetVehicleClass(vehID)));
        }

        public  double Vehicle_getWidth(string vehID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicle.GetWidth(vehID)));
        }

        public  int Vehicle_isRouteValid(string vehID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Vehicle.IsRouteValid(vehID)));
        }

        public  void Vehicle_setRoute(string vehID, SumoStringList edgeList)
        {
            this.sumo.Set_cmd(Vehicle.SetRoute(vehID, edgeList));
        }

        public  void Vehicle_setLaneChangeMode(string vehID, int lcm)
        {
            this.sumo.Set_cmd(Vehicle.SetLaneChangeMode(vehID, lcm));
        }

        public  void Vehicle_setType(string vehID, string typeID)
        {
            this.sumo.Get_cmd(Vehicle.SetType(vehID, typeID));
        }

        public  void Vehicle_slowDown(string vehID, double speed, int duration)
        {
            this.sumo.Set_cmd(Vehicle.SlowDown(vehID, speed, duration));
        }

        public  void GUI_clearPending(string routeID)
        {
            this.sumo.Set_cmd(Simulation.ClearPending(routeID));
        }

        public  SumoStringList Simulation_convert2D(string edgeID, double pos, byte laneIndex, string toGeo)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.Convert2D(edgeID, pos, laneIndex, toGeo)));
        }

        public  SumoStringList Simulation_convert3D(string edgeID, double pos, byte laneIndex, string toGeo)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.Convert3D(edgeID, pos, laneIndex, toGeo)));
        }

        public  SumoStringList Simulation_convertGeo(double x, double y, string fromGeo)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.ConvertGeo(x, y, fromGeo)));
        }

        public  SumoPosition2D Simulation_convertRoad(double x, double y, string isGeo)
        {
            return this.helper.GetPosition2D(this.sumo.Get_cmd(Simulation.ConvertRoad(x, y, isGeo)));
        }

        public  SumoStringList Simulation_getArrivedIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetArrivedIDList()));
        }

        public  int Simulation_getArrivedNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetArrivedNumber()));
        }

        public  int Simulation_getCurrentTime()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetCurrentTime()));
        }

        public  int Simulation_getBusStopWaiting()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetBusStopWaiting()));
        }

        public  SumoStringList Simulation_getParkingEndingVehiclesIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetParkingEndingVehiclesIDList()));
        }

        public  int Simulation_getParkingEndingVehiclesNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetParkingEndingVehiclesNumber()));
        }

        public  SumoStringList Simulation_getParkingStartingVehiclesIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetParkingStartingVehiclesIDList()));
        }

        public  int Simulation_getParkingStartingVehiclesNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetParkingStartingVehiclesNumber()));
        }

        public  SumoStringList Simulation_getStopEndingVehiclesIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetStopEndingVehiclesIDList()));
        }

        public  int Simulation_getStopEndingVehiclesNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetStopEndingVehiclesNumber()));
        }

        public  SumoStringList Simulation_getStopStartingVehiclesIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetStopStartingVehiclesIDList()));
        }

        public  int Simulation_getStopStartingVehiclesNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetStopStartingVehiclesNumber()));
        }

        public  int Simulation_getDeltaT()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetDeltaT()));
        }

        public  SumoStringList Simulation_getDepartedIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetDepartedIDList()));
        }

        public  int Simulation_getDepartedNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetDepartedNumber()));
        }

        public  double Simulation_getDistance2D(double x1, double y1, double x2, double y2, string isGeo, string isDriving)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Simulation.GetDistance2D(x1, y1, x2, y2, isGeo, isDriving)));
        }

        public  double Simulation_getDistanceRoad(string edgeID1, double pos1, string edgeID2, double pos2, string isDriving)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Simulation.GetDistanceRoad(edgeID1, pos1, edgeID2, pos2, isDriving)));
        }

        public  SumoStringList Simulation_getEndingTeleportIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetEndingTeleportIDList()));
        }

        public  int Simulation_getEndingTeleportNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetEndingTeleportNumber()));
        }

        public  SumoStringList Simulation_getLoadedIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetLoadedIDList()));
        }

        public  int Simulation_getLoadedNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetLoadedNumber()));
        }

        public  int Simulation_getMinExpectedNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetMinExpectedNumber()));
        }

        public  SumoStringList Simulation_getNetBoundary()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetNetBoundary()));
        }

        public  SumoStringList Simulation_getStartingTeleportIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Simulation.GetStartingTeleportIDList()));
        }

        public  int Simulation_getStartingTeleportNumber()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Simulation.GetStartingTeleportNumber()));
        }

        public  SumoTLSLogic Trafficlights_getCompleteRedYellowGreenDefinition(string tlsID)
        {
            return this.helper.GetTLSLogic(this.sumo.Get_cmd(Trafficlights.GetCompleteRedYellowGreenDefinition(tlsID)));
        }

        public  SumoStringList Trafficlights_getControlledLanes(string tlsID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Trafficlights.GetControlledLanes(tlsID)));
        }

        public  SumoStringList Trafficlights_getControlledLinks(string tlsID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Trafficlights.GetControlledLinks(tlsID)));
        }

        public  SumoStringList Trafficlights_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Trafficlights.GetIDList()));
        }

        public  int Trafficlights_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Trafficlights.GetIDCount()));
        }

        public  int Trafficlights_getNextSwitch(string tlsID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Trafficlights.GetNextSwitch(tlsID)));
        }

        public  int Trafficlights_getPhaseDuration(string tlsID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Trafficlights.GetPhaseDuration(tlsID)));
        }

        public  int Trafficlights_getPhase(string tlsID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Trafficlights.GetPhase(tlsID)));
        }

        public  string Trafficlights_getProgram(string tlsID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Trafficlights.GetProgram(tlsID)));
        }

        public  string Trafficlights_getRedYellowGreenState(string tlsID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Trafficlights.GetRedYellowGreenState(tlsID)));
        }

        public  double Vehicletype_getAccel(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetAccel(typeID)));
        }

        public  SumoColor Vehicletype_getColor(string typeID)
        {
            return this.helper.GetColor(this.sumo.Get_cmd(Vehicletype.GetColor(typeID)));
        }

        public  double Vehicletype_getDecel(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetDecel(typeID)));
        }

        public  string Vehicletype_getEmissionClass(string typeID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicletype.GetEmissionClass(typeID)));
        }

        public  SumoStringList Vehicletype_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Vehicletype.GetIDList()));
        }

        public  int Vehicletype_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Vehicletype.GetIDCount()));
        }

        public  double Vehicletype_getImperfection(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetImperfection(typeID)));
        }

        public  double Vehicletype_getLength(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetLength(typeID)));
        }

        public  double Vehicletype_getMaxSpeed(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetMaxSpeed(typeID)));
        }

        public  double Vehicletype_getMinGap(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetMinGap(typeID)));
        }

        public  string Vehicletype_getShapeClass(string typeID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicletype.GetShapeClass(typeID)));
        }

        public  double Vehicletype_getSpeedDeviation(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetSpeedDeviation(typeID)));
        }

        public  double Vehicletype_getSpeedFactor(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetSpeedFactor(typeID)));
        }

        public  double Vehicletype_getTau(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetTau(typeID)));
        }

        public  string Vehicletype_getVehicleClass(string typeID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Vehicletype.GetVehicleClass(typeID)));
        }

        public  double Vehicletype_getWidth(string typeID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Vehicletype.GetWidth(typeID)));
        }

        public  SumoStringList Lane_getAllowed(string laneID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetAllowed(laneID)));
        }

        public  double Lane_getCO2Emission(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetCO2Emission(laneID)));
        }

        public  double Lane_getCOEmission(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetCOEmission(laneID)));
        }

        public  SumoStringList Lane_getDisallowed(string laneID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetDisallowed(laneID)));
        }

        public  string Lane_getEdgeID(string laneID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetEdgeID(laneID)));
        }

        public  double Lane_getFuelConsumption(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetFuelConsumption(laneID)));
        }

        public  double Lane_getHCEmission(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetHCEmission(laneID)));
        }

        public  SumoStringList Lane_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetIDList()));
        }

        public  int Lane_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetIDCount()));
        }

        public  int Lane_getLastStepHaltingNumber(string laneID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLastStepHaltingNumber(laneID)));
        }

        public  double Lane_getLastStepLength(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLastStepLength(laneID)));
        }

        public  double Lane_getLastStepMeanSpeed(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLastStepMeanSpeed(laneID)));
        }

        public  double Lane_getLastStepOccupancy(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLastStepOccupancy(laneID)));
        }

        public  SumoStringList Lane_getLastStepVehicleIDs(string laneID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLastStepVehicleIDs(laneID)));
        }

        public  int Lane_getLastStepVehicleNumber(string laneID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLastStepVehicleNumber(laneID)));
        }

        public  double Lane_getLength(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLength(laneID)));
        }

        public  byte Lane_getLinkNumber(string laneID)
        {
            return this.helper.GetByte(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLinkNumber(laneID)));
        }

        public  SumoLinkList Lane_getLinks(string laneID)
        {
            return this.helper.GetLaneLinks(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetLinks(laneID)));
        }

        public  double Lane_getMaxSpeed(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetMaxSpeed(laneID)));
        }

        public  double Lane_getWaitingTime(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetWaitingTime(laneID)));
        }

        public  double Lane_getNOxEmission(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetNOxEmission(laneID)));
        }

        public  double Lane_getNoiseEmission(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetNoiseEmission(laneID)));
        }

        public  double Lane_getPMxEmission(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetPMxEmission(laneID)));
        }

        public  SumoGeometry Lane_getShape(string laneID)
        {
            return this.helper.GetPolygon(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetShape(laneID)));
        }

        public  double Lane_getTraveltime(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetTraveltime(laneID)));
        }

        public  double Lane_getWidth(string laneID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(TraciConnector.Tudresden.Sumo.Cmd.Lane.GetWidth(laneID)));
        }

        public  SumoColor Polygon_getColor(string polygonID)
        {
            return this.helper.GetColor(this.sumo.Get_cmd(Polygon.GetColor(polygonID)));
        }

        public  SumoStringList Polygon_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Polygon.GetIDList()));
        }

        public  int Polygon_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Polygon.GetIDCount()));
        }

        public  SumoGeometry Polygon_getShape(string polygonID)
        {
            return this.helper.GetPolygon(this.sumo.Get_cmd(Polygon.GetShape(polygonID)));
        }

        public  string Polygon_getType(string polygonID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Polygon.GetType(polygonID)));
        }

        public  void Poi_add(string poiID, double x, double y, SumoColor color, string poiType, int layer)
        {
            this.sumo.Get_cmd(Poi.Add(poiID, x, y, color, poiType, layer));
        }

        public  SumoColor Poi_getColor(string poiID)
        {
            return this.helper.GetColor(this.sumo.Get_cmd(Poi.GetColor(poiID)));
        }

        public  SumoStringList Poi_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Poi.GetIDList()));
        }

        public  int Poi_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Poi.GetIDCount()));
        }

        public  SumoPosition2D Poi_getPosition(string poiID)
        {
            return this.helper.GetPosition2D(this.sumo.Get_cmd(Poi.GetPosition(poiID)));
        }

        public  string Poi_getType(string poiID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Poi.GetType(poiID)));
        }

        public  SumoStringList Junction_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Junction.GetIDList()));
        }

        public  SumoGeometry Junction_getShape(string junctionID)
        {
            return this.helper.GetPolygon(this.sumo.Get_cmd(Junction.GetShape(junctionID)));
        }

        public  int Junction_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Junction.GetIDCount()));
        }

        public  SumoPosition2D Junction_getPosition(string junctionID)
        {
            return this.helper.GetPosition2D(this.sumo.Get_cmd(Junction.GetPosition(junctionID)));
        }

        public  SumoBoundingBox GUI_getBoundary(string viewID)
        {
            return this.helper.GetBoundingBox(this.sumo.Get_cmd(Gui.GetBoundary(viewID)));
        }

        public  SumoStringList GUI_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Gui.GetIDList()));
        }

        public  SumoPosition2D GUI_getOffset(string viewID)
        {
            return this.helper.GetPosition2D(this.sumo.Get_cmd(Gui.GetOffset(viewID)));
        }

        public  string GUI_getSchema(string viewID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Gui.GetSchema(viewID)));
        }

        public  double GUI_getZoom(string viewID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Gui.GetZoom(viewID)));
        }

        public  SumoStringList Route_getEdges(string routeID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Route.GetEdges(routeID)));
        }

        public  SumoStringList Route_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Route.GetIDList()));
        }

        public  int Route_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Route.GetIDCount()));
        }

        public  SumoStringList Inductionloop_getIDList()
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Inductionloop.GetIDList()));
        }

        public  int Inductionloop_getIDCount()
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Inductionloop.GetIDCount()));
        }

        public  string Inductionloop_getLaneID(string loopID)
        {
            return this.helper.GetString(this.sumo.Get_cmd(Inductionloop.GetLaneID(loopID)));
        }

        public  double Inductionloop_getLastStepMeanLength(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Inductionloop.GetLastStepMeanLength(loopID)));
        }

        public  double Inductionloop_getLastStepMeanSpeed(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Inductionloop.GetLastStepMeanSpeed(loopID)));
        }

        public  double Inductionloop_getLastStepOccupancy(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Inductionloop.GetLastStepOccupancy(loopID)));
        }

        public  SumoStringList Inductionloop_getLastStepVehicleIDs(string loopID)
        {
            return this.helper.GetStringList(this.sumo.Get_cmd(Inductionloop.GetLastStepVehicleIDs(loopID)));
        }

        public  int Inductionloop_getLastStepVehicleNumber(string loopID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Inductionloop.GetLastStepVehicleNumber(loopID)));
        }

        public  double Inductionloop_getPosition(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Inductionloop.GetPosition(loopID)));
        }

        public  double Inductionloop_getTimeSinceDetection(string loopID)
        {
            return this.helper.GetDouble(this.sumo.Get_cmd(Inductionloop.GetTimeSinceDetection(loopID)));
        }

        public  int Inductionloop_getVehicleData(string loopID)
        {
            return this.helper.GetInt(this.sumo.Get_cmd(Inductionloop.GetVehicleData(loopID)));
        }
    }
}