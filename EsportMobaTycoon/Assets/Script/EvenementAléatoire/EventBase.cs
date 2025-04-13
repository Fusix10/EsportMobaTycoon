using UnityEngine;

[CreateAssetMenu(fileName = "NewEventBase", menuName = "Event Base")]
public class EventBase : ScriptableObject
{
    public float probability = 0.1f;
    public PopUpData popUpData;

    public void Init(PopUpData data)
    {
        popUpData = data;
    }

    public virtual bool Condition()
    {
        return true;
    }

    public bool ThrowDice()
    {
        return Random.value < probability;
    }
}
