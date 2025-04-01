using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Utilisateur : MonoBehaviour
{
    // Argent actuel du joueur
    public int argentActuel = 1000;

    // Système de popularité
    public int popularite = 0;               // Points de popularité accumulés
    public int niveauPopularite = 1;         // Niveau actuel de popularité (minimum 1)
    public int seuilPourNiveauSuivant = 100;   // Seuil pour atteindre le niveau suivant

    // Equipe de joueurs (maximum 5 joueurs)
    public List<string> equipeJoueurs = new List<string>();

    void Start()
    {
        Debug.Log("=== Test du Manager Utilisateur ===");
        AfficherStatistiques();
    }

    void Update()
    {
        Debug.Log("Update exécuté");
        // Touche A : Argent +50
        if (Input.GetKeyDown(KeyCode.Q))//A
        {
            Debug.Log("Touche A pressée");
            argentActuel += 50;
            Debug.Log("Argent augmenté de 50. Argent actuel : " + argentActuel);
        }

        // Touche Z : Argent -100
        if (Input.GetKeyDown(KeyCode.W))//Z
        {
            Debug.Log("Touche Z pressée");
            argentActuel -= 100;
            Debug.Log("Argent diminué de 100. Argent actuel : " + argentActuel);
        }

        // Touche E : Popularité +30
        if (Input.GetKeyDown(KeyCode.E))
        {
            AjouterPopularite(30);
            Debug.Log("Popularité augmentée de 30. Popularité : " + popularite + " (Niveau : " + niveauPopularite + ")");
        }

        // Touche R : Popularité -50
        if (Input.GetKeyDown(KeyCode.R))
        {
            RetirerPopularite(50);
            Debug.Log("Popularité diminuée de 50. Popularité : " + popularite + " (Niveau : " + niveauPopularite + ")");
        }

        // Touche T : Ajouter un joueur
        if (Input.GetKeyDown(KeyCode.T))
        {
            string nouveauJoueur = "Joueur" + (equipeJoueurs.Count + 1);
            AjouterJoueur(nouveauJoueur);
        }

        // Touche Y : Retirer le dernier joueur ajouté
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (equipeJoueurs.Count > 0)
            {
                string joueurARetirer = equipeJoueurs[equipeJoueurs.Count - 1];
                RetirerJoueur(joueurARetirer);
            }
            else
            {
                Debug.Log("Aucun joueur à retirer.");
            }
        }
    }

    /// <summary>
    /// Affiche dans la console l'état actuel des statistiques.
    /// </summary>
    void AfficherStatistiques()
    {
        Debug.Log("Argent Actuel : " + argentActuel);
        Debug.Log("Popularité : " + popularite + " (Niveau : " + niveauPopularite + ")");
        Debug.Log("Nombre de joueurs dans l'équipe : " + equipeJoueurs.Count);
        if (equipeJoueurs.Count > 0)
        {
            Debug.Log("Joueurs : " + string.Join(", ", equipeJoueurs));
        }
    }

    /// <summary>
    /// Ajoute des points de popularité et gère la montée de niveau.
    /// </summary>
    /// <param name="points">Nombre de points à ajouter</param>
    public void AjouterPopularite(int points)
    {
        popularite += points;
        // Vérifie si le seuil pour monter de niveau est dépassé
        while (popularite >= seuilPourNiveauSuivant)
        {
            popularite -= seuilPourNiveauSuivant;
            niveauPopularite++;
            seuilPourNiveauSuivant *= 2; // Double le seuil pour le niveau suivant
            Debug.Log("Niveau de popularité augmenté à " + niveauPopularite);
        }
    }

    /// <summary>
    /// Retire des points de popularité et ajuste le niveau si nécessaire.
    /// Le niveau ne descend pas en dessous de 1 et la popularité reste à 0 si l'on est déjà au niveau minimal.
    /// </summary>
    /// <param name="points">Nombre de points à retirer</param>
    public void RetirerPopularite(int points)
    {
        popularite -= points;
        if (popularite < 0)
        {
            popularite = 0;
            Debug.Log("La popularité ne peut pas descendre en dessous de 0. Elle reste au niveau " + niveauPopularite);
        }
    }

    /// <summary>
    /// Ajoute un joueur à l'équipe s'il y a moins de 5 joueurs.
    /// </summary>
    /// <param name="nomJoueur">Nom du joueur à ajouter</param>
    public void AjouterJoueur(string nomJoueur)
    {
        if (equipeJoueurs.Count < 5)
        {
            equipeJoueurs.Add(nomJoueur);
            Debug.Log("Le joueur " + nomJoueur + " a été ajouté à l'équipe.");
        }
        else
        {
            Debug.Log("L'équipe est complète. Veuillez retirer un joueur avant d'en ajouter un nouveau.");
        }
    }

    /// <summary>
    /// Retire un joueur de l'équipe.
    /// </summary>
    /// <param name="nomJoueur">Nom du joueur à retirer</param>
    public void RetirerJoueur(string nomJoueur)
    {
        if (equipeJoueurs.Contains(nomJoueur))
        {
            equipeJoueurs.Remove(nomJoueur);
            Debug.Log("Le joueur " + nomJoueur + " a été retiré de l'équipe.");
        }
        else
        {
            Debug.Log("Le joueur " + nomJoueur + " n'existe pas dans l'équipe.");
        }
    }
}
