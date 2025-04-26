using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buddy : Player
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void BuddyCreate(Skin skin)
    {
        i_skin = skin;
        i_isBuddy = true;

        Mechanic mechanic = new Mechanic();
        mechanic.s_stamina = new Lvl(Random.Range(2, 6), 0);
        mechanic.s_reflexe = new Lvl(Random.Range(2, 6), 0);
        mechanic.s_lvlCombo.Add(0, new Lvl(Random.Range(2, 6), 0));
        mechanic.s_lvlCombo.Add(1, new Lvl(Random.Range(2, 6), 0));
        mechanic.s_lvlCombo.Add(2, new Lvl(Random.Range(2, 6), 0));
        mechanic.s_lvlCombo.Add(3, new Lvl(Random.Range(2, 6), 0));
        Knowledge knowledge = new Knowledge();
        knowledge.s_teamFight = new Lvl(Random.Range(2, 6), 0);
        knowledge.s_objective = new Lvl(Random.Range(2, 6), 0);
        knowledge.s_placement = new Lvl(Random.Range(2, 6), 0);
        //Init("Buddy", NickName, 2, mechanic, knowledge,0,new Lvl(2,0),500,3,GameManager.Instance.i_allMood[2]);
        Character favoriteCharacterId = GameManager.Instance.i_allCharacters[Random.Range(0, 19)];

        foreach (Character character in GameManager.Instance.i_allCharacters)
        {
            if (character.i_roleId == 2)
            {
                mechanic.s_lvlCombo.Add(character.i_Id, new Lvl(Random.Range(1, 3), Random.Range(0f, 100f)));
            }
        }
        Init("Buddy", "Buddy", (GameManager.Role)2, mechanic, knowledge,GameManager.Instance.i_allCharacters[0],new Lvl(2,0),500,3,GameManager.Instance.i_allMood[2],(GameManager.Role)(Random.Range(0,4)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
