using System.Collections.Generic;
using UnityEngine;
using TraciConnector;
using TraciConnector.Tudresden.Sumo.Cmd;
using TraciConnector.Tudresden.Ws.Container;
using System;
using Assets.Traci;
using System.Diagnostics;
using System.Collections;
using System.Linq;

public class SUMOClient : MonoBehaviour
{

    public string remoteIpAddress;
    public string remotePort;
    public bool sumoGUIEnabled=true;
    public bool enableEgoVehicle = true;
    public int refreshTimeTrafficLightsMS = 500;

    GameObject egoVehicle;

    SumoTraciConnection conn;
    int maxSimSteps = 100000;
    int simStep = 0;
    public double stepLengthSeconds = 0.05;

    Dictionary<string, SUMOCombinedPositionOrientation> vehicles;
    public static Dictionary<string, GameObject> vehicles3D;
    Dictionary<string, GameObject> trafficLights3D;
    List<GameObject> vehiclesInScene;

    Dictionary<string, SUMOCombinedPositionOrientation> lastStepVehicles;
    private double steeringAngleApproximationFactor = 6.0f;

    static List<Color> colors;

    Stopwatch unity3DstartTime;
    Stopwatch trafficLightsUpdate;

    Stopwatch watchdog;
    int watchDogCount = 0;

