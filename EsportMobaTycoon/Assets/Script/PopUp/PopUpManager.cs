using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI; // Ajoutez pour Text et Button

public class PopUpManager : MonoBehaviour
{

    [SerializeField] public GameManager i_gameManager;


    [SerializeField] private List<PopUpBase> i_popUpList;

    private Queue<PopUpData> i_PopUpsToDisplay; 

    void Awake()
    {
        i_popUpList = new List<PopUpBase>();
        i_PopUpsToDisplay = new Queue<PopUpData>();

        if (GameManager.Instance == null)
        {
            Debug.Log("Didn't find GameManager");
        }

        i_gameManager.i_eventManager.i_onEventPlay.AddListener(OnEventPlay);
        
    }

    private void OnEventPlay(EventBase eventBase)
    {
        Debug.Log("Event Display Request Received : " + eventBase.popUpData.name); 
        i_PopUpsToDisplay.Enqueue(eventBase.popUpData);
    }

    private void Update()
    {

        while (i_PopUpsToDisplay.Count > 0)
        {
            Debug.Log("FindingPopUps");
            // Trouver une pop-up libre
            PopUpBase freePopUp = FindFreePopUp();
            if (freePopUp != null)
            {
                // Remplir la pop-up libre avec les données de la file d'attente
                PopUpData popUpData = i_PopUpsToDisplay.Dequeue();
                FillPopUp(freePopUp, popUpData);
            }
            else
            {
                Debug.Log("No PopUps Available Now");
                // Si aucune pop-up n'est libre, sortir de la boucle
                break;
            }
        }
    }
    
    private PopUpBase FindFreePopUp()
    {
        foreach (var popUp in i_popUpList)
        {
            if (!popUp.i_isOccupied)
            {
                Debug.Log("popUp attribued is : " +  popUp.name);
                return popUp;
            }
        }
        return null;
    }

    private void FillPopUp(PopUpBase popUp, PopUpData popUpData)
    {
        popUp.Display();
        popUp.i_isOccupied = true;

        // Créer des boutons pour chaque action dans popUpData
        foreach (var action in popUpData.actions)
        {
            CreateButton(popUp, action);
        }

        // Si aucune action, créer un bouton qui ferme la popUp
        if (popUpData.actions.Count == 0)
        {
            CreateCloseButton(popUp);
        }
    }

    private void CreateButton(PopUpBase popUp, ActionMother action)
    {

        GameObject buttonObj = new GameObject("ActionButton");
        buttonObj.transform.SetParent(popUp.GetPopupUi().transform, false);

        Button button = buttonObj.AddComponent<Button>();
        button.onClick.AddListener(() => OnButtonClick(popUp, action));

    }

    private void CreateCloseButton(PopUpBase popUp)
    {
        GameObject buttonObj = new GameObject("CloseButton");
        buttonObj.transform.SetParent(popUp.GetPopupUi().transform, false);

        Button button = buttonObj.AddComponent<Button>();
        button.onClick.AddListener(() => OnCloseButtonClick(popUp));


        Text buttonText = buttonObj.AddComponent<Text>();
        buttonText.text = "Close";
    }

    public void OnButtonClick(PopUpBase popUp, ActionMother SelectedAction)
    {
        GameManager.Instance.AddAction(SelectedAction);
        popUp.Hide();
        popUp.i_isOccupied = false;
    }

    public void OnCloseButtonClick(PopUpBase popUp)
    {
        popUp.Hide();
        popUp.i_isOccupied = false;
    }
}
