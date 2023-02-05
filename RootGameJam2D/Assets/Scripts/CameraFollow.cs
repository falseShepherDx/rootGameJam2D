using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;
    public bool shakeCamera = false;
    public float shakeDuration = 0.1f;
    public float shakeTimer = 0f;
    [SerializeField] float xbarrier;
    [SerializeField] float ybarrier;

    void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shakeCamera = true;
            shakeTimer = shakeDuration;
        }

        if (shakeCamera)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                shakeCamera = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        if (newPos.x < -xbarrier)
        {
            newPos.x = -xbarrier;
        }
        else if (newPos.x > xbarrier)
        {
            newPos.x = xbarrier;
        }
        if (newPos.y < -ybarrier)
        {
            newPos.y = -ybarrier;
        }
        else if (newPos.y > ybarrier)
        {
            newPos.y = ybarrier;
        }
        transform.position = newPos;

        if (shakeCamera)
        {
            transform.position = transform.position + Random.insideUnitSphere * 0.1f;
        }
    }
}