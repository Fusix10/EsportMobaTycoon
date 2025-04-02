using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeSystem : MonoBehaviour
{
    int i_actualTime;
    void Start()
    {
        i_actualTime = 0;
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
        this.OnTurnPass();
    }
}