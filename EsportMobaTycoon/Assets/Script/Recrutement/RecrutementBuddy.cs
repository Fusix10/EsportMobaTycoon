using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecrutementBuddy : MonoBehaviour
{
    [SerializeField] int i_BuddyCount;

    [SerializeField] TMP_InputField i_PseudoInput;


    [Header("UI Elements")]
    [SerializeField] TMP_Text i_nameText;
    [SerializeField] TMP_Text i_roleText;
    [SerializeField] TMP_Text i_characterPlayText;
    [SerializeField] CharacterSkin i_skinUI;


    [SerializeField] Sprite i_circle;
    [SerializeField] Sprite i_fillCircle;

    List<Player> i_allPlayers;

    [Header("Stats List")]
    [SerializeField] List<Image> i_lvl;
    [SerializeField] List<Image> i_Potentiel;
    [SerializeField] List<Image> i_Mechanic;
    [SerializeField] List<Image> i_knowledge;

    int i_currentIndex;


    void Start()
    {
        i_allPlayers = new List<Player>();
        for (int i = 0; i < i_BuddyCount; i++)
        {
            Player localBud = GameManager.Instance.i_playerFactory.CreateRandomPlayerWithRole((GameManager.Role)Random.Range(0, 5), 0, null, false, true);
            
            
            i_allPlayers.Add(localBud);
            GameManager.Instance.i_allPlayers.Add(localBud);
        }

        UpdateUI();
    }

    public void NextCharacter()
    {
        i_currentIndex += 1;
        i_currentIndex %= i_allPlayers.Count;

        UpdateUI();
    }

    public void PreviousCharacter()
    {
        i_currentIndex -= 1;
        i_currentIndex += i_allPlayers.Count % i_allPlayers.Count;

        UpdateUI();
    }

    public void UpdateUI()
    {

        Player i_currentPlayer = i_allPlayers[i_currentIndex];

        i_skinUI.SetSkin(i_currentPlayer.i_skin);
        i_nameText.text = i_currentPlayer.i_name;
        i_roleText.text = i_currentPlayer.i_currentRole.ToString();
        i_characterPlayText.text = i_currentPlayer.i_favoriteCharacterId.i_name;
        InitStat(i_currentPlayer.i_lvl, i_currentPlayer.i_potentiel, i_currentPlayer.i_mechanic, i_currentPlayer.i_knowledge);
    }

    public void InitStat(int lvl, int potentiel, Mechanic mechanic, Knowledge knowledge)
    {
        int mecha = (mechanic.s_stamina.s_lvl + mechanic.s_reflexe.s_lvl) / 2;
        int know = (knowledge.s_teamFight.s_lvl + knowledge.s_objective.s_lvl + knowledge.s_placement.s_lvl) / 2;

        for (int i = 0; i < 5; i++) i_lvl[i].sprite = i < lvl ? i_fillCircle : i_circle;

        for (int i = 0; i < 5; i++) i_Potentiel[i].sprite = i < potentiel ? i_fillCircle : i_circle;

        for (int i = 0; i < 5; i++) i_Mechanic[i].sprite = i < mecha ? i_fillCircle : i_circle;

        for (int i = 0; i < 5; i++) i_knowledge[i].sprite = i < know ? i_fillCircle : i_circle;
    }

    public void NameInput()
    {
        //i_allPlayers[i_currentIndex].i_name = i_PseudoInput.text;
        i_nameText.text = i_PseudoInput.text;
    }

    public Player GetBuddy()
    {
        return i_allPlayers[i_currentIndex];
    }
}
