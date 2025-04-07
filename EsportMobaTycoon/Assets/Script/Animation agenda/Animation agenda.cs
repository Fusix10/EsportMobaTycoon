using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Animationagenda : MonoBehaviour
{
    public List<Vector2> transforms;
    public List<TMP_Text> text;
    private bool startAnim;
    public GameObject panel;
    private float time;
    // Start is called before the first frame update
    void Start()
    {

        /*text.text = "mario";
        text.rectTransform.anchoredPosition = text1.rectTransform.anchoredPosition;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0 && startAnim)
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].rectTransform.anchoredPosition += new Vector2(-1f, 0);
            }
            if (text[1].rectTransform.anchoredPosition.x <= transforms[1].x)
            {
                startAnim = false;
                time = 2;
            }
        }
        time -= Time.deltaTime;
        if (time < 0 && !startAnim)
        {
            panel.SetActive(false);
        }
    }

    public void StartAnimation()
    {
        for (int i = 0; i < text.Count; i++)
        {
            text[i].rectTransform.anchoredPosition = transforms[i + 1];
        }
        time = 1;
        panel.SetActive(true);
        startAnim = true;
    }
}
