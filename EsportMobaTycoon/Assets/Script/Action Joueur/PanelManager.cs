using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XCharts.Runtime;

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
    [Header("Tournament")]
    [SerializeField] TMP_Text i_tournamentName;
    [SerializeField] TMP_Text i_tournamentDayLeft;
    [Header("Chart")]
    [SerializeField] BarChart i_budgetChart;
    [SerializeField] BarChart i_fansChart;
    float[] i_moneyMonth;
    int[] i_fansMonth;




    void Start()
    {
        Debug.Log("DELETE THIS LINE", gameObject);

        i_moneyMonth = new float[12];
        i_fansMonth = new int[12];

        i_manager = GameManager.Instance.i_manager;
        UpdateMoney();
        i_nombreReputation.text = i_manager.i_reputation.ToString();
        ChangeColorSynergie();


        GameManager.Instance.i_timeSystem.OnTurnPass += TimeSystem_OnTurnPass;
    }

    private void TimeSystem_OnTurnPass()
    {
        Date date = DateHelper.GetDate(GameManager.Instance.i_timeSystem.GetTime());

        i_moneyMonth[date.monthID] = GameManager.Instance.i_manager.i_currentMoney;
        i_fansMonth[date.monthID] = GameManager.Instance.i_manager.i_reputation;

        UpdateNextTournement();
    }

    void Update()
    {
        
    }

    public void UpdateMoney()
    {
        i_NombreMoney.text = i_manager.i_currentMoney.ToString();
        i_NombreMoneyPrenium.text = i_manager.i_currentMoneyPrenium.ToString();

        i_budgetChart.ClearData();
        for (int i = 0; i < 12; i++)
        {
            i_budgetChart.AddXAxisData("x" + (i + 1));
            i_budgetChart.AddData(0, i_moneyMonth[i]);
        }

        i_fansChart.ClearData();
        for (int i = 0; i < 12; i++)
        {
            i_fansChart.AddXAxisData("x" + (i + 1));
            i_fansChart.AddData(0, i_fansMonth[i]);
        }
    }

    public void UpdateNextTournement()
    {
        foreach (var tournement in GameManager.Instance.i_circuit.i_tournaments)
        {
            if(tournement.i_time >= GameManager.Instance.i_timeSystem.GetTime())
            {
                i_tournamentName.text = tournement.i_name;
                i_tournamentDayLeft.text = (tournement.i_time - GameManager.Instance.i_timeSystem.GetTime()).ToString();
                break;
            }
        }
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

    private void OnDestroy()
    {
        GameManager.Instance.i_timeSystem.OnTurnPass -= TimeSystem_OnTurnPass;
    }
}
