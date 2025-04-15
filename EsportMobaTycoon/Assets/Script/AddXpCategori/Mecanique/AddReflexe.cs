using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReflexe : ActionOnButton
{
    public override void OnEndTimeButton(Player player)
    {
        TimeEndReflexe timeEnd = new TimeEndReflexe();
        timeEnd.InitPlayer(player);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
