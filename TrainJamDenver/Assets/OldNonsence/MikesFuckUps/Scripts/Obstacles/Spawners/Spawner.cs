using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    bool canSpawn = true;
    [SerializeField]
    float spawnRecharge;

    int lastSpawned = 0;

    [SerializeField]
    List<GameObject> spawnableObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            SpawnObjects();
        }
    }

    public void SpawnObjects(bool ignoreLastSpawn = false, GameObject ObjectToSpawn = null)
    {
        //print("Object should be spawning");
        if(ignoreLastSpawn || canSpawn)
        {
            if(ObjectToSpawn == null)
            {
                //print("Currently Spawning Default Item");

                int value = UnityEngine.Random.Range(0, (spawnableObjects.Count-1));
                //print("Value:" + value);

                if(lastSpawned == value)
                {
                    switch (value)
                    {
                        case 0:
                            value = 1;
                            break;
                        case 1:
                            value = 2;
                            break;
                        case 2:
                            value = 0;
                            break;
                        default:
                            print("SHOULDN'T SEE THIS");
                            break;
                    }
                }
                Instantiate(spawnableObjects[value], this.transform);
                lastSpawned = value;
            }
            else
            {
                Instantiate(ObjectToSpawn,this.transform);
            }
            canSpawn = false;
            StartCoroutine(RechargeSpawner());
        }
        else
        {
            if(!canSpawn)
            {
                return;
            }
        }
    }

    IEnumerator RechargeSpawner()
    {
        yield return new WaitForSeconds(spawnRecharge);
        canSpawn = true;
    }
}
