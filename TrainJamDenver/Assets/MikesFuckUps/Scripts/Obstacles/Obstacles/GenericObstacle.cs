using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObstacle : MonoBehaviour, ICollidable
{
    float LifeTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillMeOverTime();

        this.transform.parent = null;
        IUpdate();

    }

    void IUpdate()
    {

    }

    void KillMeOverTime()
    {
        LifeTime -= Time.deltaTime * 1;
        if(LifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public string CollideWith()
    {
        throw new System.NotImplementedException();
    }
}
