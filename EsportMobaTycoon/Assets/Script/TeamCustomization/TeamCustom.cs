using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI.Extensions;

[System.Serializable]
public class SpriteVariants
{
    [Tooltip("Nom (facultatif) pour l’UI")]
    public string groupName;

    [Tooltip("Vos sprites pour ce groupe, dans l’ordre des couleurs")]
    public List<Sprite> variants;

    [Tooltip("Couleurs correspondantes pour chaque variante")]
    public List<Color> colors;
}
public class TeamCustom : MonoBehaviour
{
    //Shape Picker
    [Header("Shape (fond)")]
    [SerializeField] private Image shapeImage;
    [SerializeField] private List<SpriteVariants> shapeGroups;
    [SerializeField] private Button shapePrevButton;
    [SerializeField] private Button shapeNextButton;
    [SerializeField] private List<Button> shapeColorButtons;

    private int shapeIndex = 0;
    private int shapeColorIndex = 0;

    [Header("Info Texte Shape")]
    [SerializeField] private TMP_Text blasonInfoText;

    //Logo Picker
    [Header("Logo")]
    [SerializeField] private Image logoImage;
    [SerializeField] private List<SpriteVariants> logoGroups;
    [SerializeField] private Button logoPrevButton;
    [SerializeField] private Button logoNextButton;
    [SerializeField] private List<Button> logoColorButtons;

    private int logoIndex = 0;
    private int logoColorIndex = 0;

    [Header("Info Texte Logo")]
    [SerializeField] private TMP_Text logoInfoText;

    //Border Picker
    [Header("Contour")]
    [SerializeField] private Image borderImage;
    [SerializeField] private List<SpriteVariants> borderGroups;
    [SerializeField] private Button toggleBorderButton;
    [SerializeField] private List<Button> borderColorButtons;

    private int borderColorIndex = 0;
    private bool useBorder = false;

    void Start()
    {
        //validation
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

        //branchements Shape
        shapePrevButton.onClick.AddListener(PreviousShape);
        shapeNextButton.onClick.AddListener(NextShape);
        foreach (var b in shapeColorButtons) b.onClick.AddListener(CycleShapeColor);

        //branchements Logo
        logoPrevButton.onClick.AddListener(PreviousLogo);
        logoNextButton.onClick.AddListener(NextLogo);
        foreach (var b in logoColorButtons) b.onClick.AddListener(CycleLogoColor);

        //branchements Border
        toggleBorderButton.onClick.AddListener(ToggleBorder);
        foreach (var b in borderColorButtons) b.onClick.AddListener(CycleBorderColor);

        borderImage.gameObject.SetActive(false);

        UpdateShapeDisplay();
        UpdateLogoDisplay();
    }

    //Shape methods
    private void UpdateShapeDisplay()
    {
        var v = shapeGroups[shapeIndex].variants;
        if (v != null && v.Count > 0) shapeImage.sprite = v[shapeColorIndex];
        else Debug.LogError($"Shape group {shapeIndex} vide");

        //met à jour le texte Blason
        if (blasonInfoText != null)
            blasonInfoText.text = $"Blason {shapeIndex + 1}";
    }

    public void NextShape()
    {
        shapeIndex = (shapeIndex + 1) % shapeGroups.Count;
        shapeColorIndex = 0;
        UpdateShapeDisplay();
        if (useBorder)
        {
            borderColorIndex = 0;
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

    //Logo methods
    private void UpdateLogoDisplay()
    {
        var v = logoGroups[logoIndex].variants;
        if (v != null && v.Count > 0) logoImage.sprite = v[logoColorIndex];
        else Debug.LogError($"Logo group {logoIndex} vide");

        //met à jour le texte Logo
        if (logoInfoText != null)
            logoInfoText.text = $"Logo {logoIndex + 1}";
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

    //Border methods
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