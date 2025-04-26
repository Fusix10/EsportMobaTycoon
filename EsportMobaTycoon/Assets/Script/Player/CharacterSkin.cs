using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkin : MonoBehaviour
{
    [Header("Stanting")]
    [SerializeField] GameObject i_standing;
    [SerializeField] Skin i_standingSkin;

    [Header("Sitting")]
    [SerializeField] GameObject i_sitting;
    [SerializeField] Skin i_sittingSkin;

    [SerializeField] bool i_isStanding;


    public void SetHair(Sprite sprite)
    {
        if (i_isStanding) i_standingSkin.i_hairSitting.sprite = sprite;
        else i_sittingSkin.i_hairSitting.sprite = sprite;
    }
    public void SetFace(Sprite sprite)
    {
        if (i_isStanding) i_standingSkin.i_faceSitting.sprite = sprite;
        else i_sittingSkin.i_faceSitting.sprite = sprite;
    }
    public void SetBody(Sprite sprite)
    {
        if (i_isStanding) i_standingSkin.i_bodySitting.sprite = sprite;
        else i_sittingSkin.i_bodySitting.sprite = sprite;
    }
    public void SetShirt(Sprite sprite)
    {
        if (i_isStanding) i_standingSkin.i_shirtSitting.sprite = sprite;
        else i_sittingSkin.i_shirtSitting.sprite = sprite;
    }
    public void SetLegs(Sprite sprite)
    {
        if (i_isStanding) i_standingSkin.i_legsSitting.sprite = sprite;
        else i_sittingSkin.i_legsSitting.sprite = sprite;
    }
    public void SetShoes(Sprite sprite)
    {
        if (i_isStanding) i_standingSkin.i_shoesSitting.sprite = sprite;
        else i_sittingSkin.i_shoesSitting.sprite = sprite;
    }

    public void SetSkin(Sprite hair, Sprite face, Sprite body, Sprite shirt, Sprite legs, Sprite shoes)
    {
        SetHair(hair);
        SetFace(face);
        SetBody(body);
        SetShirt(shirt);
        SetLegs(legs);
        SetShoes(shoes);
    }

    public void SwitchStanding()
    {
        i_isStanding = !i_isStanding;
        Draw();
    }

    void Draw()
    {
        i_standing.gameObject.SetActive(i_isStanding);

        i_sitting.gameObject.SetActive(!i_isStanding);
    }

    private void Start()
    {
        Draw();
    }
}


[Serializable]
public class Skin
{
    public GameObject i_standing;
    public Image i_hairStanding;
    public Image i_faceStanding;
    public Image i_bodyStanding;
    public Image i_shirtStanding;
    public Image i_legsStanding;
    public Image i_shoesStanding;

    public GameObject i_sitting;
    public Image i_hairSitting;
    public Image i_faceSitting;
    public Image i_bodySitting;
    public Image i_shirtSitting;
    public Image i_legsSitting;
    public Image i_shoesSitting;
}
