using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReflexe : ActionOnButton
{
    public override void OnEndTimeButton()
    {
        TimeEndReflexe timeEnd = new TimeEndReflexe();
        timeEnd.InitPlayer(GameManager.Instance.i_manager.GetPlayer()[i_player]);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
