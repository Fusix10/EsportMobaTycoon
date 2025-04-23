using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public DataQuest[] i_listQuestYellow;
    public DataQuest[] i_listQuestBlue;
    public List<TMP_Text> i_textQuest;
    public List<TMP_Text> i_textMoney;
    public List<Image> i_iconMoney;
    public List<Button> i_buttonColect;

    public Sprite i_iconYellow;
    public Sprite i_iconBlue;

    private bool i_YellowOrBlue; //Yellow = true // Blue = false

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestYellow()
    {
        for(int i = 0; i < i_listQuestYellow.Length; i++)
        {
            i_textQuest[i].text = i_listQuestYellow[i].quest;
            i_textMoney[i].text = i_listQuestYellow[i].money.ToString();
            i_iconMoney[i].sprite = i_iconYellow;
            if (i_listQuestYellow[i].objectBool && i_listQuestYellow[i].isColected)
            {
                i_buttonColect[i].interactable = false;
                i_buttonColect[i].gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Déja colectez";
            }
            else if (i_listQuestYellow[i].objectBool)
            {
                i_buttonColect[i].interactable = true;
                i_buttonColect[i].gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Colectez";
            }
            else
            {
                i_buttonColect[i].interactable = false;
                i_buttonColect[i].gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Colectez";
            }
        }
        i_YellowOrBlue = true;
    }

    public void QuestBlue()
    {
        for (int i = 0; i < i_listQuestBlue.Length; i++)
        {
            i_textQuest[i].text = i_listQuestBlue[i].quest;
            i_textMoney[i].text = i_listQuestBlue[i].money.ToString();
            i_iconMoney[i].sprite = i_iconBlue;
            if (i_listQuestBlue[i].objectBool && i_listQuestBlue[i].isColected)
            {
                i_buttonColect[i].interactable = false;
                i_buttonColect[i].gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Déja colectez";
            }else if(i_listQuestBlue[i].objectBool)
            {
                i_buttonColect[i].interactable = true;
                i_buttonColect[i].gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Colectez";
            }
            else
            {
                i_buttonColect[i].interactable = false;
                i_buttonColect[i].gameObject.transform.GetComponentInChildren<TMP_Text>().text = "Colectez";
            }
        }
        i_YellowOrBlue = false; 
    }

    public void ColectQuest(int id)
    {
        if (i_YellowOrBlue)
        {
            GameManager.Instance.i_manager.i_currentMoney += i_listQuestYellow[id].money;
            i_listQuestYellow[id].isColected = true;
            QuestYellow();
        }
        else
        {
            GameManager.Instance.i_manager.i_currentMoneyPrenium += i_listQuestBlue[id].money;
            i_listQuestBlue[id].isColected = true;
            QuestBlue();
        }
    }

}
[System.Serializable]
public class DataQuest
{
    public string quest;
    public int money;
    public bool objectBool;
    public bool isColected;
}
