using UnityEngine;

public class PopUpBase : MonoBehaviour, IPopUp
{
    [SerializeField] private GameObject i_popupUi; // Réf au GameObject contenant l'UI
    public bool i_isOccupied = false;

    void Start()
    {
        if (i_popupUi == null)
        {
            Debug.LogError("PopUp GameObject is not assigned.");
        }
        else
        {
            i_popupUi.SetActive(false);
        }
    }

    public void Display()
    {
        i_popupUi.SetActive(true);
    }

    public void Hide()
    {
        i_popupUi.SetActive(false);
    }

    public GameObject GetPopupUi()
    {
        return i_popupUi;
    }
}
