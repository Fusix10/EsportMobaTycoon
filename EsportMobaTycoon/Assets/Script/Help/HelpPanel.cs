using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterSkin skin;

    private void Start()
    {
        gameObject.SetActive(false);

        if(GameManager.Instance.i_manager.i_skin != null) skin.SetSkin(GameManager.Instance.i_manager.i_skin);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        animator.SetTrigger("FadeOut");
    }

    public void CloseEvent()
    {
        gameObject.SetActive(false);
    }
}
