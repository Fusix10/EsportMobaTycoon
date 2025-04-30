using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinRandom
{

    public static Skin RandomSkin()
    {
        Skin skin = new Skin();

        int groupId = Random.Range(0, GameManager.Instance.i_skins.hairStanding.Length);
        SkinGroup group = GameManager.Instance.i_skins.hairStanding[groupId];
        int color = Random.Range(0, group.sprites.Length);
        skin.i_hairStanding = group.sprites[color];
        group = GameManager.Instance.i_skins.hairSitting[groupId];
        skin.i_hairSitting = group.sprites[color];


        groupId = Random.Range(0, GameManager.Instance.i_skins.faceStanding.Length);
        group = GameManager.Instance.i_skins.faceStanding[groupId];
        color = Random.Range(0, group.sprites.Length);
        skin.i_faceStanding = group.sprites[color];
        group = GameManager.Instance.i_skins.faceSitting[groupId];
        skin.i_faceSitting = group.sprites[color];


        groupId = Random.Range(0, GameManager.Instance.i_skins.bodyStanding.Length);
        group = GameManager.Instance.i_skins.bodyStanding[groupId];
        skin.i_bodyStanding = group.sprites[color];
        group = GameManager.Instance.i_skins.bodySitting[groupId];
        skin.i_bodySitting = group.sprites[color];


        groupId = Random.Range(0, GameManager.Instance.i_skins.shirtStanding.Length);
        group = GameManager.Instance.i_skins.shirtStanding[groupId];
        color = Random.Range(0, group.sprites.Length);
        skin.i_shirtStanding = group.sprites[Random.Range(0, group.sprites.Length)];
        group = GameManager.Instance.i_skins.shirtSitting[groupId];
        skin.i_shirtSitting = group.sprites[Random.Range(0, group.sprites.Length)];


        groupId = Random.Range(0, GameManager.Instance.i_skins.legsStanding.Length);
        group = GameManager.Instance.i_skins.legsStanding[groupId];
        color = Random.Range(0, group.sprites.Length);
        skin.i_legsStanding = group.sprites[Random.Range(0, group.sprites.Length)];
        group = GameManager.Instance.i_skins.legsSitting[groupId];
        skin.i_legsSitting = group.sprites[Random.Range(0, group.sprites.Length)];


        groupId = Random.Range(0, GameManager.Instance.i_skins.shoesStanding.Length);
        group = GameManager.Instance.i_skins.shoesStanding[groupId];
        color = Random.Range(0, group.sprites.Length);
        skin.i_shoesStanding = group.sprites[Random.Range(0, group.sprites.Length)];
        group = GameManager.Instance.i_skins.shoesSitting[groupId];
        skin.i_shoesSitting = group.sprites[Random.Range(0, group.sprites.Length)];

        return skin;
    }

}
