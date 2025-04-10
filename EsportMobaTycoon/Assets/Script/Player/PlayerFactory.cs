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


    void Start()
    {
       
    }

    public void CreatePlayer()
    {
        string name = nameInput.text;
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
}
