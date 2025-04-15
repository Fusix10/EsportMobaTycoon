using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEndPlacement : TestTimeEnd
{
    protected override void action()
    {
        i_player.gainXP(i_player.i_knowledge.s_placement, i_xp);
        Debug.Log("Lvl = " + i_player.i_knowledge.s_placement.s_lvl + "Xp = " + i_player.i_knowledge.s_placement.s_Xp);
        i_player.UpdateTick();
    }
}
