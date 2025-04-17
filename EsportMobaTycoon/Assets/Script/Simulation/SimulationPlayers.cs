using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPlayers : MonoBehaviour
{
    [SerializeField]
    public PlayerFactory playerFactory;
    public List<Player> teamRed;
    public List<Player> teamBlue;
    void Start()
    {
        teamBlue = new List<Player>();
        teamRed = new List<Player>();
        int cmpt = 0;
        foreach (PlayerData data in GameManager.Instance.i_allPlayerData)
        {
            GameManager.Instance.i_allPlayers[cmpt] = playerFactory.CreatePlayerFromData(data);
            if (cmpt < 5)
                teamBlue.Add(GameManager.Instance.i_allPlayers[cmpt]);
            else
                teamRed.Add(GameManager.Instance.i_allPlayers[cmpt]);
            cmpt ++;
        }
        Simulation();
    }

    public void Simulation()
    {
        float blueSum = 0;
        float redSum = 0;
        for (int i = 0; i < teamRed.Count; i++)
        {
            for (int j = 0; j < teamBlue.Count; j++)
                if (teamBlue[i].i_currentRole == teamRed[j].i_currentRole)
                {
                    teamBlue[i].changeLuck(teamRed[j]);
                }
                else if (teamBlue[j].i_currentRole == teamRed[i].i_currentRole)
                {
                    teamRed[i].changeLuck(teamBlue[j]);
                }

        }
        for (int i = 0; i < teamRed.Count; i++)
        {
            blueSum += teamBlue[i].i_totalLuck;
            redSum += teamRed[i].i_totalLuck;
        }
        Debug.Log("b : " + blueSum +" , " + "r : " +redSum);
        float totalsum = blueSum + redSum;

        isWinning(((blueSum/totalsum)*100), (redSum/totalsum)*100);
    }

    void isWinning(float blue, float red)
    {
        float random = Random.Range(0, 100);
        if (red > blue)
        {
            if (random >= 0 && random < red)
            {
                Debug.Log("Blue Win !" + " b : " + blue + " random : " + random  + " r : " + red );
            }
            else
            {
                Debug.Log("Red Win !" + " r : " + red + " random : " + random + " b : " + blue);
            }
        }
        else if (red < blue)
        {
            if (random >= 0 && random < blue)
            {
                Debug.Log("Red Win !" + " r : " + red + " random : " + random + " b : " + blue);
            }
            else
            {
                Debug.Log("Blue Win !" + " b : " + blue + " random : " + random + " r : " + red);
            }
        }
        else
        {
            Debug.LogError("blue equal red");
        }
    }

    void Update()
    {
        
    }
}
