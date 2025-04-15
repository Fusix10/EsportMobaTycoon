using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text i_nom;
    public TMP_Text i_surnom;
    public TMP_Text i_role;
    //public Image i_imgRole;
    public TMP_Text i_sysn;
    //public TMP_Text i_carac;
    public GameObject i_graphNiv;
    private RadarChart chart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualiseUiPlayerProfil()
    {
        CleanUp();
        chart =  i_graphNiv.GetComponent<RadarChart>();
        Player player = GameManager.Instance.i_allPlayers[savePlayerSelectedUi.i_indexPlayer];

        int moyenMeca = (player.i_mechanic.s_stamina.s_lvl + player.i_mechanic.s_reflexe.s_lvl) / 2;
        int moyenKnow = (player.i_knowledge.s_placement.s_lvl + player.i_knowledge.s_objective.s_lvl + player.i_knowledge.s_teamFight.s_lvl) / 3;
        int LV = (moyenKnow + moyenMeca) /2;
        int potentiel = player.i_potentiel;

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

        chart.UpdateData(0, 0, new List<double> { player.i_mechanic.s_stamina.s_lvl * 100 + player.i_mechanic.s_stamina.s_Xp, player.i_mechanic.s_reflexe.s_lvl*100 + player.i_mechanic.s_reflexe.s_Xp, player.i_knowledge.s_objective.s_lvl *100 + player.i_knowledge.s_objective.s_Xp, player.i_knowledge.s_teamFight.s_lvl * 100 + player.i_knowledge.s_teamFight.s_Xp, player.i_knowledge.s_placement.s_lvl * 100 + player.i_knowledge.s_placement.s_Xp, player.i_mechanic.s_lvlCombo[player.i_favoriteCharacterId].s_lvl * 100 + player.i_mechanic.s_lvlCombo[player.i_favoriteCharacterId].s_Xp });

        i_mecaLV.text = "lvl" + moyenMeca.ToString();
        i_connaiLV.text = "lvl" + moyenKnow.ToString();

        for (int i = 0; i < LV; i++)
        {
            i_lvl[i].color = Color.yellow;
        }

        for (int i = 0; i < potentiel; i++)
        {
            i_Potentiel[i].color = Color.yellow;
        }

        i_prenom.text = player.i_name;
        i_nom.text = player.i_name;
        i_surnom.text = player.i_name;

        i_role.text = GetRoleName(player.i_role);

        //sysnergie team


    }
    public void CleanUp()
    {
        for (int i = 0; i < 5; i++)
        {
            i_lvl[i].color = Color.white;
        }

        for (int i = 0; i < 5; i++)
        {
            i_Potentiel[i].color = Color.white;
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
