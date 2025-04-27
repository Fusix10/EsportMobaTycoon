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

        //borderImage.gameObject.SetActive(false);

        UpdateShapeDisplay();
        UpdateLogoDisplay();
    }

    //Shape methods
    private void UpdateShapeDisplay()
    {
        /* var v = shapeGroups[shapeIndex].variants;
         if (v != null && v.Count > 0) shapeImage.sprite = v[shapeColorIndex];
         else Debug.LogError($"Shape group {shapeIndex} vide");*/
        var sprites = shapeGroups[shapeIndex].variants;
        if (sprites != null && sprites.Count > shapeColorIndex)
            shapeImage.sprite = sprites[shapeColorIndex];


        //met à jour le texte Blason
        if (blasonInfoText != null)
            blasonInfoText.text = $"Blason {shapeIndex + 1}";
        /*if (shapeGroups[shapeIndex].colors != null && shapeGroups[shapeIndex].colors.Count > shapeColorIndex)
        {
            Color btnColor = shapeGroups[shapeIndex].colors[shapeColorIndex];
            foreach (var btn in shapeColorButtons)
            {
                // On cherche l'image enfant nommée "Color" et on change sa couleur
                var colorImg = btn.transform.Find("Color")?.GetComponent<Image>();
                if (colorImg != null)
                    colorImg.color = btnColor;
            }
        }*/
        var colors = shapeGroups[shapeIndex].colors;
        if (colors != null && colors.Count > shapeColorIndex)
        {
            Color c = colors[shapeColorIndex];
            // Applique cette teinte UNIQUEMENT aux Images enfant "Color"
            foreach (var img in shapeColorSquares)
                img.color = c;
        }
    }

    public void NextShape()
    {
        shapeIndex = (shapeIndex + 1) % shapeGroups.Count;
        shapeColorIndex = 0;
        UpdateShapeDisplay();
        /*if (useBorder)
        {
            borderColorIndex = 0;
            UpdateBorderDisplay();
        }*/
        UpdateBorderDisplay();
    }

    public void PreviousShape()
    {
        shapeIndex = (shapeIndex - 1 + shapeGroups.Count) % shapeGroups.Count;
        shapeColorIndex = 0;
        UpdateShapeDisplay();
        /*if (useBorder)
        {
            borderColorIndex = 0;
            UpdateBorderDisplay();
        }*/
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
        /*var v = logoGroups[logoIndex].variants;
        if (v != null && v.Count > 0) logoImage.sprite = v[logoColorIndex];
        else Debug.LogError($"Logo group {logoIndex} vide");*/
        var logoSprites = logoGroups[logoIndex].variants;
        if (logoSprites != null && logoSprites.Count > logoColorIndex)
            logoImage.sprite = logoSprites[logoColorIndex];

        //met à jour le texte Logo
        if (logoInfoText != null)
            logoInfoText.text = $"Logo {logoIndex + 1}";
        /*if (logoGroups[logoIndex].colors != null && logoGroups[logoIndex].colors.Count > logoColorIndex)
        {
            Color btnColor = logoGroups[logoIndex].colors[logoColorIndex];
            foreach (var btn in logoColorButtons)
            {
                if (btn.image != null)
                    btn.image.color = btnColor;
            }
        }
        foreach (var btn in logoColorButtons)
        {
            if (btn.image != null)
                btn.image.sprite = v[logoColorIndex];
        }*/
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

        // Choisis la couleur à appliquer sur les carrés “Color”
        Color c = useBorder
            ? borderGroups[shapeIndex].colors[borderColorIndex]  // couleur active
            : borderGroups[shapeIndex].colors[0];                // couleur “inactive” (indice 0)

        // Applique-la UNIQUEMENT aux images enfant “Color”
        foreach (var img in borderColorSquares)
        {
            if (img != null)
                img.color = c;
        }
    }

    private void UpdateBorderDisplay()
    {
        /*var v = borderGroups[shapeIndex].variants;
        if (v != null && v.Count > 0)
            borderImage.sprite = v[borderColorIndex];
        else
            Debug.LogError($"Border group {shapeIndex} vide");*/
        var sprites = borderGroups[shapeIndex].variants;
        if (sprites != null && sprites.Count > borderColorIndex)
            borderImage.sprite = sprites[borderColorIndex];


        var colors = borderGroups[shapeIndex].colors;
        if (colors != null && colors.Count > borderColorIndex)
        {
            Color c = colors[borderColorIndex];
            // applique la même teinte à tous les carrés “Color”,
            // y compris celui du bouton ToggleBorder
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