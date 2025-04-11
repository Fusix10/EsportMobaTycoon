using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EventManager : MonoBehaviour
{
    //[SerializeField] private PopUpManager i_PopUpManager;
    [SerializeField] public List<EventBase> i_InactiveEvents; //List Event a remplir de tout les events avant le start
    private List<EventBase> i_ActiveEvents; 

    // List des Event qui ont ÈtÈ proc
    public UnityEvent<EventBase> i_onEventPlay;

    void Start()
    {
        i_ActiveEvents = new List<EventBase>();
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
        foreach (var inactiveEvent in i_InactiveEvents)
        {
            EventBase myEvent = inactiveEvent as EventBase;
            if (myEvent != null && myEvent.Condition())
            {
                toActivate.Add(inactiveEvent);
            }
        }

        // VÈrification des ÈlÈments actifs
        foreach (var activeEvent in i_ActiveEvents)
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
            i_ActiveEvents.Add(eventToActivate);
            i_InactiveEvents.Remove(eventToActivate);
        }

        // Ajustement des ÈlÈments ÅEdÈsactiver
        foreach (var eventToDeactivate in toDeactivate)
        {
            i_InactiveEvents.Add(eventToDeactivate);
            i_ActiveEvents.Remove(eventToDeactivate);
        }
    }

    private void ThrowDices()
    {
        foreach (var activeEvent in i_ActiveEvents)
        {
            EventBase eventBase = activeEvent as EventBase;
            if (eventBase != null)
            {
                if (eventBase.ThrowDice())
                {
                    i_onEventPlay.Invoke(eventBase);
                    //event add to 
                }

            }
        }
    }
}
