using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenuManager : MonoBehaviour
{
    public void Close()
    {
        GameManager.Instance.GoLastState();
    }
}
