using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HittableObjectManager))]
public class TimerManager : MonoBehaviour
{
    public float MainTimer;
    public float SecondaryTimer;

    //The default starting times of the main and secondary timers
    public float MainTimerStartTime;
    public float SecondaryTimerStartTime;

    //Booleans that when true run down the corresponding timer
    public bool RunMainTimer = false;
    public bool RunSecondaryTimer = false;

    public delegate void TimerRunDownEventHandler(object sender, EventArgs e);
    public event TimerRunDownEventHandler TimerRunDown;

    HittableObjectManager hom;

    // Start is called before the first frame update
    void Start()
    {
        hom = this.GetComponent<HittableObjectManager>();

        hom.ThreatholdReached += OnThreatholdReached;       //Assigns OnThreasholdReached to ThreasholdReached

        MainTimer = MainTimerStartTime;
        SecondaryTimer = SecondaryTimerStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (RunMainTimer)
            MainTimer -= Time.deltaTime;

        if (RunSecondaryTimer)
            SecondaryTimer -= Time.deltaTime;

        //Checks if either timer has run down and, if one has, resets them, moves on to the next group, and raises and event
        if (SecondaryTimer <= 0 || MainTimer <= 0)
        {
            //Reset and stop both the main and secondary timers
            ResetMainTimer();
            RunMainTimer = false;

            ResetSecondaryTimer();
            RunSecondaryTimer = false;

            //Go to next group of HittableObjects to test for
            hom.currentGroup++;

            //RaiseTimerRunDown();

            //Debug.Log("TimerRunDown");
        }
    }

    void OnThreatholdReached(object source, EventArgs e)
    {
        RunSecondaryTimer = true;
        ResetSecondaryTimer();
    }

    public void ResetMainTimer()
    {
        MainTimer = MainTimerStartTime;
    }

    public void ResetSecondaryTimer()
    {
        SecondaryTimer = SecondaryTimerStartTime;
    }

    void RaiseTimerRunDown()
    {
        if (TimerRunDown != null)
            TimerRunDown(this, null);
    }

    void OnDestroy()
    {
        hom.ThreatholdReached -= OnThreatholdReached;
    }
}
