using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObjectManager : MonoBehaviour
{
    [Tooltip("Number between 0 and 1")]
    public float TimerThreathold;
    public GameObject[] hittableObjects;

    public delegate void ThreatholdReachedEventHandler(object sender, EventArgs e);
    public event ThreatholdReachedEventHandler ThreatholdReached;

    public int currentGroup = 0;        //The current group of HittableObjects being tested

    // Start is called before the first frame update
    void Start()
    {
        hittableObjects = GameObject.FindGameObjectsWithTag("HittableObject");  //Finds all "HittableObjects" in the scene.

        //Assigns each of the HittableObject's HitEvent to OnHitEvent
        foreach (GameObject go in hittableObjects)
        {
            BaseHitObject bho = go.GetComponent<BaseHitObject>();

            bho.HitEvent += OnHitEvent;
        }

        //Debug.Log("Events Ready");
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Handles hit events from HittableObjects
    void OnHitEvent(object sender, EventArgs e)
    {
        //Debug.Log("Determine Percentage Deactivated");

        int totalActive = 0;        //Total number of active HittableObjects in hittableObjects in the currentGroup 
        int totalInGroup = 0;       //Total number of HittableObjects in hittableObjects in the currentGroup

        //Loops through to find totalActive and totalInGroup
        foreach (GameObject go in hittableObjects)
        {
            //Debug.Log("HittableObjectFound");

            BaseHitObject bho = go.GetComponent<BaseHitObject>();

            //Finding totalActive
            if (go.activeInHierarchy && bho.group == currentGroup)
            {
                totalActive++;
                //Debug.Log("HittableObjectActive");
            }

            //finding totalInGroup
            if (bho.group == currentGroup)
            {
                totalInGroup++;
            }
        }

        //Devides the totalActive by the totalInGroup and compares it to the designer set percentage threashold to determine whether or not 
        //it is time to start the secondary timer. It does so by raising an event.
        if ((float)((float)totalActive / (float)totalInGroup) <= TimerThreathold)
        {
            RaiseThreaholdReached();
            //Debug.Log("Threashold reached");
        }
    }

    //Event raiser
    void RaiseThreaholdReached()
    {
        if (ThreatholdReached != null)
        {
            ThreatholdReached(this, null);
        }
    }
}
