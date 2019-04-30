using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBehavior : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }
}
