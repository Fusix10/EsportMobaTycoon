using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoValidateButton : MonoBehaviour
{
    public TeamCustom logo;



    public void Submit()
    {
        LogoData data = new()
        {
            logo = logo.GetLogoSprite(),
            back = logo.GetShapeSprite(),
            border = logo.GetBorderSprite(),
        };

        GameManager.Instance.i_manager.i_logo = data;
    }
}
