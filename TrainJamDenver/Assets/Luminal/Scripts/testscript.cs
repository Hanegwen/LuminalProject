using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testscript : MonoBehaviour
{
    public GameObject prefab;
    int on = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0)
        {
            //Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
