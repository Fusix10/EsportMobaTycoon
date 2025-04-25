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
    TMP_Text i_difficulty1;
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
    TMP_Text i_difficulty2;
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
    TMP_Text i_difficulty3;
    [SerializeField]
    TMP_Text i_time3;
    [Header("GroupMatch3")]
    [SerializeField]
    TMP_Text i_nbMatch3;
    [SerializeField]
    TMP_Text i_contre3;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Init(Circuit circuit)
    {
        i_name1.text += circuit.i_tournaments[0].i_name;
        i_difficulty1.text += circuit.i_difficulty;
        i_time1.text += circuit.i_tournaments[0].i_name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
