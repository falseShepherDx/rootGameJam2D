using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    SpriteRenderer sr;
    Color orgcolor;
    float flashTime = .15f;

    [SerializeField] public int health;
    GainExperience xP;
    SoundManager soundManager;
    private AudioSource audioSource;
    public AudioClip hitSound;



    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        orgcolor = sr.color;
        xP = GameObject.Find("Player").GetComponent<GainExperience>();
        audioSource = GetComponent<AudioSource>();  
    }


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            FlashStart();
            xP.exp();
        }

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                StartHitSucces();

            }

        }
    }
    void FlashStart()
    {
        sr.color = Color.magenta;
        Invoke("FlashStop", flashTime);
    }

    void FlashStop()
    {
        sr.color = orgcolor;
    }

    private void StartHitSucces()
    {
        health -= 20;
        audioSource.PlayOneShot(hitSound);
    }
}
