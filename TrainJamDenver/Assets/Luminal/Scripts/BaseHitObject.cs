using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitObject : MonoBehaviour, IHitable
{
    Rigidbody rigidbody;
    public GameObject hitPointsPrefab;

    public delegate void HitEventHandler(object sender, EventArgs e);
    public event HitEventHandler HitEvent;

    public float ListNum;

    NodePlaneTeleportation nodePlaneTeleportation;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody.GetComponent<Rigidbody>();

        //this.tag = "HittableObject";

        //nodePlaneTeleportation = FindObjectOfType<NodePlaneTeleportation>();
    }

    private void Awake()
    {
        this.tag = "HittableObject";

        nodePlaneTeleportation = FindObjectOfType<NodePlaneTeleportation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Hit();
        }
    }

    public void Hit()
    {
        print("Wow2");
        //rigidbody.add

        //if(ListNum == 0)
        //{
        //    nodePlaneTeleportation.Node0.Remove(this.gameObject);
        //}
        //else if(ListNum == 1)
        //{
        //    nodePlaneTeleportation.Node1.Remove(this.gameObject);
        //}
        //else if(ListNum == 2)
        //{
        //    nodePlaneTeleportation.Node2.Remove(this.gameObject);
        //}

        RaiseHitEvent();

        Instantiate(hitPointsPrefab);

        this.gameObject.SetActive(false);

        Destroy(this.gameObject);
        //Instantiate(hitPointsPrefab);
    }

    public void RaiseHitEvent()
    {
        Debug.Log(HitEvent);
        if (HitEvent != null)
        {
            HitEvent(this, null);
            Debug.Log("HitEvent Raised");
        }
    }
}
