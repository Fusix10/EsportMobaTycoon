using UnityEngine;

public class PopUpBase : MonoBehaviour, IPopUp
{
    // Le script doit être attacher a un objet qui ne sera pas désactiver sinon le script ne marchera plus donc on désactive la target
    [SerializeField] private GameObject i_popupUi; // Réf au GameObject contenant le script
   
    public void Display()
    {
        i_popupUi.SetActive(true);
    }

    public void Hide()
    {
        i_popupUi.SetActive(false);
    }
}
