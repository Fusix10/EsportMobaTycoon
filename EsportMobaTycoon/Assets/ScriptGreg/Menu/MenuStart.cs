using UnityEngine;

public class MenuStart : MonoBehaviour
{
    [Header("Panels")]
    [Tooltip("Ton menu principal")]
    public GameObject PanelStart;
    [Tooltip("Ton panneau d’options (si il existe déjà en scène)")]
    public GameObject PanelOptions;
    [Tooltip("Sinon, ton prefab Options à instancier")]
    public GameObject OptionsPrefab;

    private GameObject optionsInstance;

    void Start()
    {
    }

    void Update()
    {
    }
    public void ButtonOptions()
    {
        PanelStart.SetActive(false);

        if (PanelOptions != null) PanelOptions.SetActive(true);
        //désactive le menu principal
        if (PanelStart != null) PanelStart.SetActive(false);

        //sinon, instancie le prefab
        if (optionsInstance == null && OptionsPrefab != null)
        {
            var parent = PanelStart.transform.parent;
            optionsInstance = Instantiate(OptionsPrefab, parent, worldPositionStays: false);
        }

        if (optionsInstance != null)
            optionsInstance.SetActive(true);
    }

    public void CloseOptions()
    {
        if (PanelOptions != null) PanelOptions.SetActive(false);
        if (optionsInstance != null) optionsInstance.SetActive(false);
        PanelStart.SetActive(true);
    }
}
