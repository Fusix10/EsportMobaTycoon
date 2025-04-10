using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeSystem : MonoBehaviour
{
    int i_actualTime;

    //RandomEvent
    public List<RandomEventTest> randomEvents;
    public float eventProbability = 0.1f;

    void Start()
    {
        i_actualTime = 0;

        //RandomEvent
        randomEvents = new List<RandomEventTest>();
        if (randomEvents.Count == 0)
        {
            Debug.LogError("No RandomEvents in list");
        }
    }

    void Update()
    {
        
    }

    public delegate void TurnPass();
    public event TurnPass OnTurnPass;

    public void AddAction(ActionMother NewAction)
    {
        OnTurnPass += NewAction.actualise;
    }

    public void DeleteAction(ActionMother NewAction)
    {
        OnTurnPass -= NewAction.actualise;
    }

    public void passingTime()
    {
        i_actualTime++;

        //RandomEvent
        if (Random.value < eventProbability)
        {
            TriggerRandomEvent();
        }

        this.OnTurnPass();
    }

    //RandomEvent
    private void TriggerRandomEvent()
    {
        int randomIndex = Random.Range(0, randomEvents.Count);
        RandomEventTest selectedEvent = randomEvents[randomIndex];
        selectedEvent.Display();
    }

}