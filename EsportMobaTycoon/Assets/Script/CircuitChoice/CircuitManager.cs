using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityRandom = UnityEngine.Random;

public class CircuitManager : MonoBehaviour
{
    private enum CircuitState
    {
        InProgress,
        Ended
    }

    public enum CircuitTracks
    {
        Casual,
        Ranked,
        Amateur,
        SemiProfessional,
        Professional
    }

    int AllTournament = 0;

    [Header("Generation Settings")]

    [Header("Circuit Settings")]
    [SerializeField, Range(1, 3)]
    private int i_circuitMinTournament;

    [Header("Tournament Settings")]
    [SerializeField, Range(1, 3)]
    private int i_tournamentMinMatches;

    [SerializeField, Range(3, 10)]
    private int i_tournamentMaxMatches;

    [Header("Major Settings")]
    [SerializeField]
    private CircuitTracks i_circuitTracks;

    [SerializeField, Range(3, 5)]
    private int i_majorMinMatches;

    [SerializeField, Range(5, 10)]
    private int i_majorMaxMatches;

    [Header("Ui Settings")]
    [Header("Ui - Circuits")]
    [SerializeField]
    private GameObject circuitUIPrefab;

    [SerializeField]
    private Transform circuitPanel;

    [Header("Ui - Buttons")]
    [SerializeField]
    private GameObject i_generateCircuitsButton;

    [SerializeField]
    private GameObject i_endCircuitButton;

    [Header("Ui - Text")]
    [SerializeField]
    private TMP_Text i_TracksListText;

    [SerializeField]
    private TMP_Text i_reputationAmountText;

    [Header("Reputation")]
    [Header("Reputation - threshold Amount")]

    [SerializeField, Range(0, 10000)]
    private int i_rankedThreshold;

    [SerializeField, Range(0, 10000)]
    private int i_amateurThreshold;

    [SerializeField, Range(0, 10000)]
    private int i_semiprofessionalThreshold;

    [SerializeField, Range(0, 10000)]
    private int i_professionalThreshold;

    /*void OnValidate()
    {
        i_rankedThreshold = Mathf.Max(i_rankedThreshold, 0);
        i_amateurThreshold = Mathf.Max(i_amateurThreshold, i_rankedThreshold);
        i_semiprofessionalThreshold = Mathf.Max(i_semiprofessionalThreshold, i_amateurThreshold);
        i_professionalThreshold = Mathf.Max(i_professionalThreshold, i_semiprofessionalThreshold);
    }*/


    private Dictionary<int, (Circuit, CircuitTracks)> i_circuitsChoices;
    private Circuit i_selectedCircuit;
    private CircuitState i_selectedCircuitState;

    void Start()
    {
        i_circuitsChoices = new Dictionary<int, (Circuit, CircuitTracks)>();
        i_selectedCircuitState = CircuitState.Ended;

        List<int> tracksThreshold = new List<int> { 0, i_rankedThreshold, i_amateurThreshold, i_semiprofessionalThreshold, i_professionalThreshold };
        string tracksList = new string("");

        CircuitTracks[] tracks = (CircuitTracks[])Enum.GetValues(typeof(CircuitTracks));

        for (int i = 0; i < tracks.Length; i++)
        {
            tracksList += tracks[i] + " : " + tracksThreshold[i] + " Rp";
        }

        i_TracksListText.text = tracksList.ToString();

        print("in");

    }

    void Update()
    {
        i_generateCircuitsButton.SetActive(i_selectedCircuitState == CircuitState.Ended);
        i_endCircuitButton.SetActive(i_selectedCircuitState == CircuitState.InProgress);
        i_reputationAmountText.text = GameManager.Instance.i_manager.i_reputation.ToString();
    }

