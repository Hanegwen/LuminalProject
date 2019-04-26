using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource backgroundMusic;

    [SerializeField]
    AudioSource EffectSounds;

    [SerializeField]
    AudioClip SpringHammerSound;

    [SerializeField]
    public AudioClip StartSound;

    [SerializeField]
    AudioClip CompleteSound;

    [SerializeField]
    AudioClip HitSound;

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

    public void PlayHitSound(Transform location)
    {
        EffectSounds.transform.position = location.position;
        EffectSounds.clip = HitSound;
        EffectSounds.Play();
    }

    public void BeginGame()
    {
        EffectSounds.clip = StartSound;
        EffectSounds.Play();
    }
}
