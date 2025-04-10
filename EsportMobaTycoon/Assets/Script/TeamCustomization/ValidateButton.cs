using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateButton : MonoBehaviour
{
    [SerializeField] private UnputFieldGrabber inputFieldGrabber1;
    [SerializeField] private UnputFieldGrabber inputFieldGrabber2;

    [SerializeField] private Carouselle carouselle1;
    [SerializeField] private Carouselle carouselle2;

    //[SerializeField] private GameManager gameManager;


    void Start()
    {
        // V�rifiez si les r�f�rences sont assign�es
        if (inputFieldGrabber1 == null || inputFieldGrabber2 == null)
        {
            Debug.LogError("InputFieldGrabber slots are not assigned.");
        }

        if (carouselle1 == null || carouselle2 == null)
        {
            Debug.LogError("Carouselle slots are not assigned.");
        }

        //if (gameManager == null)
        //{
        //    Debug.LogError("GameManager slot is not assigned.");
        //}
    }

    void Update()
    {
        
    }

    public void Validate()
    {
        string Name = inputFieldGrabber1.getInputText();
        string Surname = inputFieldGrabber2.getInputText();

        Sprite spritCarouselle1 = carouselle1.getSprite();
        Color spriteColor1 = carouselle1.getColor();

        Sprite spritCarouselle = carouselle2.getSprite();
        Color spriteColor  = carouselle2.getColor();

        // need code to send to GameManager


    }
}
