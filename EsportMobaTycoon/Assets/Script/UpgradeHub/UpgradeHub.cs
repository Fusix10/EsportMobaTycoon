using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeHub : MonoBehaviour
{
    public Button i_upgradeButton;
    public Button i_backButton;

    public void Start()
    {
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                DeselectLocal();
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                DeselectLocal();
            }
        }
    }

    public void DeselectLocal()
    {
        GameManager.Instance.i_GameState = GameState.Hub;
        i_upgradeButton.interactable = false;
        Debug.Log("Déselection via clic/tap hors UI !");
    }

    public void SelectLocal(GameState state)
    {
        GameManager.Instance.setGameState(state);
        Debug.Log(GameManager.Instance.i_GameState);
        i_upgradeButton.interactable = (state != GameState.Hub);  
    }

    public void Upgrade()
    {
        GameManager.Instance.LoadSceneForCurrentState();
    }

    public void SelectLocal1() => SelectLocal(GameState.Hub1);
    public void SelectLocal2() => SelectLocal(GameState.Hub2);
    public void SelectLocal3() => SelectLocal(GameState.Hub3);
}
