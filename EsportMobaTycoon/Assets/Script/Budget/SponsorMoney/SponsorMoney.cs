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
        return manager.popularity >= cout;
    }

    public bool AcheterSponsor(int cout)
    {
        if (PeutAcheterSponsor(cout))
        {
            manager.popularity -= cout;
            Debug.Log("Achat sponsor réussi. Nouvelle popularité : " + manager.popularity);
            return true;
        }
        else
        {
            Debug.Log("Popularité insuffisante pour acheter cet objet sponsor. Popularité actuelle : " + manager.popularity);
            return false;
        }
    }
}
