using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LogoData
{
    public Sprite logo;
    public Sprite back;
    public Sprite border;

    public void CreateFromNothing()
    {
        var Group = GameManager.Instance.logoGroups[UnityEngine.Random.Range(0, GameManager.Instance.logoGroups.Count)];
        logo = Group.variants[UnityEngine.Random.Range(0, Group.variants.Count)];

        int jeretien = UnityEngine.Random.Range(0, GameManager.Instance.logoGroups.Count);

        Group = GameManager.Instance.shapeGroups[jeretien];
        back = Group.variants[UnityEngine.Random.Range(0, Group.variants.Count)];

        Group = GameManager.Instance.borderGroups[jeretien];
        border = Group.variants[UnityEngine.Random.Range(0, Group.variants.Count)];
    }
}
