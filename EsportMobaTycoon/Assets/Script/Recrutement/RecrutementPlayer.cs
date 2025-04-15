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

    [Header("Role Panels")]
    public Transform topPanel;
    public Transform junglePanel;
    public Transform midPanel;
    public Transform adcPanel;
    public Transform supportPanel;

    public GameObject playerSlotPrefab;

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

        if (selectedTeam.Contains(selected))
        {
            Debug.Log("Ce joueur est dÈjÅEdans l'Èquipe.");
            return;
        }

        if (selectedTeam.Count >= 4)
        {
            Debug.Log("L'Èquipe est complËte.");
            return;
        }

        selectedTeam.Add(selected);
        Debug.Log($"{selected.i_name} ajoutÅEÅEl'Èquipe en tant que {GetRoleName((int)(selected.i_currentRole))}.");

        // CrÈe une UI dans le bon panel
        Transform rolePanel = GetPanelForRole((int)selected.i_currentRole);
        if (rolePanel != null)
        {
            GameObject slot = Instantiate(playerSlotPrefab, rolePanel);
            slot.GetComponentInChildren<TMP_Text>().text = selected.i_name;
        }

        UpdateUI();
    }


    private void UpdateUI()
    {
        if (allPlayers.Count == 0) return;

        Player currentPlayer = allPlayers[currentIndex];

        nameText.text = currentPlayer.i_name;
        roleText.text = GetRoleName((int)currentPlayer.i_role);
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

    private Transform GetPanelForRole(int roleId)
    {
        switch (roleId)
        {
            case 0: return topPanel;
            case 1: return supportPanel;
            case 2: return adcPanel;
            case 3: return midPanel;
            case 4: return junglePanel;
            default: return null;
        }
    }

}
