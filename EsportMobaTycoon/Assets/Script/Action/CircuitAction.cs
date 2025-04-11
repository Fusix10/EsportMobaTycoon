using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitAction : ActionOnTimeEnd
{
    private Tournament i_tournament;
    
    public void InitTournament(Tournament t)
    {
        i_tournament = t;
    }
    protected override void action()
    {
        GameManager.Instance.setGameState(GameState.Tournaments);
    }
}
