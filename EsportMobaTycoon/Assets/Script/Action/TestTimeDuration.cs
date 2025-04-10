using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeDuration : ActionOnDurationTime
{
    public Player i_player;

    public void InitPlayer(Player player)
    {
        i_player = player;
    }
    protected override void action()
    {
        i_player.gainXP(i_player.i_mechanic.s_lvlCombo[i_player.i_favoriteCharacterId], 83);
        Debug.Log("Lvl = " + i_player.i_mechanic.s_lvlCombo[i_player.i_favoriteCharacterId].s_lvl + "Xp = " + i_player.i_mechanic.s_lvlCombo[i_player.i_favoriteCharacterId].s_Xp);
        i_player.UpdateTick();
    }
}
