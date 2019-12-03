using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Protocol;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Util
{
    public class SumoCommand
    {
        public Command cmd;
        public LinkedList<Object> raw;
        public int input1;
        public int input2;
        public string input3;
        public int response;
        public int output_type;
        public SumoCommand(Object input1, Object input2, Object input3, Object response, Object output_type)
        {
            this.cmd = new Command((int)input1);
            cmd.Content().WriteUnsignedByte((int)input2);
            cmd.Content().WriteStringASCII(input3.ToString());
            this.input1 = (int)input1;
            this.input2 = (int)input2;
            this.input3 = input3.ToString();
            this.response = (int)response;
            this.output_type = (int)output_type;
            this.raw = new LinkedList<Object>();
            this.raw.AddLast(input1);
            this.raw.AddLast(input2);
            this.raw.AddLast(input3);
            this.raw.AddLast(response);
            this.raw.AddLast(output_type);
        }

        public SumoCommand(Object input1, Object input2, Object input3, Object[] array, Object response, Object output_type)
        {
            this.cmd = new Command((int)input1);
            cmd.Content().WriteUnsignedByte((int)input2);
            cmd.Content().WriteStringASCII(input3.ToString());
            if (array.Length == 1)
            {
                Add_type(array[0]);
                Add_variable(array[0]);
            }
            else
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    Add_type(array[i]);
                    Add_variable(array[i]);
                }
            }

            this.input1 = (int)input1;
            this.input2 = (int)input2;
            this.input3 = input3.ToString();
            this.response = (int)response;
            this.output_type = (int)output_type;
            this.raw = new LinkedList<Object>();
            this.raw.AddLast(input1);
            this.raw.AddLast(input2);
            this.raw.AddLast(input3);
            this.raw.AddLast(response);
            this.raw.AddLast(output_type);
        }

        public SumoCommand(Object input1, Object input3)
        {
            this.input1 = (int)input1;
            this.input2 = (int)input3;
            this.cmd = new Command((int)input1);
            this.Add_variable(input3);
            this.raw = new LinkedList<Object>();
            this.raw.AddLast(input1);
            this.raw.AddLast(input3);
        }

        public SumoCommand(Object input1, Object input2, Object input3, Object[] array)
        {
            this.cmd = new Command((int)input1);
            this.input1 = (int)input1;
            this.input2 = (int)input2;
            cmd.Content().WriteUnsignedByte((int)input2);
            cmd.Content().WriteStringASCII(input3.ToString());
            if ((int)input2 == Constants.VAR_COLOR)
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COLOR);
                for (int i = 0; i < array.Length; i++)
                {
                    Add_variable(array[i]);
                }
            }
            else if ((int)input2 == Constants.VAR_ROUTE)
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_STRINGLIST);
                SumoStringList sl = (SumoStringList)array[0];
                cmd.Content().WriteInt(sl.getList().Count());
                foreach (string s in sl.getList())
                {
                    cmd.Content().WriteStringASCII(s);
                }
            }
            else if ((int)input2 == Constants.CMD_REROUTE_EFFORT || (int)input2 == Constants.CMD_REROUTE_TRAVELTIME || (int)input2 == Constants.CMD_RESUME)
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(0);
            }
            else if ((int)input2 == Constants.VAR_VIEW_BOUNDARY)
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_BOUNDINGBOX);
                for (int i = 0; i < array.Length; i++)
                {
                    Add_variable(array[i]);
                }
            }
            else if ((int)input2 == Constants.VAR_VIEW_OFFSET)
            {
                cmd.Content().WriteUnsignedByte(Constants.POSITION_2D);
                for (int i = 0; i < array.Length; i++)
                {
                    Add_variable(array[i]);
                }
            }
            else if ((int)input1 == Constants.CMD_SET_POLYGON_VARIABLE && (int)input2 == Constants.ADD)
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(5);
                Add_type(array[3]);
                Add_variable(array[3]);
                Add_type(array[1]);
                Add_variable(array[1]);
                Add_type(array[2]);
                Add_variable(array[2]);
                Add_type(array[4]);
                Add_variable(array[4]);
                Add_type(array[0]);
                Add_variable(array[0]);
            }
            else if ((int)input1 == Constants.CMD_SET_POI_VARIABLE && (int)input2 == Constants.VAR_POSITION)
            {
                cmd.Content().WriteUnsignedByte(Constants.POSITION_2D);
                Add_variable(array[0]);
                Add_variable(array[1]);
            }
            else if ((int)input1 == Constants.CMD_SET_POI_VARIABLE && (int)input2 == Constants.ADD)
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(4);
                Add_type(array[3]);
                Add_variable(array[3]);
                Add_type(array[2]);
                Add_variable(array[2]);
                Add_type(array[4]);
                Add_variable(array[4]);
                cmd.Content().WriteUnsignedByte(Constants.POSITION_2D);
                Add_variable(array[0]);
                Add_variable(array[1]);
            }
            else
            {
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    Add_type(array[i]);
                    Add_variable(array[i]);
                }
            }

            this.raw = new LinkedList<Object>();
            this.raw.AddLast(input1);
            this.raw.AddLast(input2);
            this.raw.AddLast(input3);
            this.raw.AddLast(array);
        }

        public SumoCommand(Object input1, Object input2, Object input3, Object input)
        {
            this.cmd = new Command((int)input1);
            this.input1 = (int)input1;
            this.input2 = (int)input2;
            cmd.Content().WriteUnsignedByte((int)input2);
            cmd.Content().WriteStringASCII(input3.ToString());
            if (input.GetType().Equals(typeof (StringList)))
            {
                StringList sl = (StringList)input;
                cmd.Content().WriteUnsignedByte(Constants.TYPE_STRINGLIST);
                cmd.Content().WriteInt(sl.Count());
                foreach (string s in sl)
                {
                    cmd.Content().WriteStringASCII(s);
                }
            }
            else if (input.GetType().Equals(typeof (SumoStringList)))
            {
                SumoStringList sl = (SumoStringList)input;
                cmd.Content().WriteUnsignedByte(Constants.TYPE_STRINGLIST);
                cmd.Content().WriteInt(sl.getList().Count());
                foreach (string s in sl.getList())
                {
                    cmd.Content().WriteStringASCII(s);
                }
            }
            else if (input.GetType().Equals(typeof (SumoTLSLogic)))
            {
                SumoTLSLogic stl = (SumoTLSLogic)input;
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(stl.phases.Count());
                cmd.Content().WriteUnsignedByte(Constants.TYPE_STRING);
                cmd.Content().WriteStringASCII(stl.subID);
                cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
                cmd.Content().WriteInt(0);
                cmd.Content().WriteUnsignedByte(Constants.TYPE_COMPOUND);
                cmd.Content().WriteInt(0);
                cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
                cmd.Content().WriteInt(stl.currentPhaseIndex);
                cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
                cmd.Content().WriteInt(stl.phases.Count());
                foreach (SumoTLSPhase phase in stl.phases)
                {
                    Add_variable(phase);
                }
            }
            else
            {
                Add_type(input);
                Add_variable(input);
            }

            this.raw = new LinkedList<Object>();
            this.raw.AddLast(input1);
            this.raw.AddLast(input2);
            this.raw.AddLast(input3);
            this.raw.AddLast(input);
        }

        public virtual Object[] Get_raw()
        {
            Object[] output = new Object[this.raw.Count()];
            for (int i = 0; i < this.raw.Count(); i++)
            {
                output[i] = this.raw.ElementAt(i);
            }

            return output;
        }

        private void Add_type(Object input)
        {
            if (input.GetType().Equals(typeof (int)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
            }
            else if (input.GetType().Equals(typeof (string)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_STRING);
            }
            else if (input.GetType().Equals(typeof (Double)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_DOUBLE);
            }
            else if (input.GetType().Equals(typeof (Byte)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_BYTE);
            }
            else if (input.GetType().Equals(typeof (SumoColor)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_COLOR);
            }
            else if (input.GetType().Equals(typeof (SumoGeometry)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_POLYGON);
            }
            else if (input.GetType().Equals(typeof (SumoPosition2D)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.POSITION_2D);
            }
            else if (input.GetType().Equals(typeof (SumoPosition3D)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.POSITION_3D);
            }
            else if (input.GetType().Equals(typeof (bool)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_UBYTE);
            }
            else if (input.GetType().Equals(typeof (SumoStringList)))
            {
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_STRINGLIST);
            }
        }

        private void Add_variable(Object input)
        {
            if (input.GetType().Equals(typeof (int)))
            {
                this.cmd.Content().WriteInt((int)input);
            }
            else if (input.GetType().Equals(typeof (string)))
            {
                this.cmd.Content().WriteStringASCII((string)input);
            }
            else if (input.GetType().Equals(typeof (Double)))
            {
                this.cmd.Content().WriteDouble((Double)input);
            }
            else if (input.GetType().Equals(typeof (Byte)))
            {
                this.cmd.Content().WriteByte((Byte)input);
            }
            else if (input.GetType().Equals(typeof (bool)))
            {
                bool b = (bool)input;
                cmd.Content().WriteUnsignedByte(b ? 1 : 0);
            }
            else if (input.GetType().Equals(typeof (SumoColor)))
            {
                SumoColor sc = (SumoColor)input;
                this.cmd.Content().WriteByte(sc.r);
                this.cmd.Content().WriteByte(sc.g);
                this.cmd.Content().WriteByte(sc.b);
                this.cmd.Content().WriteByte(sc.a);
            }
            else if (input.GetType().Equals(typeof (SumoGeometry)))
            {
                SumoGeometry sg = (SumoGeometry)input;
                cmd.Content().WriteUnsignedByte(sg.coords.Count());
                foreach (SumoPosition2D pos in sg.coords)
                {
                    cmd.Content().WriteDouble(pos.x);
                    cmd.Content().WriteDouble(pos.y);
                }
            }
            else if (input.GetType().Equals(typeof (SumoPosition2D)))
            {
                SumoPosition2D pos = (SumoPosition2D)input;
                cmd.Content().WriteDouble(pos.x);
                cmd.Content().WriteDouble(pos.y);
            }
            else if (input.GetType().Equals(typeof (SumoTLSPhase)))
            {
                SumoTLSPhase stp = (SumoTLSPhase)input;
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
                cmd.Content().WriteInt(stp.duration);
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
                cmd.Content().WriteInt(stp.duration1);
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_INTEGER);
                cmd.Content().WriteInt(stp.duration2);
                this.cmd.Content().WriteUnsignedByte(Constants.TYPE_STRING);
                cmd.Content().WriteStringASCII(stp.phasedef);
            }
            else if (input.GetType().Equals(typeof (SumoStringList)))
            {
                SumoStringList sl = (SumoStringList)input;
                cmd.Content().WriteInt(sl.getList().Count());
                foreach (string s in sl.getList())
                {
                    cmd.Content().WriteStringASCII(s);
                }
            }
        }

        public virtual Command Get_command()
        {
            return this.cmd;
        }
    }
}