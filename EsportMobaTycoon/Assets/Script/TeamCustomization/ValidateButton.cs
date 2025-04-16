using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateButton : MonoBehaviour
{

    [SerializeField] private List<UnputFieldGrabber> inputFieldGrabberList;
    [SerializeField] private List<Carouselle> CarouselleList;
    GameManager gameManager;
    [SerializeField] private bool isGenderXX;
    //[SerializeField] private GameManager gameManager;

    void Start()
    {
        //if (gameManager == null)
        //{
        //    Debug.LogError("GameManager slot is not assigned.");
        //}
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        
    }

    public void ValidatePlayer(Manager_Utilisateur manager)
    {
        inputFieldGrabberList[0].getInputText();
        inputFieldGrabberList[1].getInputText();

        CarouselleList[0].getSprite();
        CarouselleList[1].getSprite();
        CarouselleList[2].getSprite();
        CarouselleList[3].getSprite();

        manager.init(inputFieldGrabberList[0].getInputText(), inputFieldGrabberList[1].getInputText(), CarouselleList[0].getSprite(),
            CarouselleList[1].getSprite(), CarouselleList[2].getSprite(), CarouselleList[3].getSprite(), isGenderXX);
    }

    public void ValidateTeam()
    {
        GameManager.Instance.i_manager.TeamInit(inputFieldGrabberList[0].getInputText(), inputFieldGrabberList[1].getInputText(),
            CarouselleList[0].getSprite(), CarouselleList[1].getSprite());
        // need code to send to GameManager
    }

    public void ToggleGender()
    {
        isGenderXX = !isGenderXX;
    }
}
