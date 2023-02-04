using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] private int currentHealth;
    private bool hit=true;
    private void Start()
    {
        currentHealth=maxHealth;
    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(0.5f);
        hit = true;


    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            if (hit)
            {
                StartCoroutine(HitBoxOff());
                currentHealth--;
                Debug.Log(currentHealth);
            }
        }
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);    
        }
    }

}
