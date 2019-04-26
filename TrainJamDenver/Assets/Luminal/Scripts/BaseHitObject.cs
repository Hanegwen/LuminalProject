using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitObject : MonoBehaviour, IHitable
{
    public GameObject hitPointsPrefab;

    public int group;       //Group this object is tested with in HittableObjectManager

    public delegate void HitEventHandler(object sender, EventArgs e);
    public event HitEventHandler HitEvent;

    public float ListNum;

    NodePlaneTeleportation nodePlaneTeleportation;

    SoundManager soundManager;
    ScoreManager scoreManager;


    float scoreAdder;

    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        scoreAdder = 10;
        //rigidbody.GetComponent<Rigidbody>();

        //this.tag = "HittableObject";

        //nodePlaneTeleportation = FindObjectOfType<NodePlaneTeleportation>();
    }

    private void Awake()
    {
        this.tag = "HittableObject";

        nodePlaneTeleportation = FindObjectOfType<NodePlaneTeleportation>();
        soundManager = FindObjectOfType<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Hit()
    {
        LifeCheck();
        
    }

    void LifeCheck()
    {
        if(life < 1)
        {
            if (ListNum == 0)
            {
                nodePlaneTeleportation.Node0.Remove(this.gameObject);
            }
            else if (ListNum == 1)
            {
                nodePlaneTeleportation.Node1.Remove(this.gameObject);
            }
            else if (ListNum == 2)
            {
                nodePlaneTeleportation.Node2.Remove(this.gameObject);
            }
            else if (ListNum == 3)
            {
                nodePlaneTeleportation.Node3.Remove(this.gameObject);
            }

            soundManager.PlayHitSound(this.transform);

            scoreManager.UpdateScore(scoreAdder);
            Instantiate(hitPointsPrefab, transform.position, transform.rotation, null);


            RaiseHitEvent();

            this.gameObject.SetActive(false);

            Destroy(this.gameObject);
        }
        else
        {
            life--;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            scoreManager.UpdateScore(scoreAdder);
            Instantiate(hitPointsPrefab, transform.position, transform.rotation, null);
            StartCoroutine(RechargeObject());
        }
    }

    public void RaiseHitEvent()
    {
        Debug.Log(HitEvent);
        if (HitEvent != null)
        {
            HitEvent(this, null);
            //Debug.Log("HitEvent Raised");
        }
    }

    IEnumerator RechargeObject()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
