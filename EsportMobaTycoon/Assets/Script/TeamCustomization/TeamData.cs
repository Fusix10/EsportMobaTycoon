using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamData", menuName = "TeamData")]
public class TeamData : ScriptableObject
{

    public string i_name;
    public string i_nickName;
    public Sprite i_LogoBack;
    public Sprite i_LogoCrown;
    public Sprite i_Logo;

    List<Player> i_players;

    public List<Player> GetTeam()
    {
        return i_players;
    }

    public void AddPlayer(Player player)
    {
        if(i_players.Count < 5)
        {
            i_players.Add(player);
        }
        else
        {
            Debug.LogError("Too Many Player");
        }
    }

    public void AddAllPlayer(List<Player> players)
    {
        if (i_players.Count + players.Count <= 5)
        {
            for (int i = 0; i < players.Count; i++)
            {
                i_players.Add(players[i]);
            }
        }
        else
        {
            Debug.LogError("Too Many Player");
        }
    }

    public void DelPlayer(int id)
    {
        if (i_players.Count > 0 && i_players.Count >= id)
        {
            i_players.RemoveAt(id);
        }
        else
        {
            Debug.LogError("no Player Left or Player Id not found");
        }
    }

    public void DelMulPlayer(List<int> ids)
    {
        for(int i = 0;i < ids.Count; i++)
        {
            if (i_players.Count > 0 && i_players.Count >= ids[i])
            {
                i_players.RemoveAt(ids[i]);
            }
            else
            {
                Debug.LogError("no Player Left or Player Id not found");
            }
        }
    }

}
