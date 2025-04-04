using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Player;

public class PlayerFactory : MonoBehaviour
{
    // UI Elements
    public InputField nameInput;
    public InputField surnameInput;
    public Dropdown temperamentDropdown;
    public Slider luckSlider;
    public Slider moraleSlider;
    public Slider teamSpiritSlider;
    public Slider levelSlider;
    public Slider xpSlider;
    public Slider maxXpSlider;
    public Slider maxLevelSlider;
    public Slider reputationSlider;
    public Image characterImage;
    public Dropdown characterDropdown;
    public Dropdown favoriteCharacterDropdown;
    public Dropdown roleDropdown;
    public Dropdown moodDropdown;
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

    private void PopulateDropdowns()
    {
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
