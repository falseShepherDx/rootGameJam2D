using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private GameObject deadGameObject;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(BulletDestroyer());


    }

    IEnumerator BulletDestroyer()
    {
        yield return new WaitForSeconds(5f);
        DestroyBullet();


    }
    void DestroyBullet()
    {
        deadGameObject = GameObject.FindWithTag("Bullet");
        Destroy(deadGameObject);
    }
}
