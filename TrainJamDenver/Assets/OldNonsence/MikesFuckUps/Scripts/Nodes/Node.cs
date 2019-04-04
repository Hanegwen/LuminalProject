using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum Positions { Left, CenterLeft, CenterRight, Right}
    public Positions MyPosition;
    public bool hasSpawned = false;

    public int myNumber;
    CountdownSystem CDS;
    NodeManager nodeManager;

    // Start is called before the first frame update
    void Start()
    {
        nodeManager = FindObjectOfType<NodeManager>();
        CDS = FindObjectOfType<CountdownSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.GetComponent<CarHealth>() != null)
        {
            nodeManager.NodeWasHit(this, MyPosition.ToString(), myNumber);
            nodeManager.NOS.ObjSpawned = true;
            nodeManager.NOS.SpawnObj();
            if (nodeManager.GlobalIncrementor < 49)
            {
                CDS.UpdateScoreText(1000);
            }

        }
    }
}
