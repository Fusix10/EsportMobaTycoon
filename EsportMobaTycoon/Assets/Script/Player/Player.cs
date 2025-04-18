using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Player : MonoBehaviour
{
    public string i_name { get; private set; }
    public string i_knickname { get; private set; }
    public int i_role { get; private set; }
    public int i_currentRole { get; private set; }
    public Sprite i_icon { get; protected set; }
    public Mechanic i_mechanic { get; private set; }//
    public Knowledge i_knowledge { get; private set; }//
    public int i_favoriteCharacterId { get; private set; }
    public int i_characterId { get; private set; }
    public float i_totalLuck { get; private set; }
    public  float i_morale { get; private set; }
    public  Lvl i_teamSpirit { get; private set; }
    public int i_reputation { get; private set; }
    public int i_lvl { get; private set; }
    public int i_potentiel { get; private set; }
    public Mood i_mood { get; private set; }

    public void Init//
    (
    string name,
    string knickname,
    int role,
    Mechanic mechanic,
    Knowledge knowledge,
    Character favoriteCharacterId,
    Lvl teamSpirit,
    int reputation,
    int potentiel,
    Mood mood,
    GameManager.Role currentRole,
    Character characterId = null,
    Sprite icon = null
    )
    {
        i_name = name;
        i_knickname = knickname;
        i_role = role;
        i_icon = icon;
        i_mechanic = mechanic;
        i_knowledge = knowledge;
        i_favoriteCharacterId = favoriteCharacterId;
        i_teamSpirit = teamSpirit;
        i_reputation = reputation;
        i_potentiel = potentiel;
        i_mood = mood;
        i_characterId = characterId;
        i_currentRole = currentRole;
        i_morale = 100;



        i_lvl = i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
        i_lvl = i_lvl / 6;

        UpdateTick();

        Debug.Log(i_name + " potentiel = " + i_potentiel); 
        Debug.Log(i_name + " Lvl = " + i_lvl);
    }
    
    public void gainXP(Lvl obj, float Gain)
    {
        if (obj.s_lvl < i_potentiel)
        {
            obj.s_Xp += ((100 - (obj.s_lvl * 5)) * Gain) / 100;
        }

        while (obj.s_Xp > 100)
        {
            obj.s_Xp -= 100;
            obj.s_lvl++;

            if (obj.s_Xp >= 100)
            {
                obj.s_lvl++;
                while (obj.s_Xp > 100)
                {
                    obj.s_Xp -= 100;
                }
            }
        }
    }
    public void Luck()
    {
        float sumLuck = i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl+i_teamSpirit.s_lvl;
        sumLuck *= (i_morale / 100);
        i_totalLuck = sumLuck;
        i_lvl = (int)Mathf.Round((i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl) / 6);
    }

    public void UpdateTick()
    {
        
    }
    private void MoraleEffectOnMorale(bool result, float moraleChange)
    {
        if (result)
        {
            i_morale += moraleChange * i_mood.i_win;
        }
        else
        {
            i_morale += moraleChange * i_mood.i_loose;
        }
    }

    public void ApplyFavoriteCharacterBonus()//
    {
        if (i_characterId == i_favoriteCharacterId)
        {
            i_morale *= 1.05f;
        }
    }

    public void ApplyRolePenalty()
    {
        if (i_currentRole != i_role)
        {
            i_totalLuck *= 0.8f;
        }
    }

    public void SetRole(int newRole)
    {
        i_role = newRole;
    }

}


