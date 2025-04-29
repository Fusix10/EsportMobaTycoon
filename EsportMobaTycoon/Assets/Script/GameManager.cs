using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.MPE;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TimeSystem i_timeSystem { get; private set; }

    // Event MAnager
    [SerializeField] public EventManager i_eventManager;

    //PopUpManager 
    [SerializeField] public PopUpManager i_popupManager;

    int i_testID = 0;
    List<ActionMother> i_allActions;
    public List<Mood> i_allMood;
    public Manager_Utilisateur i_manager;
    [SerializeField]
    public List<Player> i_allPlayers;
    public List<Character> i_allCharacters;
    [SerializeField] public List<MatchUp> i_allMatchUps;
    public List<PlayerData> i_allPlayerData;
    public List<TeamData> i_allTeam;
    public Circuit i_circuit;

    public Player i_buddy;

    public delegate void SponsorSet();
    public event SponsorSet OnSponsorSet;


    public PlayerFactory i_playerFactory { get; private set; }

    public GameState i_GameState;
    public GameState i_lastGameState;

    private Dictionary<GameState, string> i_stateToScene = new Dictionary<GameState, string>();


    [Header("Tous les sprites")]
    public SkinGroupData i_skins;

    public class MatchUp
    {
        public enum stateMatchUp {COUNTER, ISCOUNTERED, NOTHING}
        public Character firstCharacter;
        public Character secondCharacter;
        public stateMatchUp state;
    }

    public enum NameCharacter {Gragas, Jayce, Jax, Sion,Viego, LeeSin,Nidalee, JarvanIV, Yasuo, Azir, Ahri, Akali, Jinx, Ezreal, MissFortune
    , Draven, Lulu, Thresh, Lux, Braum}
    public enum Role {TOPLANER, JUNGLER, MIDLANER, ADC, SUPPORT, NONE }

    private void Awake()
    {
        Debug.Log("[GameManager] Awake() démarré sur l’instance " + this.GetInstanceID());
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


        i_playerFactory = GetComponent<PlayerFactory>();

        i_timeSystem = this.GetComponent<TimeSystem>();
        i_allActions = new List<ActionMother>();
        i_allPlayers = new List<Player>();
        i_allMatchUps = new List<MatchUp>();
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
        i_allCharacters = new List<Character>();
        i_allCharacters.Add(new Character("Gragas",0,true,9,4));
        i_allCharacters.Add(new Character("Jayce",1,false,5,4));
        i_allCharacters.Add(new Character("Jax",2,false,6,4));
        i_allCharacters.Add(new Character("Sion",3,false,3,4));
        i_allCharacters.Add(new Character("Viego",4,true,4,2));
        i_allCharacters.Add(new Character("LeeSin",5,false,10,2));
        i_allCharacters.Add(new Character("Nidalee",6,false,5,2));
        i_allCharacters.Add(new Character("JarvanIV",7,true,7,2));
        i_allCharacters.Add(new Character("Yasuo",8,true,2,3));
        i_allCharacters.Add(new Character("Azir",9,false,6,3));
        i_allCharacters.Add(new Character("Ahri",10,true,11,3));
        i_allCharacters.Add(new Character("Akali",11,false,5,3));
        i_allCharacters.Add(new Character("Jinx",12,true,12,0));
        i_allCharacters.Add(new Character("Ezreal",13,false,8,0));
        i_allCharacters.Add(new Character("MissFortune",14,true,10,0));
        i_allCharacters.Add(new Character("Draven",15,true,1,0));
        i_allCharacters.Add(new Character("Lulu",16,false,13,1));
        i_allCharacters.Add(new Character("Thresh",17,true,4,1));
        i_allCharacters.Add(new Character("Lux",18,false,12,1));
        i_allCharacters.Add(new Character("Braum",19,true,14,1));
        //To Destroy

        i_eventManager = this.GetComponent<EventManager>();
        AddMatchUp(i_allCharacters[17], i_allCharacters[4], MatchUp.stateMatchUp.COUNTER); //Thresh vs Viego
        AddMatchUp(i_allCharacters[3], i_allCharacters[8], MatchUp.stateMatchUp.COUNTER); //Sion vs Viego
        AddMatchUp(i_allCharacters[11], i_allCharacters[6], MatchUp.stateMatchUp.COUNTER); //Akali vs Nidalee
        AddMatchUp(i_allCharacters[16], i_allCharacters[17], MatchUp.stateMatchUp.COUNTER); //Lulu vs Thresh
        AddMatchUp(i_allCharacters[13], i_allCharacters[16], MatchUp.stateMatchUp.COUNTER); //Ezreal vs Lulu
        AddMatchUp(i_allCharacters[2], i_allCharacters[18], MatchUp.stateMatchUp.COUNTER); //Jax vs Lux
        AddMatchUp(i_allCharacters[19], i_allCharacters[2], MatchUp.stateMatchUp.COUNTER); //Braum vs Jax
        AddMatchUp(i_allCharacters[5], i_allCharacters[17], MatchUp.stateMatchUp.ISCOUNTERED); //LeeSin vs Thresh
        AddMatchUp(i_allCharacters[0], i_allCharacters[1], MatchUp.stateMatchUp.ISCOUNTERED); //Gragas vs Jayce
        AddMatchUp(i_allCharacters[0], i_allCharacters[17], MatchUp.stateMatchUp.ISCOUNTERED); //Gragas vs Thresh
        AddMatchUp(i_allCharacters[12], i_allCharacters[14], MatchUp.stateMatchUp.ISCOUNTERED); //Jinx vs MF
        AddMatchUp(i_allCharacters[12], i_allCharacters[17], MatchUp.stateMatchUp.ISCOUNTERED); //Jinx vs Thresh
        AddMatchUp(i_allCharacters[10], i_allCharacters[12], MatchUp.stateMatchUp.ISCOUNTERED); //Ahri vs Jinx
        AddMatchUp(i_allCharacters[10], i_allCharacters[3], MatchUp.stateMatchUp.ISCOUNTERED); //Ahri vs Sion
        AddMatchUp(i_allCharacters[4], i_allCharacters[8], MatchUp.stateMatchUp.ISCOUNTERED); //Viego vs Yasuo 
        AddMatchUp(i_allCharacters[0], i_allCharacters[4], MatchUp.stateMatchUp.ISCOUNTERED); //Gragas vs Viego 
        AddMatchUp(i_allCharacters[9], i_allCharacters[0], MatchUp.stateMatchUp.ISCOUNTERED); //Azir vs Gragas
        AddMatchUp(i_allCharacters[9], i_allCharacters[16], MatchUp.stateMatchUp.ISCOUNTERED); //Azir vs Lulu
        AddMatchUp(i_allCharacters[7], i_allCharacters[6], MatchUp.stateMatchUp.ISCOUNTERED); //JarvanIV vs Nidalee
        AddMatchUp(i_allCharacters[11], i_allCharacters[19], MatchUp.stateMatchUp.ISCOUNTERED); //Akali vs Braum
        AddMatchUp(i_allCharacters[11], i_allCharacters[12], MatchUp.stateMatchUp.ISCOUNTERED); //Akali vs Jinx
        AddMatchUp(i_allCharacters[15], i_allCharacters[18], MatchUp.stateMatchUp.ISCOUNTERED); //Draven vs Lux
        AddMatchUp(i_allCharacters[14], i_allCharacters[8], MatchUp.stateMatchUp.NOTHING); //MF vs Yasuo
        AddMatchUp(i_allCharacters[14], i_allCharacters[4], MatchUp.stateMatchUp.NOTHING); //MF vs Viego
        AddMatchUp(i_allCharacters[14], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); //MF vs Thresh
        AddMatchUp(i_allCharacters[11], i_allCharacters[2], MatchUp.stateMatchUp.NOTHING); //Akali vs Jax
        AddMatchUp(i_allCharacters[2], i_allCharacters[5], MatchUp.stateMatchUp.NOTHING); //Jax vs LeeSin
        AddMatchUp(i_allCharacters[0], i_allCharacters[3], MatchUp.stateMatchUp.NOTHING); //Gragas vs Sion
        AddMatchUp(i_allCharacters[10], i_allCharacters[0], MatchUp.stateMatchUp.NOTHING); //Ahri vs Gragas
        AddMatchUp(i_allCharacters[12], i_allCharacters[3], MatchUp.stateMatchUp.NOTHING); //Jinx vs Sion
        AddMatchUp(i_allCharacters[12], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); //Jinx vs Lulu
        AddMatchUp(i_allCharacters[19], i_allCharacters[3], MatchUp.stateMatchUp.NOTHING); //Braum vs Sion
        AddMatchUp(i_allCharacters[3], i_allCharacters[8], MatchUp.stateMatchUp.NOTHING); //Sion vs Yasuo
        AddMatchUp(i_allCharacters[1], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); //Jayce vs Lux
        AddMatchUp(i_allCharacters[1], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); //Jayce vs MF
        AddMatchUp(i_allCharacters[1], i_allCharacters[5], MatchUp.stateMatchUp.NOTHING); //Jayce vs LeeSin
        AddMatchUp(i_allCharacters[1], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); //Jayce vs Thresh
        AddMatchUp(i_allCharacters[19], i_allCharacters[13], MatchUp.stateMatchUp.NOTHING); //Braum vs Ezreal
        AddMatchUp(i_allCharacters[16], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); //Lulu vs MF
        AddMatchUp(i_allCharacters[16], i_allCharacters[3], MatchUp.stateMatchUp.NOTHING); //Lulu vs Sion
        AddMatchUp(i_allCharacters[13], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); //Ezreal vs Braum
        AddMatchUp(i_allCharacters[6], i_allCharacters[8], MatchUp.stateMatchUp.NOTHING); //Nidalee vs Yasuo
        AddMatchUp(i_allCharacters[11], i_allCharacters[4], MatchUp.stateMatchUp.NOTHING); //Akali vs Viego
        AddMatchUp(i_allCharacters[11], i_allCharacters[7], MatchUp.stateMatchUp.NOTHING); //Akali vs JarvanIV
        AddMatchUp(i_allCharacters[11], i_allCharacters[6], MatchUp.stateMatchUp.NOTHING); //Akali vs Nidalee
        AddMatchUp(i_allCharacters[15], i_allCharacters[7], MatchUp.stateMatchUp.NOTHING); //Draven vs JarvanIV
        AddMatchUp(i_allCharacters[15], i_allCharacters[12], MatchUp.stateMatchUp.NOTHING); //Draven vs Jinx
        AddMatchUp(i_allCharacters[15], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); //Draven vs MF
        AddMatchUp(i_allCharacters[15], i_allCharacters[5], MatchUp.stateMatchUp.NOTHING); //Draven vs LeeSin
        AddMatchUp(i_allCharacters[15], i_allCharacters[8], MatchUp.stateMatchUp.NOTHING); //Draven vs Yasuo
        AddMatchUp(i_allCharacters[15], i_allCharacters[6], MatchUp.stateMatchUp.NOTHING); //Draven vs Nidalee
        AddMatchUp(i_allCharacters[7], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); //JarvanIV vs Lulu
        AddMatchUp(i_allCharacters[7], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); //JarvanIV vs Lux
        AddMatchUp(i_allCharacters[7], i_allCharacters[8], MatchUp.stateMatchUp.NOTHING); //JarvanIV vs Yasuo
        AddMatchUp(i_allCharacters[5], i_allCharacters[4], MatchUp.stateMatchUp.NOTHING); //LeeSin vs Viego
        AddMatchUp(i_allCharacters[9], i_allCharacters[5], MatchUp.stateMatchUp.NOTHING); //Azir vs LeeSin
        AddMatchUp(i_allCharacters[13], i_allCharacters[5], MatchUp.stateMatchUp.NOTHING); //Ezreal vs LeeSin
        AddMatchUp(i_allCharacters[10], i_allCharacters[11], MatchUp.stateMatchUp.NOTHING); // Ahri vs Akali
        AddMatchUp(i_allCharacters[10], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Ahri vs Braum
        AddMatchUp(i_allCharacters[10], i_allCharacters[15], MatchUp.stateMatchUp.NOTHING); // Ahri vs Draven
        AddMatchUp(i_allCharacters[10], i_allCharacters[13], MatchUp.stateMatchUp.NOTHING); // Ahri vs Ezreal
        AddMatchUp(i_allCharacters[10], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); // Ahri vs Lulu
        AddMatchUp(i_allCharacters[10], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Ahri vs Lux
        AddMatchUp(i_allCharacters[10], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); // Ahri vs Miss Fortune
        AddMatchUp(i_allCharacters[10], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); // Ahri vs Thresh
        AddMatchUp(i_allCharacters[11], i_allCharacters[15], MatchUp.stateMatchUp.NOTHING); // Akali vs Draven
        AddMatchUp(i_allCharacters[11], i_allCharacters[13], MatchUp.stateMatchUp.NOTHING); // Akali vs Ezreal
        AddMatchUp(i_allCharacters[11], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); // Akali vs Lulu
        AddMatchUp(i_allCharacters[11], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Akali vs Lux
        AddMatchUp(i_allCharacters[11], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); // Akali vs Miss Fortune
        AddMatchUp(i_allCharacters[11], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); // Akali vs Thresh
        AddMatchUp(i_allCharacters[9], i_allCharacters[10], MatchUp.stateMatchUp.NOTHING); // Azir vs Ahri
        AddMatchUp(i_allCharacters[9], i_allCharacters[11], MatchUp.stateMatchUp.NOTHING); // Azir vs Akali
        AddMatchUp(i_allCharacters[9], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Azir vs Braum
        AddMatchUp(i_allCharacters[9], i_allCharacters[15], MatchUp.stateMatchUp.NOTHING); // Azir vs Draven
        AddMatchUp(i_allCharacters[9], i_allCharacters[13], MatchUp.stateMatchUp.NOTHING); // Azir vs Ezreal
        AddMatchUp(i_allCharacters[9], i_allCharacters[12], MatchUp.stateMatchUp.NOTHING); // Azir vs Jinx
        AddMatchUp(i_allCharacters[9], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Azir vs Lux
        AddMatchUp(i_allCharacters[9], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); // Azir vs Miss Fortune
        AddMatchUp(i_allCharacters[9], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); // Azir vs Thresh
        AddMatchUp(i_allCharacters[15], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Draven vs Braum
        AddMatchUp(i_allCharacters[15], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); // Draven vs Lulu
        AddMatchUp(i_allCharacters[15], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); // Draven vs Thresh
        AddMatchUp(i_allCharacters[13], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Ezreal vs Braum
        AddMatchUp(i_allCharacters[13], i_allCharacters[15], MatchUp.stateMatchUp.NOTHING); // Ezreal vs Draven
        AddMatchUp(i_allCharacters[13], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Ezreal vs Lux
        AddMatchUp(i_allCharacters[13], i_allCharacters[14], MatchUp.stateMatchUp.NOTHING); // Ezreal vs Miss Fortune
        AddMatchUp(i_allCharacters[13], i_allCharacters[17], MatchUp.stateMatchUp.NOTHING); // Ezreal vs Thresh
        AddMatchUp(i_allCharacters[16], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Lulu vs Braum
        AddMatchUp(i_allCharacters[16], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Lulu vs Lux
        AddMatchUp(i_allCharacters[18], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Lux vs Braum
        AddMatchUp(i_allCharacters[14], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Miss Fortune vs Braum
        AddMatchUp(i_allCharacters[14], i_allCharacters[16], MatchUp.stateMatchUp.NOTHING); // Miss Fortune vs Lulu
        AddMatchUp(i_allCharacters[14], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Miss Fortune vs Lux
        AddMatchUp(i_allCharacters[17], i_allCharacters[19], MatchUp.stateMatchUp.NOTHING); // Thresh vs Braum
        AddMatchUp(i_allCharacters[17], i_allCharacters[18], MatchUp.stateMatchUp.NOTHING); // Thresh vs Lux

        // PopUp MAnager
        i_popupManager = this.GetComponent<PopUpManager>();

        Instance = this;

        i_manager = new();

        /*for (int i = 0; i < 5; i++)
        {
            i_manager.AddPlayer(this.GetComponent<PlayerFactory>().CreateRandomPlayer());
            i_manager.GetPlayer()[i].transform.position = new Vector3(-0.2574105f+(i*i_manager.GetPlayer()[i].transform.localScale.x*2), 1.29f, 0.7858481f);
        }*/
        
        Knowledge knowledge = new Knowledge();
        knowledge.s_teamFight = new Lvl(0, 0);
        knowledge.s_objective = new Lvl(0, 0);
        knowledge.s_placement = new Lvl(0, 0);
        //J'ai fait des tests, il faudra remettre le code mais pour l'instant cette partie empeche le changement de scene, probablement parce que je n'ai pas les joueurs.
        /*for (int i = 0; i < 5; i++)
        {
            i_allPlayers.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayer());
            i_allPlayers[i].transform.position = new Vector3(-0.2574105f+(i*i_allPlayers[i].transform.localScale.x*2), 1.29f, 0.7858481f);
        }*/

        i_stateToScene.Add(GameState.Menu, "Menu");
        i_stateToScene.Add(GameState.CutScene, "CutScene");
        i_stateToScene.Add(GameState.Avatar, "Avatar");
        i_stateToScene.Add(GameState.Logo, "Logo");
        i_stateToScene.Add(GameState.Buddy, "Buddy");
        i_stateToScene.Add(GameState.Hiring, "Hiring");
        i_stateToScene.Add(GameState.Circuit, "Circuit");
        i_stateToScene.Add(GameState.Hub, "Hub");
        i_stateToScene.Add(GameState.Hub3, "Hub3");
        i_stateToScene.Add(GameState.Match, "Match");
        i_stateToScene.Add(GameState.Tournaments, "Tournaments");
        i_stateToScene.Add(GameState.Result, "Result");
        i_stateToScene.Add(GameState.OptionScreen, "OptionScreen");
        string allMappings = string.Join(
    ", ",
    i_stateToScene.Select(kv => kv.Key + "→" + kv.Value)

);
        Debug.Log("[GameManager] Mappings = " + allMappings);
    }

    public Role GetRandomRole()
    {
        Role[] allRoles = (Role[])System.Enum.GetValues(typeof(Role));
        int randomIndex = UnityEngine.Random.Range(0, allRoles.Length);
        return allRoles[randomIndex];
    }

    public void PassTimeButton()
    {
        i_timeSystem.passingTime();
        i_eventManager?.Churn();
    }
    public void AddAction(ActionMother NewAction)
    {
        NewAction.i_id = i_testID;
        i_testID++;
        NewAction.Init();
        Debug.Log("l'Action " + NewAction.i_id + " est creer");
        i_allActions.Add(NewAction);

        if (NewAction is SponsorEvent) OnSponsorSet?.Invoke();
    }

    public void setGameState(GameState newState)
    {
        i_GameState = newState;
    }

    public TimeSystem GetItimeSystem()
    {
        return i_timeSystem;
    }

    private void AddMatchUp(Character first, Character second, MatchUp.stateMatchUp state)
    {
        MatchUp matchUp = new MatchUp
        {
            firstCharacter = first,
            secondCharacter = second,
            state = state
        };
        i_allMatchUps.Add(matchUp);
    }

    public MatchUp GetMatchUp(Character char1, Character char2)
    {
        MatchUp matchUp = i_allMatchUps.FirstOrDefault(mu =>
        (mu.firstCharacter == char1 && mu.secondCharacter == char2) ||
        (mu.firstCharacter == char2 && mu.secondCharacter == char1));

        if (matchUp == null)
        {
            return new MatchUp
            {
                firstCharacter = char1,
                secondCharacter = char2,
                state = MatchUp.stateMatchUp.NOTHING
            };
        }

        return matchUp;
    }

    public void ChangeState(int gameState)
    {
        i_lastGameState = i_GameState;
        i_GameState = (GameState)gameState;
        LoadSceneForCurrentState();
    }

    public void GoLastState()
    {
        ChangeState((int)i_lastGameState);
    }

    public void LoadSceneForCurrentState()
    {
        Debug.Log($"[LoadScene] État courant = {i_GameState}");

        /*if (i_GameState == GameState.Hub)
        {
            Debug.Log("[LoadScene] On est encore en Hub, on ne change pas de scène.");
            return;
        }*/

        if (i_stateToScene.TryGetValue(i_GameState, out string sceneName))
        {
            Debug.Log("Chargement de la scène " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Aucune scène n'est associée à l'état " + i_GameState);
            Debug.Log(i_stateToScene[i_GameState]);
        }
    }

    public Tournament? GetTournament()
    {
        if(GameManager.Instance.i_circuit == null) return null;

        foreach (var tournement in GameManager.Instance.i_circuit.i_tournaments)
        {
            if (tournement.i_time >= GameManager.Instance.i_timeSystem.GetTime()) return tournement;
        }

        return null;
    }
}

public enum GameState
{
    Menu,
    CutScene,
    Avatar,
    Logo,
    Buddy,
    Hiring,
    Circuit,
    Hub,
    Hub1,
    Hub2,
    Hub3,
    Match,
    Tournaments,
    Result,
    OptionScreen
}
/*[System.Serializable]
public class GameData
{
    public PlayerData playerData;
}*/

/*public class PlayerData
{
    public int i_id;
}*/

