using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    TimeSystem i_timeSystem;
    int i_testID = 0;
    List<ActionMother> i_allActions;

    [SerializeField]
    List<Player> i_allPlayers;

    GameState i_GameState;

    void Start()
    {
        i_GameState = GameState.Hub;
        i_timeSystem = this.GetComponent<TimeSystem>();
        i_allActions = new List<ActionMother>();

        Instance = this;

        Mechanic mechanic = new Mechanic();
        mechanic.s_stamina = new Lvl(0,0);
        mechanic.s_reflexe = new Lvl(0,0);
        mechanic.s_lvlCombo.Add(3, new Lvl(0, 0));

        Knowledge knowledge = new Knowledge();
        knowledge.s_teamFight = new Lvl(0, 0);
        knowledge.s_objective = new Lvl(0, 0);
        knowledge.s_placement = new Lvl(0, 0);
        i_allPlayers[0].Init("Dinosaure", 2, mechanic, knowledge, 3, new Lvl(0, 0), 50,5,Player.Mood.DEPRESSED, 2);
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