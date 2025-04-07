using UnityEngine;
using UnityEngine.UI;

public class LinkedSlider : MonoBehaviour
{
    public Slider maxSlider; 
    public Slider valueSlider;

    void Start()
    {
        UpdateMax(maxSlider.value);
        maxSlider.onValueChanged.AddListener(UpdateMax);
    }

    void UpdateMax(float max)
    {
        valueSlider.maxValue = max;

        if (valueSlider.value > max)
        {
            valueSlider.value = max;
        }
    }
}
