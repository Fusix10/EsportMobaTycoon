using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class HapticsSettings : MonoBehaviour
{
    [SerializeField] private Slider i_hapticsSlider;

    private void Start()
    {
        i_hapticsSlider.onValueChanged.AddListener(SetHapticsIntensity);
    }

    private void SetHapticsIntensity(float value)
    {
        // need to set value
        // no idea how to set vibrations intensity on mobile
    }
}

