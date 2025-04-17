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
    private float time;
    public enum Day
    {
        lundi,
        mardi,
        mercredi,
        jeudi,
        vendredi,
        samedi,
        dimanche,
        //dimanche = -1
    }

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        startAnim = false;
        /*text.text = "mario";
        text.rectTransform.anchoredPosition = text1.rectTransform.anchoredPosition;*/
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && startAnim)
        {
            panel.SetActive(false);
            i_animator.SetBool("isActivate", false);
            startAnim = false;
        }
    }

    public void StartAnimation()
    {
        if (!startAnim)
        {
            UpdateName();
            time = 3;
            panel.SetActive(true);
            i_animator.SetBool("isActivate", true);
            startAnim = true;
        }
    }

    public void UpdateName()
    {
        text[0].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime()-1) % 7)).ToString();
        text[1].text = ((Day)(GameManager.Instance.GetItimeSystem().GetTime() % 7)).ToString();
        text[2].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime() + 1) % 7)).ToString();
        text[3].text = ((Day)((GameManager.Instance.GetItimeSystem().GetTime() + 2) % 7)).ToString();
    }
}
