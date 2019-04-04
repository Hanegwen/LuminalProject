using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    //This includes collision in it
    [SerializeField]
    int health;

    public bool ShieldIsUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    void CheckDeath()
    {
        if(health <= 0)
        {
            print("Health: " + health);
        }
    }

    void TakeDamage(int damage)
    {
        if (!ShieldIsUp)
        {
            health -= damage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollidable>() != null)
        {
            print("Hit a Collidable Object");
            Destroy(other.gameObject);
            TakeDamage(1);
        }
    }
}
