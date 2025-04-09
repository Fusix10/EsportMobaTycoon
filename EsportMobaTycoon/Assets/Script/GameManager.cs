using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    TimeSystem i_timeSystem;
    int i_testID = 0;
    List<ActionMother> i_ForTesting;

    [SerializeField]
    Player i_ForTestingPlayer;

    GameState i_GameState;

    void Start()
    {
        i_GameState = GameState.Hub;
        i_timeSystem = this.GetComponent<TimeSystem>();
        i_ForTesting = new List<ActionMother>();

        Instance = this;
        Mechanic mechanic = new();
        mechanic.s_stamina.s_lvl = 1;
        mechanic.s_reflexe.s_lvl = 1;
        mechanic.s_lvlCombo.s_lvl = 1;
        mechanic.s_stamina.s_Xp = 50;
        mechanic.s_reflexe.s_Xp = 50;
        mechanic.s_lvlCombo.s_Xp = 50;

        Knowledge know = new();
        know.s_objective.s_lvl = 1;
        know.s_placement.s_lvl = 1;
        know.s_teamFight.s_lvl = 1;
        know.s_objective.s_Xp = 50;
        know.s_placement.s_Xp = 50;
        know.s_teamFight.s_Xp = 50;

        Lvl TeamSpirit = new Lvl();
        TeamSpirit.s_lvl = 1;
        TeamSpirit.s_Xp = 50;
        i_ForTestingPlayer.Init("Lea", 3, mechanic, know, 2, TeamSpirit, 50, 5);
    }
    void Update()
    {
        
    }
    public void PassTimeButton()
    {
        i_timeSystem.passingTime();
    }
    public void AddAction(int Time)
    {
        TestTimeEnd NewAction = new();
        NewAction.i_id = i_testID;
        i_testID++;
        NewAction.Init();
        NewAction.setTimer(Time);
        NewAction.InitPlayer(i_ForTestingPlayer);
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