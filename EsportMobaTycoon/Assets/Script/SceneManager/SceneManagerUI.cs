using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class SceneManagerUI : MonoBehaviour
{
    [TextArea(4, 10)]
    [Tooltip("Mapping des actions par ID.")]
    public string aideMemoire = "Menu 0\r\nCutScene 1\r\nAvatar 2\r\nLogo 3\r\nBuddy 4\r\nHiring 5\r\nCircuit 6\r\nHub 7\r\nHub1 8\r\nHub2 9\r\nHub3 10\r\nMatch 11\r\nTournaments 12\r\nResult 13";

    public int i_state;
    public bool i_lock;

    public void ChangeStateButton()
    {
        if (i_lock == false)
        {
            GameManager.Instance.ChangeState(i_state);
        }
    }
}



