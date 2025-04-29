using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class FpsCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI i_fpsCapText;

    private int i_frameCount;
    private float i_elapsedTime;
    private float i_updateInterval;

    private enum FpsCap
    {
        Low = 30,
        Medium = 60,
        High = 120, 
        Uncapped = -1
    }

    private FpsCap i_currentFpsCap;

    private void Start()
    {
        i_frameCount = 0;
        i_elapsedTime = 0f;
        i_updateInterval = 0.5f;

        i_currentFpsCap = (FpsCap)PlayerPrefs.GetInt("FPS");

        QualitySettings.SetQualityLevel((int)i_currentFpsCap);

        UpdateFps();
    }

    private void Update()
    {
        i_frameCount++;
        i_elapsedTime += Time.unscaledDeltaTime;

        if (i_elapsedTime >= i_updateInterval)
        {
            i_fpsCapText.text = i_currentFpsCap == FpsCap.Uncapped ? "Uncapped" : $"{(int)i_currentFpsCap}";

            i_frameCount = 0;
            i_elapsedTime = 0f;
        }
    }

    public void UpgradeFps()
    {
        var values = (FpsCap[])System.Enum.GetValues(typeof(FpsCap));
        int currentIndex = System.Array.IndexOf(values, i_currentFpsCap);

        if (currentIndex < values.Length - 1)
        {
            i_currentFpsCap = values[currentIndex + 1];

            PlayerPrefs.SetInt("FPS", (int)i_currentFpsCap);
            PlayerPrefs.Save();

            UpdateFps();
        }
    }

    public void DowngradeFps()
    {
        var values = (FpsCap[])System.Enum.GetValues(typeof(FpsCap));
        int currentIndex = System.Array.IndexOf(values, i_currentFpsCap);

        if (currentIndex > 0) 
        {
            i_currentFpsCap = values[currentIndex - 1];

            PlayerPrefs.SetInt("FPS", (int)i_currentFpsCap);
            PlayerPrefs.Save();

            UpdateFps();
        }
    }
    private void UpdateFps()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = (int)i_currentFpsCap;

        Debug.Log($"FPS cap applied: {(int)i_currentFpsCap}");
    }

}
