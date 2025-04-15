using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjective : ActionOnButton
{
    public override void OnEndTimeButton(Player player)
    {
        TimeEndObjective timeEnd = new TimeEndObjective();
        timeEnd.InitPlayer(player);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
