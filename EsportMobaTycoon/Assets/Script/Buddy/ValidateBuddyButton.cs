using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateBuddyButton : MonoBehaviour
{
    [SerializeField] RecrutementBuddy recrutement;

    public void Submit()
    {
        PlayerData data = new();
        data.SetFromPlayer(recrutement.GetBuddy());

        GameManager.Instance.i_buddy = data;
    }
}
