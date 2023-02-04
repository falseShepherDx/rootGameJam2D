using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainExperience : MonoBehaviour
{
    public int xp;
    public int level;

    

    void Update()
    {
        if (xp >= 100)
        {
            xp = 0;
            level = level + 1;
        }

        Debug.Log("xp:" + xp + "level:" + level);
    }

    public void exp()
    {
        xp += 15;
    }
}
