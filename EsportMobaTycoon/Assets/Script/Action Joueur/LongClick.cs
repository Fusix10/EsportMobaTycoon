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
    public Button ButtonTime;

    private bool i_TimePassActivate;
    private void Start()
    {
        if(SliderTime != null)
        {
            SliderTime.maxValue = requiredHoldTime;
        }
        i_TimePassActivate = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
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
            if (pointerDownTimer >= requiredHoldTime && !i_TimePassActivate )
            {
                if(onLongClick != null)
                {
                    i_TimePassActivate = true;
                    onLongClick.Invoke();
                }
                Reset();
            }
        }
    }

    private void Reset()
    {
        i_TimePassActivate = false;
        pointerDown = false;
        pointerDownTimer = 0;
        if (SliderTime != null)
        {
            SliderTime.value = 0;
        }
    }

}
