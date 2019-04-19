using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("No Bueno");
        if(collision.gameObject.GetComponent<IHitable>() != null)
        {
            collision.gameObject.GetComponent<IHitable>().Hit();
            print("Hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Wow");
        if(other.gameObject.GetComponent<IHitable>() != null)
        {
            other.gameObject.GetComponent<IHitable>().Hit();
        }
    }
}
