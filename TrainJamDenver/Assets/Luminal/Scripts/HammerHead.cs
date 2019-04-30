using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHead : MonoBehaviour
{
    Vector3[] trailPositions = new Vector3[100];

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            transform.GetChild(1).GetComponent<TrailRenderer>().GetPositions(trailPositions);

            /*for (int i = 0; i < trailPositions.Length; i++)
            {
                print(trailPositions[i]);
            }*/
            
            if (Vector3.Distance(trailPositions[0], trailPositions[2]) > 0.2f)
            {
                print("greater");
            }
            else
                print("less");
        }
    }

    /*private void Update()
    {
        transform.GetChild(1).GetComponent<TrailRenderer>().GetPositions(trailPositions);
        print(Vector3.Distance(trailPositions[0], trailPositions[5]));
    }*/
}
