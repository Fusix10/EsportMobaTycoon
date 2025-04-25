using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCircuit : ActionOnTimeEnd
{
    private List<Match> i_matches;

    public void InitAcion(List<Match> matches)
    {
        i_matches = matches;
    }
    protected override void action()
    {
        //change d'état
        //Call la Simulation avec les donné
        //SimulationPlayers simulationPlayers = new SimulationPlayers();
    }
}
