using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCircuit : MonoBehaviour
{
    [Header("Tournament 1")]
    [SerializeField]
    TMP_Text i_name1;
    [SerializeField]
    TMP_Text i_difficulty;
    [SerializeField]
    TMP_Text i_time1;
    [Header("GroupMatch1")]
    [SerializeField]
    TMP_Text i_nbMatch1;
    [SerializeField]
    TMP_Text i_contre1;
    [Header("Tournament 2")]
    [SerializeField]
    TMP_Text i_name2;
    [SerializeField]
    TMP_Text i_time2;
    [Header("GroupMatch2")]
    [SerializeField]
    TMP_Text i_nbMatch2;
    [SerializeField]
    TMP_Text i_contre2;
    [Header("Tournament 3")]
    [SerializeField]
    TMP_Text i_name3;
    [SerializeField]
    TMP_Text i_time3;
    [Header("GroupMatch3")]
    [SerializeField]
    TMP_Text i_nbMatch3;
    [SerializeField]
    TMP_Text i_contre3;


    List<Circuit> i_circuit;
    int i_currentId;

    public void Init(List<Circuit> circuit)
    {
        i_circuit = circuit;
        i_currentId = 0;
    }

    public void ShowCircuit(Circuit circuit)
    {
        i_difficulty.text = circuit.i_difficulty.ToString();
        
        i_name1.text += circuit.i_tournaments[0].i_name;
        i_time1.text += circuit.i_tournaments[0].i_time;

        i_nbMatch1.text += circuit.i_tournaments[0].i_matches.Count;
        i_contre1.text = "";
        for (int i = 0; i < circuit.i_tournaments[0].i_matches.Count; i++)
        {
            i_contre1.text += circuit.i_tournaments[0].i_matches[i].i_team.i_name;
            i_contre1.text += " & ";
        }

        i_name2.text += circuit.i_tournaments[1].i_name;
        i_time2.text += circuit.i_tournaments[1].i_time;

        i_nbMatch2.text += circuit.i_tournaments[1].i_matches.Count;
        i_contre2.text = "";
        for (int i = 0; i < circuit.i_tournaments[1].i_matches.Count; i++)
        {
            i_contre2.text += circuit.i_tournaments[1].i_matches[i].i_team.i_name;
            i_contre2.text += " & ";
        }

        i_name3.text += circuit.i_tournaments[2].i_name;
        i_time3.text += circuit.i_tournaments[2].i_time;

        i_nbMatch3.text += circuit.i_tournaments[2].i_matches.Count;
        i_contre3.text = "";
        for (int i = 0; i < circuit.i_tournaments[2].i_matches.Count; i++)
        {
            i_contre3.text += circuit.i_tournaments[2].i_matches[i].i_team.i_name;
            i_contre3.text += " & ";
        }
    }

    public void ChangeCurrentId(int Id)
    {
        i_currentId = Id;
        UpdateCanva();
    }

    public void UpdateCanva()
    {
        ShowCircuit(i_circuit[i_currentId]);
    }
}
