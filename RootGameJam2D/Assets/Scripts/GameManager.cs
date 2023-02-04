using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyDamage EnemyDamage;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            EnemyDamage.enabled = false;
        }
        
    }
}
