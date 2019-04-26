using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool NotInTutorial = true;
    bool canPopUp = true;
    

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NotInTutorial)
        {
            if (canPopUp)
            {
                if (OVRInput.GetUp(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || Input.GetKeyDown(KeyCode.W))
                {
                    //animator.SetBool("IsExtending", true);
                    transform.GetChild(0).GetChild(0).GetComponent<Animator>().Play("TempHammerAnim");
                    print(animator.GetBool("IsExtending"));
                    canPopUp = false;
                    StartCoroutine(Recharge());
                    //Instantiate(prefab, transform.position, transform.rotation);
                }
            }
            else
            {
                animator.SetBool("IsExtending", false);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("No Bueno");
        if(collision.gameObject.GetComponent<IHitable>() != null)
        {
            collision.gameObject.GetComponent<IHitable>().Hit();
            print("Hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Wow");
        if(other.gameObject.GetComponent<IHitable>() != null)
        {
            other.gameObject.GetComponent<IHitable>().Hit();
        }
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(.5f);
        canPopUp = true;
    }
}
