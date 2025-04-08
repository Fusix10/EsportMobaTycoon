using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;
using static Player;

public class PlayerFactory : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField surnameInput;
    public TMP_Dropdown temperamentDropdown;
    public Slider luckSlider;
    public Slider moraleSlider;
    public Slider teamSpiritSlider;
    public Slider levelSlider;
    public Slider xpSlider;
    public Slider maxXpSlider;
    public Slider maxLevelSlider;
    public Slider reputationSlider;
    public Image characterImage;
    public TMP_Dropdown characterDropdown;
    public TMP_Dropdown favoriteCharacterDropdown;
    public TMP_Dropdown roleDropdown;
    public TMP_Dropdown moodDropdown;
    public Slider masteriesSlider;
    public Slider characterMasteriesSlider;

    void Start()
    {
        PopulateCharacterList();
       
    }

    private void PopulateCharacterList()
    {
        /*List<Character> characters = new List<Character>
        {
            new Character,
            new Character,
            new Character
        };

        characterMap.Clear();
        for (int i = 0; i < characters.Count; i++)
        {
            characterMap[i] = characters[i];
        }*/
    }

    public void CreatePlayer()
    {
        string name = nameInput.text;
        string surname = surnameInput.text;
        float luck = luckSlider.value;
        float morale = moraleSlider.value;
        float teamSpirit = teamSpiritSlider.value;
        int level = (int)levelSlider.value;
        int xp = (int)xpSlider.value;
        int maxXp = (int)maxXpSlider.value;
        int maxLevel = (int)maxLevelSlider.value;
        int reputation = (int)reputationSlider.value;
        Sprite image = characterImage.sprite;
        Mood mood = (Mood)moodDropdown.value;
        int masteries = (int)masteriesSlider.value;
        int characterMasteries = (int)characterMasteriesSlider.value;
        int roleId;
        Mechanic mechanic;
        Knowledge knowledge;
        int characterId;
        Lvl teamSpirits;

        Player player = new Player();
        player.Init(name,roleId, mechanic, knowledge, characterId, morale, teamSpirits, reputation, maxLevel, image);
    }
}
