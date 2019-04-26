using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    Bullet bullet;
    HammerHead hammerHead;
    HammerMaterial hammerMaterial;

    [SerializeField]
    Material TransparentHammer;
    [SerializeField]
    Material OpaqueHammer;

    bool MyTutorial = true;
    // Start is called before the first frame update
    void Awake()
    {
        hammerMaterial = FindObjectOfType<HammerMaterial>();
        bullet = FindObjectOfType<Bullet>();
        hammerHead = FindObjectOfType<HammerHead>();
        bullet.enabled = false;
        bullet.NotInTutorial = false;
        bullet.GetComponent<BoxCollider>().enabled = false;
        hammerHead.GetComponent<BoxCollider>().enabled = false;
        hammerMaterial.GetComponent<SkinnedMeshRenderer>().material = TransparentHammer;
    }

    // Update is called once per frame
    void Update()
    {
        TutorialInput();
    }
    
    void TutorialInput()
    {
        if (OVRInput.GetUp(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || Input.GetKeyDown(KeyCode.W))
        {
            if (MyTutorial)
            {
                bullet.GetComponent<BoxCollider>().enabled = true;
                hammerHead.GetComponent<BoxCollider>().enabled = true;
                hammerMaterial.GetComponent<SkinnedMeshRenderer>().material = OpaqueHammer;
                MyTutorial = false;
                bullet.NotInTutorial = true;
                bullet.enabled = true;
            }
        }
    }
}
