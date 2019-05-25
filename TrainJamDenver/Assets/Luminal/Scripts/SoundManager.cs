using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource backgroundMusic;

    [SerializeField]
    public AudioSource ExtraSound;

    [SerializeField]
    AudioClip extraSound;

    [SerializeField]
    AudioSource EffectSounds;

    [SerializeField]
    AudioSource HammerEmitter;

    [SerializeField]
    AudioClip SpringHammerSound;

    [SerializeField]
    AudioClip smash1, smash2, smash3, smash4;

    [SerializeField]
    AudioClip launch0, launch1;

    [SerializeField]
    public AudioClip StartSound;

    [SerializeField]
    AudioClip CompleteSound;

    [SerializeField]
    AudioClip HitSound;

    Random ran = new Random();
    int currentRan;
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

    public void PlayShootSound(Transform location)
    {
        HammerEmitter.transform.position = location.position;

        currentRan = Random.Range(0, 1);

        switch(currentRan)
        {
            case 1:
                HammerEmitter.clip = launch0;
                break;
            default:
                HammerEmitter.clip = launch1;
                break;
        }
        HammerEmitter.loop = false;
        HammerEmitter.Play();
    }

    public void PlayHitSound(Transform location)
    {
        EffectSounds.transform.position = location.position;

        currentRan = Random.Range(0, 4);

        switch(currentRan)
        {
            case 1:
                EffectSounds.clip = smash1;
                break;
            case 2:
                EffectSounds.clip = smash2;
                break;
            case 3:
                EffectSounds.clip = smash3;
                break;
            case 4:
                EffectSounds.clip = smash4;
                break;
            default:
                EffectSounds.clip = HitSound;
                break;
        }
         
        
        EffectSounds.Play();
    }

    public void BeginGame()
    {
        EffectSounds.clip = StartSound;
        EffectSounds.Play();
    }
}
