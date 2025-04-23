using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnButton : MonoBehaviour
{
    public float i_Xp;
    public int i_Days;
    protected int i_player;

    public void InitPlayer(int player)
    {
        player = i_player;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnEndTimeButton()
    {
        
    }
}
