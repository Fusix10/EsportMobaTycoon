using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPlayers : MonoBehaviour
{
    [SerializeField]
    public PlayerFactory playerFactory;
    void Start()
    {
        int cmpt = 0;
        foreach (PlayerData data in GameManager.Instance.i_allPlayerData)
        {
            GameManager.Instance.i_allPlayers[cmpt] = playerFactory.CreatePlayerFromData(data);
            cmpt ++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
