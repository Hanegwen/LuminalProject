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

    [SerializeField]
    public List<GameObject> Node3;

    OVRManager player;
    ChangeColors colorChanger;
    FadeUIElement fader;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<OVRManager>();
        colorChanger = FindObjectOfType<ChangeColors>();
        fader = FindObjectOfType<FadeUIElement>();

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

        foreach (GameObject node in Node3)
        {
            node.GetComponent<BaseHitObject>().ListNum = 3;
        }
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            TeleportToNextNode();
        }

        if(nextNodeIndex - 1 == 0)
        {
            if (Node0.Count == 0)
            {
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

        if(nextNodeIndex - 1 == 2)
        {
            if(Node2.Count == 0)
            {
                TeleportToNextNode();
            }
        }
    }

    public void TeleportToNextNode()
    {
        fader.FadeIn(.05f);

        player.transform.position = new Vector3(nodes[nextNodeIndex].transform.position.x, player.transform.position.y, nodes[nextNodeIndex].transform.position.z);
        player.transform.rotation = new Quaternion(player.transform.rotation.x, nodes[nextNodeIndex].transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
        nextNodeIndex++;

        if (nextNodeIndex > nodes.Count)
        {
            nextNodeIndex = 0;
        }
        
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
    }
}
