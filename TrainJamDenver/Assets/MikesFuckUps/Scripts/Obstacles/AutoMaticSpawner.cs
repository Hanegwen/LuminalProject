using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMaticSpawner : MonoBehaviour
{
    bool canSpawn = true;
    [SerializeField]
    float SpawnRecharge;

    [SerializeField]
    float DivisionRateBasedOnGrowthOfRounds;

    int lastSpawned = 0;
    int spawnedTwoAgo = 0;

    [SerializeField]
    List<GameObject> spawnableObjects;

    NodeManager nodeManager;
    CoreyManager manager;

    Transform spawnTransform;

    [SerializeField]
    Vector3 HeightDifference;
    // Start is called before the first frame update
    void Start()
    {
        nodeManager = FindObjectOfType<NodeManager>();
        manager = FindObjectOfType<CoreyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.gameHasBegun)
        {
            print("SPAWNER: Game Has Begun");
            if (canSpawn)
            {
                print("SPAWNER:I Should be Spawning");
                canSpawn = false;
                SpawnObjects(true);
            }
        }
    }

    public void SpawnObjects(bool ignoreLastSpawn = false, GameObject ObjectToSpawn = null)
    {

        if (ignoreLastSpawn || canSpawn)
        {
            if (ObjectToSpawn == null)
            {

                //Determines what object to spawn
                int value = UnityEngine.Random.Range(0, (spawnableObjects.Count - 1));


                if (lastSpawned == value)
                {
                    switch (value)
                    {
                        case 0:
                            if (spawnedTwoAgo == 2)
                            {
                                value = 1;
                                spawnedTwoAgo = lastSpawned;
                            }
                            else
                            {
                                spawnedTwoAgo = 2;
                                spawnedTwoAgo = lastSpawned;
                            }
                            break;
                        case 1:
                            if (spawnedTwoAgo == 0)
                            {
                                value = 2;
                                spawnedTwoAgo = lastSpawned;
                            }
                            else
                            {
                                value = 0;
                                spawnedTwoAgo = lastSpawned;
                            }
                            break;
                        case 2:
                            if (spawnedTwoAgo == 1)
                            {
                                value = 0;
                                spawnedTwoAgo = lastSpawned;
                            }
                            else
                            {
                                value = 1;
                                spawnedTwoAgo = lastSpawned;
                            }
                            break;
                        default:
                            print("SHOULDN'T SEE THIS");
                            break;
                    }
                }

                if(nodeManager.GlobalIncrementor >= 25)
                {
                    SpawnRecharge = (float)(SpawnRecharge / (DivisionRateBasedOnGrowthOfRounds * 1.2));

                    spawnTransform = nodeManager.CenterRightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);

                    spawnTransform = nodeManager.CenterLeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);

                    spawnTransform = nodeManager.RightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);
                }
                else if(nodeManager.GlobalIncrementor >= 20)
                {
                    SpawnRecharge = (float)(SpawnRecharge / (DivisionRateBasedOnGrowthOfRounds * 1.1));

                    spawnTransform = nodeManager.CenterRightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);

                    spawnTransform = nodeManager.LeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);
                }
                else if(nodeManager.GlobalIncrementor >= 15)
                {
                    SpawnRecharge = SpawnRecharge / DivisionRateBasedOnGrowthOfRounds;

                    spawnTransform = nodeManager.CenterLeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);

                    spawnTransform = nodeManager.RightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);
                }
                else if(nodeManager.GlobalIncrementor >= 10)
                {

                    spawnTransform = nodeManager.LeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);
                }
                else
                {
                    spawnTransform = nodeManager.RightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(spawnableObjects[value], spawnTransform);
                }
                
                lastSpawned = value;
            }
            else
            {
                if (nodeManager.GlobalIncrementor >= 25)
                {
                    SpawnRecharge = (float)(SpawnRecharge / (DivisionRateBasedOnGrowthOfRounds * 1.2));

                    spawnTransform = nodeManager.CenterRightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);

                    spawnTransform = nodeManager.CenterLeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);

                    spawnTransform = nodeManager.RightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);
                }
                else if (nodeManager.GlobalIncrementor >= 20)
                {
                    SpawnRecharge = (float)(SpawnRecharge / (DivisionRateBasedOnGrowthOfRounds * 1.1));

                    spawnTransform = nodeManager.CenterRightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);

                    spawnTransform = nodeManager.LeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);
                }
                else if (nodeManager.GlobalIncrementor >= 15)
                {
                    SpawnRecharge = SpawnRecharge / DivisionRateBasedOnGrowthOfRounds;

                    spawnTransform = nodeManager.CenterLeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);

                    spawnTransform = nodeManager.RightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);
                }
                else if (nodeManager.GlobalIncrementor >= 10)
                {

                    spawnTransform = nodeManager.LeftNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);
                }
                else
                {
                    spawnTransform = nodeManager.RightNode[nodeManager.GlobalIncrementor].transform;
                    spawnTransform.position += HeightDifference;
                    Instantiate(ObjectToSpawn, spawnTransform);
                }
                
            }
            canSpawn = false;
            StartCoroutine(RechargeSpawner());
        }
        else
        {
            if (!canSpawn)
            {
                return;
            }
        }
    }

    IEnumerator RechargeSpawner()
    {
        yield return new WaitForSeconds(SpawnRecharge);
        canSpawn = true;
    }
}

