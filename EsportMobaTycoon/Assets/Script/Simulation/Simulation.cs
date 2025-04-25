using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Simulation : MonoBehaviour
{
    public PlayerFactory i_playerfactory;
    public TeamData i_teamRed;
    public TeamData i_teamBlue;
    public List<Match> i_match;
    int i_currentId;
    void Start()
    {
        i_currentId = 0;  
    }

    public void Init(List<Match> allMatch)
    {
        i_teamBlue = GameManager.Instance.i_manager.i_teamData;
        i_match = allMatch;
    }

    public void MatchMaking()
    {
        if (i_currentId >= i_match.Count)
        {
            Debug.LogWarning("All matches were simulated.");
            return;
        }

        TeamData redTeam = i_match[i_currentId].i_team;

        Draft(i_teamBlue, redTeam);
        Simulate(redTeam);
    }



    void Draft(TeamData managerTeam, TeamData otherTeam)
    {
        List<Character> selectedCharacters = new List<Character>();

        for (int i = 0; i < managerTeam.GetTeam().Count; i++)
        {
            Character bluePick = TryAssignCharacter(managerTeam.GetTeam()[i], selectedCharacters);
            if (bluePick != null)
            {
                managerTeam.GetTeam()[i].i_characterId = bluePick;
                selectedCharacters.Add(bluePick);
                Debug.Log($" {managerTeam.GetTeam()[i].i_name} drafted {bluePick.i_name}");
            }

            Character redPick = TryAssignCharacter(otherTeam.GetTeam()[i], selectedCharacters);
            if (redPick != null)
            {
                otherTeam.GetTeam()[i].i_characterId = redPick;
                selectedCharacters.Add(redPick);
                Debug.Log($" {otherTeam.GetTeam()[i].i_name} drafted {redPick.i_name}");
            }
        }

    }

    private Character TryAssignCharacter(PlayerData player, List<Character> alreadyPicked)
    {
        if (!alreadyPicked.Contains(player.i_favoriteCharacterId))
        {
            return player.i_favoriteCharacterId;
        }

        foreach (KeyValuePair<int, Lvl> kv in player.i_mechanic.s_lvlCombo)
        {
            if (!alreadyPicked.Contains(GameManager.Instance.i_allCharacters[kv.Key]))
            {
                Character validCharacter = GameManager.Instance.i_allCharacters[kv.Key];
                return validCharacter;
            }
        }
        Debug.LogWarning($" Aucun personnage disponible pour {player.i_name} (Role: {player.i_currentRole})");
        return null;
    }


    void Update()
    {
        
    }
    public void Simulate(TeamData ennemyTeam)
    {
        i_teamRed = ennemyTeam;
        List<Player> red = new List<Player>();
        List<Player> blue = new List<Player>();
        for(int i = 0; i < 5; i++)
        {
            blue.Add(i_playerfactory.CreatePlayerFromData(i_teamBlue.GetTeam()[i]));
            red.Add(i_playerfactory.CreatePlayerFromData(i_teamRed.GetTeam()[i]));
        }
        float blueSum = 0;
        float redSum = 0;
        for (int i = 0; i < i_teamRed.GetTeam().Count; i++)
        {
            for (int j = 0; j < i_teamBlue.GetTeam().Count; j++)
            {
                if (blue[i].i_currentRole == red[j].i_currentRole)
                {
                    blue[i].ChangeLuck(red[j]);
                }
                if (blue[j].i_currentRole == red[i].i_currentRole)
                {
                    red[i].ChangeLuck(blue[j]);
                }
            }
        }
        for (int i = 0; i < i_teamRed.GetTeam().Count; i++)
        {
            blueSum += i_teamBlue.GetTeam()[i].i_totalLuck;
            redSum += i_teamRed.GetTeam()[i].i_totalLuck;
        }
        float totalsum = blueSum + redSum;
        IsWinning(((blueSum / totalsum) * 100), (redSum / totalsum) * 100);
        if(i_currentId == i_match.Count-1)
        {
            i_currentId = 0;
        }
        i_currentId++;
    }

    void AddStatsLoser(TeamData team,PlayerData player,int kills, int deaths, int assists)
    {
        Debug.Log("The player" + player.i_name + " in the team " + team.i_name + "has done" + kills + " kills, " + deaths + " deaths and " + assists + "assists");
    }
    void AddStatsWinner(TeamData team,PlayerData player, int kills, int deaths, int assists)
    {
        Debug.Log("The player" + player.i_name + " in the team " + team.i_name + "has done" + kills + " kills, " + deaths + " deaths and " + assists + "assists");
    }
    void IsWinning(float blue, float red)
    {
        float random = RoundValue(Random.Range(0.0f, 100.0f), 10.0f);
        float newBlue = RoundValue(blue, 10.0f);
        float newRed = RoundValue(red, 10.0f);
        if (newRed > newBlue)
        {
            if (random >= 0 && random < newBlue)
            {
                Debug.Log("Case 0 : Blue Win !" + " b : " + newBlue + " random : " + random + " r : " + newRed);
                for (int i = 0; i < i_teamBlue.GetTeam().Count; i++)
                {
                    AddStatsLoser(i_teamRed, i_teamRed.GetTeam()[i], Random.Range(0,6), Random.Range(6,12), Random.Range(1,10));
                    AddStatsWinner(i_teamBlue, i_teamBlue.GetTeam()[i], Random.Range(6, 15), Random.Range(0, 5), Random.Range(8, 20));
                }
            }
            else
            {
                Debug.Log("Case 1 : Red Win !" + " r : " + newRed + " random : " + random + " b : " + newBlue);
                for (int i = 0; i < i_teamBlue.GetTeam().Count; i++)
                {
                    AddStatsLoser(i_teamBlue, i_teamBlue.GetTeam()[i], Random.Range(0, 6), Random.Range(6, 12), Random.Range(1, 10));
                    AddStatsWinner(i_teamRed, i_teamRed.GetTeam()[i], Random.Range(6, 15), Random.Range(0, 5), Random.Range(8, 20));
                }
            }
        }
        else if (newRed < newBlue)
        {
            if (random >= 0 && random < newRed)
            {
                Debug.Log("Case 2 : Red Win !" + " r : " + newRed + " random : " + random + " b : " + newBlue);
                for (int i = 0; i < i_teamBlue.GetTeam().Count; i++)
                {
                    AddStatsLoser(i_teamBlue, i_teamBlue.GetTeam()[i], Random.Range(0, 6), Random.Range(6, 12), Random.Range(1, 10));
                    AddStatsWinner(i_teamRed, i_teamRed.GetTeam()[i], Random.Range(6, 15), Random.Range(0, 5), Random.Range(8, 20));
                }
            }
            else
            {
                Debug.Log("Case 3 : Blue Win !" + " b : " + newBlue + " random : " + random + " r : " + newRed);
                for (int i = 0; i < i_teamBlue.GetTeam().Count; i++)
                {
                    AddStatsLoser(i_teamRed, i_teamRed.GetTeam()[i], Random.Range(0, 6), Random.Range(6, 12), Random.Range(1, 10));
                    AddStatsWinner(i_teamBlue, i_teamBlue.GetTeam()[i], Random.Range(6, 15), Random.Range(0, 5), Random.Range(8, 20));
                }
            }
        }
        else
        {
            Debug.LogError("blue equal red");
        }
    }

    public float RoundValue(float num, float precision)
    {
        return Mathf.Floor(num * precision + 0.5f) / precision;
    }
}
