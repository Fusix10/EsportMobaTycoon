using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournament
{
    private enum TournamentStatus
    {
        NotPlayed,
        Won,
        Lost
    }

    private string i_name;

    private TimeSystem i_timeSystem;

    private bool i_is_major;

    private List<Match> i_matches;

    private TournamentStatus i_status;

    public Tournament(TimeSystem timeSystem, bool is_major, string name)
    {

        i_timeSystem = timeSystem;
        i_is_major = is_major;
        i_status = TournamentStatus.NotPlayed;

        i_matches = new List<Match>();
        i_name = name;
    }

    public void HasWon(bool win)
    {
        i_status = win ? TournamentStatus.Won : TournamentStatus.Lost;
    }

    public void AddMatch(Match match)
    {
        i_matches.Add(match);
    }
    public List<Match> GetMatches()
    {
        return i_matches;
    }

    public TimeSystem getTime()
    {
        return i_timeSystem; 
    }

    public bool IsMajor()
    {
        return i_is_major;
    }
}  
