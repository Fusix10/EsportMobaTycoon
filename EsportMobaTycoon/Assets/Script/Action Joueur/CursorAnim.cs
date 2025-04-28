using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorAnim : MonoBehaviour
{
    [SerializeField] Animator animator;


    void Update()
    {

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            transform.position = Input.GetTouch(0).position;
            animator.SetTrigger("Click");

        }
    }
}
