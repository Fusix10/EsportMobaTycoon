using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldCircuitAction : ActionOnTimeEnd
{
    private oldTournament i_tournament;
    
    public void InitTournament(oldTournament t)
    {
        i_tournament = t;
    }
    protected override void action()
    {
        GameManager.Instance.setGameState(GameState.Tournaments);
    }
}
