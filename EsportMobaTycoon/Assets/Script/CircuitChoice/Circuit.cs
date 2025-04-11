using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit
{
    private int i_id;
    private List<Tournament> i_tournaments;

    public Circuit(int circuitId)
    {
        i_id = circuitId;

        i_tournaments = new List<Tournament>();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void AddTournament(Tournament tournament)
    {
        i_tournaments.Add(tournament);
    }

    public List<Tournament> GetTournaments()
    {
        return i_tournaments;
    }

}
