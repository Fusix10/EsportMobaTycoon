using UnityEngine;
using UnityEngine.UI;

public class HapticsToggle : MonoBehaviour
{
    [SerializeField] private Toggle i_hapticsToggle;

    private void Start()
    {
        i_hapticsToggle.onValueChanged.AddListener(OnToggleChanged);

        UpdateHapticsState(i_hapticsToggle.isOn);
    }

    private void OnToggleChanged(bool isOn)
    {
        UpdateHapticsState(isOn);
    }

    private void UpdateHapticsState(bool isEnabled)
    {
        if (isEnabled)
        {
            Debug.Log("Haptics enabled");
        }
        else
        {
            Debug.Log("Haptics disbaled");
        }

    }
}
