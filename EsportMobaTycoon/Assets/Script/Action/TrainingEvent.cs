using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TrainingEvent : ActionOnTimeEnd
{
    List<Player> i_players = new();
    Lvl i_lvl = new(0,0);
    int i_gain = new();

    public void init(List<Player> players, Lvl lvl, int gain)
    {
        i_players = players;
        i_gain = gain;
        i_lvl = lvl;
    }

    protected override void action()
    {
        for(int i = 0; i< i_players.Count; i++)
        {
            i_players[i].gainXP(i_lvl, i_gain);
        }
        
    }
}
