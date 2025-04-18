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
        i_upgradeButton.interactable = false;
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

    public void SelectLocal(string localName)
    {
        switch (localName)
        {
            case "Local1":
                GameManager.Instance.setGameState(GameState.Hub1);
                break;
            case "Local2":
                GameManager.Instance.setGameState(GameState.Hub2);
                break;
            case "Local3":
                GameManager.Instance.setGameState(GameState.Hub3);
                break;
            default:
                GameManager.Instance.setGameState(GameState.Hub);
                break;

        }

        Debug.Log(GameManager.Instance.i_GameState);

        i_upgradeButton.interactable = (GameManager.Instance.i_GameState != GameState.Hub);
    }

    public void Upgrade()
    {

        if (GameManager.Instance.i_GameState == GameState.Hub)
        {
            Debug.Log("Pas local selctionné");
            return;
        }

        switch (GameManager.Instance.i_GameState)
        {
            case GameState.Hub1:
                SceneManager.LoadScene("Hub1");
                break;
            case GameState.Hub2:
                SceneManager.LoadScene("Hub2");
                break;
            case GameState.Hub3:
                SceneManager.LoadScene("Hub3");
                break;
        }
    }
}
