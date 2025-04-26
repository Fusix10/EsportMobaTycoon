using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Utilisateur
{
    //Stats dans manager
    public float i_currentMoney = 1000;//
    public float i_currentMoneyPrenium = 1000;//
    public int i_reputation = 0;//
    private List<Player> teamPlayers = new ();//

    public Budget budget;

    private Dictionary<GameManager.Role, Player> teamPlayersByRole = new();

    //Avatar Data 
    public string i_lastName;
    public string i_name;

    public Sprite i_hair;
    public Sprite i_face;
    public Sprite i_Torso;
    public Sprite i_legs;

    public bool i_isGenderMale; //true female false male 



    //my team Data 
    [SerializeField] public TeamData i_teamData;

    public void init(string name, string lastName, Sprite hair, Sprite face, Sprite torso, Sprite legs, bool isGenderXX)
    {
        i_lastName = lastName;
        i_name = name;
        i_hair = hair;
        i_face = face;
        i_Torso = torso;
        i_legs = legs;
        i_isGenderMale = isGenderXX;
    }

    public void TeamInit(string teamName, string teamNickName, Sprite logoFront, Sprite logoBack)
    {
        i_teamData.i_name = teamName;
        i_teamData.i_nickName = teamNickName;
    }

    /*public void AjouterPopularite(int points)
    {
        popularite += points;
        while (popularite >= seuilPourNiveauSuivant)
        {
            popularite -= seuilPourNiveauSuivant;
            niveauPopularite++;
            seuilPourNiveauSuivant *= 2; //le seuil double �Echaque niveau ? ou on change
        }
    }*/

   /* public void RetirerPopularite(int points)
    {
        popularite -= points;
        if (popularite < 0)
        {
            popularite = 0;
        }
    }*/

    public void AddPlayer(Player player)
    {
        if (teamPlayers.Count < 5 && !teamPlayers.Contains(player))
        {
            teamPlayers.Add(player);
            if (!teamPlayersByRole.ContainsKey(player.i_role))
            {
                teamPlayersByRole[player.i_role] = player;
            }

            Debug.Log(teamPlayers.Count);
        }
    }

    public List<Player> GetPlayer()
    {
        return teamPlayers;
    }

    public void RemovePlayer(Player player)
    {
        if (teamPlayers.Contains(player))
        {
            teamPlayers.Remove(player);

            if (teamPlayersByRole.ContainsKey(player.i_role) && teamPlayersByRole[player.i_role] == player)
            {
                teamPlayersByRole.Remove(player.i_role);
            }
        }
    }

    public void MovePlayerToRole(Player player, GameManager.Role newRole)
    {
        if (!teamPlayers.Contains(player)) return;

        if (teamPlayersByRole.ContainsKey(player.i_role) && teamPlayersByRole[player.i_role] == player)
            teamPlayersByRole.Remove(player.i_role);

        player.SetRole((GameManager.Role)newRole);
        teamPlayersByRole[newRole] = player;
    }

    void AcheterItem(int cost)
    {
        if (budget.AcheterObjet(cost))
        {
            //l'achat a �t�Er�alis�E ajouter alors l'item �El'inventaire
        }
        else
        {
            //g�rer le cas d'�chec (fonds insuffisants).
        }
    }

    public List<Player> TeamPlayers
    {
        get { return teamPlayers; }
    }

    public Player GetPlayerByRole(GameManager.Role role)
    {
        foreach (var player in teamPlayers)
        {
            if (player.i_currentRole == (GameManager.Role)role)
                return player;
        }
        return null;
    }
}