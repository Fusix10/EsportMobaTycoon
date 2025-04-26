using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorEvent : ActionOnDurationTime
{
    int requiredReputation = 50;
    public int moneyGainPerTurn = 100;
    Manager_Utilisateur manager;

    //Indique si le sponsor est activé après achat?
    //private bool isActive = false;
    public void init(Manager_Utilisateur mgr, int repCost, int moneyEarned)
    {
        manager = mgr;
        requiredReputation = repCost;
        moneyGainPerTurn = moneyEarned;
    }
    protected override void action()
    {
        if (manager == null)
        {
            Debug.LogWarning("Manager_Utilisateur n'est pas assigné dans SponsorEvent !");
            return;
        }

        if (manager.i_reputation >= requiredReputation)
        {
            manager.i_reputation -= requiredReputation;
            manager.i_currentMoney += moneyGainPerTurn;
            Debug.Log("SponsorEvent déclenché : " +
                      "Réputation utilisée : " + requiredReputation +
                      ", Argent gagné : " + moneyGainPerTurn);
        }
        else
        {
            Debug.Log("Réputation insuffisante pour déclencher SponsorEvent. " +
                      "Réputation requise : " + requiredReputation +
                      ", Réputation actuelle : " + manager.i_reputation);
        }
    }
}
