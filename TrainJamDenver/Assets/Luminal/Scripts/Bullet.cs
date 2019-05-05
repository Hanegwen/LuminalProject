using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool NotInTutorial = true;

    bool canPopUp = true;

    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (NotInTutorial)
        {
            if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) <= 0 || Input.GetKeyDown(KeyCode.A))
            {
                canPopUp = true;
            }

            if (canPopUp)
            {
                if (OVRInput.GetUp(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || Input.GetKeyDown(KeyCode.W))
                {
                    GetComponent<Animator>().Play("TempHammerAnim");
                    soundManager.PlayShootSound(this.transform);
                    GetComponent<Animator>().Play("TempHammerAnim");
                    canPopUp = false;
                    GetComponent<HammerHead>().shooting = true;
                }
            }
        }
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(.5f);
        canPopUp = true;
        GetComponent<HammerHead>().shooting = false;
    }
}
