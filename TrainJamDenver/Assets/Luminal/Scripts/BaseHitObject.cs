﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitObject : MonoBehaviour, IHitable
{
    Rigidbody rigidbody;
    public GameObject hitPointsPrefab;


    public float ListNum;

    NodePlaneTeleportation nodePlaneTeleportation;

    SoundManager soundManager;
    ScoreManager scoreManager;


    float scoreAdder;
    // Start is called before the first frame update
    void Start()
    {
        scoreAdder = 10;
        //rigidbody.GetComponent<Rigidbody>();
        nodePlaneTeleportation = FindObjectOfType<NodePlaneTeleportation>();
        soundManager = FindObjectOfType<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Hit()
    {
        print("Wow2");
        //rigidbody.add

        if(ListNum == 0)
        {
            nodePlaneTeleportation.Node0.Remove(this.gameObject);
        }
        else if(ListNum == 1)
        {
            nodePlaneTeleportation.Node1.Remove(this.gameObject);
        }
        else if(ListNum == 2)
        {
            nodePlaneTeleportation.Node2.Remove(this.gameObject);
        }
        soundManager.PlayHitSound(this.transform);

        scoreManager.UpdateScore(scoreAdder);
        Instantiate(hitPointsPrefab, transform.position, transform.rotation, null);
        Destroy(this.gameObject);
    }
}