    public void GenerateCircuit(int amount)
    {
        if (i_selectedCircuitState == CircuitState.InProgress)
        {
            Debug.Log("Denied: Another circuit already in progress!");
            return;
        }

        i_circuitsChoices.Clear();

        List<CircuitTracks> availableTracks = GetAvailableTracks();

        availableTracks = availableTracks.OrderByDescending(diff => (int)diff).ToList();



        for (int i = 0; i < amount; i++)
        {
            Circuit newCircuit = new Circuit(i);

            TimeSystem tournamentDate = GameManager.Instance.GetItimeSystem();

            CircuitTracks newCircuitTracks;

            newCircuitTracks = availableTracks[i % availableTracks.Count];

            Debug.Log("tracks : " + newCircuitTracks);

            int tournamentCount = i_circuitMinTournament + (int)newCircuitTracks;

            for (int j = 0; j < tournamentCount; j++)
            {
                AllTournament += UnityEngine.Random.Range(30, 50);
                Tournament tournament = new Tournament(AllTournament, false, "Tournament " + j);
                CircuitAction c = new CircuitAction();
                Debug.LogError(AllTournament);
                c.setTimer(AllTournament);
                c.InitTournament(tournament);
                GameManager.Instance.AddAction(c);

                int matchCount = UnityRandom.Range(i_tournamentMinMatches, i_tournamentMaxMatches);
                for (int k = 0; k < matchCount; k++)
                {
                    Match newMatch = new Match();
                    tournament.AddMatch(newMatch);
                }

                newCircuit.AddTournament(tournament);
            }

            if (newCircuitTracks >= i_circuitTracks)
            {
                Tournament majorTournament = new Tournament(AllTournament, true, "Major Tournament");
                int majorMatchCount = UnityRandom.Range(i_majorMinMatches, i_majorMaxMatches);

                for (int m = 0; m < majorMatchCount; m++)
                {
                    Match newMatch = new Match();
                    majorTournament.AddMatch(newMatch);
                }

                newCircuit.AddTournament(majorTournament);
            }

            int newId = i_circuitsChoices.Count;
            i_circuitsChoices[newId] = (newCircuit, newCircuitTracks);
        }

        Debug.Log("Successfully generated " + amount + " circuits!");

        GenerateCircuitUI();
    }


