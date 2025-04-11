using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Utilisateur : MonoBehaviour
{
    //Stats dans manager
    public float currentMoney = 1000;//
    public int popularity = 0;//
    private List<Player> teamPlayers = new ();//

    public TextMeshProUGUI infoText;

    public Budget budget;

    //met a jour le texte de la fen�tre avec les stats actuelles
    public void UpdateUi()
    {
        if (infoText != null)
        {
            infoText.text = "Argent Actuel : " + i_currentMoney + "$\n" +
                            "Popularit�E: " + i_reputation + "\n" +
                            "Joueurs (" + teamPlayers.Count + ") :\n";
        }
        else
        {
            Debug.LogWarning("infoText n'est pas assign�E!");
        }
    }

    void Start()
    {
        UpdateUi();
    }

    void Update()
    {
        
        //augenter l'argent avec A
        if (Input.GetKeyDown(KeyCode.Q))
        {
            i_currentMoney += 50;
            UpdateUi();
            Debug.Log("in A");
        }

        //diminuer l'argent avec Z
        if (Input.GetKeyDown(KeyCode.W))
        {
            i_currentMoney -= 100;
            UpdateUi();
            Debug.Log("in Z");
        }

        //augmenter la popularit�Eavec E
        if (Input.GetKeyDown(KeyCode.E))
        {
            i_reputation += 50;
            UpdateUi();
            Debug.Log("in E");
        }

        //diminuer la popularit�Eavec R
        if (Input.GetKeyDown(KeyCode.R))
        {
            i_reputation -= 50;
            UpdateUi();
            Debug.Log("in R");
        }

        //ajouter un joueur avec T
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            Player nouveauJoueur = "Joueur" + (teamPlayers.Count + 1);
            AddPlayer(nouveauJoueur);
            MettreAJourUI();
        }*/

        //retirer un joueur avec Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (teamPlayers.Count > 0 && teamPlayers.Count < 5)
            {
                Player playerToRemove = teamPlayers[teamPlayers.Count - 1];
                RemovePlayer(playerToRemove);
                UpdateUi();
                Debug.Log("in Y");
            }
        }
    }

    /*public void AjouterPopularite(int points)
    {
        popularite += points;
        while (popularite >= seuilPourNiveauSuivant)
        {
            popularite -= seuilPourNiveauSuivant;
            niveauPopularite++;
            seuilPourNiveauSuivant *= 2; //le seuil double �Echaque niveau ? ou on change
        }
    }*/

   /* public void RetirerPopularite(int points)
    {
        popularite -= points;
        if (popularite < 0)
        {
            popularite = 0;
        }
    }*/

    public void AddPlayer(Player player)//
    {
        if (teamPlayers.Count < 5)
        {
            teamPlayers.Add(player);
        }
    }

    public void RemovePlayer(Player player)//
    {
        if (teamPlayers.Contains(player) && teamPlayers.Count > 0)
        {
            teamPlayers.Remove(player);
        }
    }

    void AcheterItem(int cost)
    {
        if (budget.AcheterObjet(cost))
        {
            //l'achat a �t�Er�alis�E ajouter alors l'item �El'inventaire
        }
        else
        {
            //g�rer le cas d'�chec (fonds insuffisants).
        }
    }
}