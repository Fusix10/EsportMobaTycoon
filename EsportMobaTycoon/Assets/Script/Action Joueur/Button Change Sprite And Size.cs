using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class ButtonChangeSpriteAndSize : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
    public Image i_isDown;
    public Image i_isUp;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        i_isDown.enabled = true;
        i_isUp.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        i_isDown.enabled = false;
        i_isUp.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UISystemProfilerApi.AddMarker("Button.onClick", this);
        m_OnClick.Invoke();
    }
}
