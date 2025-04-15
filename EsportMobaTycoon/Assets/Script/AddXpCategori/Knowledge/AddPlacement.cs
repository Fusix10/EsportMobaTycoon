using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlacement : ActionOnButton
{
    public override void OnEndTimeButton(Player player)
    {
        TimeEndPlacement timeEnd = new TimeEndPlacement();
        timeEnd.InitPlayer(player);
        timeEnd.InitXp(i_Xp);
        timeEnd.setTimer(i_Days);
        GameManager.Instance.AddAction(timeEnd);
    }
}
