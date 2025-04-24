using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carouselle : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image targetImage;
    [SerializeField] private List<Sprite> sprites;

    [Header("Les 3 assets à colorer")]
    [SerializeField] private List<Image> targetImages;

    [Header("Color Controls (3 boutons)")]
    [SerializeField] private List<Button> colorButtons;
    [SerializeField] private List<Color> colors;

    private int SpriteIndex = 0;
    private int[] colorIndices;

    void Start()
    {
        if (targetImage == null) Debug.LogError("Target Image is not assigned.");
        if (sprites == null || sprites.Count == 0) Debug.LogError("Sprites list is empty.");
        if (targetImages == null || targetImages.Count != colorButtons.Count)
            Debug.LogError("Il faut autant de targetImages que de colorButtons !");
        if (colorButtons == null || colorButtons.Count == 0)
            Debug.LogError("No Color Buttons Assigned to Carouselle");
        if (colors == null || colors.Count == 0)
            Debug.LogError("Colors list is empty.");

        UpdateImage();

        colorIndices = new int[colorButtons.Count];
        for (int i = 0; i < colorIndices.Length; i++)
            colorIndices[i] = -1;

        for (int i = 0; i < colorButtons.Count; i++)
        {
            int idx = i;

            colorButtons[idx].image.color = Color.white;

            colorButtons[idx].onClick.AddListener(() => CycleColor(idx));
        }
    }

    private void CycleColor(int idx)
    {
        if (idx < 0 || idx >= colorIndices.Length) return;
        if (colors.Count == 0) return;

        //passe à la couleur suivante
        colorIndices[idx] = (colorIndices[idx] + 1) % colors.Count;
        Color c = colors[colorIndices[idx]];
        c.a = 1f;

        //applique au bouton
        if (colorButtons[idx].image != null)
            colorButtons[idx].image.color = c;

        //applique au 3ème asset correspondant
        if (targetImages[idx] != null)
            targetImages[idx].color = c;
    }

    private void UpdateImage()
    {
        if (sprites != null && sprites.Count > 0 && targetImage != null)
            targetImage.sprite = sprites[SpriteIndex];
    }

    public void NextImage()
    {
        SpriteIndex = (SpriteIndex + 1) % sprites.Count;
        UpdateImage();
    }

    public void PreviousImage()
    {
        SpriteIndex = (SpriteIndex - 1 + sprites.Count) % sprites.Count;
        UpdateImage();
    }

    public void Randomize()
    {
        SpriteIndex = Random.Range(0, sprites.Count);
        UpdateImage();

        for (int i = 0; i < colorIndices.Length; i++)
        {
            colorIndices[i] = Random.Range(0, colors.Count);
            Color c = colors[colorIndices[i]];
            c.a = 1f;
            if (colorButtons[i].image != null)
                colorButtons[i].image.color = c;
            if (targetImages[i] != null)
                targetImages[i].color = c;
        }
    }

    public void Resette()
    {
        SpriteIndex = 0;
        UpdateImage();

        for (int i = 0; i < colorIndices.Length; i++)
        {
            colorIndices[i] = 0;
            Color c = colors[0];
            c.a = 1f;
            if (colorButtons[i].image != null)
                colorButtons[i].image.color = c;
            if (targetImages[i] != null)
                targetImages[i].color = c;
        }
    }

    public Sprite getSprite()
    {
        return sprites[SpriteIndex];
    }

    public Color getColor()
    {
        if (colorIndices.Length > 0)
            return colors[colorIndices[0]];
        return Color.white;
    }
}