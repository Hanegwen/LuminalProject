using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool NotInTutorial = true;

    bool canPopUp = true;
    Animator animator;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
                    soundManager.PlayShootSound(this.transform);
                    //animator.SetBool("IsExtending", true);
                    transform.GetChild(0).GetChild(0).GetComponent<Animator>().Play("TempHammerAnim");
                    print(animator.GetBool("IsExtending"));
                    canPopUp = false;
                    //StartCoroutine(Recharge());
                    //Instantiate(prefab, transform.position, transform.rotation);
                }
            }
            else
            {
                animator.SetBool("IsExtending", false);

            }
        }
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(.5f);
        canPopUp = true;
    }
}
