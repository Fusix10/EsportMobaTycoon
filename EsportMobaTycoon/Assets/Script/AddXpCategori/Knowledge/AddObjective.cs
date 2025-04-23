using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjective : ActionOnButton
{
    public override void OnEndTimeButton()
    {
        TimeEndObjective timeEnd = new TimeEndObjective();
        timeEnd.InitPlayer(GameManager.Instance.i_manager.GetPlayer()[i_player]);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
