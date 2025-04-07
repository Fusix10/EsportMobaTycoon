using UnityEngine;

public class ClickableManager : MonoBehaviour
{
    public InfoWindowManager infoWindowManager;

    //appelée quand l'objet est cliqué/touché
    private void OnMouseDown()
    {
        if (infoWindowManager != null)
        {
            infoWindowManager.ShowInfoWindow();
        }
        else
        {
            Debug.LogWarning("InfoWindowManager non assigné sur la sphère !");
        }
    }
}
