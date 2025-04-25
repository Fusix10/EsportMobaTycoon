using UnityEngine;

public class Purchase : MonoBehaviour
{
    //coût de l'objet à acheter
    public int cost = 100;

    public Budget budget;

    //pour acheter l'objet qu'une seule fois
    private bool alreadyPurchased = false;

    private void OnMouseDown()
    {
        if (alreadyPurchased)
        {
            Debug.Log("Cet objet a déjà été acheté.");
            return;
        }

        if (budget == null)
        {
            Debug.LogWarning("La référence au Budget n'est pas assignée !");
            return;
        }

        //tente d'acheter l'objet en vérifiant le budget
        if (budget.AcheterObjet(cost))
        {
            Debug.Log("Achat de l'objet réussi !");
            //alreadyPurchased = true;
            //désactiver l'objet ou changer son apparence après l'achat ?
            //gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Fonds insuffisants pour acheter cet objet.");
        }
    }
}
