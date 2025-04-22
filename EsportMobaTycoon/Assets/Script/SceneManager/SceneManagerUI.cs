using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerUI : MonoBehaviour
{
    [Header("Button to trigger scene change")]
    public Button i_sceneChangeButton;

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (i_sceneChangeButton != null)
        {
            i_sceneChangeButton.onClick.RemoveAllListeners();
            i_sceneChangeButton.onClick.AddListener(() => GameManager.Instance.ChangeState(currentSceneIndex+1));
        }
        else
        {
            Debug.LogWarning("Scene Change Button is not assigned!");
        }
    }
}
