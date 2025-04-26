using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEndReflexe : TestTimeEnd
{
    protected override void action()
    {
        i_player.GainXP(i_player.i_mechanic.s_reflexe, i_xp);
        Debug.Log("Lvl = " + i_player.i_mechanic.s_reflexe.s_lvl + "Xp = " + i_player.i_mechanic.s_reflexe.s_Xp);
        i_player.UpdateTick();
    }
}
