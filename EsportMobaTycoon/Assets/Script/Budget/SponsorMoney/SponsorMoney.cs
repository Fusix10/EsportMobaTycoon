using UnityEngine;

public class SponsorMoney : MonoBehaviour
{
    public Manager_Utilisateur manager;

    public bool PeutAcheterSponsor(int cout)
    {
        if (manager == null)
        {
            Debug.LogWarning("Manager_Utilisateur n'est pas assigné dans PurchaseSponsor !");
            return false;
        }
        return manager.popularite >= cout;
    }

    public bool AcheterSponsor(int cout)
    {
        if (PeutAcheterSponsor(cout))
        {
            manager.popularite -= cout;
            Debug.Log("Achat sponsor réussi. Nouvelle popularité : " + manager.popularite);
            return true;
        }
        else
        {
            Debug.Log("Popularité insuffisante pour acheter cet objet sponsor. Popularité actuelle : " + manager.popularite);
            return false;
        }
    }
}
