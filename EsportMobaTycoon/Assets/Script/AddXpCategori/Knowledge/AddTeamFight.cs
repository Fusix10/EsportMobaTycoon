using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeamFight : ActionOnButton
{
    public override void OnEndTimeButton()
    {
        TimeEndTeamFight timeEnd = new TimeEndTeamFight();
        timeEnd.InitPlayer(GameManager.Instance.i_allPlayers[savePlayerSelectedUi.i_indexPlayer]);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
