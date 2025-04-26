using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
/*public class SpriteVariants
{
    [Tooltip("Nom (facultatif) pour l’UI")]
    public string groupName;

    [Tooltip("Vos sprites pour ce groupe, dans l’ordre des couleurs")]
    public List<Sprite> variants;
}*/

/*public class TeamCustom : MonoBehaviour
{
    [Header("Target Image à mettre à jour")]
    [SerializeField] private Image targetImage;

    [Header("Tous les groupes de variantes")]
    [SerializeField] private List<SpriteVariants> groups;

    [Header("Boutons UI (un bouton = changer la couleur)")]
    [SerializeField] private List<Button> cycleColorButtons;

    private int groupIndex = 0;
    private int colorIndex = 0;

    private int borderGroupIndex = 0;
    private int borderColorIndex = 0;
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
}*/
public class TeamCustom : MonoBehaviour
{
    // ——— 1) Shape Picker ———————————————————————————
    [Header("Shape (fond)")]
    [SerializeField] private Image shapeImage;
    [SerializeField] private List<SpriteVariants> shapeGroups;
    [SerializeField] private Button shapePrevButton;
    [SerializeField] private Button shapeNextButton;
    [SerializeField] private List<Button> shapeColorButtons;

    private int shapeIndex = 0;
    private int shapeColorIndex = 0;

    // ——— 2) Logo Picker ————————————————————————————
    [Header("Logo")]
    [SerializeField] private Image logoImage;
    [SerializeField] private List<SpriteVariants> logoGroups;
    [SerializeField] private Button logoPrevButton;
    [SerializeField] private Button logoNextButton;
    [SerializeField] private List<Button> logoColorButtons;

    private int logoIndex = 0;
    private int logoColorIndex = 0;

    // ——— 3) Border Picker —————————————————————————
    [Header("Contour")]
    [SerializeField] private Image borderImage;
    [SerializeField] private List<SpriteVariants> borderGroups;
    [SerializeField] private Button toggleBorderButton;
    [SerializeField] private List<Button> borderColorButtons;

    private int borderColorIndex = 0;
    private bool useBorder = false;

    void Start()
    {
        // —– validation rapide ——
        if (shapeImage == null) Debug.LogError("ShapeImage manquant");
        if (shapeGroups == null || shapeGroups.Count == 0) Debug.LogError("shapeGroups non configuré");
        if (shapePrevButton == null || shapeNextButton == null)
            Debug.LogError("Shape Prev/Next buttons manquants");
        if (shapeColorButtons == null || shapeColorButtons.Count == 0)
            Debug.LogError("Shape color buttons manquants");

        if (logoImage == null) Debug.LogError("LogoImage manquant");
        if (logoGroups == null || logoGroups.Count == 0) Debug.LogError("logoGroups non configuré");
        if (logoPrevButton == null || logoNextButton == null)
            Debug.LogError("Logo Prev/Next buttons manquants");
        if (logoColorButtons == null || logoColorButtons.Count == 0)
            Debug.LogError("Logo color buttons manquants");

        if (borderImage == null) Debug.LogError("BorderImage manquant");
        if (borderGroups == null || borderGroups.Count == 0)
            Debug.LogError("borderGroups non configuré");
        if (toggleBorderButton == null)
            Debug.LogError("toggleBorderButton manquant");
        if (borderColorButtons == null || borderColorButtons.Count == 0)
            Debug.LogError("Border color buttons manquants");

        // —– branchements Shape ——
        shapePrevButton.onClick.AddListener(PreviousShape);
        shapeNextButton.onClick.AddListener(NextShape);
        foreach (var b in shapeColorButtons) b.onClick.AddListener(CycleShapeColor);

        // —– branchements Logo ——
        logoPrevButton.onClick.AddListener(PreviousLogo);
        logoNextButton.onClick.AddListener(NextLogo);
        foreach (var b in logoColorButtons) b.onClick.AddListener(CycleLogoColor);

        // —– branchements Border ——
        toggleBorderButton.onClick.AddListener(ToggleBorder);
        foreach (var b in borderColorButtons) b.onClick.AddListener(CycleBorderColor);

        // masquage initial du contour
        borderImage.gameObject.SetActive(false);

        // affiche tout de suite
        UpdateShapeDisplay();
        UpdateLogoDisplay();
    }

    // ===== Shape methods =====
    private void UpdateShapeDisplay()
    {
        var v = shapeGroups[shapeIndex].variants;
        if (v != null && v.Count > 0) shapeImage.sprite = v[shapeColorIndex];
        else Debug.LogError($"Shape group {shapeIndex} vide");
    }

    public void NextShape()
    {
        shapeIndex = (shapeIndex + 1) % shapeGroups.Count;
        shapeColorIndex = 0;
        UpdateShapeDisplay();
        if (useBorder)
        {
            borderColorIndex = 0;        // ou conservez la même couleur si vous préférez
            UpdateBorderDisplay();
        }
    }

    public void PreviousShape()
    {
        shapeIndex = (shapeIndex - 1 + shapeGroups.Count) % shapeGroups.Count;
        shapeColorIndex = 0;
        UpdateShapeDisplay(); 
        if (useBorder)
        {
            borderColorIndex = 0;
            UpdateBorderDisplay();
        }
    }

    public void CycleShapeColor()
    {
        var v = shapeGroups[shapeIndex].variants;
        shapeColorIndex = (shapeColorIndex + 1) % v.Count;
        UpdateShapeDisplay();
    }

    // ===== Logo methods =====
    private void UpdateLogoDisplay()
    {
        var v = logoGroups[logoIndex].variants;
        if (v != null && v.Count > 0) logoImage.sprite = v[logoColorIndex];
        else Debug.LogError($"Logo group {logoIndex} vide");
    }

    public void NextLogo()
    {
        logoIndex = (logoIndex + 1) % logoGroups.Count;
        logoColorIndex = 0;
        UpdateLogoDisplay();
    }

    public void PreviousLogo()
    {
        logoIndex = (logoIndex - 1 + logoGroups.Count) % logoGroups.Count;
        logoColorIndex = 0;
        UpdateLogoDisplay();
    }

    public void CycleLogoColor()
    {
        var v = logoGroups[logoIndex].variants;
        logoColorIndex = (logoColorIndex + 1) % v.Count;
        UpdateLogoDisplay();
    }

    // ===== Border methods =====
    public void ToggleBorder()
    {
        useBorder = !useBorder;
        borderImage.gameObject.SetActive(useBorder);
        if (useBorder)
        {
            borderColorIndex = 0;
            UpdateBorderDisplay();
        }
    }

    private void UpdateBorderDisplay()
    {
        var v = borderGroups[shapeIndex].variants;
        if (v != null && v.Count > 0)
            borderImage.sprite = v[borderColorIndex];
        else
            Debug.LogError($"Border group {shapeIndex} vide");
    }

    public void CycleBorderColor()
    {
        var v = borderGroups[shapeIndex].variants;
        borderColorIndex = (borderColorIndex + 1) % v.Count;
        UpdateBorderDisplay();
    }
}