/*   
    Copyright (C) 2015 Mario Krumnow, Dresden University of Technology

    This file is part of TraaS.

    TraaS is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    TraaS is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with TraaS.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace traciConnector.tudresden.ws.container
{

    /**
     * 
     * @author Mario Krumnow
     *
     */

    public class SumoLink
    {

        public string from;
        public string to;
        public string over;

        //2nd 
        public string notInternalLane;
        public string internalLane;
        public string state;
        public string direction;
        public byte hasPriority;
        public byte isOpen;
        public byte hasApproachingFoe;
        public double length;

        int type = 0;

        //1st constructor
        public SumoLink(string from, string to, string over)
        {
            this.from = from;
            this.to = to;
            this.over = over;
            this.type = 0;
        }

        //2nd constructor
        public SumoLink(string notInternal, string internalLane, byte priority, byte isOpen, byte hasFoe, double length, string state, string direction)
        {
            this.notInternalLane = notInternal;
            this.internalLane = internalLane;
            this.hasPriority = priority;
            this.isOpen = isOpen;
            this.hasApproachingFoe = hasFoe;
            this.length = length;
            this.state = state;
            this.direction = direction;
            this.type = 1;
        }



        public string tostring()
        {

            if (this.type == 0)
            {
                return this.from + "#" + this.over + "#" + this.to;
            }
            else
            {
                return this.notInternalLane + "#" + this.internalLane + "#" + this.hasPriority + "#" + this.isOpen + "#" + this.hasApproachingFoe + "#" + this.length + "#" + this.state + "#" + this.direction;
            }

        }


    }
}