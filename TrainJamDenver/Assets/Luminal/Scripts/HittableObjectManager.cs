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

    // Start is called before the first frame update
    void Start()
    {
        hittableObjects = GameObject.FindGameObjectsWithTag("HittableObject");

        foreach (GameObject go in hittableObjects)
        {
            BaseHitObject bho = go.GetComponent<BaseHitObject>();

            bho.HitEvent += OnHitEvent;
        }

        Debug.Log("Events Ready");
    }

    private void Awake()
    {
        //hittableObjects = GameObject.FindGameObjectsWithTag("HittableObject");

        //foreach (GameObject go in hittableObjects)
        //{
        //    BaseHitObject bho = go.GetComponent<BaseHitObject>();

        //    bho.HitEvent += OnHitEvent;
        //}

        //Debug.Log("Events Ready");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnHitEvent(object sender, EventArgs e)
    {
        Debug.Log("Determine Percentage Deactivated");

        int totalActive = 0;

        foreach (GameObject go in hittableObjects)
        {
            if (go.activeInHierarchy)
            {
                totalActive++;
            }
        }

        if ((float)((float)totalActive/(float)hittableObjects.Length + 1) <= TimerThreathold)
        {
            RaiseThreaholdReached();
            Debug.Log("Threashold reached");
        }
    }

    void RaiseThreaholdReached()
    {
        if(ThreatholdReached != null)
        {
            ThreatholdReached(this, null);
        }
    }
}
