using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMother : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected int i_timer = 0;

    public void setTimer(int timer)
    {
        i_timer = timer;
    }
    public void actualise()
    {
        i_timer--;
        if (i_timer <= 0)
        {
            action();
        }
    }

    protected virtual void action()
    {

    }
}
