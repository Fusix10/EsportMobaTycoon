using UnityEngine;
using UnityEngine.Events;

public class EventBase 
{
    public float probability = 0.1f;


    public EventBase()
    {
        //Nombre de bouton 
        //Si besoin de click ou pas
    }
    public virtual bool Condition()
    {
        // Logique pour déterminer si l'événement doit être ajouté à ActiveEvents
        // Par défaut, retourne true, mais peut être redéfinie dans les classes dérivées
        return true;
    }

    public bool ThrowDice()
    {
        bool result = Random.value < probability;
        if (result)
        {
            return true;
        }
        else { return false; }
    }
}
