using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class InteractObject : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (LookForGameObject(out RaycastHit hit, touch))
                {
                    PressGameObject(hit.collider.gameObject);
                }
            }
        }
    }

    private bool LookForGameObject(out RaycastHit hit, Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        return Physics.Raycast(ray, out hit);
    }

    private void PressGameObject(GameObject go)
    {
        go.SetActive(false);
    }
}
