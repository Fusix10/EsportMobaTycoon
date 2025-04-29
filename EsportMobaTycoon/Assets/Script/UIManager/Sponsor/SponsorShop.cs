using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SponsorShop : MonoBehaviour
{
    public int i_id;
    public Image bg;

    private void Start()
    {
        UpdateUI();

        GameManager.Instance.OnSponsorSet += OnSponsorSet;
    }

    private void OnSponsorSet()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (GameManager.Instance.i_manager.i_sponsorEvent == null)
        {
            bg.color = Color.white;
            return;
        }

        if (GameManager.Instance.i_manager.i_sponsorEvent.i_sponsorId == i_id) bg.color = Color.white;
        else bg.color = Color.black;

    }

    public void OnTimeDurationButton()
    {
        if (GameManager.Instance.i_manager.i_sponsorEvent != null) return;

        SponsorEvent sponsorEvent = new SponsorEvent();
        sponsorEvent.i_sponsorId = i_id;
        GameManager.Instance.i_manager.i_sponsorEvent = sponsorEvent;
        sponsorEvent.init(GameManager.Instance.i_manager, 50, 100);
        sponsorEvent.setTimer(5);
        GameManager.Instance.AddAction(sponsorEvent);
    }
}
