using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI; // Ajoutez pour Text et Button

public class PopUpManager : MonoBehaviour
{

    [SerializeField] public EventManager i_EventManager;
    [SerializeField] public GameObject PopUpsContainer;

    [SerializeField] private List<PopUpBase> i_popUpList;

    private Queue<PopUpData> i_PopUpsToDisplay; 

    void Awake()
    {
        i_popUpList = new List<PopUpBase>();
        i_PopUpsToDisplay = new Queue<PopUpData>();

        i_EventManager = this.GetComponent<EventManager>();
        i_EventManager.i_onEventPlay.AddListener(OnEventPlay);

        GetPopUpFromContainer(PopUpsContainer);
    }

    private void GetPopUpFromContainer(GameObject container)
    {
        // Récupérer tous les composants de type PopUpBase dans les enfants du conteneur
        PopUpBase[] popUps = container.GetComponentsInChildren<PopUpBase>(true);

        // Ajouter chaque PopUpBase trouvé à la file d'attente i_PopUpsToDisplay
        foreach (var popUp in popUps)
        {
            i_popUpList.Add(popUp.GetComponent<PopUpBase>());
        }
    }

    private void OnEventPlay(EventBase eventBase)
    {
        Debug.Log("Event Display Request Received : " + eventBase.popUpData.name); 
        i_PopUpsToDisplay.Enqueue(eventBase.popUpData);
    }

    public void PopUpRequest(PopUpData popUpData)
    {
        i_PopUpsToDisplay.Enqueue(popUpData);
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

        // Si aucune action, créer un bouton qui ferme la popUp
        if (popUpData.actions == null)
        {
            Debug.Log("No Buttons found");
            CreateCloseButton(popUp);
        }
        else
        {
            // Créer des boutons pour chaque action dans popUpData
            Debug.Log("Buttons found");
            foreach (var action in popUpData.actions)
            {
                CreateButton(popUp, action);
            }
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

        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = Color.red; 

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
