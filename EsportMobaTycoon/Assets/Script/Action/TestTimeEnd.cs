using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeEnd : ActionOnTimeEnd
{
    private Player i_player;

    public void InitPlayer(Player player)
    {
        i_player = player;
    }
    protected override void action()
    {
        i_player.gainXP(i_player.i_mechanic.s_stamina, 45);
        Debug.Log("Lvl = " + i_player.i_mechanic.s_stamina.s_lvl + "Xp = " + i_player.i_mechanic.s_stamina.s_Xp);
        i_player.UpdateTick();
    }
}
