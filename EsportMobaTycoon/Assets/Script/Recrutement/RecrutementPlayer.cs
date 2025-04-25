using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RecrutementPlayer : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text i_nameText;
    public TMP_Text i_roleText;
    public TMP_Text i_characterText;
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
    public List<Player> i_allPlayersObejct;
    public List<PlayerData> i_allPlayers;
    public TeamData i_selectedTeam;
    private int i_currentIndex = 0;

    [Header("Anim")]
    public Animator i_teamAnimator;

    [Header("Image")]
    public List<Image> i_lvl;
    public List<Image> i_Potentiel;
    public List<Image> i_Mechanic;
    public List<Image> i_knowledge;
    public Sprite i_spriteStar;
    public Sprite i_spriteEmpty;


    void Start()
    {
        i_allPlayers = new List<PlayerData>(10);
        i_selectedTeam = GameManager.Instance.i_manager.i_teamData;

        for (int i = 0; i < 10; i++)
        {
            if (i < 2)
            {
                i_allPlayersObejct.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.ADC));
            }
            else if (i < 4)
            {
                i_allPlayersObejct.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.SUPPORT));
            }
            else if (i < 6)
            {
                i_allPlayersObejct.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.MIDLANER));
            }
            else if (i < 8)
            {
                i_allPlayersObejct.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.JUNGLER));
            }
            else if (i < 10)
            {
                i_allPlayersObejct.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.TOPLANER));
            }
            i_allPlayersObejct[i].transform.position = new Vector3(-0.2574105f + (i * i_allPlayersObejct[i].transform.localScale.x * 2), 1.29f, 0.7858481f);
            //i_allPlayers[i].SetFromPlayer(i_allPlayersObejct[i]);
            Debug.Log(i);
        }

        UpdateUI();
    }

    public void ScrollLeft()
    {
        i_currentIndex = (i_currentIndex - 1 + i_allPlayers.Count) % i_allPlayers.Count;
        UpdateUI();
    }

    public void ScrollRight()
    {
        if (i_allPlayers.Count > 0)
        {
            i_currentIndex = (i_currentIndex + 1) % i_allPlayers.Count;
        }
        UpdateUI();
    }

    public void AddToTeam()
    {
        Player selected = i_allPlayersObejct[i_currentIndex];
        Manager_Utilisateur manager = GameManager.Instance.i_manager;

        if (manager.TeamPlayers.Contains(selected))
        {
            Debug.Log("Ce joueur est dej�a dans l'equipe.");
            return;
        }

        if (manager.GetPlayerByRole(selected.i_currentRole) != null)
        {
            Debug.Log("Ce r�le est dej�a pris.");
            
            return;
        }

        if (manager.TeamPlayers.Count >= 5)
        {
            Debug.Log("L'equipe est complete.");
            return;
        }

        PlayerData playerData = new PlayerData();
        playerData.SetFromPlayer(selected);
        i_selectedTeam.i_players.Add(playerData);

        Debug.Log($"{selected.i_name} ajout�E�El'�quipe en tant que {selected.i_currentRole.ToString()}.");
        Transform rolePanel = GetPanelForRole(selected.i_currentRole);
        if (rolePanel != null)
        {
            GameObject slot = Instantiate(i_playerSlotPrefab, rolePanel);
            slot.GetComponentInChildren<TMP_Text>().text = selected.i_name;

            Button i_removeButton = slot.transform.Find("Remove").GetComponent<Button>();
            Button i_moveLeftButton = slot.transform.Find("MoveLeft").GetComponent<Button>();
            Button i_moveRightButton = slot.transform.Find("MoveRight").GetComponent<Button>();
            if (i_removeButton != null)
            {
                i_removeButton.onClick.AddListener(() => RemovePlayer(selected));
            }
            if (i_moveLeftButton != null)
            {
                i_moveLeftButton.onClick.AddListener(() => OnRoleChangeButtonClicked(selected, false));
            }

            if (i_moveRightButton != null)
            {
                i_moveRightButton.onClick.AddListener(() => OnRoleChangeButtonClicked(selected, true));
            }
        }

        PlayAddAnimation();

        UpdateUI();    
    }

    public void MovePlayerToAdjacentRole(Player player, bool moveRight)
    {
        Manager_Utilisateur manager = GameManager.Instance.i_manager;

        if (!manager.TeamPlayers.Contains(player))
        {
            Debug.Log("Le joueur n'est pas dans l'�quipe.");
            return;
        }

        GameManager.Role currentRole = player.i_currentRole;
        GameManager.Role newRole;
        if (moveRight)
            newRole = (Role)(((int)currentRole + 1) % 5);
        else
            newRole = (Role)(((int)currentRole - 1 + 5) % 5);

        Player playerAtNewRole = manager.GetPlayerByRole(newRole);

        if (playerAtNewRole != null)
        {
            playerAtNewRole.SetRole((GameManager.Role)currentRole);
            Debug.Log($"�change entre {player.i_name} et {playerAtNewRole.i_name}");
        }
        player.SetRole((GameManager.Role)newRole);

        UpdateUI();
    }

    public void OnRoleChangeButtonClicked(Player player, bool moveRight)
    {
        MovePlayerToAdjacentRole(player, moveRight);
    }

    public void RemovePlayer(Player player)
    {
        GameManager.Instance.i_manager.RemovePlayer(player);

        Debug.Log($"{player.i_name} a �t�Eretir�Ede l'�quipe.");

        UpdateUI();
    }

    public void OnRemoveButtonClicked(Player player)
    {
        RemovePlayer(player);
    }

    private void UpdateUI()
    {
        ClearRolePanels();

        foreach (Player player in GameManager.Instance.i_manager.TeamPlayers)
        {
            Transform rolePanel = GetPanelForRole(player.i_currentRole);
            if (rolePanel != null)
            {
                GameObject existingSlot = rolePanel.Find(player.i_name)?.gameObject;

                if (existingSlot == null)
                {
                    GameObject slot = Instantiate(i_playerSlotPrefab, rolePanel);
                    slot.GetComponentInChildren<TMP_Text>().text = player.i_name;

                    Button removeButton = slot.transform.Find("Remove").GetComponent<Button>();
                    Button moveLeftButton = slot.transform.Find("MoveLeft").GetComponent<Button>();
                    Button moveRightButton = slot.transform.Find("MoveRight").GetComponent<Button>();
                    if (removeButton != null)
                    {
                        removeButton.onClick.RemoveAllListeners();
                        removeButton.onClick.AddListener(() => RemovePlayer(player));
                    }
                    if (moveLeftButton != null)
                    {
                        moveLeftButton.onClick.RemoveAllListeners();
                        moveLeftButton.onClick.AddListener(() => OnRoleChangeButtonClicked(player, false));
                    }
                    if (moveRightButton != null)
                    {
                        moveRightButton.onClick.RemoveAllListeners();
                        moveRightButton.onClick.AddListener(() => OnRoleChangeButtonClicked(player, true));
                    }
                }
            }
        }

        Player currentPlayer = i_allPlayersObejct[i_currentIndex];
        i_nameText.text = $"Nom : " + currentPlayer.i_name;
        i_roleText.text = $"Role : " + currentPlayer.i_currentRole.ToString();
        i_characterText.text = $"Charactere : " + currentPlayer.i_characterId.i_name;
        i_countText.text = i_selectedTeam.i_players.Count.ToString() + $" / 5";
        InitStat(currentPlayer.i_lvl, currentPlayer.i_potentiel, currentPlayer.i_mechanic, currentPlayer.i_knowledge);
    }

    public void InitStat(int lvl, int potentiel, Mechanic mechanic, Knowledge knowledge)
    {
        CleanUp();

        int mecha = (mechanic.s_stamina.s_lvl + mechanic.s_reflexe.s_lvl) / 2;
        int know = (knowledge.s_teamFight.s_lvl + knowledge.s_objective.s_lvl + knowledge.s_placement.s_lvl) / 2;

        for (int i = 0; i < lvl; i++)
        {
            i_lvl[i].sprite = i_spriteStar;
        }

        for (int i = 0; i < potentiel; i++)
        {
            i_Potentiel[i].sprite = i_spriteStar;
        }

        for (int i = 0; i < mecha; i++)
        {
            i_Mechanic[i].sprite = i_spriteStar;
        }

        for (int i = 0; i < know; i++)
        {
            i_knowledge[i].sprite = i_spriteStar;
        }
    }

    public void CleanUp()
    {
        for (int i = 0; i < 5; i++)
        {
            i_lvl[i].sprite = i_spriteEmpty;
        }

        for (int i = 0; i < 5; i++)
        {
            i_Potentiel[i].sprite = i_spriteEmpty;
        }

        for (int i = 0; i < 5; i++)
        {
            i_Mechanic[i].sprite = i_spriteEmpty;
        }

        for (int i = 0; i < 5; i++)
        {
            i_knowledge[i].sprite = i_spriteEmpty;
        }
    }

    private void ClearRolePanels()
    {
        foreach (Transform child in i_topPanel)
        {
            if (child.gameObject.name != "MoveLeft" && child.gameObject.name != "Remove" && child.gameObject.name != "MoveRight")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in i_junglePanel)
        {
            if (child.gameObject.name != "MoveLeft" && child.gameObject.name != "Remove" && child.gameObject.name != "MoveRight")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in i_midPanel)
        {
            if (child.gameObject.name != "MoveLeft" && child.gameObject.name != "Remove" && child.gameObject.name != "MoveRight")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in i_adcPanel)
        {
            if (child.gameObject.name != "MoveLeft" && child.gameObject.name != "Remove" && child.gameObject.name != "MoveRight")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in i_supportPanel)
        {
            if (child.gameObject.name != "MoveLeft" && child.gameObject.name != "Remove" && child.gameObject.name != "MoveRight")
            {
                Destroy(child.gameObject);
            }
        }
    }

    private string GetRoleName(GameManager.Role role)
    {
        return role.ToString();
    }

    private Transform GetPanelForRole(GameManager.Role role)
    {
        switch (role)
        {
            case GameManager.Role.TOPLANER: return i_topPanel;
            case GameManager.Role.JUNGLER: return i_junglePanel;
            case GameManager.Role.MIDLANER: return i_midPanel;
            case GameManager.Role.SUPPORT: return i_supportPanel;
            case GameManager.Role.ADC: return i_adcPanel;
            default: return null;
        }
    }

    public void PlayAddAnimation()
    {
        i_teamAnimator.SetTrigger("isDown");
    }

}
