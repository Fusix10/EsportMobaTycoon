using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{

    [SerializeField] private Image targetImage;
    private Color buttonColor;

    void Start()
    {

        Button button = GetComponent<Button>();
        if (button != null)
        {
            buttonColor = button.image.color;
        }
        else
        {
            Debug.LogError("No button Found to get color from");
        }
    }

    public void ChangeColor()
    {
        if (targetImage != null)
        {
            targetImage.color = buttonColor;
        }
    }
}
