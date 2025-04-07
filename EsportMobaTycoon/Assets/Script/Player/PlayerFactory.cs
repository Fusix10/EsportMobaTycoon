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

    private Dictionary<int, Character> characterMap = new Dictionary<int, Character>();

    void Start()
    {
        PopulateCharacterList();
        PopulateDropdowns();
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

    private void FillDropdownWithEnum<T>(TMP_Dropdown dropdown) where T : System.Enum
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string>(System.Enum.GetNames(typeof(T))));
    }

    private void PopulateDropdowns()
    {

        FillDropdownWithEnum<Mood>(moodDropdown);
        FillDropdownWithEnum<Role>(roleDropdown);
        FillDropdownWithEnum<Temperament>(temperamentDropdown);
        // Fill dropdown options
        //characterDropdown.ClearOptions();
        //favoriteCharacterDropdown.ClearOptions();

        //List<string> characterNames = new List<string>();
        //foreach (var character in characterMap.Values)
        //{
        //    characterNames.Add(character.Name);
        //}

        //characterDropdown.AddOptions(characterNames);
        //favoriteCharacterDropdown.AddOptions(characterNames);
    }

    public void CreatePlayer()
    {
        string name = nameInput.text;
        string surname = surnameInput.text;
        Temperament temperament = (Temperament)temperamentDropdown.value;
        float luck = luckSlider.value;
        float morale = moraleSlider.value;
        float teamSpirit = teamSpiritSlider.value;
        int level = (int)levelSlider.value;
        int xp = (int)xpSlider.value;
        int maxXp = (int)maxXpSlider.value;
        int maxLevel = (int)maxLevelSlider.value;
        int reputation = (int)reputationSlider.value;
        Sprite image = characterImage.sprite;
       /* Character character = (Character)characterDropdown.value;  
        Character favoriteCharacter = (Character)favoriteCharacterDropdown.value;*/
        Role role = (Role)roleDropdown.value;
        Mood mood = (Mood)moodDropdown.value;
        int masteries = (int)masteriesSlider.value;
        int characterMasteries = (int)characterMasteriesSlider.value;

        //Player player0 = MakePlayer(name, surname, temperament, luck, morale, teamSpirit, level, xp, maxXp, maxLevel, reputation, image, character, favoriteCharacter, role, mood, masteries, characterMasteries);
    }
}
