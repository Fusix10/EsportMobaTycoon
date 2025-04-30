using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSkinManager : MonoBehaviour
{
    [SerializeField] CharacterSkin i_manager;
    [SerializeField] CharacterSkin i_buddy;

    [SerializeField] bool i_isStanding;

    void Start()
    {
        i_manager.SetSkin(GameManager.Instance.i_manager.i_skin);
        i_buddy.SetSkin(GameManager.Instance.i_buddy.i_skin);

        i_manager.SetStanding(i_isStanding);
        i_buddy.SetStanding(i_isStanding);
    }
}
