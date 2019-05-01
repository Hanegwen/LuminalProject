using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBreak : MonoBehaviour
{
    public GameObject brokenPieces;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void Explode()
    {
        GameObject brokenObject = Instantiate(brokenPieces, transform.position, transform.rotation);

        for (int i = 0; i < brokenObject.transform.childCount; i++)
        {
            brokenObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        }
    }
}
