using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    TimeSystem i_timeSystem;

    //µEvent MAnager
    EventManager i_eventManager;


    int i_testID = 0;
    List<ActionMother> i_ForTesting;

    GameState i_GameState;

    void Start()
    {
        i_GameState = GameState.Hub;
        i_timeSystem = this.GetComponent<TimeSystem>();

        //µEvent MAnager
        i_eventManager = this.GetComponent<EventManager>();
        i_ForTesting = new List<ActionMother>();
        Instance = this;
    }
    void Update()
    {
        
    }
    public void PassTimeButton()
    {
        i_timeSystem.passingTime();
    }
    public void AddAction()
    {
        ActionMother NewAction = new();
        NewAction.i_id = i_testID;
        i_testID++;
        NewAction.Init();
        Debug.Log("l'Action " + NewAction.i_id + " était créer");
        i_ForTesting.Add(NewAction);
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