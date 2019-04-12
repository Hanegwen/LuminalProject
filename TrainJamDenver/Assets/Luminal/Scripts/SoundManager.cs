using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource backgroundMusic;

    [SerializeField]
    AudioSource EffectSounds;

    [SerializeField]
    AudioClip SpringHammerSound;

    [SerializeField]
    AudioClip StartSound;

    [SerializeField]
    AudioClip CompleteSound;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        EffectSounds.clip = StartSound;
        EffectSounds.Play();
    }
}
