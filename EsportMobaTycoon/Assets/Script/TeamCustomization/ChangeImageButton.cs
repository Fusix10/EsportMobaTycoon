using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ChangeImageButton : MonoBehaviour
{

    [SerializeField] public Image Target;
    [SerializeField] public Sprite Source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeImage()
    {
        if (Target != null && Source != null)
        {
            Target.sprite = Source;
        }
    }

}
