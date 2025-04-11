using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    public List<EventBase> InactiveEvents;
    private List<EventBase> ActiveEvents;

    [SerializeField]
    private GameObject AlwaysActive; 

    void Start()
    {
        ActiveEvents = new List<EventBase>();

        if (AlwaysActive == null)
        {
            Debug.LogError("Ref a AlwaysActive pas remplie");
        }

        else 
        {
            EventBase[] alwaysActiveEvents = AlwaysActive.GetComponentsInChildren<EventBase>(true);
            foreach (var eventBase in alwaysActiveEvents)
            {
                ActiveEvents.Add(eventBase);
            }
        }

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
        foreach (var inactiveEvent in InactiveEvents)
        {
            EventBase myEvent = inactiveEvent as EventBase;
            if (myEvent != null && myEvent.Condition())
            {
                toActivate.Add(inactiveEvent);
            }
        }

        // VÈrification des ÈlÈments actifs
        foreach (var activeEvent in ActiveEvents)
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
            ActiveEvents.Add(eventToActivate);
            InactiveEvents.Remove(eventToActivate);
        }

        // Ajustement des ÈlÈments ÅEdÈsactiver
        foreach (var eventToDeactivate in toDeactivate)
        {
            InactiveEvents.Add(eventToDeactivate);
            ActiveEvents.Remove(eventToDeactivate);
        }
    }

    private void ThrowDices()
    {
        foreach (var activeEvent in ActiveEvents)
        {
            EventBase eventBase = activeEvent as EventBase;
            if (eventBase != null)
            {
                eventBase.ThrowDice();
            }
        }
    }
}
