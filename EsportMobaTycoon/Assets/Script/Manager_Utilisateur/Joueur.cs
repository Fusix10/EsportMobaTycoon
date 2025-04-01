using UnityEngine;

public class Joueur : MonoBehaviour
{
    //statistiques de base du joueur
    public int attaque = 10;
    public int defense = 10;
    public int forceMentale = 10;
    public int chance = 10;

    void Start()
    {
        Debug.Log("Statistiques du joueur initialisées.");
        AfficherStatistiques();
    }

    // Méthode pour afficher les statistiques dans la console (à remplacer par de l'UI)
    void AfficherStatistiques()
    {
        Debug.Log("Attaque : " + attaque);
        Debug.Log("Défense : " + defense);
        Debug.Log("Force Mentale : " + forceMentale);
        Debug.Log("Chance : " + chance);
    }

    public void AugmenterStatistique(string stat, int value)
    {
        switch (stat.ToLower())
        {
            case "attaque":
                attaque += value;
                break;
            case "defense":
                defense += value;
                break;
            case "forcementale":
                forceMentale += value;
                break;
            case "chance":
                chance += value;
                break;
            default:
                Debug.Log("Statistique inconnue : " + stat);
                break;
        }
        AfficherStatistiques();
    }
}
