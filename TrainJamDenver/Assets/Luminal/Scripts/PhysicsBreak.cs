using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBreak : MonoBehaviour
{
    public GameObject brokenPieces;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Explode(1);
            Destroy(gameObject);
        }
    }

    public void Explode(float yAdd)
    {
        GameObject brokenObject = Instantiate(brokenPieces, new Vector3(transform.position.x, transform.position.y + yAdd, transform.position.z), transform.rotation);

        for (int i = 0; i < brokenObject.transform.childCount; i++)
        {
            brokenObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        }
    }
}
