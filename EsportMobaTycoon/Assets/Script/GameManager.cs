using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    TimeSystem i_timeSystem;

    //�Event MAnager
    [SerializeField]public EventManager i_eventManager;

    //PopUpManager 
    [SerializeField] public PopUpManager i_popupManager;

    int i_testID = 0;
    List<ActionMother> i_allActions;
    public List<Mood> i_allMood;
    public Manager_Utilisateur i_manager;
    [SerializeField]
    public List<Player> i_allPlayers;
   

    public GameState i_GameState;

    private Dictionary<GameState, string> i_stateToScene = new Dictionary<GameState, string>();

    void Awake()
    {
        Debug.Log("[GameManager] Awake() démarré sur l’instance " + this.GetInstanceID());
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

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

        //�PopUp MAnager
        i_popupManager = this.GetComponent<PopUpManager>(); ;


        //J'ai fait des tests, il faudra remettre le code mais pour l'instant cette partie empeche le changement de scene, probablement parce que je n'ai pas les joueurs.
        /*for (int i = 0; i < 5; i++)
        {
            i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayer());
            i_allPlayers[i].transform.position = new Vector3(-0.2574105f+(i*i_allPlayers[i].transform.localScale.x*2), 1.29f, 0.7858481f);
        }*/

        i_stateToScene.Add(GameState.Hub, "Hub");
        i_stateToScene.Add(GameState.Hub1, "Hub1");
        i_stateToScene.Add(GameState.Hub2, "Hub2");
        i_stateToScene.Add(GameState.Hub3, "Hub3");
        i_stateToScene.Add(GameState.Match, "Match");
        i_stateToScene.Add(GameState.Tournaments, "Tournaments");
        i_stateToScene.Add(GameState.Result, "Result");
        string allMappings = string.Join(
    ", ",
    i_stateToScene.Select(kv => kv.Key + "→" + kv.Value)
);
        Debug.Log("[GameManager] Mappings = " + allMappings);
    }
    void Update()
    {
        
    }
    public void PassTimeButton()
    {
        i_timeSystem.passingTime();
        i_eventManager.Churn();
    }
    public void AddAction(ActionMother NewAction)
    {
        NewAction.i_id = i_testID;
        i_testID++;
        NewAction.Init();
        Debug.Log("l'Action " + NewAction.i_id + " est creer");
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

    public void LoadSceneForCurrentState()
    {
        Debug.Log($"[LoadScene] État courant = {i_GameState}");

        if (i_GameState == GameState.Hub)
        {
            Debug.Log("[LoadScene] On est encore en Hub, on ne change pas de scène.");
            return;
        }

        if (i_stateToScene.TryGetValue(i_GameState, out string sceneName))
        {
            Debug.Log("Chargement de la scène " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Aucune scène n'est associée à l'état " + i_GameState);
        }
    }
}

public enum GameState
{
    Hub,
    Hub1,
    Hub2,
    Hub3,
    Match,
    Tournaments,
    Result
}
[System.Serializable]
public class GameData
{
    public PlayerData playerData;
}
 
public class PlayerData
{
    public int i_id;
}

