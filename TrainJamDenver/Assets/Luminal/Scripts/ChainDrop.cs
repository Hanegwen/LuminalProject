using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChainDrop : MonoBehaviour {

    [Tooltip("Must have a ChainDrop Component.")]
    public GameObject NextObjectToDrop;
    public float TimeBeforeNextDropInSeconds;
    public float TimeBeforeDestruction;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = this.GetComponent<Rigidbody>();

        rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartChain()
    {
        rb.useGravity = true;

        if (NextObjectToDrop != null)
        {
            StartCoroutine(DropNext());     //start coroutine to wait and drop next object
        }

        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DropNext()
    {
        yield return new WaitForSeconds(TimeBeforeNextDropInSeconds);

        NextObjectToDrop.GetComponent<ChainDrop>().StartChain();

        yield return null;
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(TimeBeforeDestruction);

        Destroy(this.gameObject);

        yield return null;
    }
}
