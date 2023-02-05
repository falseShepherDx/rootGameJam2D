using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gunShotSound;
    public AudioClip deathSound;
    public AudioClip hitSound;

    private AudioSource audioSource;
    void Start()
    {
    audioSource=GetComponent<AudioSource>();        
    }

  public void PlayGunShotSound()
    {
        audioSource.PlayOneShot(gunShotSound);
    }
    public void DeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
    public void EnemyShotSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}
