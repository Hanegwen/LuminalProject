using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : GenericObstacle
{
    CoreyManager CM;
    CountdownSystem CDS;
    // Start is called before the first frame update
    void Start()
    {
        CM = FindObjectOfType<CoreyManager>();
        CDS = FindObjectOfType<CountdownSystem>();
        CM.Anvil.Play();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<CarHealth>() != null)
        {
            CM.CarHit.Play();
            CDS.UpdateScoreText(-500f);
        }
    }
        // Update is called once per frame
        void IUpdate()
    {
        
    }
}
