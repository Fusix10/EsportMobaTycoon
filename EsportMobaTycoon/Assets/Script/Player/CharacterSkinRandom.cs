using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinRandom
{

    public static Skin RandomSkin()
    {
        Skin skin = new Skin();

        SkinGroup group = GameManager.Instance.i_skins.hairStanding[Random.Range(0, GameManager.Instance.i_skins.hairStanding.Length)];
        skin.i_hairStanding = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.faceStanding[Random.Range(0, GameManager.Instance.i_skins.faceStanding.Length)];
        int skinColor = Random.Range(0, group.sprites.Length);
        skin.i_faceStanding = group.sprites[skinColor];

        group = GameManager.Instance.i_skins.bodyStanding[Random.Range(0, GameManager.Instance.i_skins.bodyStanding.Length)];
        skin.i_bodyStanding = group.sprites[skinColor];

        group = GameManager.Instance.i_skins.shirtStanding[Random.Range(0, GameManager.Instance.i_skins.shirtStanding.Length)];
        skin.i_shirtStanding = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.legsStanding[Random.Range(0, GameManager.Instance.i_skins.legsStanding.Length)];
        skin.i_legsStanding = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.shoesStanding[Random.Range(0, GameManager.Instance.i_skins.shoesStanding.Length)];
        skin.i_shoesStanding = group.sprites[Random.Range(0, group.sprites.Length)];


        group = GameManager.Instance.i_skins.hairSitting[Random.Range(0, GameManager.Instance.i_skins.hairSitting.Length)];
        skin.i_hairSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.faceSitting[Random.Range(0, GameManager.Instance.i_skins.faceSitting.Length)];
        skin.i_faceSitting = group.sprites[skinColor];

        group = GameManager.Instance.i_skins.bodySitting[Random.Range(0, GameManager.Instance.i_skins.bodySitting.Length)];
        skin.i_bodySitting = group.sprites[skinColor];

        group = GameManager.Instance.i_skins.shirtSitting[Random.Range(0, GameManager.Instance.i_skins.shirtSitting.Length)];
        skin.i_shirtSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.legsSitting[Random.Range(0, GameManager.Instance.i_skins.legsSitting.Length)];
        skin.i_legsSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.shoesSitting[Random.Range(0, GameManager.Instance.i_skins.shoesSitting.Length)];
        skin.i_shoesSitting = group.sprites[Random.Range(0, group.sprites.Length)];


        return skin;
    }

}
