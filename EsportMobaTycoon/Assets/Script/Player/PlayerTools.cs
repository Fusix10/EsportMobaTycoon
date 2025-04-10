using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools
{
}

public class Lvl
{
    public int s_lvl = new();
    public float s_Xp = new();
    public Lvl(int lvl, float xp)
    {
        s_lvl = lvl;
        s_Xp = xp;
    }
}

public class Mechanic
{
    public Dictionary<int,Lvl> s_lvlCombo = new();
    public Lvl s_stamina = new(0,0);
    public Lvl s_reflexe = new(0,0);
}

public class Knowledge
{
    public Lvl s_placement = new(0,0);
    public Lvl s_teamFight = new(0,0);
    public Lvl s_objective = new(0,0);
}
