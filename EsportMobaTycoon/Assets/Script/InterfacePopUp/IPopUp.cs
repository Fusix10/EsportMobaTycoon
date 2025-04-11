using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPopUp
{
    GameObject ParentWithScript { get; set; }
    void Display();
    void Hide();
}
