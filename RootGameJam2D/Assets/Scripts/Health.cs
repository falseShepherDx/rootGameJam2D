using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float currenthp = 3f;
    public float maxhp;
    [SerializeField] float delay = 2f;
    [SerializeField] bool hit = false;

    void Start()
    {
        currenthp = maxhp;
    }

    void Update()
    {
        currenthp = Mathf.Clamp(currenthp, 0, 3);
        Debug.Log(currenthp);
        if (currenthp == 0)
        {
            Destroy(this.gameObject);
            //SceneManager.LoadScene(0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currenthp--;

        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(loadDelay());


        }


    }



    IEnumerator loadDelay()
    {
        yield return new WaitForSeconds(1f);
        currenthp -= Time.time;



    }


}
