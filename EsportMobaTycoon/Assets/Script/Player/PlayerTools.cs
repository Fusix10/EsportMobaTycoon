using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools
{

}

public class Mood
{
    public string i_moodName;
    public float i_win;
    public float i_loose;
    public Mood(string name, float win, float loose)
    {
        i_moodName = name;
        i_win = win;
        i_loose = loose;
    }
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
