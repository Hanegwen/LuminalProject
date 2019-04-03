using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rigidbody;

    bool canVear = true;

    int rightLeftTurn = 0;

    [SerializeField]
    Transform Left, LeftCenter, RightCenter, Right;

    // Start is called before the first frame update

    public enum CurrentLane { Left, LeftCenter, RightCenter, Right };
    public CurrentLane MyLane;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MyLane = CurrentLane.Right;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, Right.position.y, this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

        if (OVRInput.Get(OVRInput.Button.DpadLeft))
        {
            VearLeft();

        }

        if (OVRInput.Get(OVRInput.Button.DpadRight))
        {
            VearRight();

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("WARNING: DEBUG MOVE RIGHT");
            VearRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("WARNING: DEBUG MOVE LEFT");
            VearLeft();
        }
    }

    void MoveForward()
    {
        //rigidbody.AddForce(new Vector3(0, 0, 1) * speed * Time.deltaTime);

        gameObject.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);

    }

    void VearLeft()
    {
        //if(canVear)
        {
            canVear = false;

            switch (MyLane)
            {
                case CurrentLane.Left:
                    break;
                case CurrentLane.LeftCenter:
                    MyLane = CurrentLane.Left;
                    this.gameObject.transform.position = new Vector3(/*Mathf.Lerp(this.gameObject.transform.position.x, */Left.position.x/*, Time.deltaTime * 2)*/, this.gameObject.transform.position.y, this.transform.position.z);
                    break;
                case CurrentLane.RightCenter:
                    MyLane = CurrentLane.LeftCenter;
                    this.gameObject.transform.position = new Vector3(/*Mathf.Lerp(this.gameObject.transform.position.x,*/ LeftCenter.position.x/*, Time.deltaTime * 2)*/, this.gameObject.transform.position.y, this.transform.position.z);
                    break;
                case CurrentLane.Right:
                    MyLane = CurrentLane.RightCenter;
                    this.gameObject.transform.position = new Vector3(/*Mathf.Lerp(this.gameObject.transform.position.x,*/ RightCenter.position.x/*, Time.deltaTime * 2)*/, this.gameObject.transform.position.y, this.transform.position.z);
                    break;
                default:
                    break;
            }

            StartCoroutine(VearReset());
        }
    }

    void VearRight()
    {
        //if(canVear)
        {
            canVear = false;

            switch (MyLane)
            {
                case CurrentLane.Left:
                    MyLane = CurrentLane.LeftCenter;
                    this.gameObject.transform.position = new Vector3(/*Mathf.Lerp(this.gameObject.transform.position.x,*/ LeftCenter.position.x/*, Time.deltaTime * 2)*/, this.gameObject.transform.position.y, this.transform.position.z);
                    break;
                case CurrentLane.LeftCenter:
                    MyLane = CurrentLane.RightCenter;
                    this.gameObject.transform.position = new Vector3(/*Mathf.Lerp(this.gameObject.transform.position.x,*/ RightCenter.position.x/*, Time.deltaTime * 2)*/, this.gameObject.transform.position.y, this.transform.position.z);
                    break;
                case CurrentLane.RightCenter:
                    MyLane = CurrentLane.Right;
                    this.gameObject.transform.position = new Vector3(/*Mathf.Lerp(this.gameObject.transform.position.x,*/ Right.position.x/*, Time.deltaTime * 2)*/, this.gameObject.transform.position.y, this.transform.position.z);
                    break;
                case CurrentLane.Right:
                    break;
                default:
                    break;
            }

            StartCoroutine(VearReset());
        }
    }

    IEnumerator VearReset()
    {
        yield return new WaitForSeconds(1);
        //print("Vear should reset");
        canVear = true;

    }
}
