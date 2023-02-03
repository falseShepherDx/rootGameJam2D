using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.Find("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);    
    }
}
