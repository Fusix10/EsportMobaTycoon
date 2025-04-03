using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{

    public GameObject PanelStart;
    public GameObject PanelOptions;

    public Slider vibrationSlider;
    public TMP_Dropdown dropdownFrameRate;

    // Start is called before the first frame update
    void Start()
    {
        vibrationSlider.onValueChanged.AddListener(ChangeVibration);
        dropdownFrameRate.onValueChanged.AddListener(ChangeFrameRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonBack()
    {
        PanelOptions.SetActive(false);
        PanelStart.SetActive(true);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    void ChangeVibration(float value)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        if (vibrator.Call<bool>("hasVibrator"))
        {
            long duration = (long)(value * 1000);
            vibrator.Call("vibrate", duration);
        }
    }

    void ChangeFrameRate(int index)
    {
        int[] fpsValues = { 30, 60, 120};
        if (index < fpsValues.Length)
        {
            Application.targetFrameRate = fpsValues[index];
            Debug.Log("FPS changé à : " + Application.targetFrameRate);
        }
    }
}
