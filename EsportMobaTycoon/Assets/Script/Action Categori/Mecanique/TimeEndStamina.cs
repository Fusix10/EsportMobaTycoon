using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEndStamina : TestTimeEnd
{
    protected override void action()
    {
        i_player.gainXP(i_player.i_mechanic.s_stamina, i_xp);
        Debug.Log("Lvl = " + i_player.i_mechanic.s_stamina.s_lvl + "Xp = " + i_player.i_mechanic.s_stamina.s_Xp);
        i_player.UpdateTick();
    }
}
