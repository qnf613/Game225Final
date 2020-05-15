using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource audio;
    public static SoundManager instance;

    public AudioClip jump;
    public AudioClip damaged;
    public AudioClip shoot;
    public AudioClip move;
    public AudioClip barrier;
    public AudioClip acquire;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audio.PlayOneShot(jump);
    }

    public void PlayDamaged()
    {

        audio.PlayOneShot(damaged);
    }

    public void PlayShoot()
    {

        audio.PlayOneShot(shoot);
    }

    public void PlayMove()
    {
        audio.PlayOneShot(move);
    }

    public void PlayBarrier()
    {
        audio.PlayOneShot(barrier);
    }

    public void newAbility()
    {
        audio.PlayOneShot(acquire);
    }

}
