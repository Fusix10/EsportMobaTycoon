using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateBuddyButton : MonoBehaviour
{
    [SerializeField] RecrutementBuddy recrutement;

    public void Submit()
    {
        GameManager.Instance.i_buddy = recrutement.GetBuddy();
    }
}
