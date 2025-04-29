using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoUI : MonoBehaviour
{
    [SerializeField] LogoData data;

    [SerializeField] Image logo;
    [SerializeField] Image back;
    [SerializeField] Image border;

    public void Start()
    {
        UpdateUI();
    }


    public void SetLogo(LogoData logo)
    {
        data = logo;
        UpdateUI();
    }

    private void UpdateUI()
    {
        logo.sprite = data.logo;
        back.sprite = data.back;
        border.sprite = data.border;
    }
}
