using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WriteTime();
        passTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum Day
    {
        lundi,
        mardi,
        mercredi,
        jeudi,
        vendredi,
        samedi,
        dimanche
    }

    Day day;
    public int TimeSystem = 51;

    public void passTime()
    {
        for (int i = 0; i < 50; i++)
        {
            TimeSystem++;
            WriteTime();
        }
    }

    public void WriteTime()
    {
        Debug.Log("day : " + (Day)(TimeSystem % 7));
    }
}
