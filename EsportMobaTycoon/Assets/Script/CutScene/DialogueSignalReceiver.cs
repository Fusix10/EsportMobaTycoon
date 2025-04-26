using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

public class DialogueSignalReceiver : MonoBehaviour, INotificationReceiver
{
    public DialogueBubble i_bubbleManager;
    public Transform i_targetCharacter;
    public string i_message;
    public float i_duration = 2f;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SignalEmitter)
        {
            i_bubbleManager.ShowBubble(i_message, i_duration);
        }
    }
}

