using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCollider : MonoBehaviour
{
    public enum DirectionToTurn { Right, Left};
    public DirectionToTurn MyTurn;

    Track gameTrack;

    private void Start()
    {
        gameTrack = FindObjectOfType<Track>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<CarMove>() != null)
        {
            print("Turn Collider Hit Player");
            switch (MyTurn)
            {
                case DirectionToTurn.Right:
                    other.gameObject.transform.Rotate(new Vector3(0, 1 * 90, 0));
                    gameTrack.gameObject.transform.Rotate(new Vector3(0, 1 * 90, 0));
                    //other.gameObject.transform.rotation = new Quaternion(other.gameObject.transform.rotation.x,(other.gameObject.transform.rotation.y + 90),other.gameObject.transform.rotation.z, 0);
                    break;
                case DirectionToTurn.Left:
                    other.gameObject.transform.Rotate(new Vector3(0, -1 * 90, 0));
                    gameTrack.gameObject.transform.Rotate(new Vector3(0, -1 * 90, 0));
                    //other.gameObject.transform.rotation = new Quaternion(other.gameObject.transform.rotation.x,(other.gameObject.transform.rotation.y - 90), other.gameObject.transform.rotation.z, 0);
                    break;
                default:
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
