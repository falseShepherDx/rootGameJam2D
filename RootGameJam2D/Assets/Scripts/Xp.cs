using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    public float xP;
    public float level;
    void Start()
    {
        level = 1;
        xP = 0;
    }


    void Update()
    {
        Debug.Log("xp:" + xP +"level:" +level);
        if(xP == 100)
        {
            xP -= 100;
            level = level + 1;
        }
    }
}
