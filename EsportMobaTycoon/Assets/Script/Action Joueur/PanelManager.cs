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
    [SerializeField] Image i_iconMoney;
    [SerializeField] TMP_Text i_NombreMoney;
    [SerializeField] Image i_iconMoneyPrenium;
    [SerializeField] TMP_Text i_NombreMoneyPrenium;

    [Header("Synergie")]
    [SerializeField] Image[] i_colorSynergie;
    [SerializeField] TMP_Text[] i_textSynergie;

    [Header("Meta")]
    [SerializeField] Image i_iconCharacter;

    [Header("Agenda")]
    [SerializeField] TMP_Text i_nomTournois;
    [SerializeField] TMP_Text i_joursAvantTournois;

    [Header("Réputation")]
    [SerializeField] TMP_Text i_nombreReputation;

    [Header("Tournament")]
    [SerializeField] TMP_Text[] i_tournamentName;
    [SerializeField] TMP_Text[] i_tournamentDayLeft;

    [Header("Sponsor")]
    [SerializeField] TMP_Text[] i_sponsorName;
    [SerializeField] Image[] i_sponsorImage;

    [Header("Chart")]
    [SerializeField] BarChart i_budgetChart;
    [SerializeField] BarChart i_fansChart;
    float[] i_moneyMonth;
    int[] i_fansMonth;

    bool goNextTournament;

    #if DEBUG
    public void Generate()
    {
        List<Tournament> tournaments = new();
        CircuitDifficulty circuitDifficulty = new();

        if (GameManager.Instance.i_manager.i_reputation < 10000)
        {
            circuitDifficulty = CircuitDifficulty.Easy;
        }
        else if (GameManager.Instance.i_manager.i_reputation > 10000 && GameManager.Instance.i_manager.i_reputation < 100000)
        {
            circuitDifficulty = CircuitDifficulty.Normal;
        }
        else if (GameManager.Instance.i_manager.i_reputation > 100000)
        {
            circuitDifficulty = CircuitDifficulty.Hard;
        }

        int tournamentCount = 3;
        for (int i = 0; i < tournamentCount; i++)
        {
            List<Match> matches = new();
            int matchCount = Random.Range(2, 5);
            for (int j = 0; j < matchCount; j++)
            {
                TeamData teamData = ScriptableObject.CreateInstance<TeamData>();
                switch (circuitDifficulty)
                {
                    case CircuitDifficulty.Easy:
                        teamData.CreateAllPlayerFromNothing(Random.Range(1, 3));
                        break;
                    case CircuitDifficulty.Normal:
                        teamData.CreateAllPlayerFromNothing(Random.Range(2, 5));
                        break;
                    case CircuitDifficulty.Hard:
                        teamData.CreateAllPlayerFromNothing(5);
                        break;
                }
                GameManager.Instance.i_allTeam.Add(teamData);
                matches.Add(new(teamData));
            }

            int offset = i * 60;
            tournaments.Add(new(Random.Range(offset + 30, offset + 50), matches, "NAME TEST"));
        }

        GameManager.Instance.i_circuit = new(tournaments, circuitDifficulty);
    }
    #endif


    void Start()
    {
        #if DEBUG
        Debug.Log("DELETE THIS LINE", gameObject);
        Generate();
        #endif

        i_moneyMonth = new float[12];
        i_fansMonth = new int[12];

        i_manager = GameManager.Instance.i_manager;

        UpdateMoney();
        UpdateNextTournement();
        UpdateSponsor();

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

        if(goNextTournament)
        {
            Tournament tournement = GameManager.Instance.GetTournament();
            if (tournement == null || tournement.i_time - 1 <= GameManager.Instance.i_timeSystem.GetTime())
            {
                Debug.Log("tournement");
                goNextTournament = false;
                return;
            }

            PassTime();
        }
    }

    public void PassTime()
    {
        GameManager.Instance.PassTimeButton();
    }

    public void GoNextTournament()
    {
        if (!goNextTournament && GameManager.Instance.GetTournament().i_time - 1 > GameManager.Instance.i_timeSystem.GetTime())
        {
            goNextTournament = true;
            PassTime();
        }
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
        Tournament tournement = GameManager.Instance.GetTournament();

        if (tournement == null) return;

        foreach (var name in i_tournamentName)
        {
            name.text = tournement.i_name;
        }

        foreach (var day in i_tournamentDayLeft)
        {
            day.text = (tournement.i_time - GameManager.Instance.i_timeSystem.GetTime()).ToString();
        }

        if(GameManager.Instance.i_timeSystem.GetTime() < 6)
        {

        }
    }

    public void UpdateSponsor()
    {
        foreach (var sponsor in i_sponsorName)
        {
            sponsor.text = GameManager.Instance.i_manager.i_sponsorEvent != null ? GameManager.Instance.i_manager.i_sponsorEvent.name : "";
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
        for (int i = 0; i < i_textSynergie.Length; i++)
        {
            switch (teamSynergie)
            {
                case 0:
                    i_textSynergie[i].text = "Désastreux";
                    i_textSynergie[i].color = new Color(0, 0, 0);
                    i_colorSynergie[i].color = new Color(0, 0, 0, 0.47f); break;
                case 1:
                    i_textSynergie[i].text = "Faible";
                    i_textSynergie[i].color = new Color(255, 0, 0);
                    i_colorSynergie[i].color = new Color(255, 0, 0, 0.47f); break;
                case 2:
                    i_textSynergie[i].text = "Correct";
                    i_textSynergie[i].color = new Color(255, 128, 0);
                    i_colorSynergie[i].color = new Color(255, 128, 0, 0.47f); break;
                case 3:
                    i_textSynergie[i].text = "Bon";
                    i_textSynergie[i].color = new Color(1, 0.92f, 0.016f);
                    i_colorSynergie[i].color = new Color(1, 0.92f, 0.016f, 0.47f); break;
                case 4:
                    i_textSynergie[i].text = "Incroyable";
                    i_textSynergie[i].color = new Color(200, 255, 0);
                    i_colorSynergie[i].color = new Color(200, 255, 0, 0.47f); break;
                case 5:
                    i_textSynergie[i].text = "Parfait";
                    i_textSynergie[i].color = new Color(0, 255, 0);
                    i_colorSynergie[i].color = new Color(0, 255, 0, 0.47f); break;
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.i_timeSystem.OnTurnPass -= TimeSystem_OnTurnPass;
    }
}
