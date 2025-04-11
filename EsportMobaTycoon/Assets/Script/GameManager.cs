using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    TimeSystem i_timeSystem;

    //�Event MAnager
    EventManager i_eventManager;


    int i_testID = 0;
    List<ActionMother> i_allActions;

    public List<Mood> i_allMood;
    public Manager_Utilisateur i_manager;
    [SerializeField]
    public List<Player> i_allPlayers;
   

    private GameState i_GameState;

    void Awake()
    {
        i_GameState = GameState.Hub;
        i_timeSystem = this.GetComponent<TimeSystem>();
        i_allActions = new List<ActionMother>();
        i_allPlayers = new List<Player>();
        i_allMood = new List<Mood>();
        i_allMood.Add(new Mood("Competitif", 0.75f, 1.35f));
        i_allMood.Add(new Mood("Methodique", 0.95f, 1.05f));
        i_allMood.Add(new Mood("Instinctif", 0.8f, 1.10f));
        i_allMood.Add(new Mood("Leader", 0.8f, 1.10f));
        i_allMood.Add(new Mood("Introverti", 0.75f, 1.20f));
        i_allMood.Add(new Mood("Toxique", 0.5f, 1.30f));
        i_allMood.Add(new Mood("Stable Emotionnellement", 0.98f, 1.02f));
        i_allMood.Add(new Mood("Tilt Facilement", 0.7f, 1.35f));
        i_allMood.Add(new Mood("Travailleur", 0.6f, 1.4f));
        i_allMood.Add(new Mood("Talent Brut", 0.2f, 1.8f));
        //To Destroy

        //�Event MAnager
        i_eventManager = this.GetComponent<EventManager>();
        Instance = this;


        /*for (int i = 0; i < 5; i++)
        {
            i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayer());
            i_allPlayers[i].transform.position = new Vector3(-0.2574105f+(i*i_allPlayers[i].transform.localScale.x*2), 1.29f, 0.7858481f);
        }*/
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
        Debug.Log("l'Action " + NewAction.i_id + " �tait cr�er");
        i_allActions.Add(NewAction);
    }

    public void setGameState(GameState newState)
    {
        i_GameState = newState;
    }

    public TimeSystem GetItimeSystem()
    {
        return i_timeSystem;
    }
}

public enum GameState
{
    Hub,
    Match,
    Tournaments,
    Result
}