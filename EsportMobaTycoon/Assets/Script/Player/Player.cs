using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    public string i_name { get; private set; }
    private int i_role;
    public int i_currentRole { get; private set; }
    private Sprite i_icon;
    public Mechanic i_mechanic { get; private set; }
    public Knowledge i_knowledge { get; private set; }
    public int i_favoriteCharacterId { get; private set; }
    public int i_characterId { get; private set; }
    private float i_totalLuck;
    private float i_morale;
    private Lvl i_teamSpirit;
    private int i_reputation;
    private int i_lvl;
    private int i_potentiel;
    private Mood i_mood;

    public void Init
    (
    string name,
    int role,
    Mechanic mechanic,
    Knowledge knowledge,
    int favoriteCharacterId,
    Lvl teamSpirit,
    int reputation,
    int potentiel,
    Mood mood,
    int currentRole,
    int characterId = -1,
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

        

        i_lvl = i_mechanic.s_lvlCombo[i_favoriteCharacterId].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
        i_lvl = i_lvl / 6;

        UpdateTick();
    }
    
    public void gainXP(Lvl obj, float Gain)
    {
        if (obj.s_lvl < i_potentiel)
        {
            obj.s_Xp += ((100 - (obj.s_lvl * 5))* Gain)/100;
        }

        if (obj.s_Xp >= 100)
        {
            obj.s_lvl++;
            while(obj.s_Xp > 100)
            {
                obj.s_Xp -= 100;
            }
            
        }
    }


    public void Luck()
    {
        for (int i = 0;i < 7; i++)
        {
            float sumLuck = i_mechanic.s_lvlCombo[i_favoriteCharacterId].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
            sumLuck *= i_morale / 100;
        }
    }

    public void UpdateTick()
    {
        Luck();
    }

    private void MoraleEffectOnMorale(bool result,float moraleChange)
    {
        if(result)
        {
            i_morale += moraleChange * i_mood.i_win;
        }
        else
        {
            i_morale += moraleChange * i_mood.i_loose;
        }

    }

    private void ApplyFavoriteCharacterBonus()
    {
        if (i_characterId == i_favoriteCharacterId)
        {
            i_morale *= 1.05f;
        }
    }

    private void ApplyRolePenalty()
    {
        if (i_currentRole != i_role)
        {
            i_totalLuck *= 0.8f;
        }
    }

}

//TO DO
/*
*Morale affect� par s'il joue son perso favori, par son mood(mood va donner bonus ou malus voir les deux au gain de moral 
*ou � la perte), si le player joueur joue sur un autre role que son role de 
*base il n'a que 80% de sa totalLuck apr�s l'op�ration de Luck(). S'il joue son perso pr�f�r� il va gagner 5% de morale apr�s 
*Luck(). On laisse r�putation de c�t�. Faire plusieurs petites fonctions 
*qui seront appel�es dans UpdateTick().
*
*
*/


