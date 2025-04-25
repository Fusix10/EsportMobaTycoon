using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamData", menuName = "TeamData")]
public class TeamData : ScriptableObject
{
    [Header("Infos generales")]
    public string i_name;
    public string i_nickName;

    [Header("Logos (Sprites)")]
    public Sprite i_LogoBack;
    public Sprite i_LogoCrown;
    public Sprite i_Logo;

    [Header("Couleurs des logos")]
    public Color i_LogoBackColor = Color.white;
    public Color i_LogoCrownColor = Color.white;
    public Color i_LogoMainColor = Color.white;

    public List<PlayerData> i_players;

    public List<PlayerData> GetTeam()
    {
        return i_players;
    }

    public void AddPlayer(PlayerData player)
    {
        if (i_players.Count < 5)
        {
            i_players.Add(player);
        }
        else
        {
            Debug.LogError("Too Many Player");
        }
    }

    public void AddAllPlayer(List<PlayerData> players)
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
        for (int i = 0; i < ids.Count; i++)
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

    public void CreateAllPlayerFromNothing(int potentiel = 0)
    {
        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.ADC, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.SUPPORT, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.MIDLANER, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.JUNGLER, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.TOPLANER, potentiel));
    }
}
