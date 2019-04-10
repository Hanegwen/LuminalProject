using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitObject : MonoBehaviour, IHitable
{
    Rigidbody rigidbody;
    public GameObject hitPointsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Hit();
        }
    }

    public void Hit()
    {
        //rigidbody.add
        //Destroy(this.gameObject);
        Instantiate(hitPointsPrefab, transform.position, transform.rotation, null);
    }
}
