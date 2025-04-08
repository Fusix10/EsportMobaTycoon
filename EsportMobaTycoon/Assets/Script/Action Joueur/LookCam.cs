using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LookCam : MonoBehaviour
{
    // Start is called before the first frame update
    Camera m_MainCamera;
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(m_MainCamera.transform);
    }
}
