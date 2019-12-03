using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamChanger : MonoBehaviour {

    int activeIndex=0;
    public static GameObject[] cams;

    void Start()
    {
        cams = new GameObject[5];
        cams[0] = GameObject.Find("Camera0");
        cams[1] = GameObject.Find("Camera1");
        cams[2] = GameObject.Find("Camera2");
        cams[3] = GameObject.Find("Camera3");
        cams[4] = GameObject.Find("Camera4");
        updateCams();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeIndex++;
            if (activeIndex> cams.Length-1)
            {
                activeIndex = 0;
            }

        }
        updateCams();
    }

    void updateCams()
    {
        for (int i = 0; i < cams.Length-1; i++)
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
