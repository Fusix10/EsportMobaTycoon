using UnityEngine;

public class SceneButtonHandler : MonoBehaviour
{
    public void OnTutoButtonGoToHub1()
    {
        GameManager.Instance.setGameState(GameState.Hub);
        GameManager.Instance.LoadSceneForCurrentState();
    }

    public void OnFinishHub1ButtonGoToHub2()
    {
        GameManager.Instance.setGameState(GameState.Hub2);
        GameManager.Instance.LoadSceneForCurrentState();
    }

    public void OnFinishHub2ButtonGoToHub3()
    {
        GameManager.Instance.setGameState(GameState.Hub3);
        GameManager.Instance.LoadSceneForCurrentState();
    }

    public void OnValidateHub3ButtonGoToMatch()
    {
        GameManager.Instance.setGameState(GameState.Match);
        GameManager.Instance.LoadSceneForCurrentState();
    }
}