    void GenerateCircuitUI()
    {
        foreach (Transform child in circuitPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (var circuit in i_circuitsChoices)
        {
            int circuitId = circuit.Key;
            CircuitTracks difficulty = circuit.Value.Item2;

            int totalMatchCount = 0;

            string tournamentDetails = new string("");
            for (int i = 0; i < circuit.Value.Item1.GetTournaments().Count; i++)
            {
                int matchCount = circuit.Value.Item1.GetTournaments()[i].GetMatches().Count;
                totalMatchCount += matchCount;

                if (difficulty >= i_circuitTracks && (i + 1) == circuit.Value.Item1.GetTournaments().Count)
                {
                    tournamentDetails += "- Major : " + AllTournament + " " + matchCount + " matches";
                }
                else
                {
                    tournamentDetails += "- Tournament " + i + 1 + " tours : " + AllTournament + " and " + matchCount + " matches";
                }
            }

            GameObject circuitUi = Instantiate(circuitUIPrefab, circuitPanel);

            TMP_Text circuitNumberText = circuitUi.transform.Find("CircuitNumberText").GetComponent<TMP_Text>();
            TMP_Text circuitDifficultyText = circuitUi.transform.Find("CircuitDifficultyText").GetComponent<TMP_Text>();
            TMP_Text tournamentDetailsText = circuitUi.transform.Find("CircuitTournamentText").GetComponent<TMP_Text>();
            TMP_Text circuitMatchesText = circuitUi.transform.Find("CircuitMatchesText").GetComponent<TMP_Text>();

            Button selectButton = circuitUi.transform.Find("SelectButton").GetComponent<Button>();
            TMP_Text selectText = circuitUi.transform.Find("SelectButton/SelectText").GetComponent<TMP_Text>();

            circuitNumberText.text = "Circuit " + circuitId;
            circuitDifficultyText.text = "Difficulty : " + difficulty.ToString();
            tournamentDetailsText.text = tournamentDetails.ToString();
            circuitMatchesText.text = "Total Matches : " + totalMatchCount;

            selectButton.onClick.AddListener(() => ChooseCircuit(circuitId));
            selectText.text = "Choose C" + circuitId;
        }
    }

    private int GetCircuitIdFromUI(GameObject uiElement)
    {
        string uiCircuitName = uiElement.transform.Find("CircuitNumberText").GetComponent<TMP_Text>().text;
        string[] nameParts = uiCircuitName.Split(' ');
        if (nameParts.Length > 1 && int.TryParse(nameParts[1], out int circuitId))
        {
            return circuitId;
        }
        return -1;
    }

    public void ChooseCircuit(int circuitId)
    {
        if (i_selectedCircuitState == CircuitState.InProgress)
        {
            Debug.Log("Denied: Another circuit already in progress!");
            return;
        }

        if (i_circuitsChoices.ContainsKey(circuitId))
        {
            i_selectedCircuit = i_circuitsChoices[circuitId].Item1;
            i_selectedCircuitState = CircuitState.InProgress;

            Debug.Log("Selected Circuit: " + circuitId + ", State: " + i_selectedCircuitState);

            foreach (Transform child in circuitPanel)
            {
                int childCircuitId = GetCircuitIdFromUI(child.gameObject);

                if (childCircuitId == circuitId)
                {
                    Button selectButton = child.Find("SelectButton").GetComponent<Button>();
                    TMP_Text selectText = child.Find("SelectButton/SelectText").GetComponent<TMP_Text>();

                    if (selectButton != null)
                    {
                        selectButton.interactable = false;

                        ColorBlock colors = selectButton.colors;
                        colors.disabledColor = Color.green;
                        selectButton.colors = colors;
                    }

                    if (selectText != null)
                    {
                        selectText.text = "Active";
                    }
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else
        {
            Debug.Log("Circuit ID not found: " + circuitId);
        }
    }

    public void EndSelectedCircuit()
    {
        i_selectedCircuitState = CircuitState.Ended;

        Transform child = circuitPanel.GetChild(0);

        Button selectButton = child.Find("SelectButton").GetComponent<Button>();
        TMP_Text selectText = child.Find("SelectButton/SelectText").GetComponent<TMP_Text>();

        if (selectButton != null)
        {
            ColorBlock colors = selectButton.colors;
            colors.disabledColor = Color.red;
            selectButton.colors = colors;
        }

        if (selectText != null)
        {
            selectText.text = "Ended";
        }

        Debug.Log("Selected Circuit state updated to: " + i_selectedCircuitState);
    }

    public CircuitTracks GetCircuitDifficulty(int id)
    {
        if (i_circuitsChoices.ContainsKey(id))
        {
            return i_circuitsChoices[id].Item2;
        }
        else
        {
            Debug.Log("Circuit ID not found: " + id);
            return default;
        }
    }

    private List<CircuitTracks> GetAvailableTracks()
    {
        List<CircuitTracks> availableTracks = new List<CircuitTracks>();

        availableTracks.Add(CircuitTracks.Casual);
        if (GameManager.Instance.i_manager.i_reputation >= i_rankedThreshold) availableTracks.Add(CircuitTracks.Ranked);
        if (GameManager.Instance.i_manager.i_reputation >= i_amateurThreshold) availableTracks.Add(CircuitTracks.Amateur);
        if (GameManager.Instance.i_manager.i_reputation >= i_semiprofessionalThreshold) availableTracks.Add(CircuitTracks.SemiProfessional);
        if (GameManager.Instance.i_manager.i_reputation >= i_professionalThreshold) availableTracks.Add(CircuitTracks.Professional);

        return availableTracks;
    }

    private CircuitTracks GetHighestDifficulty()
    {
        CircuitTracks[] difficulties = (CircuitTracks[])Enum.GetValues(typeof(CircuitTracks));
        return difficulties[difficulties.Length - 1];
    }
}
