using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidateAvatarButton : MonoBehaviour
{
    [SerializeField] TMP_Text nameField;
    [SerializeField] TMP_Text lastNameField;

    [SerializeField] SkinCarouselle hair;
    [SerializeField] SkinCarouselle face;
    [SerializeField] SkinCarouselle body;
    [SerializeField] SkinCarouselle torso;
    [SerializeField] SkinCarouselle legs;
    [SerializeField] SkinCarouselle shoes;

    [SerializeField] Image male;
    [SerializeField] Image female;
    [SerializeField] Sprite maleSelect;
    [SerializeField] Sprite femaleSelect;
    [SerializeField] Sprite maleUnselect;
    [SerializeField] Sprite femaleUnselect;
    [SerializeField] private bool isGenderMale;



    private void Start()
    {
        Draw();
    }

    public void Submit()
    {
        Skin skin = new()
        {
            i_hairSitting = hair.GetSprite(true),
            i_faceSitting = face.GetSprite(true),
            i_bodySitting = body.GetSprite(true),
            i_shirtSitting = torso.GetSprite(true),
            i_legsSitting = legs.GetSprite(true),
            i_shoesSitting = shoes.GetSprite(true),

            i_hairStanding = hair.GetSprite(),
            i_faceStanding = face.GetSprite(),
            i_bodyStanding = body.GetSprite(),
            i_shirtStanding = torso.GetSprite(),
            i_legsStanding = legs.GetSprite(),
            i_shoesStanding = shoes.GetSprite()
        };


        GameManager.Instance.i_manager.i_skin = skin;

        GameManager.Instance.i_manager.i_isGenderMale = isGenderMale;

        GameManager.Instance.i_manager.i_name = nameField.text;
        GameManager.Instance.i_manager.i_lastName = lastNameField.text;
    }

    public void ToggleGender()
    {
        isGenderMale = !isGenderMale;

        Draw();
    }

    void Draw()
    {
        if (male != null)
            male.sprite = isGenderMale ? maleSelect : maleUnselect;

        if (female != null)
            female.sprite = !isGenderMale ? femaleSelect : femaleUnselect;
    }
}
