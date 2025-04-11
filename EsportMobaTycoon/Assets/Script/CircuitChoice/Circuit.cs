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

    protected Status m_status;

    protected StatusManager()
    {
        m_status = Status.NotPlayed;
    }

    public void SetHasWon(bool win)
    {
        m_status = win ? Status.Won : Status.Lost;
    }

    public Status GetStatus()
    {
        return m_status;
    }
}

public class Circuit : StatusManager
{
    public class Tournament : StatusManager
    {
        private DateTime m_date;
        private bool m_is_major;
        private List<Match> m_matches;

        public Tournament(DateTime date, bool is_major)
        {
            m_date = date;
            m_is_major = is_major;
            m_matches = new List<Match>();
        }

        public void AddMatch(Match match)
        {
            m_matches.Add(match);
        }

        public List<Match> GetMatches()
        {
            return m_matches;
        }

        public DateTime GetDate()
        {
            return m_date;
        }

        public bool IsMajor()
        {
            return m_is_major;
        }
    }

    public class Match : StatusManager
    {
        public Match() { }
    }

    private int m_id;
    private List<Tournament> m_tournaments;

    public Circuit(int circuit_id)
    {
        m_id = circuit_id;
        m_tournaments = new List<Tournament>();
    }

    public void AddTournament(Tournament tournament)
    {
        m_tournaments.Add(tournament);
    }

    public List<Tournament> GetTournaments()
    {
        return m_tournaments;
    }

    public int GetCircuitId()
    {
        return m_id;
    }
}
