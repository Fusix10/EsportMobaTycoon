using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteVariants
{
    [Tooltip("Nom (facultatif) pour l’UI")]
    public string groupName;

    [Tooltip("Vos sprites pour ce groupe, dans l’ordre des couleurs")]
    public List<Sprite> variants;
}

public class TeamCustom : MonoBehaviour
{
    [Header("Target Image à mettre à jour")]
    [SerializeField] private Image targetImage;

    [Header("Tous les groupes de variantes")]
    [SerializeField] private List<SpriteVariants> groups;

    [Header("Boutons UI (un bouton = changer la couleur)")]
    [SerializeField] private List<Button> cycleColorButtons;

    private int groupIndex = 0;
    private int colorIndex = 0;

    void Start()
    {
        if (targetImage == null) Debug.LogError("TargetImage manquant.");
        if (groups == null || groups.Count == 0) Debug.LogError("Aucun groupe configuré.");
        if (cycleColorButtons == null || cycleColorButtons.Count == 0)
            Debug.LogError("Aucun bouton de cycle configuré.");

        for (int i = 0; i < cycleColorButtons.Count; i++)
        {
            cycleColorButtons[i].onClick.AddListener(CycleColor);
        }

        UpdateDisplay();
    }

    private void CycleColor()
    {
        var variants = groups[groupIndex].variants;
        if (variants == null || variants.Count == 0) return;

        colorIndex = (colorIndex + 1) % variants.Count;
        UpdateDisplay();
    }

    public void NextGroup()
    {
        groupIndex = (groupIndex + 1) % groups.Count;
        var variants = groups[groupIndex].variants;
        colorIndex = Mathf.Clamp(colorIndex, 0, variants.Count - 1);
        UpdateDisplay();
    }

    public void PreviousGroup()
    {
        groupIndex = (groupIndex - 1 + groups.Count) % groups.Count;
        var variants = groups[groupIndex].variants;
        colorIndex = Mathf.Clamp(colorIndex, 0, variants.Count - 1);
        UpdateDisplay();
    }

    public void Resette()
    {
        groupIndex = 0;
        colorIndex = 0;
        UpdateDisplay();
    }

    public void Randomize()
    {
        groupIndex = Random.Range(0, groups.Count);
        var variants = groups[groupIndex].variants;
        if (variants != null && variants.Count > 0)
            colorIndex = Random.Range(0, variants.Count);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        var variants = groups[groupIndex].variants;
        if (variants != null && variants.Count > 0)
            targetImage.sprite = variants[colorIndex];
        else
            Debug.LogError($"Groupe {groupIndex} sans variantes !");
    }

    public Sprite getSprite()
    {
        var variants = groups[groupIndex].variants;
        return (variants != null && variants.Count > 0)
            ? variants[colorIndex]
            : null;
    }

    public void GetIndices(out int outGroup, out int outColor)
    {
        outGroup = groupIndex;
        outColor = colorIndex;
    }
}