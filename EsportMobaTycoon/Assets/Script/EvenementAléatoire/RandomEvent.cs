using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    
    public GameObject canvasPrefab;
    private GameObject canvasInstance;

    void Start()
    {
        if (canvasPrefab == null)
        {
            Debug.LogError("Canvas prefab is not assigned.");
        }
    }

    void Update()
    {
    }

    public void Display()
    {
        
        canvasInstance = Instantiate(canvasPrefab);
    }

    public virtual void CustomEventLogic()
    {
    }


    public void CloseCanvas()
    {
        if (canvasInstance != null)
        {
            Destroy(canvasInstance);
        }
    }
}
