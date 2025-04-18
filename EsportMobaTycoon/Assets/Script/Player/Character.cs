using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character 
{
    public string i_name;
    public int i_Id;
    public Sprite i_icon;
    public bool i_meta;
    public int i_cohesion;
    public int i_roleId;

    public Character(string name, int id, bool meta, int cohesion, int roleId, Sprite icon = null)
    {
        i_name = name;
        i_Id = id;
        i_icon = icon;
        i_meta = meta;
        i_cohesion = cohesion;
        i_roleId = roleId;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
