using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    private Manager_Utilisateur i_manager; 
    [Header("Money")]
    [SerializeField]
    Image i_iconMoney;
    [SerializeField]
    TMP_Text i_NombreMoney;
    [SerializeField]
    Image i_iconMoneyPrenium;
    [SerializeField]
    TMP_Text i_NombreMoneyPrenium;
    [Header("Synergie")]
    [SerializeField]
    Image i_colorSynergie;
    [SerializeField]
    TMP_Text i_textSynergie;
    [Header("Meta")]
    [SerializeField]
    Image i_iconCharacter;
    [Header("Agenda")]
    [SerializeField]
    TMP_Text i_nomTournois;
    [SerializeField]
    TMP_Text i_joursAvantTournois;
    [Header("Réputation")]
    [SerializeField]
    TMP_Text i_nombreReputation;


    void Start()
    {
        i_manager = GameManager.Instance.i_manager;
        i_NombreMoney.text = i_manager.i_currentMoney.ToString();
        i_NombreMoneyPrenium.text = i_manager.i_currentMoneyPrenium.ToString();
        i_nombreReputation.text = i_manager.i_reputation.ToString();
        ChangeColorSynergie();

    }
    void Update()
    {
        
    }

    void ChangeColorSynergie()
    {
        int teamSynergie = 0;
        for (int i = 0; i < i_manager.GetPlayer().Count; i++)
        {
            teamSynergie += i_manager.GetPlayer()[i].i_teamSpirit.s_lvl;
        }
        if (i_manager.GetPlayer().Count > 0)
        {
            teamSynergie = teamSynergie / i_manager.GetPlayer().Count;
        }
        switch (teamSynergie) 
        { 
            case 0:
                i_textSynergie.text = "Désastreux";
                i_textSynergie.color = new Color(0, 0, 0);
                i_colorSynergie.color = new Color(0, 0, 0, 0.47f); break;
            case 1:
                i_textSynergie.text = "Faible";
                i_textSynergie.color = new Color(255, 0, 0);
                i_colorSynergie.color = new Color(255,0,0, 0.47f); break;
            case 2:
                i_textSynergie.text = "Correct";
                i_textSynergie.color = new Color(255, 128, 0);
                i_colorSynergie.color = new Color(255,128,0, 0.47f); break;
            case 3:
                i_textSynergie.text = "Bon";
                i_textSynergie.color = new Color(1, 0.92f, 0.016f);
                i_colorSynergie.color = new Color(1,0.92f,0.016f, 0.47f) ; break;
            case 4:
                i_textSynergie.text = "Incroyable";
                i_textSynergie.color = new Color(200, 255, 0);
                i_colorSynergie.color = new Color(200, 255, 0, 0.47f); break;
            case 5:
                i_textSynergie.text = "Parfait";
                i_textSynergie.color = new Color(0, 255, 0);
                i_colorSynergie.color = new Color(0,255,0, 0.47f); break;
        }
    }
}
