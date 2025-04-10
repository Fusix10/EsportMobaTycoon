//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TMPro;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityRandom = UnityEngine.Random;

//public class CircuitManager : MonoBehaviour
//{
//    private enum CircuitState
//    {
//        InProgress,
//        Ended
//    }

//    public enum CircuitDifficulty
//    {
//        Casual,
//        Ranked,
//        Amateur,
//        SemiProfessional,
//        Professional
//    }

//    class Match
//    {
//        private enum MatchStatus
//        {
//            NotPlayed,
//            Won,
//            Lost
//        }

//        private MatchStatus m_status;

//        public Match()
//        {
//            m_status = MatchStatus.NotPlayed;
//        }

//        public void HasWon(bool win)
//        {
//            m_status = win ? MatchStatus.Won : MatchStatus.Lost;
//        }
//    }

//    [Header("Generation Settings")]

//    [Header("Circuit Settings")]
//    [SerializeField, Range(1, 3)]
//    private int circuit_min_tournament;

//    [Header("Tournament Settings")]
//    [SerializeField, Range(1, 3)]
//    private int tournament_min_matches;

//    [SerializeField, Range(3, 10)]
//    private int tournament_max_matches;

//    [Header("Major Settings")]
//    [SerializeField]
//    private CircuitDifficulty major_threshold_difficulty;

//    [SerializeField, Range(3, 5)]
//    private int major_min_matches;

//    [SerializeField, Range(5, 10)]
//    private int major_max_matches;

//    [Header("Ui Settings")]
//    [Header("Ui - Circuits")]
//    [SerializeField]
//    private GameObject circuitUIPrefab;

//    [SerializeField]
//    private Transform circuitPanel;

//    [Header("Ui - Buttons")]
//    [SerializeField]
//    private GameObject generate_circuits_button;

//    [SerializeField]
//    private GameObject end_circuit_button;

//    [Header("Ui - Text")]
//    [SerializeField]
//    private TMP_Text difficulties_list_text;

//    [SerializeField]
//    private TMP_Text reputation_amount_text;

//    [Header("Reputation")]
//    [Header("Reputation - threshold Amount")]

//    [SerializeField, Range(0, 10000)]
//    private int ranked_threshold;

//    [SerializeField, Range(0, 10000)]
//    private int amateur_threshold;

//    [SerializeField, Range(0, 10000)]
//    private int semiprofessional_threshold;

//    [SerializeField, Range(0, 10000)]
//    private int professional_threshold;

//    [Header("Reputation - Max Amount")]

//    [SerializeField]
//    private int max_reputation;

//    void OnValidate()
//    {
//        ranked_threshold = Mathf.Max(ranked_threshold, 0);
//        amateur_threshold = Mathf.Max(amateur_threshold, ranked_threshold);
//        semiprofessional_threshold = Mathf.Max(semiprofessional_threshold, amateur_threshold);
//        professional_threshold = Mathf.Max(professional_threshold, semiprofessional_threshold);

//        max_reputation = Mathf.Max(max_reputation, professional_threshold);
//    }


//    //

//    private int m_reputation;
//    public int Reputation
//    {
//        get { return m_reputation; }
//        private set { m_reputation = value; }
//    }

//    private Dictionary<int, (List<List<Match>>, CircuitDifficulty)> m_circuits_choices;
//    private List<List<Match>> m_selected_circuit;
//    private CircuitState m_selected_circuit_state;

//    void Start()
//    {
//        m_circuits_choices = new Dictionary<int, (List<List<Match>>, CircuitDifficulty)>();
//        m_selected_circuit_state = CircuitState.Ended;

//        Reputation = 0;

//        List<int> difficultiesThreshold = new List<int> { 0, ranked_threshold, amateur_threshold, semiprofessional_threshold, professional_threshold };
//        StringBuilder difficultiesList = new StringBuilder();

//        CircuitDifficulty[] difficulties = (CircuitDifficulty[])Enum.GetValues(typeof(CircuitDifficulty));

//        for (int i = 0; i < difficulties.Length; i++)
//        {
//            difficultiesList.AppendLine($"- {difficulties[i]} : {difficultiesThreshold[i]} Rp");
//        }

//        difficulties_list_text.text = difficultiesList.ToString();

//    }

//    void Update()
//    {
//        generate_circuits_button.SetActive(m_selected_circuit_state == CircuitState.Ended);
//        end_circuit_button.SetActive(m_selected_circuit_state == CircuitState.InProgress);

