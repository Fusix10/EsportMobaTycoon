using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeEnd : ActionOnTimeEnd
{
    protected Player i_player;
    protected float i_xp;

    public void InitPlayer(Player player)
    {
        i_player = player;
    }

    public void InitXp(float xp)
    {
        i_xp = xp;
    }
}
