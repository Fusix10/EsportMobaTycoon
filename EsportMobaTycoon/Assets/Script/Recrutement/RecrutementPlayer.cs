using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RecrutementPlayer : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text i_nameText;
    public TMP_Text i_roleText;
    public TMP_Text i_countText;

    [Header("Role Panels")]
    public Transform i_topPanel;
    public Transform i_junglePanel;
    public Transform i_midPanel;
    public Transform i_adcPanel;
    public Transform i_supportPanel;
    public Transform i_PanelLevel;
    public Transform i_PanelPotential;

    public GameObject i_playerSlotPrefab;

    [Header("Player List")]
    public List<Player> i_allPlayers;
    public List<Player> i_selectedTeam = new List<Player>();

    private int i_currentIndex = 0;

    public Animator i_teamAnimator;

    public Sprite i_lvlImage1;
    public Sprite i_lvlImage2;
    public Sprite i_lvlImage3;
    public Sprite i_lvlImage4;
    public Sprite i_lvlImage5;

    public Sprite i_potentielImage1;
    public Sprite i_potentielImage2;
    public Sprite i_potentielImage3;
    public Sprite i_potentielImage4;
    public Sprite i_potentielImage5;

    void Start()
    {
        i_selectedTeam = GameManager.Instance.i_manager.TeamPlayers;
        i_allPlayers = GameManager.Instance.i_allPlayers;
        UpdateUI();
    }

    public void ScrollLeft()
    {
        i_currentIndex = (i_currentIndex - 1 + i_allPlayers.Count) % i_allPlayers.Count;
        UpdateUI();
    }

    public void ScrollRight()
    {
        i_currentIndex = (i_currentIndex + 1) % i_allPlayers.Count;
        UpdateUI();
    }

    public void AddToTeam()
    {
        Player i_selected = i_allPlayers[i_currentIndex];
        var i_manager = GameManager.Instance.i_manager;

        if (i_manager.TeamPlayers.Contains(i_selected))
        {
            Debug.Log("Ce joueur est déjà dans l'équipe.");
            return;
        }

        if (i_manager.GetPlayerByRole(i_selected.i_role) != null)
        {
            Debug.Log("Ce rôle est déjà pris.");
            return;
        }

        if (i_manager.TeamPlayers.Count >= 5)
        {
            Debug.Log("L'équipe est complète.");
            return;
        }

        i_manager.AddPlayer(i_selected);

        Transform i_rolePanel = GetPanelForRole(i_selected.i_role);
        if (i_rolePanel != null)
        {
            GameObject i_slot = Instantiate(i_playerSlotPrefab, i_rolePanel);
            i_slot.GetComponentInChildren<TMP_Text>().text = i_selected.i_name;

            Button i_removeButton = i_slot.transform.Find("Remove").GetComponent<Button>();
            Button i_moveLeftButton = i_slot.transform.Find("MoveLeft").GetComponent<Button>();
            Button i_moveRightButton = i_slot.transform.Find("MoveRight").GetComponent<Button>();
            if (i_removeButton != null)
            {
                i_removeButton.onClick.AddListener(() => RemovePlayer(i_selected));
            }
            if (i_moveLeftButton != null)
            {
                i_moveLeftButton.onClick.AddListener(() => OnRoleChangeButtonClicked(i_selected, false));
            }

            if (i_moveRightButton != null)
            {
                i_moveRightButton.onClick.AddListener(() => OnRoleChangeButtonClicked(i_selected, true));
            }
        }

        PlayAddAnimation();

        UpdateUI();
    }

    public void MovePlayerToNewRole(int i_newRole)
    {
        Player i_selected = i_allPlayers[i_currentIndex];
        var i_manager = GameManager.Instance.i_manager;

        if (i_manager.TeamPlayers.Contains(i_selected))
        {
            i_manager.MovePlayerToRole(i_selected, i_newRole);
            Debug.Log($"{i_selected.i_name} déplacé vers le rôle {GetRoleName(i_newRole)}");

            UpdateUI();
        }
        else
        {
            Debug.Log("Le joueur n'est pas dans l'équipe.");
        }
    }

    public void MovePlayerToAdjacentRole(Player i_player, bool i_moveRight)
    {
        var i_manager = GameManager.Instance.i_manager;

        if (!i_manager.TeamPlayers.Contains(i_player))
        {
            Debug.Log("Le joueur n'est pas dans l'équipe.");
            return;
        }

        int i_currentRole = i_player.i_role;
        int i_newRole;
        if (i_moveRight)
            i_newRole = (i_currentRole + 1) % 5;
        else
            i_newRole = (i_currentRole - 1 + 5) % 5;

        Player i_playerAtNewRole = i_manager.GetPlayerByRole(i_newRole);

        if (i_playerAtNewRole != null)
        {
            i_playerAtNewRole.SetRole(i_currentRole);
            Debug.Log($"Échange entre {i_player.i_name} et {i_playerAtNewRole.i_name}");
        }
        i_player.SetRole(i_newRole);

        UpdateUI();
    }

    public void OnRoleChangeButtonClicked(Player i_player, bool i_moveRight)
    {
        MovePlayerToAdjacentRole(i_player, i_moveRight);
    }

    public void RemovePlayer(Player i_player)
    {
        GameManager.Instance.i_manager.RemovePlayer(i_player);

        Debug.Log($"{i_player.i_name} a été retiré de l'équipe.");

        UpdateUI();
    }

    public void OnRemoveButtonClicked(Player i_player)
    {
        RemovePlayer(i_player);
    }

    private void UpdateUI()
    {
        ClearRolePanels();

        foreach (var i_player in GameManager.Instance.i_manager.TeamPlayers)
        {
            Transform i_rolePanel = GetPanelForRole(i_player.i_role);
            if (i_rolePanel != null)
            {
                GameObject i_existingSlot = i_rolePanel.Find(i_player.i_name)?.gameObject;

                if (i_existingSlot == null)
                {
                    GameObject i_slot = Instantiate(i_playerSlotPrefab, i_rolePanel);
                    i_slot.GetComponentInChildren<TMP_Text>().text = i_player.i_name;

                    Button i_removeButton = i_slot.transform.Find("Remove").GetComponent<Button>();
                    Button i_moveLeftButton = i_slot.transform.Find("MoveLeft").GetComponent<Button>();
                    Button i_moveRightButton = i_slot.transform.Find("MoveRight").GetComponent<Button>();
                    if (i_removeButton != null)
                    {
                        i_removeButton.onClick.RemoveAllListeners();
                        i_removeButton.onClick.AddListener(() => RemovePlayer(i_player));
                    }
                    if (i_moveLeftButton != null)
                    {
                        i_moveLeftButton.onClick.RemoveAllListeners();
                        i_moveLeftButton.onClick.AddListener(() => OnRoleChangeButtonClicked(i_player, false));
                    }

                    if (i_moveRightButton != null)
                    {
                        i_moveRightButton.onClick.RemoveAllListeners();
                        i_moveRightButton.onClick.AddListener(() => OnRoleChangeButtonClicked(i_player, true));
                    }
                }
            }
        }

        Player i_currentPlayer = i_allPlayers[i_currentIndex];
        i_nameText.text = i_currentPlayer.i_name;
        i_roleText.text = GetRoleName(i_currentPlayer.i_role);
        i_countText.text = i_selectedTeam.Count.ToString() + $" / 5";

        for (int i = 0; i < i_allPlayers.Count; i++)
        {
            UpdateLevelAndPotentialImages(i_allPlayers[i], i);
        }
    }

    private void UpdateLevelAndPotentialImages(Player i_player, int playerIndex)
    {
        Transform i_lvlPanelInList = i_PanelLevel.GetChild(playerIndex); 
        Transform i_potentielPanelInList = i_PanelPotential.GetChild(playerIndex);

        // Mise à jour de l'image de niveau
        if (i_PanelLevel != null)
        {
            Image i_lvlImageInPanel = i_PanelLevel.Find("LvlImage")?.GetComponent<Image>();
            if (i_lvlImageInPanel != null)
            {
                i_lvlImageInPanel.sprite = GetLevelImage(i_player.i_lvl);
            }
        }

        // Mise à jour de l'image de potentiel
        if (i_PanelPotential != null)
        {
            Image i_potentielImageInPanel = i_PanelPotential.Find("PotentielImage")?.GetComponent<Image>();
            if (i_potentielImageInPanel != null)
            {
                i_potentielImageInPanel.sprite = GetPotentielImage(i_player.i_potentiel);
            }
        }
    }



    private void ClearRolePanels()
    {
        foreach (Transform i_child in i_topPanel)
        {
            if (i_child.gameObject.name != "Move" && i_child.gameObject.name != "Remove")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_junglePanel)
        {
            if (i_child.gameObject.name != "Move" && i_child.gameObject.name != "Remove")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_midPanel)
        {
            if (i_child.gameObject.name != "Move" && i_child.gameObject.name != "Remove")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_adcPanel)
        {
            if (i_child.gameObject.name != "Move" && i_child.gameObject.name != "Remove")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_supportPanel)
        {
            if (i_child.gameObject.name != "Move" && i_child.gameObject.name != "Remove")
            {
                Destroy(i_child.gameObject);
            }
        }
    }

    private string GetRoleName(int i_roleId)
    {
        switch (i_roleId)
        {
            case 0: return "Top";
            case 1: return "Jungle";
            case 2: return "Mid";
            case 3: return "Support";
            case 4: return "Adc";
            default: return "Inconnu";
        }
    }

    private Transform GetPanelForRole(int i_roleId)
    {
        switch (i_roleId)
        {
            case 0: return i_topPanel;
            case 1: return i_junglePanel;
            case 2: return i_midPanel;
            case 3: return i_supportPanel;
            case 4: return i_adcPanel;
            default: return null;
        }
    }


    private Sprite GetLevelImage(int lvl)
    {
        switch (lvl)
        {
            case 1: return i_lvlImage1; 
            case 2: return i_lvlImage2; 
            case 3: return i_lvlImage3; 
            case 4: return i_lvlImage4; 
            case 5: return i_lvlImage5;
            default: return null;
        }
    }

    private Sprite GetPotentielImage(int potentiel)
    {
        switch (potentiel)
        {
            case 1: return i_potentielImage1; 
            case 2: return i_potentielImage2; 
            case 3: return i_potentielImage3; 
            case 4: return i_potentielImage4; 
            case 5: return i_potentielImage5;
            default: return null;
        }
    }

    public void PlayAddAnimation()
    {
        i_teamAnimator.SetTrigger("isDown");
    }


}
