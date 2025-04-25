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
        // (tu n’avais rien ici)
    }

    void Update()
    {
        // (tu n’avais rien ici non plus)
    }

    /// <summary>
    /// Lié à ton bouton “Options” dans le menu Start.
    /// </summary>
    public void ButtonOptions()
    {
        // Masque le menu principal
        PanelStart.SetActive(false);

        if (PanelOptions != null) PanelOptions.SetActive(true);
        // …et désactive le menu principal
        if (PanelStart != null) PanelStart.SetActive(false);

        // Sinon, on instancie le prefab
        if (optionsInstance == null && OptionsPrefab != null)
        {
            var parent = PanelStart.transform.parent;
            optionsInstance = Instantiate(OptionsPrefab, parent, worldPositionStays: false);
        }

        if (optionsInstance != null)
            optionsInstance.SetActive(true);
    }

    /// <summary>
    /// Fermeture du panneau Options → revient au menu Start.
    /// À appeler depuis ton MenuOptions ou ton bouton “Retour”.
    /// </summary>
    public void CloseOptions()
    {
        if (PanelOptions != null) PanelOptions.SetActive(false);
        if (optionsInstance != null) optionsInstance.SetActive(false);
        PanelStart.SetActive(true);
    }
}
