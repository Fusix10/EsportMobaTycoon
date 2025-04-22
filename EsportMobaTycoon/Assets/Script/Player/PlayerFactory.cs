using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;
using static Player;
using System.Xml.Linq;

public class PlayerFactory : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField knicknameInput;
    public Image characterImage;
    public Slider teamSpiritXpSlider;
    public Slider teamSpiritLvlSlider;
    public Slider xpSlider;
    public Slider roleSlider;
    public Slider rolePlayedSlider;
    public Slider potentialSlider;
    public Slider reputationSlider;
    public Slider reflexelvlSlider;
    public Slider reflexexpSlider;
    public Slider staminalvlSlider;
    public Slider staminaxpSlider;
    public Slider combolvlSlider;
    public Slider comboxpSlider;
    public Slider objectivexpSlider;
    public Slider objectivelvlSlider;
    public Slider placementxpSlider;
    public Slider placementlvlSlider;
    public Slider teamFightxpSlider;
    public Slider teamFightlvlSlider;
    public Slider favoriteCharacterSlider;
    public Slider characterPlayedSlider;
    public TMP_Dropdown moodDropdown;
    public GameObject playerPrefab;
    public Material baseMaterial;

    public GameObject PlayerPrefabs;

    void Start()
    {
       
    }

    public Player CreatePlayerFromData(PlayerData data)
    {
        string name = data.i_name;
        string knickname = data.i_knickname;
        Lvl teamSpirit = data.i_teamSpirit;
        GameManager.Role roleId = data.i_role;
        GameManager.Role rolePlayedId = data.i_currentRole;
        int potential = data.i_potential;
        int reputation = data.i_reputation;
        Sprite image = data.i_icon;
        Mood mood = data.i_mood;
        Character favoriteCharacterId = data.i_favoriteCharacterId;
        Mechanic mechanic = new();
        mechanic.s_reflexe = new Lvl((int)reflexelvlSlider.value, (float)reflexexpSlider.value);
        mechanic.s_stamina = new Lvl((int)staminalvlSlider.value, (float)staminaxpSlider.value);
        mechanic.s_lvlCombo.Add(favoriteCharacterId.i_Id, new Lvl((int)combolvlSlider.value, (float)comboxpSlider.value));
        Knowledge knowledge = new();
        knowledge.s_objective = new Lvl((int)objectivelvlSlider.value, (float)objectivexpSlider.value);
        knowledge.s_placement = new Lvl((int)placementlvlSlider.value, (float)placementxpSlider.value);
        knowledge.s_teamFight = new Lvl((int)teamFightlvlSlider.value, (float)teamFightxpSlider.value);
        Character characterPlayedId = data.i_characterId;

        GameObject playerObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playerObj.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), 1f, UnityEngine.Random.Range(-5f, 5f));

        if (image != null && baseMaterial != null)
        {
            Debug.LogError("Player prefab non assign� dans le GameManager.");
            return null;
        }


        Player playerComponent = playerObj.AddComponent<Player>();
        playerComponent.Init(name,
                            knickname,
                            roleId,
                            mechanic,
                            knowledge,
                            favoriteCharacterId,
                            teamSpirit,
                            reputation,
                            potential,
                            mood,
                            rolePlayedId,
                            characterPlayedId,
                            image = null
                            );
        GameManager.Instance.i_allPlayers.Add(playerComponent);
        return playerComponent;
    }


    public Player CreateRandomPlayer()//
    {
        GameObject playerObj = Instantiate(PlayerPrefabs);

        string name = "Joueur_" + UnityEngine.Random.Range(1, 1000);
        string knickname = "Knickname" + UnityEngine.Random.Range(1, 1000);
        GameManager.Role role = GameManager.Instance.GetRandomRole();
        int potential = UnityEngine.Random.Range(1, 5);
        GameManager.Role currentRole = GameManager.Instance.GetRandomRole();
        int reputation = UnityEngine.Random.Range(0, 100);

        Character characterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 19)];

        //Sprite icon = characterImage.sprite;

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
                mechanic.s_lvlCombo.Add(character.i_Id, new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f)));
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



        playerObj.GetComponent<Player>().Init(name, knickname, role, mechanic, knowledge, favoriteCharacterId, teamSpirit, reputation, potential, GameManager.Instance.i_allMood[UnityEngine.Random.Range(0, 9)], currentRole, characterId);
        return playerObj.GetComponent<Player>();
    }
}
