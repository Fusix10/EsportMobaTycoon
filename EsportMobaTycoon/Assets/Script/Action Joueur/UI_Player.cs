using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using XCharts.Runtime;

public class UI_Player : MonoBehaviour
{
    public SavePlayerSelectedUi savePlayerSelectedUi;

    [Header("Profil UI")]
    public TMP_Text i_mecaLV;
    public TMP_Text i_connaiLV;

    public List<Image> i_lvl;
    public List<Image> i_Potentiel;

    public TMP_Text i_prenom;
    public TMP_Text i_surnom;
    public TMP_Text i_caractere;
    public TMP_Text i_synergie;
    private Color i_synergieColor;
    public TMP_Text i_role;
    //public Image i_imgRole;
    //public TMP_Text i_carac;
    public GameObject i_graphNiv;
    private RadarChart chart;


    [Header("Champion UI")]
    public GameObject i_prefabChamp;
    public Transform i_panelExce;
    public Transform i_panelBonne;
    public Transform i_panelCorrect;

    [Header("Entrainnement UI")]

    public TMP_Text i_nomE;
    public List<Image> i_lvlE;
    public List<Image> i_PotentielE;
    public Slider i_sliderMeca;
    public Slider i_sliderConnai;
    public Slider i_sliderCoh;
    public TMP_Text i_champFav;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int moyenMeca;
    int moyenKnow;
    int potentiel;
    public void ActualiseUiPlayerProfil()
    {
        CleanUp(i_lvl);
        CleanUp(i_Potentiel);

        chart =  i_graphNiv.GetComponent<RadarChart>();
        Player player = GameManager.Instance.i_manager.GetPlayer()[savePlayerSelectedUi.i_indexPlayer];

        CalculPlayer(player);

        //Meca2
        /* i_graphNiv.data[0].data[0] = player.i_mechanic.s_stamina.s_lvl;
         //Meca3
         i_graphNiv.data[0].data[1] = player.i_mechanic.s_reflexe.s_lvl;
         //Know3
         i_graphNiv.data[0].data[2] = player.i_knowledge.s_objective.s_lvl;
         //Know2
         i_graphNiv.data[0].data[3] = player.i_knowledge.s_teamFight.s_lvl;
         //Know1
         i_graphNiv.data[0].data[4] = player.i_knowledge.s_placement.s_lvl;*/
        //Meca1
        //i_graphNiv.data[0].data[5] = player.i_mechanic.s_lvlCombo;

        chart.UpdateData(0, 0, new List<double> { 0, player.i_mechanic.s_lvlCombo[player.i_favoriteCharacterId.i_Id].s_lvl * 100 + player.i_mechanic.s_lvlCombo[player.i_favoriteCharacterId.i_Id].s_Xp });
        chart.UpdateData(0, 1, new List<double> { 0, player.i_mechanic.s_stamina.s_lvl * 100 + player.i_mechanic.s_stamina.s_Xp });
        chart.UpdateData(0, 2, new List<double> { 0, player.i_mechanic.s_reflexe.s_lvl * 100 + player.i_mechanic.s_reflexe.s_Xp });
        chart.UpdateData(0, 5, new List<double> { 0, player.i_knowledge.s_objective.s_lvl * 100 + player.i_knowledge.s_objective.s_Xp });
        chart.UpdateData(0, 4, new List<double> { 0, player.i_knowledge.s_teamFight.s_lvl * 100 + player.i_knowledge.s_teamFight.s_Xp });
        chart.UpdateData(0, 3, new List<double> { 0, player.i_knowledge.s_placement.s_lvl * 100 + player.i_knowledge.s_placement.s_Xp });
        Debug.Log("meca 1 = " + (player.i_mechanic.s_lvlCombo[player.i_favoriteCharacterId.i_Id].s_lvl * 100 + player.i_mechanic.s_lvlCombo[player.i_favoriteCharacterId.i_Id].s_Xp));
        Debug.Log("meca 2 = " + (player.i_mechanic.s_stamina.s_lvl * 100 + player.i_mechanic.s_stamina.s_Xp));
        Debug.Log("meca 3 = " + (player.i_mechanic.s_reflexe.s_lvl * 100 + player.i_mechanic.s_reflexe.s_Xp));
        Debug.Log("connai 1 = " + (player.i_knowledge.s_objective.s_lvl * 100 + player.i_knowledge.s_objective.s_Xp));
        Debug.Log("connai 2 = " + (player.i_knowledge.s_teamFight.s_lvl * 100 + player.i_knowledge.s_teamFight.s_Xp));
        Debug.Log("connai 3 = " + (player.i_knowledge.s_placement.s_lvl * 100 + player.i_knowledge.s_placement.s_Xp));
        i_mecaLV.text = "lvl" + moyenMeca.ToString();
        i_connaiLV.text = "lvl" + moyenKnow.ToString();

        for (int i = 0; i < player.i_lvl; i++)
        {
            i_lvl[i].color = Color.yellow;
        }

        for (int i = 0; i < potentiel; i++)
        {
            i_Potentiel[i].color = Color.yellow;
        }

        i_prenom.text = player.i_name;
        i_surnom.text = player.i_name;

        i_role.text = GetRoleName((int)player.i_role);

        i_caractere.text = player.i_mood.i_moodName;

        i_synergie.text = FindSynergie(player.i_teamSpirit.s_lvl);
        i_synergie.color = i_synergieColor;
    }
    int i_exce;
    int i_bonne;
    int i_correct;
    public void ActualiseUiPlayerChampion()
    {
        ClearChampion();

        Player player = GameManager.Instance.i_manager.GetPlayer()[savePlayerSelectedUi.i_indexPlayer];
        foreach (KeyValuePair<int, Lvl> pair in player.i_mechanic.s_lvlCombo)
        {
            GameObject predab = Instantiate(i_prefabChamp);
            predab.GetComponentInChildren<TMP_Text>().text = GameManager.Instance.i_allCharacters[pair.Key].i_name;
            if (pair.Value.s_lvl <= 1)
            {
               predab.transform.SetParent(i_panelCorrect);
                i_correct++;
            }
            else if(pair.Value.s_lvl == 2 || pair.Value.s_lvl == 3)
            {
                predab.transform.SetParent(i_panelBonne);
                i_bonne++;
            }
            else if(pair.Value.s_lvl >= 4 )
            {
                predab.transform.SetParent(i_panelExce);
                i_exce++;
            }
        }
        ActuliseContent(i_panelExce,i_exce);
        ActuliseContent(i_panelCorrect,i_correct);
        ActuliseContent(i_panelBonne,i_bonne);
    }
    float widthContent;
    void ActuliseContent(Transform content, int child)
    {
        widthContent = 0;
        if(content.childCount != 0)
        {
            widthContent = content.GetChild(0).GetComponent<RectTransform>().sizeDelta.x * child;
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(widthContent, content.GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    void ClearChampion()
    {
        i_exce = 0;
        i_bonne = 0;
        i_correct = 0;

        for(int i = 0; i < i_panelExce.childCount; i++)
        {
            Destroy(i_panelExce.GetChild(i).gameObject);
        }
        for(int i = 0; i < i_panelBonne.childCount; i++)
        {
            Destroy(i_panelBonne.GetChild(i).gameObject);
        }
        for(int i = 0; i < i_panelCorrect.childCount; i++)
        {
            Destroy(i_panelCorrect.GetChild(i).gameObject);
        }
        
    }

    string FindSynergie(int synergie)
    {
        switch (synergie)
        {
            case 0:
                i_synergieColor = new Color(0, 0, 0); 
                return "Désastreux";
            case 1:
                i_synergieColor = new Color(255, 0, 0);
                return "Faible";
            case 2:
                i_synergieColor = new Color(255, 128, 0);
                return "Correct";
            case 3:
                i_synergieColor = new Color(1, 0.92f, 0.016f);
                return "Bon";
            case 4:
                i_synergieColor = new Color(200, 255, 0);
                return "Incroyable";
            case 5:
                i_synergieColor = new Color(0, 255, 0);
                return "Parfait";
            default:
                i_synergieColor = new Color(255, 255, 255); 
                return "";
        }
    }

    void CalculPlayer(Player player)
    {
        moyenMeca = (player.i_mechanic.s_stamina.s_lvl + player.i_mechanic.s_reflexe.s_lvl) / 2;
        moyenKnow = (player.i_knowledge.s_placement.s_lvl + player.i_knowledge.s_objective.s_lvl + player.i_knowledge.s_teamFight.s_lvl) / 3;
        potentiel = player.i_potentiel;
    }

    public void ActualiseUiPlayerTrain()
    {
        CleanUp(i_lvlE);
        CleanUp(i_PotentielE);

        Player player = GameManager.Instance.i_manager.GetPlayer()[savePlayerSelectedUi.i_indexPlayer];

        CalculPlayer(player);

        i_nomE.text = player.i_name;

        for (int i = 0; i < player.i_lvl; i++)
        {
            i_lvlE[i].color = Color.yellow;
        }
        
        for (int i = 0; i < potentiel; i++)
        {
            i_PotentielE[i].color = Color.yellow;
        }

        i_sliderMeca.value = moyenMeca;
        i_sliderConnai.value = moyenKnow;

    }

    public void CleanUp(List<Image> img)
    {
        for (int i = 0; i < 5; i++)
        {
            img[i].color = Color.white;
        }
    }

    private string GetRoleName(int roleId)
    {
        switch (roleId)
        {
            case 0: return "Top";
            case 1: return "Support";
            case 2: return "Adc";
            case 3: return "Mid";
            case 4: return "Jungle";
            default: return "Inconnu";
        }
    }
}
