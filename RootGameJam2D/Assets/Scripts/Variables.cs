using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{

    public float currenthp = 3f;
    public float maxhp;
    [SerializeField] float delay = 0.2f;
    [SerializeField] bool hit = false;

    void Start()
    {
        currenthp = maxhp;
    }

    void Update()
    {
        if (hit)
        {
            currenthp--;
        }
        if(currenthp == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemey"))
        {
           
            hit = true;
            StartCoroutine(loadDelay());
            hit = false;
            

        }
       
    }
    IEnumerator loadDelay()
    {
        yield return new WaitForSeconds(delay);
        
    }
}
