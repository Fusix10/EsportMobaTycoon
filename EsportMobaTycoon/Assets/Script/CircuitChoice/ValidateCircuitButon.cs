using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateCircuitButon : MonoBehaviour
{
    [SerializeField] CircuitManager i_manager;


    public void Submit()
    {
        GameManager.Instance.i_circuit = i_manager.i_circuits[i_manager.i_circuitManager.i_currentId];
    }
}
