using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    int i_actualTime;
    void Start()
    {
        i_actualTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    List<ActionMother> actionMothers = new();



    public void passingTime()
    {
        i_actualTime++;
        foreach (ActionMother action in actionMothers)
        {
            action.actualise();
        }
    }
}
