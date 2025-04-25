using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Simulation : MonoBehaviour
{
    public PlayerFactory i_playerfactory;
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
}
