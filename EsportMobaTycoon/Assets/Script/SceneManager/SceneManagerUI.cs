using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneManagerUI : MonoBehaviour
{
    //[Header("Button to trigger scene change")]
    //public Button i_sceneChangeButton;

    private void Start()
    {
        /*int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (i_sceneChangeButton != null)
        {
            i_sceneChangeButton.onClick.RemoveAllListeners();
            i_sceneChangeButton.onClick.AddListener(() => GameManager.Instance.ChangeState(currentSceneIndex+1));
        }
        else
        {
            Debug.LogWarning("Scene Change Button is not assigned!");
        }*/
    }
    [TextArea(4, 10)]
    [Tooltip("Mapping des actions par ID.")]
    public string aideMemoire = "Menu 0\r\nCutScene 1\r\nAvatar 2\r\nLogo 3\r\nBuddy 4\r\nHiring 5\r\nCircuit 6\r\nHub 7\r\nHub1 8\r\nHub2 9\r\nHub3 10\r\nMatch 11\r\nTournaments 12\r\nResult 13";
    public void ChangeStateButton(int State)
    {
        GameManager.Instance.ChangeState(State);
    }
}
