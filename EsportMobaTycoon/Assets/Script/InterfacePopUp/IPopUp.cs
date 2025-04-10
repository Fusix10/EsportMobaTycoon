using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPopUp
{
    Canvas PopUpCanva { get; set; }
    void Display();
    void Hide();
}
