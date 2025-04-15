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

    public void CreatePlayer()//
    {
        string name = nameInput.text;
        string knickname = knicknameInput.text;
        Lvl teamSpirit = new((int)teamSpiritLvlSlider.value,teamSpiritXpSlider.value);
        int xp = (int)xpSlider.value;
        int roleId = (int)roleSlider.value;
        int rolePlayedId = (int)rolePlayedSlider.value;
        int potential = (int)potentialSlider.value;
        int reputation = (int)reputationSlider.value;
        Sprite image = characterImage.sprite;
        Mood mood = GameManager.Instance.i_allMood[(int)moodDropdown.value];
        int favoriteCharacterId = (int)favoriteCharacterSlider.value;
        Mechanic mechanic = new();
        mechanic.s_reflexe = new Lvl((int)reflexelvlSlider.value, (float)reflexexpSlider.value);
        mechanic.s_stamina = new Lvl((int)staminalvlSlider.value, (float)staminaxpSlider.value);
        mechanic.s_lvlCombo.Add(favoriteCharacterId, new Lvl((int)combolvlSlider.value, (float)comboxpSlider.value));
        Knowledge knowledge = new();
        knowledge.s_objective =  new Lvl((int)objectivelvlSlider.value, (float)objectivexpSlider.value);
        knowledge.s_placement = new Lvl((int)placementlvlSlider.value, (float)placementxpSlider.value);
        knowledge.s_teamFight = new Lvl((int)teamFightlvlSlider.value, (float)teamFightxpSlider.value);
        int characterPlayedId = (int)characterPlayedSlider.value;

        GameObject playerObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playerObj.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), 1f, UnityEngine.Random.Range(-5f, 5f));

        if (image != null && baseMaterial != null)
        {
            Material playerMaterial = new Material(baseMaterial);
            playerMaterial.mainTexture = image.texture;
            playerObj.GetComponent<Renderer>().material = playerMaterial;
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
                            characterPlayedId,
                            rolePlayedId,
                            image
                            );
        GameManager.Instance.i_allPlayers.Add(playerComponent);
    }


    public Player CreateRandomPlayer()//
    {
        string name = "Joueur_" + UnityEngine.Random.Range(1, 1000);
        string knickname = "Knickname" + UnityEngine.Random.Range(1, 1000);
        int role = UnityEngine.Random.Range(0, 5); 
        int potential = UnityEngine.Random.Range(1, 5);
        int reputation = UnityEngine.Random.Range(0, 100);
        int characterId = UnityEngine.Random.Range(0, 5);

        //Sprite icon = characterImage.sprite;

        Lvl teamSpirit = new Lvl(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(0f, 100f));

        Mechanic mechanic = new Mechanic();
        mechanic.s_lvlCombo.Add(characterId, new Lvl(UnityEngine.Random.Range(1, potential),UnityEngine.Random.Range(0f, 100f)));
        mechanic.s_stamina = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        mechanic.s_reflexe = new Lvl(UnityEngine.Random.Range(1, potential),UnityEngine.Random.Range(0f, 100f));

        Knowledge knowledge = new Knowledge();
        knowledge.s_objective = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));
        knowledge.s_placement = new Lvl(UnityEngine.Random.Range(1, potential),UnityEngine.Random.Range(0f, 100f));
        knowledge.s_teamFight = new Lvl(UnityEngine.Random.Range(1, potential), UnityEngine.Random.Range(0f, 100f));

        Debug.Log(name + " s_lvlCombo = " + mechanic.s_lvlCombo[characterId].s_lvl);
        Debug.Log(name + " s_stamina = " + mechanic.s_stamina.s_lvl);
        Debug.Log(name + " s_reflexe = " + mechanic.s_reflexe.s_lvl);
        Debug.Log(name + " s_objective = " + knowledge.s_objective.s_lvl);
        Debug.Log(name + " s_placement = " + knowledge.s_placement.s_lvl);
        Debug.Log(name + " s_teamFight = " + knowledge.s_teamFight.s_lvl);

        GameObject playerObj = Instantiate(PlayerPrefabs);

        playerObj.GetComponent<Player>().Init(name,knickname, role, mechanic, knowledge, characterId, teamSpirit, reputation, potential, GameManager.Instance.i_allMood[UnityEngine.Random.Range(0,9)]);
        return playerObj.GetComponent<Player>();
    }
}
