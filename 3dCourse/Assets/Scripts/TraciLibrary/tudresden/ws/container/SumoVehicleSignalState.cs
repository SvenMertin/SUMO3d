using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Tudresden.Ws.Container
{

    public class SumoVehicleSignalState
    {

        public static int VEH_SIGNAL_BLINKER_RIGHT = 0;
        public static int VEH_SIGNAL_BLINKER_LEFT = 1;
        public static int VEH_SIGNAL_BLINKER_EMERGENCY = 2;
        public static int VEH_SIGNAL_BRAKELIGHT=3;
        public static int VEH_SIGNAL_FRONTLIGHT = 4;
        public static int VEH_SIGNAL_FOGLIGHT = 5;
        public static int VEH_SIGNAL_HIGHBEAM=6;
        public static int VEH_SIGNAL_BACKDRIVE = 7;
        public static int VEH_SIGNAL_WIPER = 8;
        public static int VEH_SIGNAL_DOOR_OPEN_LEFT = 9;
        public static int VEH_SIGNAL_DOOR_OPEN_RIGHT = 10;
        public static int VEH_SIGNAL_EMERGENCY_BLUE = 11;
        public static int VEH_SIGNAL_EMERGENCY_RED = 12;
        public static int VEH_SIGNAL_EMERGENCY_YELLOW = 13;

        private int position;

        public SumoVehicleSignalState(int pos) { this.position = pos; }

        public int getPos() { return this.position; }
    }

}