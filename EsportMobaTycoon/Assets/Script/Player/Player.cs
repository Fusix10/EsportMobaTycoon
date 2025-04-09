using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class Lvl
{
    public int s_lvl;
    public float s_Xp;
}
public struct Mechanic
{
    public Lvl s_lvlCombo;
    public Lvl s_stamina;
    public Lvl s_reflexe;
}
public struct Knowledge
{
    public Lvl s_placement;
    public Lvl s_teamFight;
    public Lvl s_objective;
}
public class Player : MonoBehaviour
{
    public enum Mood { DEPRESSED, SAD, NORMAL, HAPPY, OVERHELMED }


    public string i_name;
    public int i_role;
    public Sprite i_icon;
    public Mechanic i_mechanic;
    public Knowledge i_knowledge;
    public int i_favoriteCharacterId;
    public float i_totalLuck;
    public float i_morale;
    public Lvl i_teamSpirit;
    public int i_reputation;
    public int i_lvl;
    public int i_potentiel;

    public int testlvlEndurance;
    public float testxpEndurance;




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

        i_lvl = i_mechanic.s_lvlCombo.s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
        i_lvl = i_lvl / 6;

        UpdateTick();
    }
    
    public void gainXP(Lvl obj, float Gain)
    {
        Debug.Log("here is GainXP1 " + obj.s_lvl + " hooo " + obj.s_Xp + "gain " + Gain);
        if (obj.s_lvl < i_potentiel)
        {
            obj.s_Xp += ((100 - (obj.s_lvl * 5))* Gain)/100;
        }
        Debug.Log("here is GainXP2 " + obj.s_lvl + " hooo " + obj.s_Xp);

        if (obj.s_Xp >= 100)
        {
            obj.s_lvl++;
            while(obj.s_Xp > 100)
            {
                obj.s_Xp -= 100;
                Debug.Log("here is GainXP3 " + obj.s_lvl + " hooo " + obj.s_Xp);
            }
            
        }
    }


    public void Luck()
    {
        for (int i = 0;i < 7; i++)
        {
            float sumLuck = i_mechanic.s_lvlCombo.s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
            sumLuck *= i_morale / 100;
        }
    }

    public void UpdateTick()
    {
        Luck();
        testlvlEndurance = this.i_mechanic.s_stamina.s_lvl;
        testxpEndurance = this.i_mechanic.s_stamina.s_Xp;
    }

}

//TO DO
/*
*Morale affecté par s'il joue son perso favori, par son mood(mood va donner bonus ou malus voir les deux au gain de moral 
*ou à la perte), si le player joueur joue sur un autre role que son role de 
*base il n'a que 80% de sa totalLuck après l'opération de Luck(). S'il joue son perso préféré il va gagner 5% de morale après 
*Luck(). On laisse réputation de côté. Faire plusieurs petites fonctions 
*qui seront appelées dans UpdateTick().
*
*
*/


