using UnityEngine;
using UnityEngine.UI;

public class HapticsToggle : MonoBehaviour
{
    [SerializeField] private Toggle i_hapticsToggle;

    private void Start()
    {
        i_hapticsToggle.isOn = PlayerPrefs.GetInt("Haptics") == 1;
    }

    public void OnToggleChanged(bool isOn)
    {
        if (isOn) PlayerPrefs.SetInt("Haptics", 1);
        else PlayerPrefs.SetInt("Haptics", 0);

        PlayerPrefs.Save();
    }
}
