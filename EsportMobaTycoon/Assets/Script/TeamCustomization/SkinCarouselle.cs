using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkinCarouselle : MonoBehaviour
{
    [Header("Target Image à mettre à jour")]
    [SerializeField] private Image[] i_targetImage;
    [SerializeField] private Image i_targetColor;
    [SerializeField] private TMP_Text i_targetText;

    [Header("Tous les sprites")]
    [SerializeField] private SkinGroup[] i_standingSprites;
    [SerializeField] private SkinGroup[] i_sittingSprites;

    private int i_groupIndex;
    private int i_colorIndex;
    private int i_maxGroupIndex;
    private int i_maxColorIndex;

    void Awake()
    {
        if (i_targetImage.Length == 0) Debug.LogError("TargetImage manquant.", gameObject);
        if (i_standingSprites.Length == 0) Debug.LogError("Aucun sprite configuré.", gameObject);
        if (i_standingSprites.Length != i_sittingSprites.Length) Debug.LogError("Les liste de sprites ne sont pas égals", gameObject);

        i_groupIndex = 0;
        i_colorIndex = 0;
        i_maxGroupIndex = i_standingSprites.Length;
        i_maxColorIndex = i_standingSprites[0].sprites.Length;
    }

    private void Start()
    {
        UpdateDisplay();
    }

    public void NextGroup()
    {
        i_groupIndex = (i_groupIndex + 1) % i_maxGroupIndex;
        i_colorIndex = 0;

        i_maxColorIndex = i_standingSprites[i_groupIndex].sprites.Length;

        UpdateDisplay();
    }

    public void PreviousGroup()
    {
        i_groupIndex = (i_groupIndex - 1 + i_maxGroupIndex) % i_maxGroupIndex;
        i_colorIndex = 0;

        i_maxColorIndex = i_standingSprites[i_groupIndex].sprites.Length;

        UpdateDisplay();
    }

    public void NextColor()
    {
        i_colorIndex = (i_colorIndex + 1) % i_maxColorIndex;

        UpdateDisplay();
    }

    public void PreviousColor()
    {

        i_colorIndex = (i_colorIndex - 1 + i_maxColorIndex) % i_maxColorIndex;

        UpdateDisplay();
    }

    public void Reset()
    {
        i_groupIndex = 0;
        i_colorIndex = 0;

        UpdateDisplay();
    }

    public void Randomize()
    {
        i_groupIndex = UnityEngine.Random.Range(0, i_maxGroupIndex);
        i_colorIndex = 0;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        foreach (var target in i_targetImage)
        {
            target.sprite = GetSprite();
        }

        if(i_targetColor != null) i_targetColor.color = GetColor();

        if(i_targetText != null) i_targetText.text = GetGroupName();
    }

    public Sprite GetSprite(bool isSitting = false) => isSitting ? i_sittingSprites[i_groupIndex].sprites[i_colorIndex] : i_standingSprites[i_groupIndex].sprites[i_colorIndex];

    public Color GetColor() => i_sittingSprites[i_groupIndex].colors[i_colorIndex];

    public string GetGroupName() => i_sittingSprites[i_groupIndex].name;

    public void GetIndices(out int outSprite)
    {
        outSprite = i_groupIndex;
    }
}

[Serializable]
public struct SkinGroup
{
    public Sprite[] sprites;
    public Color[] colors;
    public string name;
}

[Serializable]
public struct SkinGroupData
{
    public SkinGroup[] hairStanding;
    public SkinGroup[] faceStanding;
    public SkinGroup[] bodyStanding;
    public SkinGroup[] shirtStanding;
    public SkinGroup[] legsStanding;
    public SkinGroup[] shoesStanding;

    public SkinGroup[] hairSitting;
    public SkinGroup[] faceSitting;
    public SkinGroup[] bodySitting;
    public SkinGroup[] shirtSitting;
    public SkinGroup[] legsSitting;
    public SkinGroup[] shoesSitting;
}