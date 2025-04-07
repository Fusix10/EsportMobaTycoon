using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Mood { DEPRESSED, SAD, NORMAL, HAPPY, OVERWHELMED }
    public enum Role { ADC, SUPPORT, MIDLANER, JUNGLER, TOPLANER }

    public enum Temperament {AGGRESSIVE, FAIRPLAY}

    public string i_name { get;private set; }

    public string i_surname { get;private set; }

    public Sprite i_image { get;private set; }

    public float i_totalLuck { get; private set; }
    public float i_morale { get; private set; }
    public float i_teamSpirit { get; private set; }
    public Character i_character { get; private set; }
    public Character i_favoriteCharacter { get; private set; }
    public int i_level { get; private set; }
    public float i_currentExperience { get; private set; }
    public float i_maxExperience { get; private set; }
    public int i_maxLevel { get; private set; }
    public int i_reputation { get; private set; }

    public Mood i_currentMood;
    public Role i_currentRole { get; private set; }

    public int i_masteries { get; private set; }

    public int i_characterMasteries { get; private set; }

    public Temperament i_temparement { get; private set; }

    public Mood getMood()
    {
        return i_currentMood;
    }

    private void setMood(Mood newMood)
    {
        i_currentMood = newMood;
        moraleChange();
    }

    public Role getRole()
    {
        return i_currentRole;
    }

    private void setRole(Role newRole)
    {
        i_currentRole = newRole;
    }

    public void abilityToWin()
    {
        if (i_character == i_favoriteCharacter)
        {
            if ((int)i_character.i_role == (int)i_currentRole)
            {
                i_totalLuck = ((i_totalLuck / 100f) * 1.75f)*100f;
            }
            else
            {
                i_totalLuck = ((i_totalLuck / 100f) * 1.25f)*100f;
            }
        }
        else
        {
            i_totalLuck = ((i_totalLuck / 100f) * 0.5f)*100f;
        }
    }

    public float moralePercentage()
    {
        return (i_morale / 100f) * 100f;
    }

    public void moraleChange()
    {
        switch (i_currentMood)
        {
            case Mood.DEPRESSED:
                i_morale *= 0.8f;
                break;
            case Mood.SAD:
                i_morale *= 0.9f;
                break;
            case Mood.NORMAL:
                i_morale *= 1f;
                break;
            case Mood.HAPPY:
                i_morale *= 1.1f;
                break;
            case Mood.OVERWHELMED:
                i_morale *= 1.2f;
                break;
            default:
                Debug.Log(i_morale);
                break;
        }
    }

    public void changeLuck (float newLuck)
    {
        i_totalLuck += newLuck/100f;
    }

    public float xpBar()
    {
        if(i_maxExperience > 0 &&  i_maxExperience > i_currentExperience)
        {
            return i_currentExperience / i_maxExperience;
        }
        return i_currentExperience;
    }

    void Start()
    {
      
    }

    void Update()
    {
        
    }

    public static Player MakePlayer(string name,string surname, Temperament temperament,float luck,float morale,float teamSpirit, int level,int xp, int maxXp,int maxLevel, int reputation, Sprite image, Character character,Character favoriteCharacter,Role role,Mood mood,int masteries, int charactermasteries)
    {
        Player player = new();
        player.i_name = name;
        player.i_surname = surname;
        player.i_temparement = temperament;
        player.i_totalLuck = luck;
        player.i_morale = morale;
        player.i_teamSpirit = teamSpirit;
        player.i_level = level;
        player.i_currentExperience = xp;
        player.i_maxExperience = maxXp;
        player.i_level = level;
        player.i_maxLevel = maxLevel;
        player.i_reputation = reputation;
        player.i_image = image;
        player.i_character = character;
        player.i_favoriteCharacter = favoriteCharacter;
        player.i_currentRole = role;
        player.i_currentMood = mood;
        player.i_masteries = masteries;
        player.i_characterMasteries = charactermasteries;
        return player;
    }
}
