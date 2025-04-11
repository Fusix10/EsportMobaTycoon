using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecrutementPlayer : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text nameText;
    public TMP_Text roleText;

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
        selectedTeam = GameManager.Instance.i_manager.TeamPlayers;
        allPlayers = GameManager.Instance.i_allPlayers;
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
        var manager = GameManager.Instance.i_manager;

        if (manager.TeamPlayers.Contains(selected))
        {
            Debug.Log("Ce joueur est déjà dans l'équipe.");
            return;
        }

        if (manager.TeamPlayers.Count >= 5)
        {
            Debug.Log("L'équipe est complète.");
            return;
        }

        manager.AddPlayer(selected);

        Transform rolePanel = GetPanelForRole(selected.i_role);
        if (rolePanel != null)
        {
            GameObject slot = Instantiate(playerSlotPrefab, rolePanel);
            slot.GetComponentInChildren<TMP_Text>().text = selected.i_name;

            Button removeButton = slot.GetComponentInChildren<Button>();
            if (removeButton != null)
            {
                removeButton.onClick.AddListener(() => RemovePlayer(selected));
            }
        }

        UpdateUI();
    }


    public void MovePlayerToNewRole(int newRole)
    {
        Player selected = allPlayers[currentIndex];
        var manager = GameManager.Instance.i_manager;

        if (manager.TeamPlayers.Contains(selected))
        {
            manager.MovePlayerToRole(selected, newRole); 
            Debug.Log($"{selected.i_name} déplacé vers le rôle {GetRoleName(newRole)}");

            UpdateUI(); 
        }
        else
        {
            Debug.Log("Le joueur n'est pas dans l'équipe.");
        }
    }

    public void OnRoleChangeButtonClicked(int newRole)
    {
        MovePlayerToNewRole(newRole);
    }

    public void RemovePlayerFromTeam()
    {
        Player selected = allPlayers[currentIndex];
        var manager = GameManager.Instance.i_manager;

        if (manager.TeamPlayers.Contains(selected))
        {
            manager.RemovePlayer(selected); 
            Debug.Log($"{selected.i_name} a été retiré de l'équipe.");

            UpdateUI();
        }
        else
        {
            Debug.Log("Le joueur n'est pas dans l'équipe.");
        }
    }

    public void OnRemoveButtonClicked(Player player)
    {
        RemovePlayer(player);
    }

    public void RemovePlayer(Player player)
    {
        GameManager.Instance.i_manager.TeamPlayers.Remove(player);

        Debug.Log($"{player.i_name} a été retiré de l'équipe.");

        UpdateUI(); 
    }

    private void UpdateUI()
    {
        ClearRolePanels();

        foreach (var player in GameManager.Instance.i_manager.TeamPlayers)
        {
            Transform rolePanel = GetPanelForRole(player.i_role);
            if (rolePanel != null)
            {
                GameObject existingSlot = rolePanel.Find(player.i_name)?.gameObject;

                if (existingSlot == null)
                {
                    GameObject slot = Instantiate(playerSlotPrefab, rolePanel);
                    slot.GetComponentInChildren<TMP_Text>().text = player.i_name;

                    Button removeButton = slot.GetComponentInChildren<Button>();
                    if (removeButton != null)
                    {
                        removeButton.onClick.RemoveAllListeners();
                        removeButton.onClick.AddListener(() => RemovePlayer(player));
                    }
                }
            }
        }
        Player currentPlayer = allPlayers[currentIndex];
        nameText.text = currentPlayer.i_name;
        roleText.text = GetRoleName(currentPlayer.i_role);
    }


    private void ClearRolePanels()
    {
        foreach (Transform child in topPanel)
        {
            if (child.gameObject.name != "RemoveButton" && child.gameObject.name != "Remove")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in junglePanel)
        {
            if (child.gameObject.name != "RemoveButton" && child.gameObject.name != "Remove")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in midPanel)
        {
            if (child.gameObject.name != "RemoveButton" && child.gameObject.name != "Remove")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in adcPanel)
        {
            if (child.gameObject.name != "RemoveButton" && child.gameObject.name != "Remove")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in supportPanel)
        {
            if (child.gameObject.name != "RemoveButton" && child.gameObject.name != "Remove")
            {
                Destroy(child.gameObject);
            }
        }
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
