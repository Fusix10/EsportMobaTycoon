using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStamina : ActionOnButton
{
    public override void OnEndTimeButton()
    {
        TimeEndStamina timeEnd = new TimeEndStamina();
        timeEnd.InitPlayer(GameManager.Instance.i_allPlayers[i_player]);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
