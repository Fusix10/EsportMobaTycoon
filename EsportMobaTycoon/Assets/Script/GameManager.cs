using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    TimeSystem i_timeSystem;
    int i_testID = 0;
    List<ActionMother> i_allActions;
    List<Player> i_allPlayers;

    GameState i_GameState;

    void Start()
    {
        i_GameState = GameState.Hub;
        i_timeSystem = this.GetComponent<TimeSystem>();
        i_allActions = new List<ActionMother>();
        i_allPlayers = new List<Player>();

        Instance = this;

    }
    void Update()
    {
        
    }
    public void PassTimeButton()
    {
        i_timeSystem.passingTime();
    }
    public void AddAction(ActionMother NewAction)
    {
        NewAction.i_id = i_testID;
        i_testID++;
        NewAction.Init();
        Debug.Log("l'Action " + NewAction.i_id + " était créer");
        i_allActions.Add(NewAction);
    }

    public TimeSystem GetItimeSystem()
    {
        return i_timeSystem;
    }
}

enum GameState
{
    Hub,
    Match,
    Tournaments,
    Result
}