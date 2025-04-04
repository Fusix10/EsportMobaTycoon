using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class teamCustomization : MonoBehaviour
{
    [SerializeField] public TextMeshPro Input1;

    [SerializeField] private string Nom;
    [SerializeField] private string Surnom;
    [SerializeField] private Image icon1;
    [SerializeField] private Image icon2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInfos()
    {
        Nom = Input1.text;
    }
}
