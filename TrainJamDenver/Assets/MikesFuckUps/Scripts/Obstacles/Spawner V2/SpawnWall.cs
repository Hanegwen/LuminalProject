using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField]
    float DelayForSpawnOnTrigger;

    bool hasBeenUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenUsed)
        {
            hasBeenUsed = true;
            if (other.gameObject.GetComponent<CarMove>() != null)
            {
                print("Object about to Spawn");
                StartCoroutine(SpawnObject());

            }
        }
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(DelayForSpawnOnTrigger);

        var Spawner = FindObjectOfType<Spawner>();
        Spawner.SpawnObjects(true);
    }
}
