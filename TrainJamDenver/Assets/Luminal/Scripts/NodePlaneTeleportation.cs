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

    [SerializeField]
    public List<GameObject> Node0;

    [SerializeField]
    public List<GameObject> Node1;

    [SerializeField]
    public List<GameObject> Node2;

    OVRManager player;
    ChangeColors colorChanger;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<OVRManager>();
        colorChanger = FindObjectOfType<ChangeColors>();

        foreach (GameObject node in Node0)
        {
            node.GetComponent<BaseHitObject>().ListNum = 0;
        }

        foreach (GameObject node in Node1)
        {
            node.GetComponent<BaseHitObject>().ListNum = 1;
        }

        foreach (GameObject node in Node2)
        {
            node.GetComponent<BaseHitObject>().ListNum = 2;
        }
    }


    // Update is called once per frame
    void Update()
    {
//<<<<<<< HEAD
//<<<<<<< HEAD
        if (nextNodeIndex - 1 == 0)
//=======
//=======
//>>>>>>> a12a40364e6085e4be944e7f5c3618ca939e9510
        if (Input.GetKeyDown(KeyCode.D))
        {
            TeleportToNextNode();
        }

        if(nextNodeIndex - 1 == 0)
//>>>>>>> a12a40364e6085e4be944e7f5c3618ca939e9510
        {
            //print("**********");
            if (Node0.Count == 0)
            {
                //print("&&&&&&&&&&&&&&&&&&&");
                TeleportToNextNode();
            }
        }

        if (nextNodeIndex - 1 == 1)
        {
            if (Node1.Count == 0)
            {
                TeleportToNextNode();
            }
        }
    }

    public void TeleportToNextNode()
    {
//<<<<<<< HEAD
        player.transform.position = new Vector3(nodes[nextNodeIndex].transform.position.x, this.transform.position.y, nodes[nextNodeIndex].transform.position.z);
//=======
        player.transform.position = new Vector3(nodes[nextNodeIndex].transform.position.x, player.transform.position.y, nodes[nextNodeIndex].transform.position.z);
        player.transform.rotation = new Quaternion(player.transform.rotation.x, nodes[nextNodeIndex].transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
//<<<<<<< HEAD
//>>>>>>> a12a40364e6085e4be944e7f5c3618ca939e9510
//=======
//>>>>>>> a12a40364e6085e4be944e7f5c3618ca939e9510
        nextNodeIndex++;

        if (nextNodeIndex >= nodes.Count)
        {
            nextNodeIndex = 0;
        }
//<<<<<<< HEAD
//=======
        
        switch(nextNodeIndex)
        {
            case 1:
                colorChanger.ColorTransition(-22, 1, 0.7735f);
                break;
            case 2:
                colorChanger.ColorTransition(50, 3, 0.7735f);
                break;
            case 3:
                colorChanger.ColorTransition(70, 3, 0.9245f);
                break;
            case 4:
                colorChanger.ColorTransition(90, 4, 0.9245f);
                break;
            default:
                break;
        }
//>>>>>>> a12a40364e6085e4be944e7f5c3618ca939e9510

        //Debug.Log("Teleported to next node");
    }
}
