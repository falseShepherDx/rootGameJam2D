using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 25f;
    private GameObject deadGameObject;
    SoundManager soundManager;
    private AudioSource audioSource;
    public AudioClip shootingSound;

    float fireRate = 0.25f;
    float nextFire = 0f;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(shootingSound);
        soundManager.PlayGunShotSound();
        StartCoroutine(BulletDestroyer());
    }

    IEnumerator BulletDestroyer()
    {
        yield return new WaitForSeconds(5f);
        deadGameObject = GameObject.FindWithTag("Bullet");
        Destroy(deadGameObject);
    }
}

