using System.Diagnostics;
using UnityEngine;

public class AutomaticStaticCamChanger : MonoBehaviour
{

    int activeIndex = 0;
    static double time = 5;
    Stopwatch timer;
    public static GameObject[] cams;

    void Start()
    {
        cams = new GameObject[4];
        cams[0] = GameObject.Find("Camera0");
        cams[1] = GameObject.Find("Camera1");
        cams[2] = GameObject.Find("Camera2");
        cams[2] = GameObject.Find("Camera3");
        updateCams();

        timer = Stopwatch.StartNew();
    }

    void Update()
    {
        if (timer.ElapsedMilliseconds>time*1000 || Input.GetKeyDown(KeyCode.C))
        {
            activeIndex++;
            if (activeIndex > cams.Length - 1)
            {
                activeIndex = 0;
            }
            timer.Reset();
            timer.Start();
        }
        updateCams();        
    }

    void updateCams()
    {
        for (int i = 0; i < cams.Length - 1; i++)
        {
            if (i == activeIndex)
            {
                cams[i].SetActive(true);
            }
            else
            {
                cams[i].SetActive(false);
            }
        }
    }
}
