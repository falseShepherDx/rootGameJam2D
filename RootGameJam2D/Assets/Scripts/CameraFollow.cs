using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;
    private bool shakeCamera = false;
    private float shakeDuration = 0.1f;
    private float shakeTimer = 0f;

    void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);

        if (shakeCamera)
        {
            transform.position = transform.position + Random.insideUnitSphere * 0.1f;
        }
    }
}
