using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreFabPIGet : MonoBehaviour
{
    [Header("Info")]
    [SerializeField]
    public TMP_Text i_ValueKill;
    [SerializeField]
    public TMP_Text i_ValueMort;
    [SerializeField]
    public TMP_Text i_ValueAssist;
    [SerializeField]
    public TMP_Text i_playerName;

    [Header("InfoImage")]
    [SerializeField]
    public Image i_Head;
    [SerializeField]
    public Image i_Hair;

    [SerializeField]
    public GameManager.Role i_Role;
    void Start()
    {
        
    }
}
