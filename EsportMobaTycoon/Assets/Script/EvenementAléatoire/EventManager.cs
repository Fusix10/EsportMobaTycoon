using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private List<PopUpBase> LPopUp;
    [SerializeField] public List<EventBase> LInactiveEvents; //List Event a remplir de tout les events avant le start
    private List<EventBase> LActiveEvents; 

    [SerializeField]
    private GameObject AlwaysActive; 

    void Start()
    {
        LActiveEvents = new List<EventBase>();

        if (AlwaysActive == null)
        {
            Debug.LogError("Ref a AlwaysActive pas remplie");
        }

        else 
        {
            EventBase[] alwaysActiveEvents = AlwaysActive.GetComponentsInChildren<EventBase>(true);
            foreach (var eventBase in alwaysActiveEvents)
            {
                LActiveEvents.Add(eventBase);
            }
        }

        LinkPopUpToEvent();

    }

    void Update()
    {

    }

    public void Churn()
    {
        UpdateEvent();
        ThrowDices();
    }

    private void UpdateEvent()
    {
        List<EventBase> toActivate = new List<EventBase>();
        List<EventBase> toDeactivate = new List<EventBase>();

        // VÈrification des ÈlÈments inactifs
        foreach (var inactiveEvent in LInactiveEvents)
        {
            EventBase myEvent = inactiveEvent as EventBase;
            if (myEvent != null && myEvent.Condition())
            {
                toActivate.Add(inactiveEvent);
            }
        }

        // VÈrification des ÈlÈments actifs
        foreach (var activeEvent in LActiveEvents)
        {
            EventBase myEvent = activeEvent as EventBase;
            if (myEvent != null && !myEvent.Condition())
            {
                toDeactivate.Add(activeEvent);
            }
        }

        // Ajustement des ÈlÈments ÅEactiver
        foreach (var eventToActivate in toActivate)
        {
            LActiveEvents.Add(eventToActivate);
            LInactiveEvents.Remove(eventToActivate);
        }

        // Ajustement des ÈlÈments ÅEdÈsactiver
        foreach (var eventToDeactivate in toDeactivate)
        {
            LInactiveEvents.Add(eventToDeactivate);
            LActiveEvents.Remove(eventToDeactivate);
        }
    }

    private void ThrowDices()
    {
        foreach (var activeEvent in LActiveEvents)
        {
            EventBase eventBase = activeEvent as EventBase;
            if (eventBase != null)
            {
                eventBase.ThrowDice();
            }
        }
    }

    private void LinkPopUpToEvent()
    {
        foreach (var inactiveEvent in LInactiveEvents)
        {
            foreach (var popUp in LPopUp)
            {
                if (popUp.gameObject.tag == inactiveEvent.GetType().Name)
                {
                    inactiveEvent.popUp = popUp;
                    break; // Sortir de la boucle une fois le PopUp associÈ
                }
            }
        }
    }
}
