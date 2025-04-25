using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldTournament
{
    private enum TournamentStatus
    {
        NotPlayed,
        Won,
        Lost
    }

    private string i_name;

    private int i_nbTurn;

    private bool i_is_major;

    private List<oldMatch> i_matches;

    private TournamentStatus i_status;

    public oldTournament(int nbTurn, bool is_major, string name)
    {

        i_nbTurn = nbTurn;
        i_is_major = is_major;
        i_status = TournamentStatus.NotPlayed;

        i_matches = new List<oldMatch>();
        i_name = name;
    }

    public void HasWon(bool win)
    {
        i_status = win ? TournamentStatus.Won : TournamentStatus.Lost;
    }

    public void AddMatch(oldMatch match)
    {
        i_matches.Add(match);
    }
    public List<oldMatch> GetMatches()
    {
        return i_matches;
    }

    public int getNbTurn()
    {
        return i_nbTurn;
    }

    public bool IsMajor()
    {
        return i_is_major;
    }
}
