using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    void Start()
    {
        TestAbilityToWin();
        TestMoraleChange();
    }

    public Character testCharacter(string str)
    {
        Character character = new Character();
        character.setRole((Character.Role)Random.Range(0, 4));
        Debug.Log("Role " + str + " " + character.getRole());
        return character;
    }


    void TestAbilityToWin()
    {
        Player testPlayer = new GameObject().AddComponent<Player>();
       
        testPlayer.setFavoriteCharacter(testCharacter("favorite"));
        testPlayer.setCharacter(testCharacter("character"));
        testPlayer.setRole((Player.Role.ADC));
        Debug.Log("role player " + testPlayer.getRole());

        testPlayer.setLuck(50f);
        testPlayer.abilityToWin();

        Debug.Log("Ability To Win - Luck: " + testPlayer.getLuck());
    }


    void TestMoraleChange()
    {
        Player testPlayer = new GameObject().AddComponent<Player>();

        testPlayer.setMorale(50f);
        float moralePercent = testPlayer.moralePercentage();
        Debug.Log("Morale Percentage: " + moralePercent + "%");

        testPlayer.setMood((Player.Mood)(Random.Range(0,4)));
        moralePercent = testPlayer.moralePercentage();
        Debug.Log("Morale " + testPlayer.getMood() + " Percentage: " + moralePercent + "%");

        testPlayer.setMood((Player.Mood)(Random.Range(0, 4)));
        moralePercent = testPlayer.moralePercentage();
        Debug.Log("Morale " + testPlayer.getMood() +" Percentage: " + moralePercent + "%");
    }
}

