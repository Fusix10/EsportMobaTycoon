using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum Role { ADC, SUPPORT, MIDLANER, JUNGLER, TOPLANER }
    private Role i_role;


    public Role getRole()
    {
        return i_role;
    }

    public void setRole(Role newRole)
    {
       i_role = newRole;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
