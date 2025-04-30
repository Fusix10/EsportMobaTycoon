using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateCircuitButon : MonoBehaviour
{
    [SerializeField] CircuitManager i_manager;


    public void Submit()
    {
        GameManager.Instance.i_circuit = i_manager.i_circuits[i_manager.i_circuitManager.i_currentId];
        for (int i = 0; i < i_manager.i_circuits[i_manager.i_circuitManager.i_currentId].i_tournaments.Count; i++) 
        {
            CircuitAction circuitAction = new CircuitAction();
            circuitAction.init(i_manager.i_circuits[i_manager.i_circuitManager.i_currentId].i_tournaments[i]);
            circuitAction.setTimer(i_manager.i_circuits[i_manager.i_circuitManager.i_currentId].i_tournaments[i].i_time);
            GameManager.Instance.AddAction(circuitAction);
        }
    }
}
