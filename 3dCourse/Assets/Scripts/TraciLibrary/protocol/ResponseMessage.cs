using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Uniluebeck.Itm.Tcpip;

namespace TraciConnector.Protocol
{
    public class ResponseMessage
    {
        public static readonly int[] STATUS_ONLY_RESPONSES = new int[] { Constants.CMD_CLOSE, Constants.CMD_SET_EDGE_VARIABLE, Constants.CMD_SET_GUI_VARIABLE, Constants.CMD_SET_LANE_VARIABLE, Constants.CMD_SET_PERSON_VARIABLE, Constants.CMD_SET_POI_VARIABLE, Constants.CMD_SET_POLYGON_VARIABLE, Constants.CMD_SET_ROUTE_VARIABLE, Constants.CMD_SET_SIM_VARIABLE, Constants.CMD_SET_TL_VARIABLE, Constants.CMD_SET_VEHICLE_VARIABLE, Constants.CMD_SET_VEHICLETYPE_VARIABLE};
        private List<ResponseContainer> pairs = new List<ResponseContainer>();

        public ResponseMessage(NetworkStream dis)
        {
            byte[] b = new byte[4];
            dis.Read(b, 0, 4);
            Array.Reverse(b, 0, b.Length);
            int totalLen = BitConverter.ToInt32(b,0) - 4;

            //UnityEngine.MonoBehaviour.print(totalLen);

            sbyte[] buffer = new sbyte[totalLen];
            //dis.Read(buffer, 0, (int)totalLen);
            for(int i = 0; i < totalLen; i++)
            {                
                buffer[i] = (sbyte) BitConverter.GetBytes(dis.ReadByte())[0];
            }
            //Array.Reverse(buffer, 0, buffer.Length);
            Storage s = new Storage(buffer);
            while (s.ValidPos())
            {
                StatusResponse sr = new StatusResponse(s);
                ResponseContainer responseContainer;
                if (sr.Result() != Constants.RTYPE_OK)
                {
                    responseContainer = new ResponseContainer(sr, null);
                }
                else if (sr.Id() == Constants.CMD_SIMSTEP2)
                {
                    int nSubResponses = s.ReadInt();
                    List<Command> subResponses = new List<Command>(nSubResponses);
                    for (int i = 0; i < nSubResponses; i++)
                    {
                        subResponses.Add(new Command(s));
                    }

                    responseContainer = new ResponseContainer(sr, null, subResponses);
                }
                else if (IsStatusOnlyResponse(sr.Id()))
                {
                    responseContainer = new ResponseContainer(sr, null);
                }
                else
                    responseContainer = new ResponseContainer(sr, new Command(s));
                pairs.Add(responseContainer);
            }
        }

        private bool IsStatusOnlyResponse(int statusResponseID)
        {
            foreach (int id in STATUS_ONLY_RESPONSES)
                if (id == statusResponseID)
                    return true;
            return false;
        }

        public virtual List<ResponseContainer> Responses()
        {
            return pairs;
        }
    }
}