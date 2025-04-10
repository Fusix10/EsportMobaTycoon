using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LongClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;
    public UnityEvent onLongClick;
    public Slider SliderTime;

    private void Start()
    {
        if(SliderTime != null)
        {
            SliderTime.maxValue = requiredHoldTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("Up");
    }

    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (SliderTime != null)
            {
                SliderTime.value = pointerDownTimer;
            }
            if (pointerDownTimer >= requiredHoldTime)
            {
                if(onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Reset();
            }
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        if (SliderTime != null)
        {
            SliderTime.value = 0;
        }
    }

}
