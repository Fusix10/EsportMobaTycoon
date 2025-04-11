using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusManager
{
    public enum Status
    {
        NotPlayed,
        Won,
        Lost
    }

    protected Status i_status;

    protected StatusManager()
    {
        i_status = Status.NotPlayed;
    }

    public void SetHasWon(bool win)
    {
        i_status = win ? Status.Won : Status.Lost;
    }

    public Status GetStatus()
    {
        return i_status;
    }
}

public class Circuit : StatusManager
{
    private int i_id;
    private List<Tournament> i_tournaments;

    public Circuit(int circuit_id)
    {
        i_id = circuit_id;
        i_tournaments = new List<Tournament>();
    }

    public void AddTournament(Tournament tournament)
    {
        i_tournaments.Add(tournament);
    }

    public List<Tournament> GetTournaments()
    {
        return i_tournaments;
    }

    public int GetCircuitId()
    {
        return i_id;
    }
}

public class Match : StatusManager
{
    public Match() { }
}

public class Tournament : StatusManager
{
    private int i_nbTurn;
    private bool m_is_major;
    private List<Match> m_matches;
    private string i_name;

    public Tournament(int nbTurn, bool is_major,string name)
    {
        i_nbTurn = nbTurn;
        m_is_major = is_major;
        m_matches = new List<Match>();
        i_name = name;
    }

    public void AddMatch(Match match)
    {
        m_matches.Add(match);
    }

    public List<Match> GetMatches()
    {
        return m_matches;
    }

    public int GetTurn()
    {
        return i_nbTurn;
    }

    public bool IsMajor()
    {
        return m_is_major;
    }
}