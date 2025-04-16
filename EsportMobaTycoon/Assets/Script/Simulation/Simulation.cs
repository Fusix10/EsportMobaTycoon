using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    void Single(List<Player> allPlayers)
    {
        int teamSize = 5;
        for (int teamStartIndex = 0; teamStartIndex < allPlayers.Count; teamStartIndex += teamSize)
        {
            List<GameManager.Role> availableRoles = System.Enum.GetValues(typeof(GameManager.Role)).Cast<GameManager.Role>().ToList();
            availableRoles = availableRoles.OrderBy(r => UnityEngine.Random.value).ToList();

            for (int i = 0; i < teamSize; i++)
            {
                allPlayers[teamStartIndex + i].i_currentRole = availableRoles[i];
            }
        }
    }

    public void changeScene()
    {
        for (int i = 0; i < 10; i++)
        {
            GameManager.Instance.i_allPlayers.Add(playerfactory.CreateRandomPlayer());
        }

        Single(GameManager.Instance.i_allPlayers);

        for (int i = 0; i < 10; i++)
        {
            PlayerData data = new PlayerData();
            data.SetFromPlayer(GameManager.Instance.i_allPlayers[i]);
            GameManager.Instance.i_allPlayerData.Add(data);
        }
        SceneManager.LoadScene("Simulation");
    }
}
