using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircuitAction : ActionOnTimeEnd
{
    Tournament i_tournament;

    public void init(Tournament tournament)
    {
        i_tournament = tournament;
    }

    protected override void action()
    {
        GameManager.Instance.i_tournamentOfSimulation = i_tournament;
        SceneManager.LoadScene("Simulation");
    }
}
