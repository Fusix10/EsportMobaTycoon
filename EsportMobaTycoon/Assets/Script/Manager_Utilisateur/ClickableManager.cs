using UnityEngine;

public class ClickableManager : MonoBehaviour
{
    public InfoWindowManager infoWindowManager;

    //appelÈe quand l'objet est cliquÅEtouchÅE
    private void OnMouseDown()
    {
        if (infoWindowManager != null)
        {
            infoWindowManager.ShowInfoWindow();
        }
        else
        {
            Debug.LogWarning("InfoWindowManager non assignÅEsur la sphËre !");
        }
    }
}
