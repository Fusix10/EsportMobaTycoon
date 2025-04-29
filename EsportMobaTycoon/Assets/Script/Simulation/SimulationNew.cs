using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SimulationNew : MonoBehaviour
{

    TeamData i_managerTeam;
    TeamData i_enemyTeam;

    List<Player> i_managerPlayer;
    List<Player> i_enemyPlayer;

    List<Match> i_matchList;
    int i_currentIdMatchList;

    void Start()
    {
        i_currentIdMatchList = 0;
        i_matchList = new List<Match>();
        i_managerTeam = GameManager.Instance.i_manager.i_teamData;

        i_managerPlayer = new List<Player>();
        i_enemyPlayer = new List<Player>();

        i_managerTeam.CreateAllPlayerFromNothing();

        for (int i = 0; i < 3; i++)
        {
            TeamData team = new TeamData();
            team.CreateAllPlayerFromNothing();
            i_matchList.Add(new(team));
        }

        ChooseCharacter(i_managerTeam);
        PassToPlayerObject(i_managerTeam, i_managerPlayer);
    }

    public void init(List<Match> matchList)
    {
        i_matchList = matchList;
    } 

    public void MatchUp()
    {
        if(i_currentIdMatchList < i_matchList.Count)
        {
            i_enemyTeam = i_matchList[i_currentIdMatchList].i_team;
            ChooseCharacter(i_enemyTeam);
            PassToPlayerObject(i_enemyTeam, i_enemyPlayer);
            ApplyLuck();
            Simulation();
            i_currentIdMatchList++;
        }
    }

    private void ChooseCharacter(TeamData team)
    {
        foreach(PlayerData player in team.i_players)
        {
            List<Character> characterList = new List<Character>();
            for(int i = 0; i < GameManager.Instance.i_allCharacters.Count; i++)
            {
                if (GameManager.Instance.i_allCharacters[i].i_roleId == (int)player.i_role)
                {
                    characterList.Add(GameManager.Instance.i_allCharacters[i]);
                }
            }
            player.i_characterId = characterList[Random.Range(0, characterList.Count)];
        }
    }

    private void PassToPlayerObject(TeamData team, List<Player> playerteam)
    {
        foreach (PlayerData player in team.i_players)
        {
            playerteam.Add(GameManager.Instance.i_playerFactory.CreatePlayerFromData(player));
        }
    }

    private void ApplyLuck()
    {
        for (int i = 0; i < 5; i++)
        {
            i_managerPlayer[i].ChangeLuck(i_enemyPlayer[i]);

            i_enemyPlayer[i].ChangeLuck(i_managerPlayer[i]);
        }
    }

    private void Simulation()
    {
        float luckEnemy = 0;
        float luckManager = 0;
        for (int i =0; i < i_enemyPlayer.Count; i++)
        {
            luckEnemy += i_enemyPlayer[i].i_totalLuck;
            luckManager += i_managerPlayer[i].i_totalLuck;
        }
        float totalLuckMatch = luckEnemy+luckManager;
        float LE = (luckEnemy * 100) / totalLuckMatch;
        float LM = (luckManager * 100) / totalLuckMatch;

        float random = Random.Range(0, 100.0f);

        if(random >= 0 && random <= LE)
        {
            Debug.Log("team Enemy win");
        }
        else if(random > LE && random <= LM+LE)
        {
            Debug.Log("team manager win");
        }
        else
        {
            Debug.Log("vasi tu soule");
        }

        for(int i = 0; i < i_enemyPlayer.Count; i++)
        {
            Destroy(i_enemyPlayer[i].gameObject);
        }
        i_enemyPlayer = new();
        i_enemyTeam = new();
    }
}
