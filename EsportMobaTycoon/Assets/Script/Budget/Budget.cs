using UnityEngine;

public class Budget : MonoBehaviour
{
    public Manager_Utilisateur manager;
    //vérifie si le joueur possède suffisamment d'argent pour acheter un objet
    public bool PeutAcheterObjet(int cout)
    {
        if (manager == null)
        {
            Debug.LogWarning("Manager_Utilisateur n'est pas assignEdans Budget !");
            return false;
        }
        return manager.i_currentMoney >= cout;
    }
    //tente d'acheter un objet en déduisant son coût du budget si possible
    public bool AcheterObjet(int cout)
    {
        if (PeutAcheterObjet(cout))
        {
            manager.i_currentMoney -= cout;
            Debug.Log("Achat réussi. Nouvel argent : " + manager.i_currentMoney);
            return true;
        }
        else
        {
            Debug.Log("Fonds insuffisants pour acheter cet objet. Argent actuel : " + manager.i_currentMoney);
            return false;
        }
    }
}
