using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newHealth : MonoBehaviour
{
    public float currenhealth;
    public float maxHealth = 10f;
    void Start()
    {
        currenhealth = maxHealth;
    }

    void Update()
    {
        Debug.Log(currenhealth);
    }

    public void TakeDamage(int amount)
    {
        currenhealth -= amount;
        if(currenhealth <= 0)
        {
           
            Destroy(gameObject);
        }
    }
}
