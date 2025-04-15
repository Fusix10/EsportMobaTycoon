using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewPopUpData", menuName = "PopUp Data")]
public class PopUpData : ScriptableObject
{
    public List<ActionMother> actions; // Liste des actions associées à la pop-up
    // un bouton est créer pour chaque action dans la liste Si la liste est vide un bouton pour fermer la popUp sera créer par défault. 
}
