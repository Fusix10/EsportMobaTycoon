using UnityEngine;

public class Joueur : MonoBehaviour
{
    // Statistiques de base du joueur
    public int attaque = 10;
    public int defense = 10;
    public int forceMentale = 10;
    public int chance = 10;

    // Initialisation
    void Start()
    {
        Debug.Log("Statistiques du joueur initialisées.");
        AfficherStatistiques();
    }

    // Méthode pour afficher les statistiques dans la console (à remplacer par de l'UI si besoin)
    void AfficherStatistiques()
    {
        Debug.Log("Attaque : " + attaque);
        Debug.Log("Défense : " + defense);
        Debug.Log("Force Mentale : " + forceMentale);
        Debug.Log("Chance : " + chance);
    }

    /// <summary>
    /// Méthode pour augmenter une statistique donnée.
    /// </summary>
    /// <param name="stat">Nom de la statistique ("attaque", "defense", "forcementale", "chance")</param>
    /// <param name="value">Valeur à ajouter</param>
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
