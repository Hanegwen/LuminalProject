using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBreak : MonoBehaviour
{
    public GameObject brokenPieces;
    public bool dontBreakMe = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!dontBreakMe)
        {
            if (collision.gameObject.tag == "Floor")
            {
                GetComponent<BaseHitObject>().Hit();
            }
        }
    }

    public void Explode(float yAdd)
    {
        GameObject brokenObject = Instantiate(brokenPieces, new Vector3(transform.position.x, transform.position.y + yAdd, transform.position.z), transform.rotation, null);

        /*for (int i = 0; i < brokenObject.transform.childCount; i++)
        {
            brokenObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        }*/
    }
}
