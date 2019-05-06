using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHead : MonoBehaviour
{
    public TrailRenderer hammerTrail;

    //[HideInInspector]
    public bool shooting = false;

    Vector3[] trailPositions = new Vector3[100];
    int numTrails = 0;
    float minNumberOfPoints = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IHitable>() != null)
        {
            numTrails = hammerTrail.GetPositions(trailPositions);

            if (collision.gameObject.layer == 10 && numTrails > minNumberOfPoints || shooting)
            {
                collision.gameObject.GetComponent<IHitable>().Hit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IHitable>() != null)
        {
            numTrails = hammerTrail.GetPositions(trailPositions);

            if (other.gameObject.layer == 10 && numTrails > minNumberOfPoints || shooting)
            {
                other.gameObject.GetComponent<IHitable>().Hit();
            }
        }
    }
}
