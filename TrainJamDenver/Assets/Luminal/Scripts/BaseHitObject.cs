using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitObject : MonoBehaviour, IHitable
{
    Rigidbody rigidbody;
    public GameObject hitPointsPrefab;


    public float ListNum;

    NodePlaneTeleportation nodePlaneTeleportation;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody.GetComponent<Rigidbody>();
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
        Destroy(this.gameObject);
        //Instantiate(hitPointsPrefab);
    }
}
