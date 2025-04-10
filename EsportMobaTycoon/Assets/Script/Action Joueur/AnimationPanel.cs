using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPanel : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DownPanel(bool isdown)
    {
        animator.SetBool("isDown", isdown);
    }
}
