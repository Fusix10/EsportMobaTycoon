using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Player : MonoBehaviour
{
    public string i_name { get; set; }
    public GameManager.Role i_role;
    public GameManager.Role i_currentRole { get; set; }
    private Sprite i_icon;
    public Mechanic i_mechanic { get; set; }
    public Knowledge i_knowledge { get; set; }
    public Character i_favoriteCharacterId { get; set; }
    public Character i_characterId { get; set; }
    public float i_totalLuck;
    public float i_morale;
    public Lvl i_teamSpirit;
    public int i_reputation;
    public int i_lvl;
    public int i_potentiel;
    public Mood i_mood;

    public void Init//
    (
    string name,
    GameManager.Role role,
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
        float sumLuck = i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
        sumLuck = sumLuck / 6;
        sumLuck *= (i_morale / 100);
        i_totalLuck = sumLuck;
        i_lvl = (int)Mathf.Round(sumLuck);
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

    public void metaLuck()
    {
        if (i_characterId.i_meta)
        {
            i_totalLuck *= 1.05f;
        }
    }

    public void matchUpLuck(Player opppent)
    {
        if (GameManager.Instance.GetMatchUp(i_characterId,opppent.i_characterId).state == 
            GameManager.MatchUp.stateMatchUp.COUNTER)
        {
            i_totalLuck *= 1.3f;
        }
        else if(GameManager.Instance.GetMatchUp(i_characterId, opppent.i_characterId).state ==
            GameManager.MatchUp.stateMatchUp.ISCOUNTERED)
        {
            i_totalLuck *= 0.7f;
        }
    }

    public void changeLuck(Player opponent)
    {
        i_totalLuck = 0f;
        Luck();
        ApplyFavoriteCharacterBonus();
        ApplyRolePenalty();
        metaLuck();
        matchUpLuck(opponent);
    }
}


