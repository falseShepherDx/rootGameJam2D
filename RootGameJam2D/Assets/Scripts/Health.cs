using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{
    SpriteRenderer sr;
    Color orgcolor;
    float flashTime = .15f;
    [SerializeField] public int shakevalue;
    private bool shakeCamera = false;
    private float shakeDuration = 0.015f;
    private float shakeTimer = 0f;
    public int maxHealth;
    [SerializeField] private int currentHealth;
    private bool hit=true;
    SoundManager soundManager;
    private Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
    }
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        orgcolor = sr.color;
        currentHealth = maxHealth;
    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(0.5f);
        hit = true;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);

        if (shakeCamera)
        {
            transform.position = transform.position + Random.insideUnitSphere * 0.1f * shakevalue;
            Debug.Log("sa");
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();

        }
        if (shakeCamera)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                shakeCamera = false;
            }
        }        

        
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            if (hit)
            {
                FlashStart();
                StartCoroutine(HitBoxOff());
                currentHealth--;
                Debug.Log(currentHealth);
                shakeCamera = true;
                shakeTimer = shakeDuration * 10;
            }
        }
    }
    void FlashStart()
    {
        sr.color = Color.red;
        Invoke("FlashStop", flashTime);
    }

    void FlashStop()
    {
        sr.color = orgcolor;
    }

    private void Die()
    {
        Destroy(gameObject);
        soundManager.DeathSound();


    }
}
