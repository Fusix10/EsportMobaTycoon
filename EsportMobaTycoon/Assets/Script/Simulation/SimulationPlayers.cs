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
            {
                if (teamBlue[i].i_currentRole == teamRed[j].i_currentRole)
                {
                    teamBlue[i].changeLuck(teamRed[j]);
                }
                if (teamBlue[j].i_currentRole == teamRed[i].i_currentRole)
                {
                    teamRed[i].changeLuck(teamBlue[j]);
                    Debug.Log("b : " + teamRed[i].i_totalLuck);
                }
            }

        }
        for (int i = 0; i < teamRed.Count; i++)
        {
            blueSum += teamBlue[i].i_totalLuck;
            redSum += teamRed[i].i_totalLuck;
            Debug.Log("b : " + blueSum + " , " + "r : " + redSum);
        }
        
        float totalsum = blueSum + redSum;

        IsWinning(((blueSum/totalsum)*100), (redSum/totalsum)*100);
    }

    void IsWinning(float blue, float red)
    {
        float random = RoundValue(Random.Range(0.0f, 100.0f),10.0f);
        float newBlue = RoundValue(blue, 10.0f);
        float newRed = RoundValue(red, 10.0f);
        if (newRed > newBlue)
        {
            if (random >= 0 && random < newBlue)
            {
                Debug.Log("Case 0 : Blue Win !" + " b : " + newBlue + " random : " + random  + " r : " + newRed );
            }
            else
            {
                Debug.Log("Case 1 : Red Win !" + " r : " + newRed + " random : " + random + " b : " + newBlue);
            }
        }
        else if (newRed < newBlue)
        {
            if (random >= 0 && random < newRed)
            {
                Debug.Log("Case 2 : Red Win !" + " r : " + newRed + " random : " + random + " b : " + newBlue);
            }
            else
            {
                Debug.Log("Case 3 : Blue Win !" + " b : " + newBlue + " random : " + random + " r : " + newRed);
            }
        }
        else
        {
            Debug.LogError("blue equal red");
        }
    }

    public float RoundValue(float num, float precision)
    {
        return Mathf.Floor(num*precision+0.5f)/precision;
    }
    void Update()
    {
        
    }
}
