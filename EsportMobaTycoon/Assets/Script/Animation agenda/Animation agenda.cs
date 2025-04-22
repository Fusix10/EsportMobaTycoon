using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Animationagenda : MonoBehaviour
{
    public Animator i_animator;
    public List<TMP_Text> text;
    public bool startAnim;
    public GameObject panel;
    public float time;
    public GameObject i_continuButton;
    public enum Day
    {
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
        Dimanche,
        //dimanche = -1
    }

    // Start is called before the first frame update
    void Start()
    {
        startAnim = false;
        time = 0;
        panel.SetActive(false);
        /*text.text = "mario";
        text.rectTransform.anchoredPosition = text1.rectTransform.anchoredPosition;*/
    }

    // Update is called once per frame
    void Update()
    {
        if(startAnim)
        {
            time -= Time.deltaTime;
        }
        if (time < 0 && startAnim)
        {
            panel.SetActive(false);
            i_animator.SetBool("isActivate", false);
            startAnim = false;
            i_continuButton.SetActive(true);
        }
    }

    public void StartAnimation()
    {
        if (!startAnim)
        {
            UpdateName();
            time = 3;
            startAnim = true;
            panel.SetActive(true);
            i_animator.SetBool("isActivate", true);
            i_continuButton.SetActive(false);
        }
    }

    public void UpdateName()
    {
        text[0].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime()-1) % 7)).ToString();
        text[1].text = ((Day)(GameManager.Instance.GetItimeSystem().GetTime() % 7)).ToString();
        text[2].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime() + 1) % 7)).ToString();
        text[3].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime() + 2) % 7)).ToString();
        text[4].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime() + 3) % 7)).ToString();
    }
}
