using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    class ForeignTrafficCamera : MonoBehaviour
    {
        int index;

        void Start()
        {
           index = 0;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.C) && SUMOClient.vehicles3D.Count > 0)
            {
                if (index + 1 > SUMOClient.vehicles3D.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
           if ((SUMOClient.vehicles3D.Count > 0))
            {
                for(int i=0;i<SUMOClient.vehicles3D.Keys.Count;i++)
                {
                    GameObject randomVehicle = SUMOClient.vehicles3D.Values.ElementAt(i);
                    if (i == index)
                    {
                        (randomVehicle.transform.Find("simpleVehicle/Camera")).gameObject.SetActive(true);
                    }
                    else
                    {
                        (randomVehicle.transform.Find("simpleVehicle/Camera")).gameObject.SetActive(false);
                    }
                }                
            }
            
        }


    }


   
}
