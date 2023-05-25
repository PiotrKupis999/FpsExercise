using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public enum Sounds
    {
        pistolSound,
        pmSound,
        m4Sound,
    }

    AudioSource audiosrc;

    [Header("AudioClips")]
    public AudioClip pistolSound_clip;
    public AudioClip pmSound_clip;
    public AudioClip m4Sound_clip;



    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }



    public void PlaySound(Sounds sound)
    {

        switch (sound)
        {
            case Sounds.pistolSound:
                audiosrc.PlayOneShot(pistolSound_clip);
                break;
            case Sounds.pmSound:
                audiosrc.PlayOneShot(pmSound_clip);
                break;
            case Sounds.m4Sound:
                audiosrc.PlayOneShot(m4Sound_clip);
                break;
        }
    }
}