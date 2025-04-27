using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text i_textComponent; 
    public float i_delay = 0.1f;     

    private string i_fullText;        
    private string i_currentText = ""; 

    public void StartTypewriter(string textToDisplay)
    {
        i_fullText = textToDisplay;
        i_currentText = "";
        StopAllCoroutines();
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char c in i_fullText)
        {
            i_currentText += c;
            i_textComponent.text = i_currentText;
            yield return new WaitForSeconds(i_delay);
        }
    }
}
