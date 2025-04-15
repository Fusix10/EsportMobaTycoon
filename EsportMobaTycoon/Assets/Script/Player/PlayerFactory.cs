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
        if (PlayerPrefabs == null)
        {
            Debug.LogError("Player prefab non assigné dans le GameManager.");
            return null;
        }

        GameObject playerObj = Instantiate(PlayerPrefabs);
        Player playerComponent = playerObj.GetComponent<Player>();

        if (playerComponent == null)
        {
            Debug.LogError("Le prefab ne contient pas de composant 'Player'.");
            return null;
        }
        playerComponent.i_name = data.i_name;
        playerComponent.i_role = data.i_role;
        playerComponent.i_currentRole = data.i_currentRole;
        playerComponent.i_mechanic = data.i_mechanic;
        playerComponent.i_knowledge = data.i_knowledge;
        playerComponent.i_favoriteCharacterId = data.i_favoriteCharacterId;
        playerComponent.i_characterId = data.i_characterId;
        playerComponent.i_totalLuck = data.i_totalLuck;
        playerComponent.i_morale = data.i_morale;
        playerComponent.i_teamSpirit = data.i_teamSpirit;
        playerComponent.i_reputation = data.i_reputation;
        playerComponent.i_lvl = data.i_lvl;
        playerComponent.i_potentiel = data.i_potentiel;
        playerComponent.i_mood = data.i_mood;

        return playerComponent;
    }



    public Player CreateRandomPlayer()//
    {
        string name = "Joueur_" + UnityEngine.Random.Range(1, 1000);
        int role = UnityEngine.Random.Range(0, 5); 
        int currentrole = UnityEngine.Random.Range(0, 5); 
        int potential = UnityEngine.Random.Range(5, 5);
        int reputation = UnityEngine.Random.Range(0, 100);
        Character favoriteCharacterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 20)];
        Character characterId = GameManager.Instance.i_allCharacters[UnityEngine.Random.Range(0, 20)];

        //Sprite icon = characterImage.sprite;

        Lvl teamSpirit = new Lvl(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(0f, 100f));

        Mechanic mechanic = new Mechanic();
        mechanic.s_lvlCombo.Add(favoriteCharacterId.i_Id, new Lvl(UnityEngine.Random.Range(1, potential),UnityEngine.Random.Range(0f, 100f)));
        mechanic.s_stamina = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        mechanic.s_reflexe = new Lvl(UnityEngine.Random.Range(1, potential),UnityEngine.Random.Range(0f, 100f));

        Knowledge knowledge = new Knowledge();
        knowledge.s_objective = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        knowledge.s_placement = new Lvl(UnityEngine.Random.Range(1, potential),UnityEngine.Random.Range(0f, 100f));
        knowledge.s_teamFight = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));

        Debug.Log(name + " s_lvlCombo = " + mechanic.s_lvlCombo[favoriteCharacterId.i_Id].s_lvl);
        Debug.Log(name + " s_stamina = " + mechanic.s_stamina.s_lvl);
        Debug.Log(name + " s_reflexe = " + mechanic.s_reflexe.s_lvl);
        Debug.Log(name + " s_objective = " + knowledge.s_objective.s_lvl);
        Debug.Log(name + " s_placement = " + knowledge.s_placement.s_lvl);
        Debug.Log(name + " s_teamFight = " + knowledge.s_teamFight.s_lvl);

        GameObject playerObj = Instantiate(PlayerPrefabs);

        playerObj.GetComponent<Player>().Init(name, (GameManager.Role)role, mechanic, knowledge, GameManager.Instance.i_allCharacters[favoriteCharacterId.i_Id], teamSpirit, reputation, potential, GameManager.Instance.i_allMood[UnityEngine.Random.Range(0,9)],(GameManager.Role)(currentrole), GameManager.Instance.i_allCharacters[characterId.i_Id]);
        return playerObj.GetComponent<Player>();
    }
}
