using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRedButton : MonoBehaviour, IInteractable
{
    [HideInInspector]
    public bool CanActivate = false;
    bool hasBeenUsed = false;

    [SerializeField]
    float TimeShieldIsUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        if(CanActivate)
        {
            if(!hasBeenUsed)
            {
                var car = FindObjectOfType<CarHealth>();
                car.ShieldIsUp = true;
                StartCoroutine(ShieldCoolDown());
            }
        }
    }

    IEnumerator ShieldCoolDown()
    {
        yield return new WaitForSeconds(TimeShieldIsUp);
        var car = FindObjectOfType<CarHealth>();
        car.ShieldIsUp = false;
    }

    public void InteracterActWith()
    {
        OnHit();
    }
}
