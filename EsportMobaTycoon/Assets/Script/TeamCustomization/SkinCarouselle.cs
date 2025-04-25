using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkinCarouselle : MonoBehaviour
{
    [Header("Target Image à mettre à jour")]
    [SerializeField] private Image[] targetImage;
    [SerializeField] private Image targetColor;
    [SerializeField] private TMP_Text targetText;

    [Header("Tous les sprites")]
    [SerializeField] private SkinGroup[] standingSprites;
    [SerializeField] private SkinGroup[] sittingSprites;

    private int groupIndex;
    private int colorIndex;
    private int maxGroupIndex;
    private int maxColorIndex;

    private bool isMale;

    void Start()
    {
        if (targetImage.Length == 0) Debug.LogError("TargetImage manquant.", gameObject);
        if (standingSprites.Length == 0) Debug.LogError("Aucun sprite configuré.", gameObject);
        if (standingSprites.Length != sittingSprites.Length) Debug.LogError("Les liste de sprites ne sont pas égals", gameObject);

        groupIndex = 0;
        colorIndex = 0;
        maxGroupIndex = standingSprites.Length;
        maxColorIndex = standingSprites[0].sprites.Length;

        isMale = true;

        UpdateDisplay();
    }

    public void NextGroup()
    {
        groupIndex = (groupIndex + 1) % maxGroupIndex;
        colorIndex = 0;

        maxColorIndex = standingSprites[groupIndex].sprites.Length;

        UpdateDisplay();
    }

    public void PreviousGroup()
    {
        groupIndex = (groupIndex - 1 + maxGroupIndex) % maxGroupIndex;
        colorIndex = 0;

        maxColorIndex = standingSprites[groupIndex].sprites.Length;

        UpdateDisplay();
    }

    public void NextColor()
    {
        colorIndex = (colorIndex + 1) % maxColorIndex;

        UpdateDisplay();
    }

    public void PreviousColor()
    {

        colorIndex = (colorIndex - 1 + maxColorIndex) % maxColorIndex;

        UpdateDisplay();
    }

    public void Reset()
    {
        groupIndex = 0;
        colorIndex = 0;

        UpdateDisplay();
    }

    public void Randomize()
    {
        groupIndex = UnityEngine.Random.Range(0, maxGroupIndex);
        colorIndex = 0;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        foreach (var target in targetImage)
        {
            target.sprite = GetSprite();
        }

        if(targetColor != null) targetColor.color = GetColor();

        if(targetText != null) targetText.text = GetGroupName();
    }

    public void SetGender(bool isMale)
    {
        this.isMale = isMale;
        UpdateDisplay();
    }

    public Sprite GetSprite(bool sitting = false) => sitting ? sittingSprites[groupIndex].sprites[colorIndex] : standingSprites[groupIndex].sprites[colorIndex];

    public Color GetColor() => sittingSprites[groupIndex].colors[colorIndex];

    public string GetGroupName() => sittingSprites[groupIndex].name;

    public void GetIndices(out int outSprite)
    {
        outSprite = groupIndex;
    }
}

[Serializable]
public struct SkinGroup
{
    public Sprite[] sprites;
    public Color[] colors;
    public string name;
}