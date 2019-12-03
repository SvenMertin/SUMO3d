using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BlinkLight : MonoBehaviour {

    Stopwatch timer;
    double blinkingTimeSeconds = 0.5;


    // Use this for initialization
    void Start () {
        timer = Stopwatch.StartNew();
        this.gameObject.GetComponent<Light>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

        if(timer.ElapsedMilliseconds > blinkingTimeSeconds * 1000)
        {
            this.gameObject.GetComponent<Light>().enabled = !this.gameObject.GetComponent<Light>().enabled;
            timer.Reset();
            timer.Start();
        }

    }
}
