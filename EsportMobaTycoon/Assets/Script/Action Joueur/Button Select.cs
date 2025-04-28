using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class ButtonSelect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
    public List<GameObject> i_button;

    public Sprite i_select;
    public Sprite i_dontSelect;

    public Color i_colorBase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = i_select;
        GetComponentInChildren<TMP_Text>().color = Color.white;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = i_dontSelect;
        GetComponentInChildren<TMP_Text>().color = i_colorBase;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = i_select;
        GetComponentInChildren<TMP_Text>().color = Color.white;
        for (int i = 0; i < i_button.Count; i++)
        {
            i_button[i].GetComponent<Image>().sprite = i_dontSelect;
            i_button[i].GetComponentInChildren<TMP_Text>().color = i_colorBase;
        }
        UISystemProfilerApi.AddMarker("Button.onClick", this);
        m_OnClick.Invoke();
    }
}
