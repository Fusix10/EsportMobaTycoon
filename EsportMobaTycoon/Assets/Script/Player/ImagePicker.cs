using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImagePicker : MonoBehaviour
{
    public Image targetImage;

    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                LoadImage(path);
            }
        }, "Select an image", "image/*");
    }

    private void LoadImage(string path)
    {
        byte[] imageData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(imageData))
        {
            targetImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
