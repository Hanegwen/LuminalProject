using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxForBigRedButton : MonoBehaviour, IInteractable
{
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("DEBBUG: SPACE HIT TO FORCE BOX");
            OnHit();
        }
    }

    void OnHit()
    {
        var button = FindObjectOfType<BigRedButton>();
        if (!isOpen)
        {
            isOpen = true;
            button.CanActivate = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            isOpen = false;
            button.CanActivate = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void InteracterActWith()
    {
        OnHit();
    }
}
