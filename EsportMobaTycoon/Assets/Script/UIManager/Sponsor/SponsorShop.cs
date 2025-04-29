using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorShop : MonoBehaviour
{
    public static void OnTimeDurationButton()
    {
        if (GameManager.Instance.i_manager.i_sponsorEvent != null) return;

        SponsorEvent sponsorEvent = new SponsorEvent();
        GameManager.Instance.i_manager.i_sponsorEvent = sponsorEvent;
        sponsorEvent.init(GameManager.Instance.i_manager, 50, 100);
        sponsorEvent.setTimer(5);
        GameManager.Instance.AddAction(sponsorEvent);
    }
}
