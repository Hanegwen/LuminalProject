using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //I'm guessing Input here is a page for it
        //https://developer.oculus.com/documentation/unity/latest/concepts/unity-ovrinput/
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {

        }
    }

    protected virtual void Shoot()
    {
        if(canShoot)
        {

        }
    }
}
