using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerFactory : MonoBehaviour
{
    public GameObject PlayerPrefabs;

    void Start()
    {
        
    }

    public Player CreatePlayerFromData(PlayerData data)
    {
        GameObject Prefab = Instantiate(PlayerPrefabs);
        Prefab.GetComponent<Player>().Init(data.i_name, data.i_nickname,data.i_role,data.i_mechanic,data.i_knowledge,data.i_favoriteCharacterId,data.i_teamSpirit,data.i_reputation,data.i_potentiel,data.i_mood,data.i_currentRole,data.i_characterId,data.i_skin,data.i_isBuddy);
        GameManager.Instance.i_allPlayers.Add(Prefab.GetComponent<Player>());
        return Prefab.GetComponent<Player>();
    }

    public Player CreateRandomPlayer()
    {
        GameObject playerObj = Instantiate(PlayerPrefabs);

        //string name = firstNameArray[UnityEngine.Random.Range(0, firstNameArray.Length)] + lastNameArray[UnityEngine.Random.Range(0, lastNameArray.Length)];
        string knickname = "Knickname" + UnityEngine.Random.Range(1, 1000);
        GameManager.Role role = GameManager.Instance.GetRandomRole();
        int potential = UnityEngine.Random.Range(1, 5);
        GameManager.Role currentRole = GameManager.Instance.GetRandomRole();
        int reputation = UnityEngine.Random.Range(0, 100);
        Character favoriteCharacterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 19)];
        Character characterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 19)];

        //Sprite icon = characterImage.sprite;

        Lvl teamSpirit = new Lvl(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(0f, 100f));

        Mechanic mechanic = new Mechanic();
        mechanic.s_lvlCombo.Add(favoriteCharacterId.i_Id, new Lvl(UnityEngine.Random.Range(1, potential+1),UnityEngine.Random.Range(0f, 100f)));
        mechanic.s_stamina = new Lvl(UnityEngine.Random.Range(1, potential + 1), UnityEngine.Random.Range(0f, 100f));
        mechanic.s_reflexe = new Lvl(UnityEngine.Random.Range(1, potential + 1), UnityEngine.Random.Range(0f, 100f));

        Knowledge knowledge = new Knowledge();
        knowledge.s_objective = new Lvl(UnityEngine.Random.Range(1, potential + 1), UnityEngine.Random.Range(0f, 100f));
        knowledge.s_placement = new Lvl(UnityEngine.Random.Range(1, potential + 1), UnityEngine.Random.Range(0f, 100f));
        knowledge.s_teamFight = new Lvl(UnityEngine.Random.Range(1, potential + 1), UnityEngine.Random.Range(0f, 100f));

        foreach (Character character in GameManager.Instance.i_allCharacters)
        {
            if ((GameManager.Role)character.i_roleId == role)
            {
                mechanic.s_lvlCombo[favoriteCharacterId.i_Id] = new Lvl(UnityEngine.Random.Range(1, potential + 1), UnityEngine.Random.Range(0f, 100f));
            }
        }
        Debug.Log(name + " s_lvlCombo = " + mechanic.s_lvlCombo[favoriteCharacterId.i_Id].s_lvl);
        Debug.Log(name + " s_stamina = " + mechanic.s_stamina.s_lvl);
        Debug.Log(name + " s_reflexe = " + mechanic.s_reflexe.s_lvl);
        Debug.Log(name + " s_objective = " + knowledge.s_objective.s_lvl);
        Debug.Log(name + " s_placement = " + knowledge.s_placement.s_lvl);
        Debug.Log(name + " s_teamFight = " + knowledge.s_teamFight.s_lvl);


        playerObj.GetComponent<Player>().Init(name, knickname, role, mechanic, knowledge, favoriteCharacterId, teamSpirit, reputation, potential, GameManager.Instance.i_allMood[UnityEngine.Random.Range(0, 9)], currentRole, characterId);
        return playerObj.GetComponent<Player>();
    }

    public Player CreateRandomPlayerWithRole(GameManager.Role role, int potential = 0, Skin skin = null, bool Data = false, bool isBuddy = false)
    {
        GameObject playerObj = Instantiate(PlayerPrefabs);

        string[] firstNameArray = { "Léa", "Julien", "Clémence", "Hugo", "James", "Emily", "Michael", "Ashley", "Carlos", "Isabella", "Diego", "Lucia", "Marco", "Giulia", "Luca", "Sofia", "Youssef", "Layla", "Amine", "Fatima", "Haruto", "Aiko", "Ren", "Yuna", "Kwame", "Aminata", "Tariq", "Zahra", "Erik", "Freya", "Sven", "Astrid", "Raj", "Priya", "Anil", "Deepa", "Wei", "Mei", "Li", "Xiao", "Hans", "Greta", "Klaus", "Anna", "Ivan", "Anastasia", "Yuri", "Olga", "Noah", "Maya", "Elijah", "Zoe", "Kai", "Nina", "Aria", "Leo", "Salim", "Aisha", "Kenji", "Inari", "Mateo", "Lina", "Rami", "Elsa" };
        string[] lastNameArray = { "Dupont", "Lemoine", "Charrier", "Giraud", "Smith", "Johnson", "Williams", "Brown", "Fernandez", "Gomez", "Sanchez", "Morales", "Rossi", "Bianchi", "Esposito", "Conti", "Al-Farsi", "Benali", "El-Mansouri", "Zahiri", "Takahashi", "Saito", "Kobayashi", "Fujimoto", "Diop", "Traoré", "Kouyaté", "Ndiaye", "Andersen", "Johansson", "Larsen", "Hansen", "Patel", "Reddy", "Sharma", "Kumar", "Zhang", "Wang", "Chen", "Liu", "Schmidt", "Müller", "Kaiser", "Fischer", "Volkov", "Smirnov", "Petrov", "Ivanov", "Nguyen", "Kim", "Okafor", "Diallo", "Silva", "Costa", "Tanaka", "Ahmed" };

        string name = firstNameArray[Random.Range(0, firstNameArray.Length)] + $"  " + lastNameArray[UnityEngine.Random.Range(0, lastNameArray.Length)];
        string knickname = "Knickname" + Random.Range(1, 1000);
        GameManager.Role favoriteRole = GameManager.Instance.GetRandomRole();
        if (potential == 0)
        {
            potential = Random.Range(1, 5);
        }
        GameManager.Role currentRole = role;
        int reputation = Random.Range(0, 100);
        //Character characterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 19)];

        //Sprite icon = characterImage.sprite;

        Lvl teamSpirit = new Lvl(Random.Range(1, 5), Random.Range(0f, 100f));

        Mechanic mechanic = new Mechanic();
        mechanic.s_stamina = new Lvl(Random.Range(1, potential), Random.Range(0f, 100f));
        mechanic.s_reflexe = new Lvl(Random.Range(1, potential), Random.Range(0f, 100f));

        Knowledge knowledge = new Knowledge();
        knowledge.s_objective = new Lvl(Random.Range(1, potential), Random.Range(0f, 100f));
        knowledge.s_placement = new Lvl(Random.Range(1, potential), Random.Range(0f, 100f));
        knowledge.s_teamFight = new Lvl(Random.Range(1, potential), Random.Range(0f, 100f));

        foreach (Character character in GameManager.Instance.i_allCharacters)
        {
            if ((GameManager.Role)character.i_roleId == role)
            {
                mechanic.s_lvlCombo[character.i_Id] = new Lvl(Random.Range(1, potential), Random.Range(0f, 100f));
            }
        }

        int bestlvlid = -55555555;
        int lvl = -6555555;

        foreach (KeyValuePair<int, Lvl> character in mechanic.s_lvlCombo)
        {

            if (character.Value.s_lvl > lvl)
            {
                bestlvlid = character.Key;
                lvl = character.Value.s_lvl;
            }
        }

        Character favoriteCharacterId = GameManager.Instance.i_allCharacters[bestlvlid];

        Debug.Log(name + " s_lvlCombo = " + mechanic.s_lvlCombo[favoriteCharacterId.i_Id].s_lvl);
        Debug.Log(name + " s_stamina = " + mechanic.s_stamina.s_lvl);
        Debug.Log(name + " s_reflexe = " + mechanic.s_reflexe.s_lvl);
        Debug.Log(name + " s_objective = " + knowledge.s_objective.s_lvl);
        Debug.Log(name + " s_placement = " + knowledge.s_placement.s_lvl);
        Debug.Log(name + " s_teamFight = " + knowledge.s_teamFight.s_lvl);


        playerObj.GetComponent<Player>().Init(name, knickname, favoriteRole, mechanic, knowledge, favoriteCharacterId, teamSpirit, reputation, potential, GameManager.Instance.i_allMood[UnityEngine.Random.Range(0, 9)], currentRole, null, skin, isBuddy);
        return playerObj.GetComponent<Player>();
    }

    public PlayerData CreateRandomPlayerDataWithRole(GameManager.Role role, int potential = 0, Skin skin = null, bool Data = false)
    {
        PlayerData playerData = new();

        string[] firstNameArray = { "Léa", "Julien", "Clémence", "Hugo", "James", "Emily", "Michael", "Ashley", "Carlos", "Isabella", "Diego", "Lucia", "Marco", "Giulia", "Luca", "Sofia", "Youssef", "Layla", "Amine", "Fatima", "Haruto", "Aiko", "Ren", "Yuna", "Kwame", "Aminata", "Tariq", "Zahra", "Erik", "Freya", "Sven", "Astrid", "Raj", "Priya", "Anil", "Deepa", "Wei", "Mei", "Li", "Xiao", "Hans", "Greta", "Klaus", "Anna", "Ivan", "Anastasia", "Yuri", "Olga", "Noah", "Maya", "Elijah", "Zoe", "Kai", "Nina", "Aria", "Leo", "Salim", "Aisha", "Kenji", "Inari", "Mateo", "Lina", "Rami", "Elsa" };
        string[] lastNameArray = { "Dupont", "Lemoine", "Charrier", "Giraud", "Smith", "Johnson", "Williams", "Brown", "Fernandez", "Gomez", "Sanchez", "Morales", "Rossi", "Bianchi", "Esposito", "Conti", "Al-Farsi", "Benali", "El-Mansouri", "Zahiri", "Takahashi", "Saito", "Kobayashi", "Fujimoto", "Diop", "Traoré", "Kouyaté", "Ndiaye", "Andersen", "Johansson", "Larsen", "Hansen", "Patel", "Reddy", "Sharma", "Kumar", "Zhang", "Wang", "Chen", "Liu", "Schmidt", "Müller", "Kaiser", "Fischer", "Volkov", "Smirnov", "Petrov", "Ivanov", "Nguyen", "Kim", "Okafor", "Diallo", "Silva", "Costa", "Tanaka", "Ahmed" };

        string name = firstNameArray[UnityEngine.Random.Range(0, firstNameArray.Length)] + $"  " + lastNameArray[UnityEngine.Random.Range(0, lastNameArray.Length)];
        string knickname = "Knickname" + UnityEngine.Random.Range(1, 1000);
        GameManager.Role favoriteRole = GameManager.Instance.GetRandomRole();
        if (potential == 0)
        {
            potential = UnityEngine.Random.Range(1, 5);
        }
        GameManager.Role currentRole = role;
        int reputation = UnityEngine.Random.Range(0, 100);

        if (skin == null)
        {
            skin = CharacterSkinRandom.RandomSkin();
        }

        Lvl teamSpirit = new Lvl(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(0f, 100f));

        Mechanic mechanic = new Mechanic();
        mechanic.s_stamina = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        mechanic.s_reflexe = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));

        Knowledge knowledge = new Knowledge();
        knowledge.s_objective = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        knowledge.s_placement = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        knowledge.s_teamFight = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));

        foreach (Character character in GameManager.Instance.i_allCharacters)
        {
            if ((GameManager.Role)character.i_roleId == role)
            {
                mechanic.s_lvlCombo[character.i_Id] = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
            }
        }

        int bestlvlid = -55555555;
        int lvl = -6555555;

        foreach (KeyValuePair<int, Lvl> character in mechanic.s_lvlCombo)
        {

            if (character.Value.s_lvl > lvl)
            {
                bestlvlid = character.Key;
                lvl = character.Value.s_lvl;
            }
        }

        Character favoriteCharacterId = GameManager.Instance.i_allCharacters[bestlvlid];

        Debug.Log(name + " s_lvlCombo = " + mechanic.s_lvlCombo[favoriteCharacterId.i_Id].s_lvl);
        Debug.Log(name + " s_stamina = " + mechanic.s_stamina.s_lvl);
        Debug.Log(name + " s_reflexe = " + mechanic.s_reflexe.s_lvl);
        Debug.Log(name + " s_objective = " + knowledge.s_objective.s_lvl);
        Debug.Log(name + " s_placement = " + knowledge.s_placement.s_lvl);
        Debug.Log(name + " s_teamFight = " + knowledge.s_teamFight.s_lvl);


        playerData.SetFromData(name, knickname, favoriteRole, mechanic, knowledge, favoriteCharacterId, teamSpirit, reputation, potential, GameManager.Instance.i_allMood[UnityEngine.Random.Range(0, 9)], currentRole, null, skin);
        return playerData;
    }
}
