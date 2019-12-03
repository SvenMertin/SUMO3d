using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using traciConnector.tudresden.ws.container;
using TraciConnector.Protocol;
using TraciConnector.Tudresden.Sumo.Conf;
using TraciConnector.Tudresden.Ws.Container;

namespace TraciConnector.Tudresden.Sumo.Util
{
    public class CommandProcessor : Query
    {
        int temp;
        public CommandProcessor(Socket sock): base (sock)
        {
        }

        public virtual void Do_job_set(SumoCommand sc)
        {
            lock (this)
            {
                QueryAndVerifySingle(sc.cmd);
            }
        }

        public virtual Object Do_job_get(SumoCommand sc)
        {
            lock (this)
            {
                Object output = null;
                ResponseContainer rc = QueryAndVerifySingle(sc.cmd);
                Command resp = rc.GetResponse();
                VerifyGetVarResponse(resp, sc.response, sc.input2, sc.input3);
                Verify("", sc.output_type, (int)resp.Content().ReadUnsignedByte());
                if (sc.output_type == Constants.TYPE_INTEGER)
                {
                    output = resp.Content().ReadInt();
                }
                else if (sc.output_type == Constants.TYPE_DOUBLE)
                {
                    output = resp.Content().ReadDouble();
                }
                else if (sc.output_type == Constants.TYPE_STRING)
                {
                    output = resp.Content().ReadStringUTF8();
                }
                else if (sc.output_type == Constants.POSITION_2D)
                {
                    double x = resp.Content().ReadDouble();
                    double y = resp.Content().ReadDouble();
                    output = new SumoPosition2D(x, y);
                }
                else if (sc.output_type == Constants.POSITION_3D)
                {
                    double x = resp.Content().ReadDouble();
                    double y = resp.Content().ReadDouble();
                    double z = resp.Content().ReadDouble();
                    output = new SumoPosition3D(x, y, z);
                }
                else if (sc.output_type == Constants.TYPE_STRINGLIST)
                {
                    SumoStringList ssl = new SumoStringList();
                    int laenge = resp.Content().ReadInt();
                    for (int i = 0; i < laenge; i++)
                    {
                        ssl.Add(resp.Content().ReadStringASCII());
                    }

                    output = ssl;
                }
                else if (sc.output_type == Constants.TYPE_BOUNDINGBOX)
                {
                    double min_x = resp.Content().ReadDouble();
                    double min_y = resp.Content().ReadDouble();
                    double max_x = resp.Content().ReadDouble();
                    double max_y = resp.Content().ReadDouble();
                    output = new SumoBoundingBox(min_x, min_y, max_x, max_y);
                }
                else if (sc.output_type == Constants.TYPE_COMPOUND)
                {
                    Object[] obj = null;
                    if (sc.input2 == Constants.TL_CONTROLLED_LINKS)
                    {
                        SumoLinkList sll = new SumoLinkList();
                        resp.Content().ReadUnsignedByte();
                        resp.Content().ReadInt();
                        int laenge = resp.Content().ReadInt();
                        obj = new StringList[laenge];
                        for (int i = 0; i < laenge; i++)
                        {
                            resp.Content().ReadUnsignedByte();
                            int anzahl = resp.Content().ReadInt();
                            for (int i1 = 0; i1 < anzahl; i1++)
                            {
                                resp.Content().ReadUnsignedByte();
                                resp.Content().ReadInt();
                                string from = resp.Content().ReadStringASCII();
                                string to = resp.Content().ReadStringASCII();
                                string over = resp.Content().ReadStringASCII();
                                sll.Add(new SumoLink(from, to, over));
                            }
                        }

                        output = sll;
                    }
                    else if (sc.input2 == Constants.TL_COMPLETE_DEFINITION_RYG)
                    {
                        resp.Content().ReadUnsignedByte();
                        resp.Content().ReadInt();
                        int length = resp.Content().ReadInt();
                        for (int i = 0; i < length; i++)
                        {
                            resp.Content().ReadUnsignedByte();
                            string subID = resp.Content().ReadStringASCII();
                            resp.Content().ReadUnsignedByte();
                            int type = resp.Content().ReadInt();
                            resp.Content().ReadUnsignedByte();
                            int subParameter = resp.Content().ReadInt();
                            resp.Content().ReadUnsignedByte();
                            int currentPhaseIndex = resp.Content().ReadInt();
                            SumoTLSLogic stl = new SumoTLSLogic(subID, type, subParameter, currentPhaseIndex);
                            resp.Content().ReadUnsignedByte();
                            int nbPhases = resp.Content().ReadInt();
                            for (int i1 = 0; i1 < nbPhases; i1++)
                            {
                                resp.Content().ReadUnsignedByte();
                                int duration = resp.Content().ReadInt();
                                resp.Content().ReadUnsignedByte();
                                int duration1 = resp.Content().ReadInt();
                                resp.Content().ReadUnsignedByte();
                                int duration2 = resp.Content().ReadInt();
                                resp.Content().ReadUnsignedByte();
                                string phaseDef = resp.Content().ReadStringASCII();
                                stl.Add(new SumoTLSPhase(duration, duration1, duration2, phaseDef));
                            }

                            output = stl;
                        }
                    }
                    else if (sc.input2 == Constants.LANE_LINKS)
                    {
                        resp.Content().ReadUnsignedByte();
                        resp.Content().ReadInt();
                        int length = resp.Content().ReadInt();
                        SumoLinkList links = new SumoLinkList();
                        for (int i = 0; i < length; i++)
                        {
                            resp.Content().ReadUnsignedByte();
                            string notInternalLane = resp.Content().ReadStringASCII();
                            resp.Content().ReadUnsignedByte();
                            string internalLane = resp.Content().ReadStringASCII();
                            resp.Content().ReadUnsignedByte();
                            byte hasPriority = (byte)resp.Content().ReadUnsignedByte();
                            resp.Content().ReadUnsignedByte();
                            byte isOpened = (byte)resp.Content().ReadUnsignedByte();
                            resp.Content().ReadUnsignedByte();
                            byte hasFoes = (byte)resp.Content().ReadUnsignedByte();
                            resp.Content().ReadUnsignedByte();
                            string state = resp.Content().ReadStringASCII();
                            resp.Content().ReadUnsignedByte();
                            string direction = resp.Content().ReadStringASCII();
                            resp.Content().ReadUnsignedByte();
                            double laneLength = resp.Content().ReadDouble();
                            links.Add(new SumoLink(notInternalLane, internalLane, hasPriority, isOpened, hasFoes, laneLength, state, direction));
                        }

                        output = links;
                    }
                    else
                    {
                        int laenge = resp.Content().ReadInt();
                        obj = new Object[laenge];
                        for (int i = 0; i < laenge; i++)
                        {
                            int k = resp.Content().ReadUnsignedByte();
                            obj[i] = this.Get_value(k, resp);
                        }

                        output = obj;
                    }
                }
                else if (sc.output_type == Constants.TYPE_POLYGON)
                {
                    int laenge = resp.Content().ReadUnsignedByte();
                    SumoGeometry sg = new SumoGeometry();
                    for (int i = 0; i < laenge; i++)
                    {
                        double x = (Double)this.Get_value(Constants.TYPE_DOUBLE, resp);
                        double y = (Double)this.Get_value(Constants.TYPE_DOUBLE, resp);
                        sg.Add(new SumoPosition2D(x, y));
                    }

                    output = sg;
                }
                else if (sc.output_type == Constants.TYPE_COLOR)
                {
                    int r = resp.Content().ReadUnsignedByte();
                    int g = resp.Content().ReadUnsignedByte();
                    int b = resp.Content().ReadUnsignedByte();
                    int a = resp.Content().ReadUnsignedByte();
                    output = new SumoColor(r, g, b, a);
                }
                else if (sc.output_type == Constants.TYPE_UBYTE)
                {
                    output = resp.Content().ReadUnsignedByte();
                }

                return output;
            }
        }

        private Object Get_value(int code, Command resp)
        {
            Object obj = -1;
            if (code == Constants.TYPE_STRING)
            {
                obj = resp.Content().ReadStringASCII();
            }
            else if (code == Constants.TYPE_INTEGER)
            {
                obj = resp.Content().ReadInt();
            }
            else if (code == Constants.TYPE_UBYTE)
            {
                obj = resp.Content().ReadUnsignedByte();
            }
            else if (code == Constants.TYPE_DOUBLE)
            {
                obj = resp.Content().ReadDouble();
            }
            else
            {
                //System.out_renamed.Println("unknown: " + code);
            }

            return obj;
        }

        protected static new string VerifyGetVarResponse(Command resp, int commandID, int variable, string objectID)
        {
            Verify("response code", commandID, resp.Id());
            Verify("variable ID", variable, (int)resp.Content().ReadUnsignedByte());
            string respObjectID = resp.Content().ReadStringASCII();
            if (objectID != null)
            {
                Verify("object ID", objectID, respObjectID);
            }

            return respObjectID;
        }
    }
}