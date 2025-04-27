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
    [SerializeField] private List<Image> shapeColorSquares;

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

    [SerializeField] private List<Image> logoColorSquares;

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

    [SerializeField] private List<Image> borderColorSquares;

    private int borderColorIndex = 0;
    private bool useBorder = false;

    public Sprite GetShapeSprite()
    {
        return shapeImage.sprite;
    }
    public Sprite GetLogoSprite()
    {
        return logoImage.sprite;
    }
    public Sprite GetBorderSprite()
    {
        return borderImage.sprite;
    }
    void Start()
    {
        //validation
        if (shapeImage == null) Debug.LogError("ShapeImage manquant");
        if (shapeGroups == null || shapeGroups.Count == 0) Debug.LogError("shapeGroups non configur");
        if (shapePrevButton == null || shapeNextButton == null)
            Debug.LogError("Shape Prev/Next buttons manquants");
        if (shapeColorButtons == null || shapeColorButtons.Count == 0)
            Debug.LogError("Shape color buttons manquants");

        if (logoImage == null) Debug.LogError("LogoImage manquant");
        if (logoGroups == null || logoGroups.Count == 0) Debug.LogError("logoGroups non configur");
        if (logoPrevButton == null || logoNextButton == null)
            Debug.LogError("Logo Prev/Next buttons manquants");
        if (logoColorButtons == null || logoColorButtons.Count == 0)
            Debug.LogError("Logo color buttons manquants");

        if (borderImage == null) Debug.LogError("BorderImage manquant");
        if (borderGroups == null || borderGroups.Count == 0)
            Debug.LogError("borderGroups non configur");
        if (toggleBorderButton == null)
            Debug.LogError("toggleBorderButton manquant");
        if (borderColorButtons == null || borderColorButtons.Count == 0)
            Debug.LogError("Border color buttons manquants");

        shapePrevButton.onClick.AddListener(PreviousShape);
        shapeNextButton.onClick.AddListener(NextShape);
        foreach (var b in shapeColorButtons) b.onClick.AddListener(CycleShapeColor);

        logoPrevButton.onClick.AddListener(PreviousLogo);
        logoNextButton.onClick.AddListener(NextLogo);
        foreach (var b in logoColorButtons) b.onClick.AddListener(CycleLogoColor);

        toggleBorderButton.onClick.AddListener(ToggleBorder);
        foreach (var b in borderColorButtons) b.onClick.AddListener(CycleBorderColor);


        UpdateShapeDisplay();
        UpdateLogoDisplay();
    }

    //Shape methods
    private void UpdateShapeDisplay()
    {
        var sprites = shapeGroups[shapeIndex].variants;
        if (sprites != null && sprites.Count > shapeColorIndex)
            shapeImage.sprite = sprites[shapeColorIndex];


        if (blasonInfoText != null)
            blasonInfoText.text = $"Blason {shapeIndex + 1}";
        var colors = shapeGroups[shapeIndex].colors;
        if (colors != null && colors.Count > shapeColorIndex)
        {
            Color c = colors[shapeColorIndex];
            foreach (var img in shapeColorSquares)
                img.color = c;
        }
    }

    public void NextShape()
    {
        shapeIndex = (shapeIndex + 1) % shapeGroups.Count;
        UpdateShapeDisplay();
        UpdateBorderDisplay();
    }

    public void PreviousShape()
    {
        shapeIndex = (shapeIndex - 1 + shapeGroups.Count) % shapeGroups.Count;
        UpdateShapeDisplay();
        UpdateBorderDisplay();
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
        var logoSprites = logoGroups[logoIndex].variants;
        if (logoSprites != null && logoSprites.Count > logoColorIndex)
            logoImage.sprite = logoSprites[logoColorIndex];

        if (logoInfoText != null)
            logoInfoText.text = $"Logo {logoIndex + 1}";
        var logoColors = logoGroups[logoIndex].colors;
        if (logoColors != null && logoColors.Count > logoColorIndex)
        {
            Color c = logoColors[logoColorIndex];
            foreach (var img in logoColorSquares)
                img.color = c;
        }
    }

    public void NextLogo()
    {
        logoIndex = (logoIndex + 1) % logoGroups.Count;
        UpdateLogoDisplay();
    }

    public void PreviousLogo()
    {
        logoIndex = (logoIndex - 1 + logoGroups.Count) % logoGroups.Count;
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

        Color c = useBorder
            ? borderGroups[shapeIndex].colors[borderColorIndex]
            : borderGroups[shapeIndex].colors[0];

        foreach (var img in borderColorSquares)
        {
            if (img != null)
                img.color = c;
        }
    }

    private void UpdateBorderDisplay()
    {
        var sprites = borderGroups[shapeIndex].variants;
        if (sprites != null && sprites.Count > borderColorIndex)
            borderImage.sprite = sprites[borderColorIndex];


        var colors = borderGroups[shapeIndex].colors;
        if (colors != null && colors.Count > borderColorIndex)
        {
            Color c = colors[borderColorIndex];
            foreach (var img in borderColorSquares)
                img.color = c;
        }
    }

    public void CycleBorderColor()
    {
        var v = borderGroups[shapeIndex].variants;
        borderColorIndex = (borderColorIndex + 1) % v.Count;
        UpdateBorderDisplay();
    }
}