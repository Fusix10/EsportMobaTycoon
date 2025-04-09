using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecrutementPlayer : MonoBehaviour
{
    [Header("UI Elements")]
    //public Image portraitImage;
    public TMP_Text nameText;
    public TMP_Text roleText;
    //public Image levelText;
    //public Image potentielText;

    [Header("Player List")]
    public PlayerFactory playerFactory;
    public List<Player> allPlayers;
    public List<Player> selectedTeam = new List<Player>();

    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < 6; i++) 
        {
            Player player = playerFactory.CreateRandomPlayer();
            allPlayers.Add(player);
        }
        UpdateUI();
    }

    public void ScrollLeft()
    {
        currentIndex = (currentIndex - 1 + allPlayers.Count) % allPlayers.Count;
        UpdateUI();
    }

    public void ScrollRight()
    {
        currentIndex = (currentIndex + 1) % allPlayers.Count;
        UpdateUI();
    }

    public void AddToTeam()
    {
        Player selected = allPlayers[currentIndex];
        if (!selectedTeam.Contains(selected))
        {
            selectedTeam.Add(selected);
            Debug.Log($"{selected.i_name} ajouté à l'équipe !");
        }
    }

    private void UpdateUI()
    {
        if (allPlayers.Count == 0) return;

        Player currentPlayer = allPlayers[currentIndex];

        nameText.text = currentPlayer.i_name;
        roleText.text = GetRoleName(currentPlayer.i_role);
    }

    private string GetRoleName(int roleId)
    {
        switch (roleId)
        {
            case 0: return "Top";
            case 1: return "Support";
            case 2: return "Adc";
            case 3: return "Mid";
            case 4: return "Jungle";
            default: return "Inconnu";
        }
    }
}
