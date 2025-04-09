using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnTimeEnd : ActionMother
{

    public override void actualise()
    {
        i_timer--;
        if (i_timer <= 0)
        {
            GameManager.Instance.GetItimeSystem().DeleteAction(this);
            action();
        }
    }
}
