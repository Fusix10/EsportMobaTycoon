using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;
using static Player;

public class PlayerFactory : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Image characterImage;
    public Slider teamSpiritXpSlider;
    public Slider teamSpiritLvlSlider;
    public Slider levelSlider;
    public Slider xpSlider;
    public Slider roleSlider;
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
    public Slider characterSlider;
    public TMP_Dropdown moodDropdown;
    public GameObject playerPrefab;
    public Material baseMaterial;


    void Start()
    {
       
    }

    public void CreatePlayer()
    {
        string name = nameInput.text;
        Lvl teamSpirit;
        teamSpirit.s_Xp = teamSpiritXpSlider.value;
        teamSpirit.s_lvl = (int)teamSpiritLvlSlider.value;
        int xp = (int)xpSlider.value;
        int roleId = (int)roleSlider.value;
        int potential = (int)potentialSlider.value;
        int reputation = (int)reputationSlider.value;
        Sprite image = characterImage.sprite;
        Mood mood = (Mood)moodDropdown.value;
        Mechanic mechanic;
        mechanic.s_reflexe.s_lvl = (int)reflexelvlSlider.value;
        mechanic.s_reflexe.s_Xp = (int)reflexexpSlider.value;
        mechanic.s_stamina.s_Xp = (int)staminaxpSlider.value;
        mechanic.s_stamina.s_lvl = (int)staminalvlSlider.value; 
        mechanic.s_lvlCombo.s_Xp = (int)comboxpSlider.value;
        mechanic.s_lvlCombo.s_lvl = (int)combolvlSlider.value;
        Knowledge knowledge;
        knowledge.s_objective.s_lvl = (int)objectivelvlSlider.value;
        knowledge.s_objective.s_Xp = (int)objectivexpSlider.value;
        knowledge.s_placement.s_lvl = (int)placementlvlSlider.value;
        knowledge.s_placement.s_Xp = (int)placementxpSlider.value;
        knowledge.s_teamFight.s_lvl = (int)teamFightlvlSlider.value;
        knowledge.s_teamFight.s_Xp = (int)teamFightxpSlider.value;
        int characterId = (int)characterSlider.value;

        GameObject playerObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playerObj.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), 1f, UnityEngine.Random.Range(-5f, 5f));

        if (image != null && baseMaterial != null)
        {
            Material playerMaterial = new Material(baseMaterial);
            playerMaterial.mainTexture = image.texture;
            playerObj.GetComponent<Renderer>().material = playerMaterial;
        }

     
        Player playerComponent = playerObj.AddComponent<Player>();
        playerComponent.Init(name, roleId, mechanic, knowledge, characterId, teamSpirit, reputation, potential, image);
    }


    public Player CreateRandomPlayer()
    {
        string name = "Joueur_" + UnityEngine.Random.Range(1, 1000);
        int role = UnityEngine.Random.Range(0, 5); 
        int potential = UnityEngine.Random.Range(0, 5);
        int reputation = UnityEngine.Random.Range(0, 100);
        int characterId = UnityEngine.Random.Range(0, 5);

        Sprite icon = characterImage.sprite;

        Player.Lvl teamSpirit = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 5), s_Xp = UnityEngine.Random.Range(0f, 100f) };

        Player.Mechanic mechanic = new Player.Mechanic
        {
            s_lvlCombo = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 10), s_Xp = UnityEngine.Random.Range(0f, 100f) },
            s_stamina = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 10), s_Xp = UnityEngine.Random.Range(0f, 100f) },
            s_reflexe = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 10), s_Xp = UnityEngine.Random.Range(0f, 100f) }
        };

        Player.Knowledge knowledge = new Player.Knowledge
        {
            s_objective = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 10), s_Xp = UnityEngine.Random.Range(0f, 100f) },
            s_placement = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 10), s_Xp = UnityEngine.Random.Range(0f, 100f) },
            s_teamFight = new Player.Lvl { s_lvl = UnityEngine.Random.Range(1, 10), s_Xp = UnityEngine.Random.Range(0f, 100f) }
        };

        GameObject playerObj = new GameObject(name);
        Player playerComponent = playerObj.AddComponent<Player>();
        playerComponent.Init(name, role, mechanic, knowledge, characterId, teamSpirit, reputation, potential, icon);

        return playerComponent;

    }
}
