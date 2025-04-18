using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Init("Buddy", NickName, (GameManager.Role)2, mechanic, knowledge,GameManager.Instance.i_allCharacters[0],new Lvl(2,0),500,3,GameManager.Instance.i_allMood[2],(GameManager.Role)(Random.Range(0,4)));
        i_icon = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
