using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeamFight : ActionOnButton
{
    public override void OnEndTimeButton(Player player)
    {
        TimeEndTeamFight timeEnd = new TimeEndTeamFight();
        timeEnd.InitPlayer(player);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
