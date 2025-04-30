using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkin : MonoBehaviour
{
    [Header("Stanting")]
    [SerializeField] GameObject i_standing;
    [SerializeField] Image i_hairStanding;
    [SerializeField] Image i_faceStanding;
    [SerializeField] Image i_bodyStanding;
    [SerializeField] Image i_shirtStanding;
    [SerializeField] Image i_legsStanding;
    [SerializeField] Image i_shoesStanding;

    [Header("Sitting")]
    [SerializeField] GameObject i_sitting;
    [SerializeField] Image i_hairSitting;
    [SerializeField] Image i_faceSitting;
    [SerializeField] Image i_bodySitting;
    [SerializeField] Image i_shirtSitting;
    [SerializeField] Image i_legsSitting;
    [SerializeField] Image i_shoesSitting;

    [SerializeField] Skin i_skin;

    [SerializeField] bool i_isStanding;

    public void SetSkin(Skin skin)
    {
        i_skin = skin;
        UpdateSkin();
    }

    public void UpdateSkin()
    {
        i_hairSitting.sprite = i_skin.i_hairSitting;
        i_hairStanding.sprite = i_skin.i_hairStanding;
        i_faceSitting.sprite = i_skin.i_faceSitting;
        i_faceStanding.sprite = i_skin.i_faceStanding;
        i_bodySitting.sprite = i_skin.i_bodySitting;
        i_bodyStanding.sprite = i_skin.i_bodyStanding;
        i_shirtSitting.sprite = i_skin.i_shirtSitting;
        i_shirtStanding.sprite = i_skin.i_shirtStanding;
        i_legsSitting.sprite = i_skin.i_legsSitting;
        i_legsStanding.sprite = i_skin.i_legsStanding;
        i_shoesSitting.sprite = i_skin.i_shoesSitting;
        i_shoesStanding.sprite = i_skin.i_shoesStanding;
    }

    public void SwitchStanding() => SetStanding(!i_standing);
    public void SetStanding(bool isStanding)
    {
        i_isStanding = isStanding;
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
    public Sprite i_hairStanding;
    public Sprite i_faceStanding;
    public Sprite i_bodyStanding;
    public Sprite i_shirtStanding;
    public Sprite i_legsStanding;
    public Sprite i_shoesStanding;

    public Sprite i_hairSitting;
    public Sprite i_faceSitting;
    public Sprite i_bodySitting;
    public Sprite i_shirtSitting;
    public Sprite i_legsSitting;
    public Sprite i_shoesSitting;
}
