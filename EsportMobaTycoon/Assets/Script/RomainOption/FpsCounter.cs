using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI i_fpsText;

    private int i_frameCount;
    private float i_elapsedTime;
    private float i_updateInterval;

    private void Start()
    {
        i_frameCount = 0;
        i_elapsedTime = 0f;
        i_updateInterval = 0.5f;
    }

    private void Update()
    {
        i_frameCount++;
        i_elapsedTime += Time.unscaledDeltaTime;

        if (i_elapsedTime >= i_updateInterval)
        {
            float fps = i_frameCount / i_elapsedTime;
            i_fpsText.text = $"{Mathf.RoundToInt(fps)}";

            i_frameCount = 0;
            i_elapsedTime = 0f;
        }
    }
}
