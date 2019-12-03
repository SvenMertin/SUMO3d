using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class MixedStaticAndForeignCameraChanger : MonoBehaviour
{

    GameObject[] staticCams;
    string[] vehicleCams;
    int vehicleIndex;
    Stopwatch timer;
    bool staticCamActive = true;
    float changeTimeMillis = 10000;

    void Start()
    {
        staticCams = new GameObject[4];
        staticCams[0] = GameObject.Find("Camera0");
        staticCams[1] = GameObject.Find("Camera1");
        staticCams[2] = GameObject.Find("Camera2");
        staticCams[3] = GameObject.Find("Camera3");
        vehicleIndex = 0;

        vehicleCams = new string[4];
        vehicleCams[0] = "simpleVehicle/CameraFPV";
        vehicleCams[1] = "simpleVehicle/CameraThirdPerson";
        vehicleCams[2] = "simpleVehicle/CameraFront";
        vehicleCams[3] = "simpleVehicle/CameraSide";

        timer = Stopwatch.StartNew();
    }

    void Update()
    {
        if (timer.ElapsedMilliseconds > changeTimeMillis || Input.GetKeyDown(KeyCode.C))
        {
            if (staticCamActive)
            {
                // Disable all foreign vehicle cameras
                for (int i = 0; i < SUMOClient.vehicles3D.Keys.Count; i++)
                {
                    GameObject vehicle = SUMOClient.vehicles3D.Values.ElementAt(i);
                    foreach (string cam in vehicleCams)
                    {
                        (vehicle.transform.Find(cam)).gameObject.SetActive(false);
                    }
                }

                // Enable random static camera
                staticCams[Random.Range(0, staticCams.Length)].SetActive(true);
            }
            else
            {
                // Disable all static camera
                for (int i = 0; i < staticCams.Length; i++)
                {
                    staticCams[i].SetActive(false);
                }

                // Enable random foreign vehicle camera
                vehicleIndex = Random.Range(0, SUMOClient.vehicles3D.Keys.Count);
                if ((SUMOClient.vehicles3D.Count > 0))
                {
                    for (int i = 0; i < SUMOClient.vehicles3D.Keys.Count; i++)
                    {
                        GameObject randomVehicle = SUMOClient.vehicles3D.Values.ElementAt(i);
                        if (i == vehicleIndex)
                        {
                            int randomCamera = Random.Range(0, vehicleCams.Length-1);
                            randomVehicle.transform.Find(vehicleCams[randomCamera]).gameObject.SetActive(true);
                        }
                        else
                        {
                            foreach (string cam in vehicleCams)
                            {
                                (randomVehicle.transform.Find(cam)).gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }
            staticCamActive = !staticCamActive;
            timer.Reset();
            timer.Start();
        }
    }
}
