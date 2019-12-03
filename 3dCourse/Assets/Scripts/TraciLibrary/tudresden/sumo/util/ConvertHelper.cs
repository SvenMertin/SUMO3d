using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraciConnector.Tudresden.Ws.Container;
using TraciConnector.Tudresden.Ws.Log;
using UnityEngine;

namespace TraciConnector.Tudresden.Sumo.Util
{
    public class ConvertHelper
    {
       
        public ConvertHelper()
        {
            
        }

        public virtual byte GetByte(System.Object obj)
        {
            byte output = Convert.ToByte(-1);
            try
            {
                if (obj.GetType().Equals(typeof (short)))
                {
                    short helpVariable = (short)obj;
                    output = (byte)helpVariable;
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual int GetInt(System.Object obj)
        {
            int output = -1;
            try
            {
                if (obj.GetType().Equals(typeof (int)))
                {
                    output = (int)obj;
                }
            }
            catch (Exception ex)
            {
               MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual double GetDouble(System.Object obj)
        {
            double output = -1;
            try
            {
                if (obj.GetType().Equals(typeof (Double)))
                {
                    output = (Double)obj;
                }
            }
            catch (Exception ex)
            {
              MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoStringList GetStringList(System.Object obj)
        {
            SumoStringList output = new SumoStringList();
            try
            {
                if (obj.GetType().Equals(typeof (SumoStringList)))
                {
                    output = (SumoStringList)obj;
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoColor GetColor(System.Object obj)
        {
            SumoColor output = new SumoColor(0, 0, 0, 0);
            try
            {
                if (obj.GetType().Equals(typeof (SumoColor)))
                {
                    output = (SumoColor)obj;
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual string GetString(System.Object obj)
        {
            string output = "";
            try
            {
                if (obj.GetType().Equals(typeof (string)))
                {
                    output = (string)obj;
                }
            }
            catch (Exception ex)
            {
               MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoPosition2D GetPosition2D(System.Object obj)
        {
            SumoPosition2D output = new SumoPosition2D(0, 0);
            try
            {
                if (obj.GetType().Equals(typeof (SumoPosition2D)))
                {
                    output = (SumoPosition2D)obj;
                }
            }
            catch (Exception ex)
            {
               MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoPosition3D GetPosition3D(System.Object obj)
        {
            SumoPosition3D output = new SumoPosition3D(0, 0, 0);
            try
            {
                if (obj.GetType().Equals(typeof (SumoPosition3D)))
                {
                    output = (SumoPosition3D)obj;
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoTLSLogic GetTLSLogic(System.Object obj)
        {
            SumoTLSLogic output = new SumoTLSLogic(null, 0, 0, 0);
            try
            {
                if (obj.GetType().Equals(typeof (SumoTLSLogic)))
                {
                    output = (SumoTLSLogic)obj;
                }
            }
            catch (Exception ex)
            {
               MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoGeometry GetPolygon(System.Object obj)
        {
            SumoGeometry output = new SumoGeometry();
            try
            {
                if (obj.GetType().Equals(typeof (SumoGeometry)))
                {
                    output = (SumoGeometry)obj;
                }
            }
            catch (Exception ex)
            {
               MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoBoundingBox GetBoundingBox(System.Object obj)
        {
            SumoBoundingBox output = new SumoBoundingBox(0, 0, 0, 0);
            try
            {
                if (obj.GetType().Equals(typeof (SumoBoundingBox)))
                {
                    output = (SumoBoundingBox)obj;
                }
            }
            catch (Exception ex)
            {
               MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }

        public virtual SumoLinkList GetLaneLinks(System.Object obj)
        {
            SumoLinkList output = new SumoLinkList();
            try
            {
                if (obj.GetType().Equals(typeof (SumoLinkList)))
                {
                    output = (SumoLinkList)obj;
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }

            return output;
        }
    }
}