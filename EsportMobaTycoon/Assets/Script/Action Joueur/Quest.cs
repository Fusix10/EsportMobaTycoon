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

    public Sprite i_iconYellow;
    public Sprite i_iconBlue;

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
        }
    }

    public void QuestBlue()
    {
        for (int i = 0; i < i_listQuestBlue.Length; i++)
        {
            i_textQuest[i].text = i_listQuestBlue[i].quest;
            i_textMoney[i].text = i_listQuestBlue[i].money.ToString();
            i_iconMoney[i].sprite = i_iconBlue;
        }
    }
}
[System.Serializable]
public class DataQuest
{
    public string quest;
    public int money;
    public bool objectBool;
}
