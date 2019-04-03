using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFollower : MonoBehaviour
{
    public enum Position {Left, CenterLeft, CenterRight, Right };
    public Position goalPositon;

    //public Position newGoalPosition;
    CoreyManager manager;
    NodeManager nodeManager;

    [SerializeField]
    Node goalPoint;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoreyManager>();
        nodeManager = FindObjectOfType<NodeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.DpadRight) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (goalPositon)
            {
                case Position.Left:
                    goalPoint = nodeManager.NodeRequest(Position.CenterLeft);
                    goalPositon = Position.CenterLeft;
                    break;
                case Position.CenterLeft:
                    goalPoint = nodeManager.NodeRequest(Position.CenterRight);
                    goalPositon = Position.CenterRight;
                    break;
                case Position.CenterRight:
                    goalPoint = nodeManager.NodeRequest(Position.Right);
                    goalPositon = Position.Right;
                    break;
                case Position.Right:
                    print("Already Max");
                    break;
                default:
                    print("******");
                    break;
            }
        }
        if (OVRInput.Get(OVRInput.Button.DpadLeft) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (goalPositon)
            {
                case Position.Left:
                    print("Already Max");
                    break;
                case Position.CenterLeft:
                   goalPoint = nodeManager.NodeRequest(Position.Left);
                    goalPositon = Position.Left;

                    break;
                case Position.CenterRight:
                    goalPoint = nodeManager.NodeRequest(Position.CenterLeft);
                    goalPositon = Position.CenterLeft;
                    break;
                case Position.Right:
                    print("fuckyou");
                    goalPoint = nodeManager.NodeRequest(Position.CenterRight);
                    goalPositon = Position.CenterRight;
                    break;
                default:
                    print("&&&&&&&");
                    break;
            }
        }




        if (manager.gameHasBegun) { GoalPointMoveTo(); }

        if(this.gameObject.transform.rotation.x != 0)
        {
            this.gameObject.transform.rotation = new Quaternion(0, this.gameObject.transform.rotation.y,this.gameObject.transform.rotation.z, 0);
        }
        if(this.gameObject.transform.rotation.z != 0)
        {
            this.gameObject.transform.rotation = new Quaternion(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, 0, 0);
        }
    }

    void GoalPointMoveTo()
    {
        if (nodeManager.GlobalIncrementor >= nodeManager.LeftNode.Count)
        {

            goalPoint.transform.position = this.gameObject.transform.position;
        }
        else
        {
            goalPoint.transform.position = new Vector3(goalPoint.transform.position.x, this.transform.position.y, goalPoint.transform.position.z);
        }
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, goalPoint.transform.position, .8f * Time.deltaTime);
        

        this.gameObject.transform.Rotate(0, goalPoint.gameObject.transform.rotation.y , 0);
       // print(goalPoint.gameObject.transform.rotation.y);

    }

    public void MoveToNextNode(Node NextNode)
    {

        goalPoint = NextNode;

        //this.gameObject.transform.position = new Vector3(Mathf.Lerp(this.gameObject.transform.position.x, NextNode.transform.position.x, 2), Mathf.Lerp(this.gameObject.transform.position.y, NextNode.transform.position.y, 2), Mathf.Lerp(this.gameObject.transform.position.z, NextNode.transform.position.z, 2));
    }
}
