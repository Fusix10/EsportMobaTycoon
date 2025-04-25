using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;
//using Unity.Notifications.iOS;

public class NotificationManager : MonoBehaviour
{
    public Button notificationButton;
    private bool areNotificationsEnabled = false;

    void Start()
    {
        // Initialisez les notifications selon la plateforme
        InitializeNotifications();

        // Ajoutez l'événement au bouton
        notificationButton.onClick.AddListener(ToggleNotifications);
    }

    void InitializeNotifications()
    {
#if UNITY_ANDROID
        AndroidNotificationCenter.Initialize();
#elif UNITY_IOS
        iOSNotificationCenter.ApplicationDidFinishLaunching();
#endif
    }

    void ToggleNotifications()
    {
        areNotificationsEnabled = !areNotificationsEnabled;

        if (areNotificationsEnabled)
        {
            // Activez les notifications
            EnableNotifications();
        }
        else
        {
            // Désactivez les notifications
            DisableNotifications();
        }
    }

    void EnableNotifications()
    {
#if UNITY_ANDROID
        // Exemple pour Android : Envoyer une notification
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Notification";
        notification.Text = "Vous avez activé les notifications !";
        notification.FireTime = System.DateTime.Now.AddSeconds(5);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
#elif UNITY_IOS
        // Exemple pour iOS : Planifier une notification locale
        iOSNotification notification = new iOSNotification();
        notification.Identifier = "test_notification";
        notification.Title = "Notification";
        notification.Body = "Vous avez activé les notifications !";
        notification.Trigger = new iOSNotificationTimeTrigger() { TimeInterval = new System.TimeSpan(0, 0, 5) };

        iOSNotificationCenter.ScheduleNotification(notification);
#endif
    }

    void DisableNotifications()
    {
#if UNITY_ANDROID
        // Exemple pour Android : Désactiver les notifications
        AndroidNotificationCenter.CancelAllNotifications();
#elif UNITY_IOS
        // Exemple pour iOS : Annuler les notifications
        iOSNotificationCenter.RemoveScheduledNotification("test_notification");
#endif
    }
}

