using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
    public ScrollRect scrollbar;
    float waitTime;
    float niveauScroll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;
        if (waitTime > 0.2)
        {
            if (niveauScroll <= 0.25)
            {
                scrollbar.horizontalScrollbar.value = 0;
            }
            else if (niveauScroll > 0.25 && niveauScroll <= 0.25 *3)
            {
                scrollbar.horizontalScrollbar.value = 0.5f;
            }
            else if (niveauScroll > 0.25 * 3 && niveauScroll <= 0.25 * 4)
            {
                scrollbar.horizontalScrollbar.value = 1f;
            }
        }
    }

    public void ClampScroll(Vector2 vec)
    {
        waitTime = 0;
        niveauScroll = vec.x;
    }
}
