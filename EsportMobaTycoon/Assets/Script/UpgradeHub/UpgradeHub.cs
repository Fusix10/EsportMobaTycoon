using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHub : MonoBehaviour
{

    public Button UpgradeButton;
    public Button BackButton;

    public void SelectLocal(string localName)
    {
        switch (localName)
        {
            case "Local1":
                GameManager.Instance.setGameState(GameState.Hub);
                break;
            case "Local2":
                GameManager.Instance.setGameState(GameState.Hub2);
                break;
            case "Local3":
                GameManager.Instance.setGameState(GameState.Hub3);
                break;

        }
    }
}
