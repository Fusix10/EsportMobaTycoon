using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMother
{

    public int i_id = 0;

    protected int i_timer = 0;
    void Start()
    {
        GameManager.Instance.GetItimeSystem().AddAction(this);
        i_timer = 2;
    }

    public void Init()
    {
        GameManager.Instance.GetItimeSystem().AddAction(this);
        i_timer = 2;
    }

    void Update()
    {
        
    }


    public void setTimer(int timer)
    {
        i_timer = timer;
    }
    public void actualise()
    {
        i_timer--;
        if (i_timer <= 0)
        {
            GameManager.Instance.GetItimeSystem().DeleteAction(this);
            action();
        }
    }

    protected virtual void action()
    {
        Debug.Log("l'Action" + i_id + "a pris effet");
    }
}
