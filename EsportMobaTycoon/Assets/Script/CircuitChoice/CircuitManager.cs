using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    List<string> tournamentName = new List<string>() {
    "Summoner's Clash",
    "Nexus Arena",
    "Baron Brawl",
    "League Masters Cup",
    "Void Rift Invitational",
    "Elder Drake Showdown",
    "Runeterra Rivals",
    "The Hextech Championship",
    "Demacia Duel",
    "Shadow Isles Series",
    "ARAM Elite Series",
    "The Rift Showdown",
    "Laning Legends",
    "Final Nexus",
    "Clash of Regions",
    "Freljord Frost Cup",
    "The Challenger Gauntlet",
    "Dragon Soul Tournament",
    "Pentakill Pro League",
    "Hexgate Cup",
    "Wild Rift Warriors",
    "Blue Buff Bash",
    "Legends Never Die Series",
    "The Ranked Royale",
    "SummonerÅfs Crown"
    };
    public void Generate()
    {
        List<Tournament> tournaments = new();
        CircuitDifficulty circuitDifficulty = new();

        if (GameManager.Instance.i_manager.i_reputation < 10000)
        {
            circuitDifficulty = CircuitDifficulty.Easy;
        }
        else if (GameManager.Instance.i_manager.i_reputation > 10000 && GameManager.Instance.i_manager.i_reputation < 100000)
        {
            circuitDifficulty = CircuitDifficulty.Normal;
        }
        else if (GameManager.Instance.i_manager.i_reputation > 100000)
        {
            circuitDifficulty = CircuitDifficulty.Hard;
        }
        int tournamentCount = 3;
        for (int i = 0; i < tournamentCount; i++)
        {
            List<Match> matches = new();
            int matchCount = Random.Range(2, 5);
            for (int j = 0; j < matchCount; j++)
            {
                TeamData teamData = new TeamData();
                switch (circuitDifficulty)
                {
                    case CircuitDifficulty.Easy:
                        teamData.CreateAllPlayerFromNothing(Random.Range(1, 3));
                        break;
                    case CircuitDifficulty.Normal:
                        teamData.CreateAllPlayerFromNothing(Random.Range(2, 5));
                        break;
                    case CircuitDifficulty.Hard:
                        teamData.CreateAllPlayerFromNothing(5);
                        break;
                }
                GameManager.Instance.i_allTeam.Add(teamData);
                matches.Add(new(teamData));
            }

            int offset = i * 60;
            tournaments.Add(new(Random.Range(offset + 30, offset + 50), matches, tournamentName[Random.Range(0, (tournamentName.Count-1))]));
        }
        GameManager.Instance.i_circuit = new(tournaments, circuitDifficulty);
    }
}

public enum CircuitDifficulty
{
    Easy,
    Normal,
    Hard
}

public class Circuit
{
    public List<Tournament> i_tournaments;
    public CircuitDifficulty i_difficulty;

    public Circuit(List<Tournament> tournaments, CircuitDifficulty difficulty)
    {
        this.i_tournaments = tournaments;
        this.i_difficulty = difficulty;
    }
}

public class Tournament
{
    public List<Match> i_matches;
    public string i_name;
    public int i_time;
    
    public Tournament(int time, List<Match> matches, string name)
    {
        i_name = name;
        i_time = time;
        ActionCircuit actionCircuit = new ActionCircuit();
        actionCircuit.setTimer(time);
        this.i_matches = matches;
        actionCircuit.InitAcion(matches);
        GameManager.Instance.AddAction(actionCircuit);
    }
}

public class Match
{
    public TeamData i_team;

    public Match(TeamData team)
    {
        this.i_team = team;
    }
}
