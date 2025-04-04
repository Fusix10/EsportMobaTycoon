using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carouselle : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<Button> colorButtons;

    private int currentIndex = 0;

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
            UpdateColor(0);
        }
    }

    private void UpdateImage()
    {
        targetImage.sprite = sprites[currentIndex];
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % sprites.Count;
        UpdateImage();
    }

    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + sprites.Count) % sprites.Count;
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
            }
        }
        else
        {
            Debug.LogError("Index out of range for color buttons.");
        }
    }

    public void Randomize()
    {
        currentIndex = Random.Range(0, sprites.Count);
        UpdateImage();

        int randomColorIndex = Random.Range(0, colorButtons.Count);
        UpdateColor(randomColorIndex);
    }

    public void Resette()
    {
        currentIndex = 0;
        UpdateImage();
        UpdateColor(0);
    }
}
