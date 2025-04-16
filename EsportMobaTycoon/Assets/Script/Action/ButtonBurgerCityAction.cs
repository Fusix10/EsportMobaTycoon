using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBurgerCity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void OnTimeDurationButton(Manager_Utilisateur manager)
    {
        SponsorEvent sponsorEvent = new SponsorEvent();
        sponsorEvent.init(manager, 50, 100);
        sponsorEvent.setTimer(5);
        GameManager.Instance.AddAction(sponsorEvent);
    }
}
