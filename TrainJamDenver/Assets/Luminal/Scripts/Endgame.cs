using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    void Start()
    {
        Invoke("End", 4);
    }

    void End()
    {
        Application.Quit();
        print("end");
    }
}
