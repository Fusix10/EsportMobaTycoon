using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.ParticleSystem;

public class InteractObject : MonoBehaviour
{
    bool isActive;
    public Canvas canvas;
    public GameObject panelClick;
    public GameObject panelLongClick;
    public GameObject panelPC;

    public Player i_playerPanel;

    float pointerDownTimer;

    public float requiredHoldTime;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                pointerDownTimer += Time.deltaTime;
                if (pointerDownTimer >= requiredHoldTime)
                {
                    if (!isActive && LookForGameObject(out RaycastHit hite, touch))
                    {
                        PressLongGameObject(hite.collider.gameObject);
                    }
                    //Reset();
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (!isActive && LookForGameObject(out RaycastHit hit, touch))
                {
                    if (hit.collider.gameObject.layer == 6)
                    {
                        PressGameObject(hit.collider.gameObject);
                    }
                    else if (hit.collider.gameObject.layer == 7)
                    {
                        panelPC.SetActive(true);
                    }
                }
                else if(!isActive)
                {
                    Reset();
                }
                isActive = false;
                pointerDownTimer = 0;
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
        //go.SetActive(false);
        Reset();
        canvas.transform.position = go.transform.position;
        panelClick.SetActive(true);
        isActive = true;
        Player player = go.GetComponent<Player>();
        i_playerPanel = player;
        panelClick.GetComponent<SimplePressPanel>().InitStat(player.i_name, player.i_morale, player.i_lvl, player.i_potentiel);
    }

    private void PressLongGameObject(GameObject go)
    {
        //go.SetActive(false);
        Reset();
        canvas.transform.position = go.transform.position;
        Player player = go.GetComponent<Player>();
        i_playerPanel = player;
        panelLongClick.SetActive(true);
        isActive = true;
    }

    private void Reset()
    {
        pointerDownTimer = 0;
        panelClick.SetActive(false);
        panelLongClick.SetActive(false);
        isActive = false;
    }
}
