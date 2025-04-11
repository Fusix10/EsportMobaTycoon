using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusManager
{
    public class Tournament
    {
        private enum TournamentStatus
        {
            NotPlayed,
            Won,
            Lost
        }

        private DateTime m_date;

        private bool m_is_major;

        private List<Match> m_matches;

        private TournamentStatus m_status;

        public Tournament(DateTime date, bool is_major)
        {
            m_date = date;
            m_is_major = is_major;
            m_status = TournamentStatus.NotPlayed;

            m_matches = new List<Match>();
        }

        public void HasWon(bool win)
        {
            m_status = win ? TournamentStatus.Won : TournamentStatus.Lost;
        }

        public void AddMatch(Match match)
        {
            m_matches.Add(match);   
        }
        public List<Match> GetMatches()
        {
            return m_matches;
        }
        }

        public void HasWon(bool win)
        {
            m_status = win ? TournamentStatus.Won : TournamentStatus.Lost;
        }

        public void AddMatch(Match match)
        {
            m_matches.Add(match);   
        }
        public List<Match> GetMatches()
        {
            return m_matches;
        }
        }

        public void HasWon(bool win)
        {
            m_status = win ? TournamentStatus.Won : TournamentStatus.Lost;
        }

        public void AddMatch(Match match)
        {
            m_matches.Add(match);   
        }
        public List<Match> GetMatches()
        {
            return m_matches;
        }
        }

        public void HasWon(bool win)
        {
            m_status = win ? TournamentStatus.Won : TournamentStatus.Lost;
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

    public class Match
    {
        private enum MatchStatus
        {
            NotPlayed,
            Won,
            Lost
        }

        private MatchStatus m_status;

        public Match()
        {
            m_status = MatchStatus.NotPlayed;
        }

        public void HasWon(bool win)
        {
            m_status = win ? MatchStatus.Won : MatchStatus.Lost;
        }
    }

    private int id;
    private List<Tournament> m_tournaments;


    public Circuit(int circuitId)
    {
        id = circuitId;

        m_tournaments = new List<Tournament>();
    }

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
    public void AddTournament(Tournament tournament)
    {
        m_tournaments.Add(tournament);
    }

    public bool IsMajor()
    {
        return m_tournaments;
    }
}