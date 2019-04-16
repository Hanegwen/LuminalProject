using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Using GameObjects, create a list of nodes in the Unity Editor, starting with the initial spawn location.
/// This script will teleport the player to the next node when TeleportToNextNode is called.
/// Once the player has teleported to the last node, the next node will be the first in the list.
/// This script must have at least two nodes to function.
/// This script is meant to be attached to the VR Rig's parent object.
/// </summary>
public class NodePlaneTeleportation : MonoBehaviour
{
    [Tooltip("Must have two or more nodes to function.\nFirst node should be the initial spawn point.")]
    public List<GameObject> nodes;

    private int nextNodeIndex = 1;

    //[SerializeField]
    //public List<GameObject> Node0;

    //[SerializeField]
    //public List<GameObject> Node1;

    //[SerializeField]
    //public List<GameObject> Node2;

    //OVRManager player;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<OVRManager>();

        //foreach(GameObject node in Node0)
        //{
        //    node.GetComponent<BaseHitObject>().ListNum = 0;
        //}

        //foreach (GameObject node in Node1)
        //{
        //    node.GetComponent<BaseHitObject>().ListNum = 1;
        //}

        //foreach(GameObject node in Node2)
        //{
        //    node.GetComponent<BaseHitObject>().ListNum = 2;
        //}
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(nextNodeIndex - 1 == 0)
        //{
        //    if(Node0.Count == 0)
        //    {
        //        TeleportToNextNode();
        //    }
        //}

        //if(nextNodeIndex - 1 == 1)
        //{
        //    if(Node1.Count == 0)
        //    {
        //        TeleportToNextNode();
        //    }
        //}
    }

    public void TeleportToNextNode()
    {
        this.transform.position = new Vector3(nodes[nextNodeIndex].transform.position.x, this.transform.position.y, nodes[nextNodeIndex].transform.position.z);
        nextNodeIndex++;

        if (nextNodeIndex >= nodes.Count)
        {
            nextNodeIndex = 0;
        }

        Debug.Log("Teleported to next node");
    }
}
