using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnRadius = 7f, time = 1.5f;
    public GameObject[] enemies;
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    void Update()
    {
        
    }
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemies[Random.Range(0, enemies.Length)],spawnPos,Quaternion.identity);  
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