    // Use this for initialization
    void Start()
    {
        // Init Colors
        colors = new List<Color> {
            new Color(153f/255f, 0f, 0f),
            new Color(51f/255f, 102f/255f, 0f),
            new Color(0f, 102f/255f, 204f/255f),
            new Color(1f, 1f, 1f),
            new Color(0f, 0f, 0f),
            new Color(77f/255f, 77f/255f, 77f/255f),
            new Color(97f/255f, 83f/255f, 63f/255f),
            new Color(1f, 1f, 102f/255f),
            new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f)),
            new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f)),
            new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f)),
            new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f))
        };

        // Read paths from text files
        string sumoBinPath;
        if (sumoGUIEnabled)
            sumoBinPath = System.IO.File.ReadAllText(Application.dataPath + "\\Resources\\sumoBinPath.dat") + "\\sumo-gui.exe";
        else
            sumoBinPath = System.IO.File.ReadAllText(Application.dataPath + "\\Resources\\sumoBinPath.dat") + "\\sumo.exe";
        string mapNet = (System.IO.File.ReadAllText(Application.dataPath + "\\Resources\\sumoFilesPath.dat") + "\\map.net.xml").Replace("/", "\\");
        string routeNet = (System.IO.File.ReadAllText(Application.dataPath + "\\Resources\\sumoFilesPath.dat") + "\\map.rou.xml").Replace("/", "\\");

        // Other vehicles
        vehiclesInScene = new List<GameObject>();
        vehicles = new Dictionary<string, SUMOCombinedPositionOrientation>();
        vehicles3D = new Dictionary<string, GameObject>();

        conn = new SumoTraciConnection(sumoBinPath, mapNet, routeNet);

        conn.AddOption("step-length", stepLengthSeconds + "");
        conn.AddOption("start", ""); // start sumo immediately
        conn.AddOption("quit-on-end", ""); // stop sumo immediately after unity3D stopped

        // start Traci Server
        conn.RunServer(remoteIpAddress, Convert.ToInt32(this.remotePort));

        if (enableEgoVehicle)
        {
            // Insert ego vehicle
            // Get random route for being able to insert the ego vehicle (A new vehicle must have a route assigned)
            SumoStringList routes = (SumoStringList)conn.Do_job_get(Route.GetIDList());
            conn.Do_job_set(Vehicle.Add("egoVehicle", "DEFAULT_VEHTYPE", routes.Get(0), 0, 0, 0, (byte)0));
            conn.Do_job_set(Vehicle.SetColor("egoVehicle", new SumoColor(127, 0, 0, 127)));
        }

        // Find all traffic lights
        trafficLights3D = new Dictionary<string, GameObject>();
        SumoStringList trafficLights = (SumoStringList)conn.Do_job_get(Trafficlights.GetIDList());
        foreach (string s in trafficLights.getList())
        {
            var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.Equals("TrafficLight_" + s));
            foreach (GameObject g in objects)
            {
                trafficLights3D.Add(s + g.transform.Find("index").GetChild(0).name, g);
            }

        }

        // Timer for Realtime-Simulation
        unity3DstartTime = Stopwatch.StartNew();

        // Timer for traffic lights update (No need to do this every sim step)
        trafficLightsUpdate = Stopwatch.StartNew();

        // Timer for watchdog
        watchdog = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        watchdog.Start();

        // Simulation step with realtime check
        if ((unity3DstartTime.ElapsedMilliseconds> stepLengthSeconds * 1000 * simStep) && (simStep < maxSimSteps))
        {
            // Update egoVehicle coordinates for forwarding them to SUMO
            double xEgo = 0; ;
            double yEgo = 0; ;
            double angleEgo = 0; ;
            if (enableEgoVehicle)
            {
                egoVehicle = GameObject.Find("egoVehicle_Peugot_WASD(Clone)");
                if (egoVehicle == null)
                    egoVehicle = GameObject.Find("egoVehicle_Peugot(Clone)");

                xEgo = egoVehicle.transform.position.x;
                yEgo = egoVehicle.transform.position.z;
                angleEgo = egoVehicle.transform.rotation.eulerAngles.y;
            }

            // Only do next time step if it's necessary (not to fast)
            conn.Do_timestep();
            simStep++;

            if (enableEgoVehicle)
            {
                // Update egoVehicle
                conn.Do_job_set(Vehicle.MoveToVTD("egoVehicle", "0", 0, xEgo, yEgo, angleEgo, 2));
            }

            // Before updating all vehicles store the vehicles from last step for steering angle approximation (and prob. other interpolations)
            lastStepVehicles = vehicles.ToDictionary(i => i.Key, i => i.Value);


            // Get IDs of all vehicles in Simulation
            SumoStringList vehicleIDs = (SumoStringList)conn.Do_job_get(Vehicle.GetIDList());
            vehicles.Clear();            

            foreach (string id in vehicleIDs.getList())
            {
                SumoPosition3D position = (SumoPosition3D)conn.Do_job_get(Vehicle.GetPosition3D(id));
                double yawAngle = (double)conn.Do_job_get(Vehicle.GetAngle(id));
                vehicles.Add(id, new SUMOCombinedPositionOrientation(id,position,yawAngle));                
            }

            // Update all 3D vehicle models
            update3DVehiclesInScene();

            // Update all traffic lights every refreshTimeTrafficLightsMS miliseconds
            if (trafficLightsUpdate.ElapsedMilliseconds > refreshTimeTrafficLightsMS)
            {
                updateAllTrafficLights();
                trafficLightsUpdate.Reset();
                trafficLightsUpdate.Start();
            }            
        }

        // Watchdog
        long stopTime = watchdog.ElapsedMilliseconds;        
        if (stopTime > stepLengthSeconds * 1000)
        {
            watchDogCount++;
            print("Warning: Stepwidth of " + stepLengthSeconds * 1000 + "ms is too short for calculation loop, needed " + stopTime + 
                "ms, Exceeded " + watchDogCount +" times, Current total offset: " + (unity3DstartTime.ElapsedMilliseconds-1000*simStep*stepLengthSeconds+stopTime)+" ms");
        }
        watchdog.Reset();        
    }

    private void updateAllTrafficLights()
    {
        SumoStringList trafficLights = (SumoStringList)conn.Do_job_get(Trafficlights.GetIDList());
        foreach (string s in trafficLights.getList())
        {
            //string phase = (string) conn.Do_job_get(Trafficlights.GetProgram(s));
            string phase = (string)conn.Do_job_get(Trafficlights.GetRedYellowGreenState(s));
            // TODO: ONLY WORKS FOR 3- or 4- lanes intersections!!!!!!!!!
            int increment = (phase.Length == 6 ? 2 : 3);
            for (int i = 0; i < phase.Length; i += increment)
            {
                switch (phase.Substring(i, 1))
                {
                    case "G":
                    case "g":
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen").gameObject.SetActive(true);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot1").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb1").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen1").gameObject.SetActive(true);
                        break;
                    case "Y":
                    case "y":
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb").gameObject.SetActive(true);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot1").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb1").gameObject.SetActive(true);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen1").gameObject.SetActive(false);
                        break;
                    case "r":
                    case "R":
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot").gameObject.SetActive(true);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot1").gameObject.SetActive(true);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb1").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen1").gameObject.SetActive(false);
                        break;
                    case "0":
                    case "o":
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/rot1").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gelb1").gameObject.SetActive(false);
                        trafficLights3D[s + i / increment].transform.Find("Traffic_light/gruen1").gameObject.SetActive(false);
                        break;
                }
            }
        }
    }

    private void update3DVehiclesInScene()
    {
        foreach (SUMOCombinedPositionOrientation vehicle in vehicles.Values)
        {
            if (vehicles3D.ContainsKey(vehicle.id) && !vehicle.id.Equals("egoVehicle"))
            {
                // Move 3d Model
                vehicles3D[vehicle.id].transform.position = new Vector3((float)vehicle.position.x, (float)vehicle.position.z, (float)vehicle.position.y);
                vehicles3D[vehicle.id].transform.rotation = Quaternion.Euler(0, (float)vehicle.orientation - 90.0f, 0);

                // Check for signals (blinker, braking light etc)
                BitArray b = new BitArray(new int[] { (int)conn.Do_job_get(Vehicle.GetSignals(vehicle.id)) });
                bool blinkerRight = b[0];
                bool blinkerLeft = b[1];
                bool brake = b[3];
                bool blinkerEmergency = b[2];

                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Lights/BlinkerLights/LeftBlinker").gameObject.SetActive(blinkerLeft || blinkerEmergency);
                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Lights/BlinkerLights/RightBlinker").gameObject.SetActive(blinkerRight || blinkerEmergency);
                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Lights/BrakingLights").gameObject.SetActive(brake);

                // Set wheel rotational speed from vehicle speed
                double speed = (double)conn.Do_job_get(Vehicle.GetSpeed(vehicle.id));
                double wheelRadius = 0.4;
                float rotationAngleDelta = (float)(Time.deltaTime * speed / wheelRadius * Mathf.Rad2Deg);                
                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVL").gameObject.transform.Rotate(Vector3.right, rotationAngleDelta);
                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVR").gameObject.transform.Rotate(Vector3.right, rotationAngleDelta);
                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelHL").gameObject.transform.Rotate(Vector3.right, rotationAngleDelta);
                vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelHR").gameObject.transform.Rotate(Vector3.right, rotationAngleDelta);
                
                // Set Wheel Angles as approximated by the last yaw angle and the current one divided by time (=speed)
                if (lastStepVehicles.ContainsKey(vehicle.id))
                {
                    float angularSpeed = (float)((vehicle.orientation - lastStepVehicles[vehicle.id].orientation)*steeringAngleApproximationFactor);
                    float actualXVL = vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVL").gameObject.transform.localRotation.eulerAngles.x;                    
                    float actualZVL = vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVL").gameObject.transform.localRotation.eulerAngles.z;
                    float actualXVR = vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVR").gameObject.transform.localRotation.eulerAngles.x;
                    float actualZVR = vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVR").gameObject.transform.localRotation.eulerAngles.z;
                    vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVL").gameObject.transform.localRotation = Quaternion.Euler(new Vector3(actualXVL, angularSpeed, actualZVL));
                    vehicles3D[vehicle.id].transform.Find("simpleVehicle/Wheels/WheelVR").gameObject.transform.localRotation = Quaternion.Euler(new Vector3(actualXVR, angularSpeed, actualZVR));
                }
            }
            else if (!vehicle.id.Equals("egoVehicle"))
            {
                // Create 3d Model
                GameObject v = Instantiate(Resources.Load(PathConstants.pathForeignVehicle, typeof(GameObject)) as GameObject);

                // Random color, copy from existing material
                Material tmpMaterial = new Material(v.transform.Find("simpleVehicle/Body/Classic_16_Body").GetComponent<MeshRenderer>().material);
                tmpMaterial.name = "tmpMaterial";
                tmpMaterial.color = colors[UnityEngine.Random.Range(0, colors.Count)];
                v.transform.Find("simpleVehicle/Body/Classic_16_Body").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Door_L").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Door_R").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Hood").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Roof").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Taillights").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Trunk").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Bumper_F_3").GetComponent<MeshRenderer>().material = tmpMaterial;
                v.transform.Find("simpleVehicle/Body/Classic_16_Bumper_B_1").GetComponent<MeshRenderer>().material = tmpMaterial;

                // Position
                v.transform.position = new Vector3((float)vehicle.position.x, (float)vehicle.position.z, (float)vehicle.position.y);
                v.transform.Rotate(new Vector3(0, 1, 0), (float)vehicle.orientation - 90.0f);

                vehicles3D.Add(vehicle.id, v);
                vehiclesInScene.Add(v);
            }
        }

        // Remove 3D-vehicles which already leaved the simulation
        if (vehicles.Count < vehicles3D.Count)
        {
            List<string> id2Remove = new List<string>();
            foreach (string id in vehicles3D.Keys)
            {
                if (!vehicles.ContainsKey(id))
                {
                    id2Remove.Add(id);
                }
            }
            foreach (string id in id2Remove)
            {
                Destroy(vehicles3D[id]);
                vehicles3D.Remove(id);
            }
        }

    }

    void OnApplicationQuit()
    {
        conn.Close(true);
    }



}



