using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    private enum GraphicTier
    {
        Low,
        Medium,    
        High
    }

    private GraphicTier i_currentGraphic;

    [SerializeField]
    private TextMeshProUGUI i_displayGraphicText;

    void Start()
    {
        i_currentGraphic = GraphicTier.Medium;
    }

    void Update()
    {
        i_displayGraphicText.text = i_currentGraphic.ToString();
    }

    public void UpgradeGraphics()
    {
        int current = (int)i_currentGraphic;
        int max = System.Enum.GetValues(typeof(GraphicTier)).Length - 1;

        if (current < max)
        {
            i_currentGraphic = (GraphicTier)(current + 1);
            UpdateGraphics();
        }
    }

    public void DowngradeGraphics()
    {
        int current = (int)i_currentGraphic;

        if (current > 0)
        {
            i_currentGraphic = (GraphicTier)(current - 1);
            UpdateGraphics(); 
        }
    }


    private void UpdateGraphics()
    {
        Debug.Log($"Graphics set to : {i_currentGraphic}");

        // need to do ?
        // update the game graphics 
    }
}
