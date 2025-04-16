using UnityEngine;
using UnityEngine.UI;

public class NotificationsToggle : MonoBehaviour
{
    [SerializeField] private Toggle i_notificationsToggle;

    private void Start()
    {
        i_notificationsToggle.onValueChanged.AddListener(OnToggleChanged);

        UpdateNotificationState(i_notificationsToggle.isOn);
    }

    private void OnToggleChanged(bool isOn)
    {
        UpdateNotificationState(isOn);
    }

    private void UpdateNotificationState(bool isEnabled)
    {
        if (isEnabled)
        {
            Debug.Log("Notifications enabled");
        }
        else
        {
            Debug.Log("Notifications disbaled");
        }

    }
}
