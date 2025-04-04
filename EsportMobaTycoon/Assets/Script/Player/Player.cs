using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Mood { DEPRESSED, SAD, NORMAL, HAPPY, OVERWHELMED }
    public enum Role { ADC, SUPPORT, MIDLANER, JUNGLER, TOPLANER }
    private float i_totalLuck { get; set; }
    private float i_morale { get; set; }
    private float i_teamSpirit { get; set; }
    private Character i_character { get; set; }
    private Character i_favoriteCharacter { get; set; }
    private int i_level { get; set; }
    private float i_currentExperience { get; set; }
    private float i_maxExperience { get; set; }
    private int i_maxLevel { get; set; }
    private int i_reputation { get; set; }

    private Mood i_currentMood;
    private Role i_currentRole { get; set; }

    private int masteries { get; set; }

    private int characterMasteries { get; set; }

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
        if (i_character == i_favoriteCharacter)
        {
            if ((int)i_character.getRole() == (int)i_currentRole)
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

    private void changeLuck (float newLuck)
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
}
