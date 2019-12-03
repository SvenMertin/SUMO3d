using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Person
    {
        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetSpeed(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_SPEED, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetPosition(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_POSITION, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.POSITION_2D);
        }

        public static SumoCommand GetPosition3D(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_POSITION3D, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.POSITION_3D);
        }

        public static SumoCommand GetAngle(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_ANGLE, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetRoadID(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_ROAD_ID, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetTypeID(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_TYPE, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetLanePosition(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_LANEPOSITION, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetColor(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_COLOR, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_COLOR);
        }

        public static SumoCommand GetPersonNumber(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_PERSON_NUMBER, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetLength(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_LENGTH, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetWaitingTime(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_WAITING_TIME, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetWidth(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_WIDTH, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }

        public static SumoCommand GetMinGap(string id)
        {
            return new SumoCommand(Constants.CMD_GET_PERSON_VARIABLE, Constants.VAR_MINGAP, id, Constants.RESPONSE_GET_PERSON_VARIABLE, Constants.TYPE_DOUBLE);
        }
    }
}