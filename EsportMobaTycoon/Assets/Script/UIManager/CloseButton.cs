using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public InfoWindowManager infoWindowManager;

    public void CloseWindow()
    {
        if (infoWindowManager != null)
        {
            infoWindowManager.HideInfoWindow();
        }
        else
        {
            Debug.LogWarning("InfoWindowManager non assigné sur le bouton !");
        }
    }
}
