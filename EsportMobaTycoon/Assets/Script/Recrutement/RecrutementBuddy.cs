using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RecrutementBuddy : MonoBehaviour
{
    [SerializeField] List<Sprite> i_BuddySprite;

    [SerializeField] UnputFieldGrabber PseudoInput;

    [SerializeField] Buddy PrefabBuddy;


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

    public List<Image> i_lvl;
    public List<Image> i_Potentiel;
    public List<Image> i_Mechanic;
    public List<Image> i_knowledge;


    void Start()
    {

        i_selectedTeam = GameManager.Instance.i_manager.TeamPlayers;

        foreach (Sprite sprite in i_BuddySprite)
        {
            Buddy localBud = Instantiate(PrefabBuddy);
            localBud.buddyCreate(sprite.name, sprite);
            i_allPlayers.Add(localBud);
            GameManager.Instance.i_allPlayers.Add(localBud);
        }

        //for (int i = 0; i < 10; i++)
        //{
        //    if (i < 2)
        //    {
        //        i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.ADC));
        //    }
        //    else if (i < 4)
        //    {
        //        i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.SUPPORT));
        //    }
        //    else if (i < 6)
        //    {
        //        i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.MIDLANER));
        //    }
        //    else if (i < 8)
        //    {
        //        i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.JUNGLER));
        //    }
        //    else if (i < 10)
        //    {
        //        i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerWithRole(GameManager.Role.TOPLANER));
        //    }
        //    i_allPlayers[i].transform.position = new Vector3(-0.2574105f + (i * i_allPlayers[i].transform.localScale.x * 2), 1.29f, 0.7858481f);
        //    GameManager.Instance.i_allPlayers.Add(i_allPlayers[i]);
        //    Debug.Log(i);
        //}

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
        Player i_selected = i_allPlayers[i_currentIndex];
        i_selected.name = PseudoInput.getInputText(); //new
        Manager_Utilisateur i_manager = GameManager.Instance.i_manager;

        if (i_manager.TeamPlayers.Contains(i_selected))
        {
            Debug.Log("Ce joueur est dejÅa dans l'equipe.");
            return;
        }

        if (i_manager.GetPlayerByRole(i_selected.i_currentRole) != null)
        {
            Debug.Log("Ce rÙle est dejÅa pris.");

            return;
        }

        if (i_manager.TeamPlayers.Count >= 5)
        {
            Debug.Log("L'equipe est complete.");
            return;
        }

        i_selectedTeam.Add(i_selected);
        Debug.Log($"{i_selected.i_name} ajoutÔøΩEÔøΩEl'ÔøΩquipe en tant que {i_selected.i_currentRole.ToString()}.");
        Transform rolePanel = GetPanelForRole(i_selected.i_currentRole);
        if (rolePanel != null)
        {
            GameObject i_slot = Instantiate(i_playerSlotPrefab, rolePanel);
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
    public void MovePlayerToNewRole(Role newRole)
    {
        Player i_selected = i_allPlayers[i_currentIndex];
        var i_manager = GameManager.Instance.i_manager;

        if (i_manager.TeamPlayers.Contains(i_selected))
        {
            i_manager.MovePlayerToRole(i_selected, newRole);
            Debug.Log($"{i_selected.i_name} dÈplacÅEvers le rÙle {GetRoleName(newRole)}");

            UpdateUI();
        }
        else
        {
            Debug.Log("Le joueur n'est pas dans l'Èquipe.");
        }
    }
    public void MovePlayerToAdjacentRole(Player i_player, bool i_moveRight)
    {
        Manager_Utilisateur i_manager = GameManager.Instance.i_manager;

        if (!i_manager.TeamPlayers.Contains(i_player))
        {
            Debug.Log("Le joueur n'est pas dans l'ÔøΩquipe.");
            return;
        }

        GameManager.Role i_currentRole = i_player.i_currentRole;
        GameManager.Role i_newRole;
        if (i_moveRight)
            i_newRole = (Role)(((int)i_currentRole + 1) % 5);
        else
            i_newRole = (Role)(((int)i_currentRole - 1 + 5) % 5);

        Player i_playerAtNewRole = i_manager.GetPlayerByRole(i_newRole);

        if (i_playerAtNewRole != null)
        {
            i_playerAtNewRole.SetRole((GameManager.Role)i_currentRole);
            Debug.Log($"…change entre {i_player.i_name} et {i_playerAtNewRole.i_name}");
        }
        i_player.SetRole((GameManager.Role)i_newRole);

        UpdateUI();
    }

    public void OnRoleChangeButtonClicked(Player i_player, bool i_moveRight)
    {
        MovePlayerToAdjacentRole(i_player, i_moveRight);
    }

    public void RemovePlayer(Player i_player)
    {
        GameManager.Instance.i_manager.RemovePlayer(i_player);

        Debug.Log($"{i_player.i_name} a ÈtÅEretirÅEde l'Èquipe.");

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
            Transform i_rolePanel = GetPanelForRole(i_player.i_currentRole);
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
        i_roleText.text = i_currentPlayer.i_currentRole.ToString();
        i_countText.text = i_selectedTeam.Count.ToString() + $" / 5";
        InitStat(i_currentPlayer.i_lvl, i_currentPlayer.i_potentiel, i_currentPlayer.i_mechanic, i_currentPlayer.i_knowledge);
    }

    public void InitStat(int lvl, int potentiel, Mechanic mechanic, Knowledge knowledge)
    {
        CleanUp();

        int mecha = (mechanic.s_stamina.s_lvl + mechanic.s_reflexe.s_lvl) / 2;
        int know = (knowledge.s_teamFight.s_lvl + knowledge.s_objective.s_lvl + knowledge.s_placement.s_lvl) / 2;

        for (int i = 0; i < lvl; i++)
        {
            i_lvl[i].color = Color.yellow;
        }

        for (int i = 0; i < potentiel; i++)
        {
            i_Potentiel[i].color = Color.yellow;
        }

        for (int i = 0; i < mecha; i++)
        {
            i_Mechanic[i].color = Color.yellow;
        }

        for (int i = 0; i < know; i++)
        {
            i_knowledge[i].color = Color.yellow;
        }
    }

    public void CleanUp()
    {
        for (int i = 0; i < 5; i++)
        {
            i_lvl[i].color = Color.white;
        }

        for (int i = 0; i < 5; i++)
        {
            i_Potentiel[i].color = Color.white;
        }

        for (int i = 0; i < 5; i++)
        {
            i_Mechanic[i].color = Color.white;
        }

        for (int i = 0; i < 5; i++)
        {
            i_knowledge[i].color = Color.white;
        }
    }

    private void ClearRolePanels()
    {
        foreach (Transform i_child in i_topPanel)
        {
            if (i_child.gameObject.name != "MoveLeft" && i_child.gameObject.name != "Remove" && i_child.gameObject.name != "MoveRight")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_junglePanel)
        {
            if (i_child.gameObject.name != "MoveLeft" && i_child.gameObject.name != "Remove" && i_child.gameObject.name != "MoveRight")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_midPanel)
        {
            if (i_child.gameObject.name != "MoveLeft" && i_child.gameObject.name != "Remove" && i_child.gameObject.name != "MoveRight")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_adcPanel)
        {
            if (i_child.gameObject.name != "MoveLeft" && i_child.gameObject.name != "Remove" && i_child.gameObject.name != "MoveRight")
            {
                Destroy(i_child.gameObject);
            }
        }

        foreach (Transform i_child in i_supportPanel)
        {
            if (i_child.gameObject.name != "MoveLeft" && i_child.gameObject.name != "Remove" && i_child.gameObject.name != "MoveRight")
            {
                Destroy(i_child.gameObject);
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
