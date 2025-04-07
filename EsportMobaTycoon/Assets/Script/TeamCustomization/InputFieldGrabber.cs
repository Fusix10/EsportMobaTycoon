using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnputFieldGrabber : MonoBehaviour
{

    [SerializeField] private string inputText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabFromInputField(string input)
    {
        inputText = input.Trim();
    }

    public string getInputText()
    {
        return inputText;
    }

}
