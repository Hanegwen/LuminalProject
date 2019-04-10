using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSwapManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> BrokenPiecesRooms;

    [SerializeField]
    List<GameObject> OnePieceRooms;

    int currentRoom = 1;


    // Start is called before the first frame update
    void Start()
    {
        //RoomSwap(currentRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomSwap(int newNumber)
    {
        print("Room Swap Activated");
        if(newNumber != 1)
        {
            if(BrokenPiecesRooms[newNumber - 1] == true)
            {
                BrokenPiecesRooms[newNumber - 1].SetActive(false);
            }
        }
        if(BrokenPiecesRooms[newNumber].activeSelf == false)
        {
            BrokenPiecesRooms[newNumber].SetActive(true);
        }
    }
}
