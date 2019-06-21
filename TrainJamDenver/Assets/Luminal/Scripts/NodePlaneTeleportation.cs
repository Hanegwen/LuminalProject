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

    [SerializeField]
    public List<GameObject> Node4;

    [SerializeField]
    GameObject hammer;
    [SerializeField]
    GameObject chandelier;
    [SerializeField]
    Transform chandelierNewTransform;

    OVRManager player;
    ChangeColors colorChanger;
    FadeUIElement fader;
    SoundManager soundManager;
    HammerHead[] hammerHead;

    [SerializeField]
    GameObject Floor;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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

        foreach (GameObject node in Node4)
        {
            node.GetComponent<BaseHitObject>().ListNum = 4;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartTeleportProcess();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.transform.rotation = new Quaternion(player.transform.rotation.x, nodes[4].transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
        }

        if (nextNodeIndex - 1 == 0)
        {
            if (Node0.Count == 0)
            {
                StartTeleportProcess();
            }
        }

        if (nextNodeIndex - 1 == 1)
        {
            if (Node1.Count == 0)
            {
                StartTeleportProcess();
            }
        }

        if(nextNodeIndex - 1 == 2)
        {
            if(Node2.Count == 0)
            {
                StartTeleportProcess();
            }
        }

        if(nextNodeIndex - 1 == 3)
        {
            if(Node3.Count == 0)
            {
                HammerHead hammer = FindObjectOfType<HammerHead>();
                hammer.enabled = false;
                StartTeleportProcess();


                //StartCoroutine(DelayHammerActive());

            }
        }
    }

    IEnumerator DelayHammerActive()
    {
        yield return new WaitForSeconds(1f);
        hammerHead = FindObjectsOfType<HammerHead>();
        foreach (HammerHead head in hammerHead)
        {
            head.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void StartTeleportProcess()
    {
        fader.FadeIn(.5f);
    }

    public void TeleportToNextNode()
    {
        //fader.FadeIn(.05f);

        player.transform.position = new Vector3(nodes[nextNodeIndex].transform.position.x, player.transform.position.y, nodes[nextNodeIndex].transform.position.z);
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, nodes[nextNodeIndex].transform.eulerAngles.y, player.transform.eulerAngles.z);
        nextNodeIndex++;

        if (nextNodeIndex > nodes.Count)
        {
            nextNodeIndex = 0;
        }

        print("NODE " + nextNodeIndex);

        hammerHead = FindObjectsOfType<HammerHead>();
        foreach (HammerHead head in hammerHead)
        {
            head.GetComponent<BoxCollider>().enabled = false;
        }
        StartCoroutine(DelayHammerActive());

        switch(nextNodeIndex)
        {
            case 1:
                colorChanger.ColorTransition(-22, 1, 0.7735f);
                break;
            case 2:
                colorChanger.ColorTransition(50, 3, 0.7735f);
                break;
            case 3:
                soundManager.ExtraSound.volume = .286f;
                colorChanger.ColorTransition(70, 3, 0.9245f);
                break;
            case 4:
                colorChanger.ColorTransition(90, 4, 0.9245f);
                break;
            case 5:
                Floor.GetComponent<BoxCollider>().enabled = false;
                //Ceiling.GetComponent

                chandelier.GetComponent<PhysicsBreak>().dontBreakMe = true;

                chandelier.transform.position = chandelierNewTransform.position;
                chandelier.transform.rotation = chandelierNewTransform.rotation;
                chandelier.GetComponent<BaseHitObject>().enabled = true;
                chandelier.GetComponent<Collider>().enabled = true;
                //hammer.transform.position = new Vector3(0.43f, 0, 3.96f);
                hammer.transform.localScale = new Vector3(2f, 2f, 2f);
                break;
            default:
                break;
        }
    }
}
