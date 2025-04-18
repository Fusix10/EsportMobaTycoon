using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerSelectedUi : MonoBehaviour
{
    public int i_indexPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void findPlayer(string playerName)
    {
        for (int i = 0; i < GameManager.Instance.i_manager.GetPlayer().Count; i++)
        {
            if(GameManager.Instance.i_manager.GetPlayer()[i].i_name == playerName)
            {
                i_indexPlayer = i;
            }
        }
    }
}