//        reputation_amount_text.text = Reputation.ToString();

//    }

//    public void GenerateCircuit(int amount)
//    {
//        if (m_selected_circuit_state == CircuitState.InProgress)
//        {
//            Debug.Log("Denied: Another circuit already in progress!");
//            return;
//        }

//        m_circuits_choices.Clear();

//        List<CircuitDifficulty> available_difficulties = GetAvailableDifficulties();

//        available_difficulties = available_difficulties.OrderByDescending(diff => (int)diff).ToList();


//        bool is_max_reputation = Reputation == max_reputation;

//        for (int i = 0; i < amount; i++)
//        {
//            List<List<Match>> new_circuit = new List<List<Match>>();

//            CircuitDifficulty new_circuit_difficulty;

//            if (is_max_reputation)
//            {
//                new_circuit_difficulty = GetHighestDifficulty();
//            }
//            else
//            {
//                new_circuit_difficulty = available_difficulties[i % available_difficulties.Count];
//            }

//            int tournament_count = circuit_min_tournament + (int)new_circuit_difficulty;

//            for (int j = 0; j < tournament_count; j++)
//            {
//                List<Match> tournament = new List<Match>();

//                int match_count = UnityRandom.Range(tournament_min_matches, tournament_max_matches);
//                for (int k = 0; k < match_count; k++)
//                {
//                    Match new_match = new Match();
//                    tournament.Add(new_match);
//                }

//                new_circuit.Add(tournament);
//            }

//            if (new_circuit_difficulty >= major_threshold_difficulty)
//            {
//                List<Match> major_tournament = new List<Match>();
//                int major_match_count = UnityRandom.Range(major_min_matches, major_max_matches);
//                for (int m = 0; m < major_match_count; m++)
//                {
//                    Match new_match = new Match();
//                    major_tournament.Add(new_match);
//                }

//                new_circuit.Add(major_tournament);
//            }

//            int new_id = m_circuits_choices.Count;
//            m_circuits_choices[new_id] = (new_circuit, new_circuit_difficulty);
//        }

//        Debug.Log("Successfully generated " + amount + " circuits!");

//        GenerateCircuitUI();
//    }


//    void GenerateCircuitUI()
//    {
//        foreach (Transform child in circuitPanel)
//        {
//            Destroy(child.gameObject);
//        }

//        foreach (var circuit in m_circuits_choices)
//        {
//            int circuit_id = circuit.Key;
//            CircuitDifficulty difficulty = circuit.Value.Item2;

//            int total_match_count = 0;

//            StringBuilder tournament_details = new StringBuilder();
//            for (int i = 0; i < circuit.Value.Item1.Count; i++)
//            {
//                int match_count = circuit.Value.Item1[i].Count;
//                total_match_count += match_count;

//                if (difficulty >= major_threshold_difficulty && (i + 1) == circuit.Value.Item1.Count)
//                {
//                    tournament_details.AppendLine($"- Major : {match_count} matches");

//                }
//                else
//                {
//                    tournament_details.AppendLine($"- Tournament {i + 1}: {match_count} matches");
//                }
//            }

//            GameObject circuit_ui = Instantiate(circuitUIPrefab, circuitPanel);

//            TMP_Text circuit_number_text = circuit_ui.transform.Find("CircuitNumberText").GetComponent<TMP_Text>();
//            TMP_Text circuit_difficulty_text = circuit_ui.transform.Find("CircuitDifficultyText").GetComponent<TMP_Text>();
//            TMP_Text tournament_details_text = circuit_ui.transform.Find("CircuitTournamentText").GetComponent<TMP_Text>();
//            TMP_Text circuit_matches_text = circuit_ui.transform.Find("CircuitMatchesText").GetComponent<TMP_Text>();

//            Button select_button = circuit_ui.transform.Find("SelectButton").GetComponent<Button>();
//            TMP_Text select_text = circuit_ui.transform.Find("SelectButton/SelectText").GetComponent<TMP_Text>();

//            circuit_number_text.text = "Circuit " + circuit_id;
//            circuit_difficulty_text.text = "Difficulty : " + difficulty.ToString();
//            tournament_details_text.text = tournament_details.ToString();
//            circuit_matches_text.text = "Total Matches : " + total_match_count;

//            select_button.onClick.AddListener(() => ChooseCircuit(circuit_id));
//            select_text.text = "Choose C" + circuit_id;
//        }
//    }

