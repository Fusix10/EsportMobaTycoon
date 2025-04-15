using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Simulation : MonoBehaviour
{
    public PlayerFactory playerfactory;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void changeScene()
    {
        for (int i = 0; i < 10; i++)
        {
            GameManager.Instance.i_allPlayers.Add(playerfactory.CreateRandomPlayer());
            PlayerData data = new PlayerData();
            data.SetFromPlayer(GameManager.Instance.i_allPlayers[i]);
            GameManager.Instance.i_allPlayerData.Add(data);
        }

        SceneManager.LoadScene("Simulation");
    }
}
