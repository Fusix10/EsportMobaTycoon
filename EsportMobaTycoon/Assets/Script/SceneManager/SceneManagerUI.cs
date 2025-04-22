using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerUI : MonoBehaviour
{
    [Header("Button to trigger scene change")]
    public Button sceneChangeButton;

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneChangeButton != null)
        {
            sceneChangeButton.onClick.RemoveAllListeners();
            sceneChangeButton.onClick.AddListener(() => GameManager.Instance.ChangeState(currentSceneIndex+1));
        }
        else
        {
            Debug.LogWarning("Scene Change Button is not assigned!");
        }
    }
}
