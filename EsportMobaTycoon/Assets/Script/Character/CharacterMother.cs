using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMother : MonoBehaviour
{
    //Stat
    bool i_Meta;

    //
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

enum AllCharacterName
{
    None,
}

enum StatMatchUp
{
    Good,
    Bad,
    Equal
}
struct Matchup
{
    AllCharacterName EnemyCharacter;
    StatMatchUp MatchUpCorrect; //si MatchUpCorrect = false alors le matchup est mauvais, sinon il est bon
}
