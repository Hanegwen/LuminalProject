using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeObjSpawning : MonoBehaviour
{
    #region Managers
    CoreyManager CM;
    NodeManager NM;
    public bool GameHasStarted = false;
    
    bool LeftSpawn, LeftMSpawn, RightMSpawn, RightSpawn;

    int spawnLane;
    #endregion
   public bool ObjSpawned = false;
    [SerializeField] List<GameObject> spawnableObjects;
    int num2Spawn = 1;
    Transform spawnTransform;

    int spawnTime = 0;
    int time;
    int maxSpawnTime = 10;

    [SerializeField] Vector3 HeightDifference;

    // Start is called before the first frame update
    void Start()
    {
        CM = FindObjectOfType<CoreyManager>();
        NM = FindObjectOfType<NodeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CM.gameHasBegun)
        {
            print("SPAWNER: Game Has Begun");
            //if (ObjSpawned == false)
            //{
            //    print("SPAWNER:I Should be Spawning");
            //    ObjSpawned = false;
            //   // SpawnObjects(true); Update to SpawnObj
            //}
        }


    }

    private void FixedUpdate()
    {
        //print(time);
        // if (ObjSpawned == false)
        //{
        //    time = Random.Range(2, maxSpawnTime);
        //    ObjSpawned = true;
        //}
        //else
        //{
        //    if (spawnTime >= time)
        //    {
        //        SpawnObj();

        //        print("SpawnedObj");

        //    }

        //    else if (spawnTime < time)
        //    {
        //        spawnTime++;
        //    }
        //}
    }

   public  void SpawnObj()
    {
        if(NM.GlobalIncrementor< 48 && GameHasStarted == true)
        { 

        if (ObjSpawned == true)
        {


                for (int i = 0; i <= num2Spawn; i++)
                {
                    int value = UnityEngine.Random.Range(0, (spawnableObjects.Count));
                    int lane = Random.Range(0, 4);
                    spawnLane = lane;
                    switch (spawnLane)
                    {
                        case 0: // Left Lane

                            if (LeftSpawn == false && NM.LeftNode[NM.GlobalIncrementor + 1].hasSpawned == false)
                            {
                                spawnTransform = NM.LeftNode[NM.GlobalIncrementor + 1].transform;
                                NM.LeftNode[NM.GlobalIncrementor + 1].hasSpawned = true;
                                spawnTransform.position += HeightDifference;
                                Instantiate(spawnableObjects[value], spawnTransform);
                                LeftSpawn = true;
                            }
                            else print("Obj Spawned in lane already");
                            break;

                        case 1: // Left Center
                            if (LeftMSpawn == false && NM.CenterLeftNode[NM.GlobalIncrementor + 1].hasSpawned == false)
                            {
                                spawnTransform = NM.CenterLeftNode[NM.GlobalIncrementor + 1].transform;
                                NM.CenterLeftNode[NM.GlobalIncrementor + 1].hasSpawned = true;
                                spawnTransform.position += HeightDifference;
                                Instantiate(spawnableObjects[value], spawnTransform);
                                LeftMSpawn = true;
                            }
                            else print("Obj Spawned in lane already");
                            break;

                        case 2: // Right Center
                            if (RightMSpawn == false && NM.CenterRightNode[NM.GlobalIncrementor + 1].hasSpawned == false)
                            {
                                spawnTransform = NM.CenterRightNode[NM.GlobalIncrementor + 1].transform;
                                NM.CenterRightNode[NM.GlobalIncrementor + 1].hasSpawned = true;
                                spawnTransform.position += HeightDifference;
                                Instantiate(spawnableObjects[value], spawnTransform);
                                LeftSpawn = true;
                            }
                            else print("Obj Spawned in lane already");
                            break;

                        case 3:// Right Lane
                            if (RightSpawn == false && NM.RightNode[NM.GlobalIncrementor + 1].hasSpawned == false)
                            {
                                spawnTransform = NM.RightNode[NM.GlobalIncrementor + 1].transform;
                                NM.RightNode[NM.GlobalIncrementor + 1].hasSpawned = true;
                                spawnTransform.position += HeightDifference;
                                Instantiate(spawnableObjects[value], spawnTransform);
                                LeftSpawn = true;
                            }
                            else print("Obj Spawned in lane already");
                            break;

                        default:
                            break;
                    }
                }





            }
            LeftSpawn = false;
            LeftMSpawn = false;
            RightMSpawn = false;
            RightSpawn = false;
           ObjSpawned = false;



        }
    }

    
    
    
}
