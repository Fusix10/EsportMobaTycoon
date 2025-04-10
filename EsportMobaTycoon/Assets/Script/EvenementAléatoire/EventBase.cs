using UnityEngine;

public class EventBase : PopUpBase
{
    public float probability = 0.1f;

    public virtual bool Condition()
    {
        // Logique pour déterminer si l'événement doit être ajouté à ActiveEvents
        // Par défaut, retourne true, mais peut être redéfinie dans les classes dérivées
        return true;
    }

    public void ThrowDice()
    {
        bool result = Random.value < probability;
        if (result)
        {
            Play();
        }
    }

    public void Play()
    {
        Display();
    }

    
}
