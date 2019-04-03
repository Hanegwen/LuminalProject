using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NodeManager : MonoBehaviour
{
    [SerializeField] Image panelImage;
    [SerializeField]
    public List<Node> LeftNode, CenterLeftNode, CenterRightNode, RightNode;
    [SerializeField] CanvasGroup CG;
    int LeftNodeNum = 0, CenterLeftNodeNum = 0, CenterRightNodeNum = 0, RightNodeNum = 0;
    GameObject DemoOver;
    [SerializeField]
    public int GlobalIncrementor;
    [SerializeField] TextMeshPro DemoOverText;
    public NodeObjSpawning NOS;
    NodeFollower nodeFollower;
    // Start is called before the first frame update
    void Start()
    {
        nodeFollower = FindObjectOfType<NodeFollower>();
        NOS = FindObjectOfType<NodeObjSpawning>();
        foreach(Node N in LeftNode)
        {
            N.myNumber = LeftNodeNum;
            LeftNodeNum++;
            N.MyPosition = Node.Positions.Left;
        }

        foreach(Node P in CenterLeftNode)
        {
            P.myNumber = CenterLeftNodeNum;
            CenterLeftNodeNum++;
            P.MyPosition = Node.Positions.CenterLeft;
        }

        foreach(Node Q in CenterRightNode)
        {
            Q.myNumber = CenterRightNodeNum;
            CenterRightNodeNum++;
            Q.MyPosition = Node.Positions.CenterRight;
        }

        foreach(Node R in RightNode)
        {
            R.myNumber = RightNodeNum;
            RightNodeNum++;
            R.MyPosition = Node.Positions.Right;
        }

        nodeFollower.MoveToNextNode(RightNode[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //if (GlobalIncrementor >= 49)
        //{
        //    DemoOver.SetActive(true);

        //}
            if (GlobalIncrementor >= 50)
        {
            CG.alpha += Time.deltaTime / 5;
            DemoOverText.text = "Demo Over";

        }
    }

    public Node NodeRequest(NodeFollower.Position newPosition)
    {
        print("LOSER"+ newPosition);
        switch (newPosition)
        {
            case NodeFollower.Position.CenterLeft:
                return CenterLeftNode[GlobalIncrementor];
                
            case NodeFollower.Position.CenterRight:
                return CenterRightNode[GlobalIncrementor];
                
            case NodeFollower.Position.Left:
                return LeftNode[GlobalIncrementor];
                
            case NodeFollower.Position.Right:
                return RightNode[GlobalIncrementor];
                
            default:
                return CenterLeftNode[0];
                
        }
    }

    public void NodeWasHit(Node HitNode, string Position, int Num)
    {
        //nodeFollower.gameObject.transform.Rotate(HitNode.transform.position);
        Node nodeToSend = CenterRightNode[0]; 

        switch (nodeFollower.goalPositon)
        {
            case NodeFollower.Position.Left:
                if (LeftNode.Count != (Num + 1))
                {
                    GlobalIncrementor = Num + 1;
                    nodeToSend = LeftNode[Num + 1];
                }

                //nodeFollower.goalPositon = NodeFollower.Position.CenterLeft;
                break;
            case NodeFollower.Position.CenterLeft:
                if (CenterLeftNode.Count != (Num + 1))
                {
                    GlobalIncrementor = Num + 1;
                    nodeToSend = CenterLeftNode[Num + 1];
                }

                //nodeFollower.goalPositon = NodeFollower.Position.CenterRight;
                break;
            case NodeFollower.Position.CenterRight:
                if (CenterRightNode.Count != (Num + 1))
                {
                    GlobalIncrementor = Num + 1;
                    nodeToSend = CenterRightNode[Num + 1];
                }

                //nodeFollower.goalPositon = NodeFollower.Position.Right;
                break;
            case NodeFollower.Position.Right:
                if (RightNode.Count != (Num + 1))
                {
                    GlobalIncrementor = Num + 1;
                    nodeToSend = RightNode[Num + 1];
                }

                //nodeFollower.goalPositon = NodeFollower.Position.Left;
                break;
            default:
                
                break;
        }
        nodeFollower.MoveToNextNode(nodeToSend);
    }
}
