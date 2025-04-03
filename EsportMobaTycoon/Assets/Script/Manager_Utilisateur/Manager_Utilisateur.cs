using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Utilisateur : MonoBehaviour
{
    //Stats dans manager
    public int argentActuel = 1000;
    public int popularite = 0;
    public int niveauPopularite = 1;
    public int seuilPourNiveauSuivant = 100;
    public List<string> equipeJoueurs = new List<string>();

    public TextMeshProUGUI infoText;

    //met a jour le texte de la fenêtre avec les stats actuelles
    public void MettreAJourUI()
    {
        if (infoText != null)
        {
            infoText.text = "Argent Actuel : " + argentActuel + "$\n" +
                            "Popularité : " + popularite + "/" + seuilPourNiveauSuivant + " (Niveau : " + niveauPopularite + ")\n" +
                            "Joueurs (" + equipeJoueurs.Count + ") : " + string.Join(", ", equipeJoueurs);
        }
        else
        {
            Debug.LogWarning("infoText n'est pas assigné !");
        }
    }

    void Start()
    {
        MettreAJourUI();
    }

    void Update()
    {
        //augenter l'argent avec A
        if (Input.GetKeyDown(KeyCode.Q))
        {
            argentActuel += 50;
            MettreAJourUI();
        }

        //diminuer l'argent avec Z
        if (Input.GetKeyDown(KeyCode.W))
        {
            argentActuel -= 100;
            MettreAJourUI();
        }

        //augmenter la popularité avec E
        if (Input.GetKeyDown(KeyCode.E))
        {
            AjouterPopularite(30);
            MettreAJourUI();
        }

        //diminuer la popularité avec R
        if (Input.GetKeyDown(KeyCode.R))
        {
            RetirerPopularite(50);
            MettreAJourUI();
        }

        //ajouter un joueur avec T
        if (Input.GetKeyDown(KeyCode.T))
        {
            string nouveauJoueur = "Joueur" + (equipeJoueurs.Count + 1);
            AjouterJoueur(nouveauJoueur);
            MettreAJourUI();
        }

        //retirer un joueur avec Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (equipeJoueurs.Count > 0)
            {
                string joueurARetirer = equipeJoueurs[equipeJoueurs.Count - 1];
                RetirerJoueur(joueurARetirer);
                MettreAJourUI();
            }
        }
    }

    public void AjouterPopularite(int points)
    {
        popularite += points;
        while (popularite >= seuilPourNiveauSuivant)
        {
            popularite -= seuilPourNiveauSuivant;
            niveauPopularite++;
            seuilPourNiveauSuivant *= 2; //le seuil double à chaque niveau ? ou on change
        }
    }

    public void RetirerPopularite(int points)
    {
        popularite -= points;
        if (popularite < 0)
        {
            popularite = 0;
        }
    }

    public void AjouterJoueur(string nomJoueur)
    {
        if (equipeJoueurs.Count < 5)
        {
            equipeJoueurs.Add(nomJoueur);
        }
    }

    public void RetirerJoueur(string nomJoueur)
    {
        if (equipeJoueurs.Contains(nomJoueur))
        {
            equipeJoueurs.Remove(nomJoueur);
        }
    }
}