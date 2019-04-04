using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource Wind, Water, Tires;

    float TiresDelay = 10;
    bool TiesHavePlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TiresDelay -= Time.deltaTime;

        if (TiresDelay <= 0)
        {
            if (!TiesHavePlayed)
            {
                TiesHavePlayed = true;
                Tires.Play();
            }
        }
    }

    public void StopActiveMusic()
    {
        Wind.Stop();
        Water.Stop();
    }
}
