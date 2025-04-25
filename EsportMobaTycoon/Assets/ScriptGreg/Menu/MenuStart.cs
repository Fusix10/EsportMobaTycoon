using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    [Header("Panels de navigation")]
    [Tooltip("Le panneau principal du menu Start")]
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelOptions;

    [Header("Prefab à instancier")]
    [Tooltip("Le prefab du panneau Options (UI)")]
    [SerializeField] private GameObject optionsPrefab;

    private GameObject optionsInstance;

    public void OpenOptions()
    {
        if (panelStart != null) panelStart.SetActive(false);

        if (panelOptions != null)
        {
            panelOptions.SetActive(true);
            return;
        }

        if (optionsInstance == null && optionsPrefab != null)
        {
            var parent = panelStart != null ? panelStart.transform.parent : transform;
            optionsInstance = Instantiate(optionsPrefab, parent, worldPositionStays: false);
        }

        if (optionsInstance != null)
            optionsInstance.SetActive(true);
    }

    public void CloseOptions()
    {
        if (panelOptions != null)
            panelOptions.SetActive(false);
        if (optionsInstance != null)
            optionsInstance.SetActive(false);

        if (panelStart != null)
            panelStart.SetActive(true);
    }
}
