using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carouselle : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<Button> colorButtons;

    private int SpriteIndex = 0;
    private int colorButtonIndex = 0; 

    void Start()
    {
        if (targetImage == null)
        {
            Debug.LogError("Target Image is not assigned.");
        }

        if (sprites.Count == 0)
        {
            Debug.LogError("Sprites list is empty.");
        }

        if (colorButtons.Count == 0)
        {
            Debug.LogError("colorButtons list is empty.");
        }
        else
        {
            UpdateImage();
            UpdateColor(colorButtonIndex);
        }
    }

    private void UpdateImage()
    {
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

    public void UpdateColor(int index)
    {
        if (index >= 0 && index < colorButtons.Count)
        {
            Button button = colorButtons[index];
            if (button != null && targetImage != null)
            {
                targetImage.color = button.image.color;
                colorButtonIndex = index; 
            }
        }
        else
        {
            Debug.LogError("Index out of range for color buttons.");
        }
    }

    public void Randomize()
    {
        SpriteIndex = Random.Range(0, sprites.Count);
        UpdateImage();

        colorButtonIndex = Random.Range(0, colorButtons.Count);
        UpdateColor(colorButtonIndex);
    }

    public void Resette()
    {
        SpriteIndex = 0;
        UpdateImage();
        colorButtonIndex = 0;
        UpdateColor(colorButtonIndex);
    }

    public Sprite getSprite()
    {
        return sprites[SpriteIndex];
    }

    public Color getColor()
    {
        return colorButtons[colorButtonIndex].image.color;
    }

}
