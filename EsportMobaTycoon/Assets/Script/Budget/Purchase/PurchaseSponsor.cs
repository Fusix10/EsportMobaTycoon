using UnityEngine;

public class PurchaseSponsor : MonoBehaviour
{
    public Manager_Utilisateur manager;

    public int coutSponsor = 300;

    private bool alreadyPurchased = false;

    public bool PeutAcheterSponsor(int cout)
    {
        if (manager == null)
        {
            Debug.LogWarning("Manager_Utilisateur n'est pas assigné dans PurchaseSponsor !");
            return false;
        }
        return manager.i_reputation >= cout;
    }

    public bool AcheterSponsor(int cout)
    {
        if (PeutAcheterSponsor(cout))
        {
            manager.i_reputation -= cout;
            Debug.Log("Achat sponsor réussi. Nouvelle popularité : " + manager.i_reputation);
            return true;
        }
        else
        {
            Debug.Log("Popularité insuffisante pour acheter cet objet sponsor. Popularité actuelle : " + manager.i_reputation);
            return false;
        }
    }

    private void OnMouseDown()
    {
        if (alreadyPurchased)
        {
            Debug.Log("Cet objet sponsor a déjà été acheté.");
            return;
        }

        if (AcheterSponsor(coutSponsor))
        {
            Debug.Log("Sponsor acheté avec succès !");
            alreadyPurchased = true;
            //optionnel : Désactiver l'objet après achat
            // gameObject.SetActive(false);
        }
    }
}