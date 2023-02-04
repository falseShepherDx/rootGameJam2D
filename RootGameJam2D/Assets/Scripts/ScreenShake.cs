using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool start;
    [SerializeField] float duraction = 1f;
    public AnimationCurve curve;
    [SerializeField] float fixer = 0.1f;
    void Start()
    {
        start = false;
    }

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duraction)
        {
            elapsedTime+= Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duraction) ;
            transform.position = startPosition + Random.insideUnitSphere * strenght * fixer;
            yield return null;
        }
        transform.position = startPosition; 
    }
}
