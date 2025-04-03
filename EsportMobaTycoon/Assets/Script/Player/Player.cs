using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Mood {DEPRESSED, SAD ,NORMAL, HAPPY, OVERWHELMED}
    public enum Role {ADC, SUPPORT, MIDLANER, JUNGLER, TOPLANER}
    private float i_totalLuck;
    private float i_morale;
    private float i_teamSpirit;
    private Character i_player;
    private Character i_favoritePlayer;
    private int i_level;
    private float i_currentExperience;
    private float i_maxExperience;
    private int i_maxLevel;
    private int i_reputation;
    private Mood i_currentMood;
    private Role i_currentRole;

    public float getLuck()
    {
        return i_totalLuck;
    }

    public void setLuck(float luck)
    {
        i_totalLuck = luck;
    }

    public float getMorale()
    {
        return i_morale;
    }

    public void setMorale(float morale)
    {
        i_morale = morale;
    }
    public float getTeamSpirit()
    {
        return i_teamSpirit;
    }

    public void setTeamSpirit(float teamSpirit)
    {
        i_teamSpirit = teamSpirit;
    }

    public Character getCharacterPlayed()
    {
        return i_player;
    }

    public void setCharacter(Character newCharacter)
    {
        i_player = newCharacter;
    }

    public Character getFavoriteCharacter()
    {
        return i_favoritePlayer;
    }

    public void setFavoriteCharacter(Character newCharacter)
    {
        i_favoritePlayer = newCharacter;
    }

    public int getLevel()
    {
        return i_level;
    }

    public void setLevel(int newLevel)
    {
        i_level = newLevel;
    }

    public float getCurrentExperience()
    {
        return i_currentExperience;
    }

    public void setCurrentExperience(float newExperience)
    {
        i_currentExperience = newExperience;
    }
    
    public float getMaxExperience()
    {
        return i_maxExperience;
    }

    public void setMaxExperience(float newMaxExperience)
    {
        i_maxExperience = newMaxExperience;
    }

    public int getMaxLevel()
    {
        return i_maxLevel;
    }

    public void setMaxLevel(int newMaxLevel)
    {
        i_maxLevel = newMaxLevel;
    }

    public int getReputation()
    {
        return i_reputation;
    }

    public void setReputation(int newReputation)
    {
        i_reputation = newReputation;
    }

    public Mood getMood()
    {
        return i_currentMood;
    }

    public void setMood(Mood newMood)
    {
        i_currentMood = newMood;
        moraleChange();
    }

    public Role getRole()
    {
        return i_currentRole;
    }

    public void setRole(Role newRole)
    {
        i_currentRole = newRole;
    }

    public void abilityToWin()
    {
        if (i_player == i_favoritePlayer)
        {
            if((int)i_player.getRole() == (int)i_currentRole)
            {
                i_totalLuck = (i_totalLuck / 100f) * 2f;
            }
            else
            {
                i_totalLuck = (i_totalLuck / 100f) * 1.25f;
            }
            
        }
        else
        {
            i_totalLuck = (i_totalLuck / 100f) * 0.5f;
        }
    }

    public float moralePercentage()
    {
        return (i_morale/100f)*100f;
    }

    public void moraleChange()
    {
        switch(i_currentMood)
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

    void Start()
    {
      
    }

    void Update()
    {
        
    }
}
