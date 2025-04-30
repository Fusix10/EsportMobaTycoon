using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationDisplay : MonoBehaviour
{
    [Header("To Hide")]
    [SerializeField]
    GameObject i_versus;
    [SerializeField]
    GameObject i_theTwoButton;
    [SerializeField]
    LogoUI LogoManager;
    [SerializeField]
    LogoUI LogoEnemy;

    [Header("ToShow")]
    [SerializeField]
    GameObject i_Page;

    [SerializeField]
    TMP_Text i_whoWin;


    [SerializeField]
    List<PreFabPIGet> i_TeamManager;
    [SerializeField]
    List<PreFabPIGet> i_TeamEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawTeam(string kill, string mort, string assist, string playerName, Sprite head, Sprite hair, GameManager.Role role, bool isManagerTeam)
    {
        if (isManagerTeam == true) 
        {
            for (int i = 0; i < i_TeamManager.Count; i++)
            {
                if (i_TeamManager[i].i_Role == role)
                {
                    i_TeamManager[i].i_ValueKill.text = kill;
                    i_TeamManager[i].i_ValueMort.text = mort;
                    i_TeamManager[i].i_ValueAssist.text = assist;
                    i_TeamManager[i].i_playerName.text = playerName;

                    i_TeamManager[i].i_Head.sprite = head;
                    i_TeamManager[i].i_Hair.sprite = hair;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < i_TeamEnemy.Count; i++)
            {
                if (i_TeamEnemy[i].i_Role == role)
                {
                    i_TeamEnemy[i].i_ValueKill.text = kill;
                    i_TeamEnemy[i].i_ValueMort.text = mort;
                    i_TeamEnemy[i].i_ValueAssist.text = assist;
                    i_TeamEnemy[i].i_playerName.text = playerName;

                    i_TeamEnemy[i].i_Head.sprite = head;
                    i_TeamEnemy[i].i_Hair.sprite = hair;
                    break;
                }
            }
        } 
    }

    public void initWin(bool isManagerWin)
    {
        if (isManagerWin)
        {
            i_whoWin.text = "Team manager à Gagné";
        }
        else
        {
            i_whoWin.text = "Team enemy à Gagné";
        }
    }

    public void initLogo(LogoData logoData, bool isManagerTeam)
    {
        if (isManagerTeam)
        {
            LogoManager.SetLogo(logoData);
        }
        else
        {
            LogoEnemy.SetLogo(logoData);
        }
    }

    public void ChangeScene(bool Active)
    {
        i_versus.SetActive(Active);
        i_theTwoButton.SetActive(Active);

        LogoManager.gameObject.SetActive(Active);
        LogoEnemy.gameObject.SetActive(Active);

        i_Page.SetActive(!Active);
    }
}
