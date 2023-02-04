using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private List<Rigidbody2D> EnemyRBs;
    public float speed;
    private Transform playerPos;
    private float repelRange = 0.5f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").transform;
        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }
        EnemyRBs.Add(rb);
    }

    private void OnDestroy()
    {
        EnemyRBs.Remove(rb);
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 0.25f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

            Vector2 direction = (playerPos.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += 180;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
            {
                continue;
            }
            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }
    }
}
