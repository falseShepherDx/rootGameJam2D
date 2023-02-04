using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health;
    GainExperience xP;

    private void Start()
    {
        xP = GameObject.Find("Player").GetComponent<GainExperience>();
    }


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            xP.exp();
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
