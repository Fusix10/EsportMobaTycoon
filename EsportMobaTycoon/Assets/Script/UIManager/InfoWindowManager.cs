using UnityEngine;

public class InfoWindowManager : MonoBehaviour
{
    public GameObject infoManager;

    //affiche la fenÍtre d'information
    public void ShowInfoWindow()
    {
        if (infoManager != null)
        {
            infoManager.SetActive(true);
        }
        else
        {
            Debug.LogWarning("infoWindow n'est pas assignÅE!");
        }
    }

    //cache la fenÍtre d'information
    public void HideInfoWindow()
    {
        if (infoManager != null)
        {
            infoManager.SetActive(false);
        }
    }
}
