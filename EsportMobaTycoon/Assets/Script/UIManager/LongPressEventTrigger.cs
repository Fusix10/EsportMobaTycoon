using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongPressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    public float durationThreshold;

    public UnityEvent onLongPress;
    public UnityEvent onSmallPress;

    private bool isPointerDown;
    private bool longPressTriggered;
    private float timePressStarted;


    private void Update()
    {
        if (isPointerDown && !longPressTriggered)
        {
            if (Time.time - timePressStarted > durationThreshold)
            {
                longPressTriggered = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        timePressStarted = Time.time;
        isPointerDown = true;
        longPressTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (longPressTriggered) onLongPress.Invoke();
        else onSmallPress.Invoke();

        isPointerDown = false;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerDown = false;
    }
}