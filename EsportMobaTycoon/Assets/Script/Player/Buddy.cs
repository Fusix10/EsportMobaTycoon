using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Buddy : Player
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void buddyCreate(string NickName, Sprite sprite)
    {
        Mechanic mechanic = new Mechanic();
        mechanic.s_stamina = new Lvl(2, 0);
        mechanic.s_reflexe = new Lvl(2, 0);
        mechanic.s_lvlCombo.Add(0,new Lvl(2,0));  
        mechanic.s_lvlCombo.Add(1,new Lvl(2,0));  
        mechanic.s_lvlCombo.Add(2,new Lvl(2,0));  
        mechanic.s_lvlCombo.Add(3,new Lvl(2,0));  
        Knowledge knowledge = new Knowledge();
        knowledge.s_teamFight = new Lvl(2, 0);
        knowledge.s_objective = new Lvl(2, 0);
        knowledge.s_placement = new Lvl(2, 0);
        Character favoriteCharacterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 19)];

        foreach (Character character in GameManager.Instance.i_allCharacters)
        {
            if (character.i_roleId == 2)
            {
                mechanic.s_lvlCombo.Add(character.i_Id, new Lvl(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(0f, 100f)));
            }
        }

        Init("Buddy", NickName, (GameManager.Role)2, mechanic, knowledge, favoriteCharacterId, new Lvl(2,0),500,3,GameManager.Instance.i_allMood[2], (GameManager.Role)2);
        i_icon = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
