using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuOptions : MonoBehaviour
{
    [Header("Panels (directement en scène)")]
    [Tooltip("Le menu principal pour le réafficher")]
    public GameObject PanelStart;
    [Tooltip("Le panneau d’options à désactiver")]
    public GameObject PanelOptions;

    [Header("Réglages")]
    public Slider vibrationSlider;
    public TMP_Dropdown dropdownFrameRate;

    private MenuStart menuStart;

    void Awake()
    {
        // Trouve le MenuStart actif dans la scène
        menuStart = FindFirstObjectByType<MenuStart>();
        if (menuStart == null)
            Debug.LogError("MenuStart introuvable dans la scène !");
    }

    void Start()
    {
        vibrationSlider.onValueChanged.AddListener(ChangeVibration);
        dropdownFrameRate.onValueChanged.AddListener(ChangeFrameRate);
    }

    void Update()
    {
        // pas d’update spécifique avant
    }

    /// <summary>
    /// Bouton “Retour” dans le panneau Options.
    /// Appelle CloseOptions() de MenuStart.
    /// </summary>
    public void ButtonBack()
    {
        if (menuStart != null)
            menuStart.CloseOptions();
        else
        {
            // fallback si jamais
            PanelOptions.SetActive(false);
            PanelStart.SetActive(true);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void ChangeVibration(float value)
    {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        var vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        if (vibrator.Call<bool>("hasVibrator"))
        {
            long duration = (long)(value * 1000);
            vibrator.Call("vibrate", duration);
        }
    }

    private void ChangeFrameRate(int index)
    {
        int[] fpsValues = { 30, 60, 120 };
        if (index < fpsValues.Length)
        {
            Application.targetFrameRate = fpsValues[index];
            Debug.Log("FPS changé : " + Application.targetFrameRate);
        }
    }
}
