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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
