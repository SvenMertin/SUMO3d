using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class NetworkListener : MonoBehaviour
{

    // read Thread
    Thread readThread;

    // udpclient object
    UdpClient client;

    // port number
    public int port = 15006;

    // static ego vehicle
    public static GameObject egoVehicle;
    double x;
    double y;
    double z;
    double roll;
    double pitch;
    double yaw;
    double steeringAngle;
    double speed;
    double pos;

    static float xq = 0;
    static float yq = 0;
    static float zq = 0;

    void Start()
    {
        // static ego vehicle
        egoVehicle = GameObject.Find("egoVehicle_Peugot(Clone)");

        // create thread for reading UDP messages
        readThread = new Thread(new ThreadStart(ReceiveData));
        readThread.IsBackground = true;
        readThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        pos += Time.time * speed / 3.6f;

        egoVehicle.transform.position = new Vector3((float)x, (float)z + 0.9f, (float)y);
        egoVehicle.transform.rotation = Quaternion.Euler((float)roll, (float)(yaw * (-1) + 90), (float)pitch);

        GameObject steeringWheel = GameObject.Find("Lenkrad 1");
        steeringWheel.transform.localEulerAngles = new Vector3(0, (float)steeringAngle,0);

        GameObject wheelVL = GameObject.Find("Rad_Lenkung_VL");
        wheelVL.transform.localEulerAngles = new Vector3((float)(pos), (float)steeringAngle, 0);        

        GameObject wheelVR = GameObject.Find("Rad_Lenkung_VR");
        wheelVR.transform.localEulerAngles = new Vector3((float)(pos),(float)steeringAngle, 0);

        GameObject wheelHL = GameObject.Find("Rad_Lenkung_HL");
        wheelHL.transform.localEulerAngles = new Vector3((float)(pos), 0, 0);

        GameObject wheelHR = GameObject.Find("Rad_Lenkung_HR");
        wheelHR.transform.localEulerAngles = new Vector3((float)(pos), 0, 0);
    }


        // Unity Application Quit Function
        void OnApplicationQuit()
    {
        StopThread();
    }

    // Stop reading UDP messages
    private void StopThread()
    {
        if (readThread.IsAlive)
        {
            readThread.Abort();
        }
        client.Close();
    }

    // receive thread function
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                // receive bytes
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);

                x = BitConverter.ToDouble(data, 0);
                y = BitConverter.ToDouble(data, 8);
                z = BitConverter.ToDouble(data, 16);
                roll = BitConverter.ToDouble(data, 24);
                pitch = BitConverter.ToDouble(data, 32);
                yaw = BitConverter.ToDouble(data, 40);
                steeringAngle = BitConverter.ToDouble(data, 48);
                speed= BitConverter.ToDouble(data, 56);

            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }
}
