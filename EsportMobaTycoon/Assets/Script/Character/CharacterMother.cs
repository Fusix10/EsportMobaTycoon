using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMother : MonoBehaviour
{
    //Stat
    bool i_Meta;
    List<Matchup> allMatchUp;
    int IdCoesion;
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
    StatMatchUp MatchUpCorrect;
}
