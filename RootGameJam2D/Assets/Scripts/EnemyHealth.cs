using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Xp xp;
    [SerializeField] float health;
   
    void Update()
    {
        if (health <=0f)
        {
            Destroy(gameObject);
            xp.xP += 15;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                health -= 20;
            }

        }
    }

}
