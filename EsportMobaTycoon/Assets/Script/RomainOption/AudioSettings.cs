using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider i_musicSlider;
    [SerializeField] private Slider i_soundsSlider;

    // Need to make audio mixer with music and sound files 

    //[SerializeField] 
    //private AudioMixer i_audioMixer;

    private void Start()
    {
        i_musicSlider.onValueChanged.AddListener(SetMusicVolume);
        i_soundsSlider.onValueChanged.AddListener(SetSoundsVolume);
    }

    private void SetMusicVolume(float value)
    {
        Debug.Log($"Music volume set to {value}");

        //i_audioMixer.SetFloat("MusicVolume", SliderValueToDecibel(value));
    }

    private void SetSoundsVolume(float value)
    {
        Debug.Log($"Sounds volume set to {value}");
        //i_audioMixer.SetFloat("SoundsVolume", SliderValueToDecibel(value));
    }

    // Convert slider value 0 / 10 to decibels -80 / 0
    private float SliderValueToDecibel(float sliderValue)
    {
        return Mathf.Lerp(-80f, 0f, sliderValue / 10f);
    }
}

