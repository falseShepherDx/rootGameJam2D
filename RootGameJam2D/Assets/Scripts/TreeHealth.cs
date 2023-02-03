using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeHealth : MonoBehaviour
{
    [SerializeField] float currentTreeHp = 120f;
    [SerializeField] float maxTreeHp = 120f;
    void Start()
    {
        
    }

     void Update()
    {
        currentTreeHp = Mathf.Clamp(currentTreeHp, 0, maxTreeHp);
        Debug.Log(currentTreeHp);

        if(currentTreeHp == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentTreeHp = currentTreeHp - 5;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(treeloadDelay());
        }
    }

    IEnumerator treeloadDelay()
    {
        yield return new WaitForSeconds(1f);
        currentTreeHp -= 5  * Time.time;



    }

}
