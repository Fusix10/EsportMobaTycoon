using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinRandom
{

    public static Skin RandomSkin()
    {
        Skin skin = new Skin();

        SkinGroup group = GameManager.Instance.i_skins.hairStanding[Random.Range(0, GameManager.Instance.i_skins.hairStanding.Length)];
        int color = Random.Range(0, group.sprites.Length);
        skin.i_hairStanding = group.sprites[color];
        skin.i_hairSitting = group.sprites[color];


        group = GameManager.Instance.i_skins.faceStanding[Random.Range(0, GameManager.Instance.i_skins.faceStanding.Length)];
        color = Random.Range(0, group.sprites.Length);
        skin.i_faceStanding = group.sprites[color];
        skin.i_faceSitting = group.sprites[color];

        group = GameManager.Instance.i_skins.bodyStanding[Random.Range(0, GameManager.Instance.i_skins.bodyStanding.Length)];
        skin.i_bodyStanding = group.sprites[color];
        skin.i_bodySitting = group.sprites[color];

        group = GameManager.Instance.i_skins.shirtStanding[Random.Range(0, GameManager.Instance.i_skins.shirtStanding.Length)];
        color = Random.Range(0, group.sprites.Length);
        skin.i_shirtStanding = group.sprites[Random.Range(0, group.sprites.Length)];
        skin.i_shirtSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.legsStanding[Random.Range(0, GameManager.Instance.i_skins.legsStanding.Length)];
        color = Random.Range(0, group.sprites.Length);
        skin.i_legsStanding = group.sprites[Random.Range(0, group.sprites.Length)];
        skin.i_legsSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        group = GameManager.Instance.i_skins.shoesStanding[Random.Range(0, GameManager.Instance.i_skins.shoesStanding.Length)];
        color = Random.Range(0, group.sprites.Length);
        skin.i_shoesStanding = group.sprites[Random.Range(0, group.sprites.Length)];
        skin.i_shoesSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        return skin;
    }

}
