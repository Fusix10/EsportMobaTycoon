using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Mood { DEPRESSED, SAD, NORMAL, HAPPY, OVERHELMED }
    public struct Lvl
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

    public void Init
    (    
    string name,
    int role,
    Mechanic mechanic,
    Knowledge knowledge,
    int favoriteCharacterId,
    float morale,
    Lvl teamSpirit,
    int reputation,
    int potentiel,
    Sprite icon
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
    }
    
    public void gainXP(Lvl obj, float Gain)
    {
        for (int i = 0; i < i_potentiel; i++)
        {
            obj.s_Xp += (Gain * (100 - (i * 5)));
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
    }

}

//TO DO
/*
*Morale affecté par s'il joue son perso favori, par son mood(mood va donner bonus ou malus voir les deux au gain de moral ou à la perte), si le player joueur joue sur un autre role que son role de 
*base il n'a que 80% de sa totalLuck après l'opération de Luck(). S'il joue son perso préféré il va gagner 5% de morale après Luck(). On laisse réputation de côté. Faire plusieurs petites fonctions 
*qui seront appelées dans UpdateTick().
*
*
*/


