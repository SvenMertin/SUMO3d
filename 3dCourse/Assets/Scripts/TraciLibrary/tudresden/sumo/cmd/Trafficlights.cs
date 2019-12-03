using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Sumo.Util;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Cmd
{
    public class Trafficlights
    {
        public static SumoCommand GetCompleteRedYellowGreenDefinition(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_COMPLETE_DEFINITION_RYG, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_COMPOUND);
        }

        public static SumoCommand GetIDCount()
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.ID_COUNT, "", Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetPhaseDuration(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_PHASE_DURATION, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetControlledLanes(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_CONTROLLED_LANES, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetControlledLinks(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_CONTROLLED_LINKS, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_COMPOUND);
        }

        public static SumoCommand GetIDList()
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.ID_LIST, "", Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_STRINGLIST);
        }

        public static SumoCommand GetNextSwitch(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_NEXT_SWITCH, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetPhase(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_CURRENT_PHASE, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_INTEGER);
        }

        public static SumoCommand GetProgram(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_CURRENT_PROGRAM, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand GetRedYellowGreenState(string tlsID)
        {
            return new SumoCommand(Constants.CMD_GET_TL_VARIABLE, Constants.TL_RED_YELLOW_GREEN_STATE, tlsID, Constants.RESPONSE_GET_TL_VARIABLE, Constants.TYPE_STRING);
        }

        public static SumoCommand SetCompleteRedYellowGreenDefinition(string tlsID, SumoTLSLogic tls)
        {
            return new SumoCommand(Constants.CMD_SET_TL_VARIABLE, Constants.TL_COMPLETE_PROGRAM_RYG, tlsID, tls);
        }

        public static SumoCommand SetPhase(string tlsID, int index)
        {
            return new SumoCommand(Constants.CMD_SET_TL_VARIABLE, Constants.TL_PHASE_INDEX, tlsID, index);
        }

        public static SumoCommand SetPhaseDuration(string tlsID, int phaseDuration)
        {
            return new SumoCommand(Constants.CMD_SET_TL_VARIABLE, Constants.TL_PHASE_DURATION, tlsID, phaseDuration);
        }

        public static SumoCommand SetProgram(string tlsID, string programID)
        {
            return new SumoCommand(Constants.CMD_SET_TL_VARIABLE, Constants.TL_PROGRAM, tlsID, programID);
        }

        public static SumoCommand SetRedYellowGreenState(string tlsID, string state)
        {
            return new SumoCommand(Constants.CMD_SET_TL_VARIABLE, Constants.TL_RED_YELLOW_GREEN_STATE, tlsID, state);
        }
    }
}