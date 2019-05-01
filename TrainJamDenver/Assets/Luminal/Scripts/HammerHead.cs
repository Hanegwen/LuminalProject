using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHead : MonoBehaviour
{
    public TrailRenderer hammerTrail;

    Vector3[] trailPositions = new Vector3[100];
    int numTrails = 0;

    private void Update()
    {
        //hammerTrail.GetPositions(trailPositions);
        //print(hammerTrail.GetPositions(trailPositions));
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("No Bueno");
        if (collision.gameObject.GetComponent<IHitable>() != null)
        {
            numTrails = hammerTrail.GetPositions(trailPositions);

            if (collision.gameObject.layer == 10 && numTrails > 5)
            {
                collision.gameObject.GetComponent<IHitable>().Hit();
                print("Hit");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Wow");
        if (other.gameObject.GetComponent<IHitable>() != null)
        {
            hammerTrail.GetPositions(trailPositions);

            if (other.gameObject.layer == 10 && numTrails > 5)
            {
                other.gameObject.GetComponent<IHitable>().Hit();
            }
        }
    }

    /*private void Update()
    {
        transform.GetChild(1).GetComponent<TrailRenderer>().GetPositions(trailPositions);
        print(Vector3.Distance(trailPositions[0], trailPositions[5]));
    }*/
}
