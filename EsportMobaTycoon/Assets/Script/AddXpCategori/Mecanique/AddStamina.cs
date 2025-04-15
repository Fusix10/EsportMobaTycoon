using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStamina : ActionOnButton
{
    public override void OnEndTimeButton(Player player)
    {
        TimeEndStamina timeEnd = new TimeEndStamina();
        timeEnd.InitPlayer(player);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