//    private int GetCircuitIdFromUI(GameObject ui_element)
//    {
//        string ui_circuit_name = ui_element.transform.Find("CircuitNumberText").GetComponent<TMP_Text>().text;
//        string[] name_parts = ui_circuit_name.Split(' ');
//        if (name_parts.Length > 1 && int.TryParse(name_parts[1], out int circuit_id))
//        {
//            return circuit_id;
//        }
//        return -1;
//    }

//    public void ChooseCircuit(int circuit_id)
//    {
//        if (m_selected_circuit_state == CircuitState.InProgress)
//        {
//            Debug.Log("Denied: Another circuit already in progress!");
//            return;
//        }

//        if (m_circuits_choices.ContainsKey(circuit_id))
//        {
//            m_selected_circuit = m_circuits_choices[circuit_id].Item1;
//            m_selected_circuit_state = CircuitState.InProgress;

//            Debug.Log("Selected Circuit: " + circuit_id + ", State: " + m_selected_circuit_state);

//            foreach (Transform child in circuitPanel)
//            {
//                int child_circuitId = GetCircuitIdFromUI(child.gameObject);

//                if (child_circuitId == circuit_id)
//                {
//                    Button select_button = child.Find("SelectButton").GetComponent<Button>();
//                    TMP_Text select_text = child.Find("SelectButton/SelectText").GetComponent<TMP_Text>();

//                    if (select_button != null)
//                    {
//                        select_button.interactable = false;

//                        ColorBlock colors = select_button.colors;
//                        colors.disabledColor = Color.green;
//                        select_button.colors = colors;
//                    }

//                    if (select_text != null)
//                    {
//                        select_text.text = "Active";
//                    }
//                }
//                else
//                {
//                    Destroy(child.gameObject);
//                }
//            }
//        }
//        else
//        {
//            Debug.Log("Circuit ID not found: " + circuit_id);
//        }
//    }

//    public void EndSelectedCircuit()
//    {
//        m_selected_circuit_state = CircuitState.Ended;

//        Transform child = circuitPanel.GetChild(0);

//        Button select_button = child.Find("SelectButton").GetComponent<Button>();
//        TMP_Text select_text = child.Find("SelectButton/SelectText").GetComponent<TMP_Text>();

//        if (select_button != null)
//        {
//            ColorBlock colors = select_button.colors;
//            colors.disabledColor = Color.red;
//            select_button.colors = colors;
//        }

//        if (select_text != null)
//        {
//            select_text.text = "Ended";
//        }

//        Debug.Log("Selected Circuit state updated to: " + m_selected_circuit_state);
//    }

//    public CircuitDifficulty GetCircuitDifficulty(int id)
//    {
//        if (m_circuits_choices.ContainsKey(id))
//        {
//            return m_circuits_choices[id].Item2;
//        }
//        else
//        {
//            Debug.Log("Circuit ID not found: " + id);
//            return default;
//        }
//    }

//    private List<CircuitDifficulty> GetAvailableDifficulties()
//    {
//        List<CircuitDifficulty> available_difficulties = new List<CircuitDifficulty>();

//        available_difficulties.Add(CircuitDifficulty.Casual);
//        if (Reputation >= ranked_threshold) available_difficulties.Add(CircuitDifficulty.Ranked);
//        if (Reputation >= amateur_threshold) available_difficulties.Add(CircuitDifficulty.Amateur);
//        if (Reputation >= semiprofessional_threshold) available_difficulties.Add(CircuitDifficulty.SemiProfessional);
//        if (Reputation >= professional_threshold) available_difficulties.Add(CircuitDifficulty.Professional);

//        return available_difficulties;
//    }

//    public void AddReputation(int amount)
//    {
//        if ((Reputation + amount) > max_reputation)
//        {
//            Reputation = max_reputation;
//            return;
//        }

//        Reputation += amount;
//    }

//    public void SubtractReputation(int amount)
//    {
//        if ((Reputation - amount) < 0)
//        {
//            Reputation = 0;
//            return;
//        }

//        Reputation -= amount;
//    }

//    private CircuitDifficulty GetHighestDifficulty()
//    {
//        CircuitDifficulty[] difficulties = (CircuitDifficulty[])Enum.GetValues(typeof(CircuitDifficulty));
//        return difficulties[difficulties.Length - 1];
//    }
//}
