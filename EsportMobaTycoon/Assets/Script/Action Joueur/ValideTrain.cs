using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValideTrain : MonoBehaviour
{
    public List<ActionOnButton> i_actions;
    public SavePlayerSelectedUi savePlayerSelectedUi;
    public int i_index;
    // Start is called before the first frame update
    void Start()
    {
        i_index = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectTrain(int indexAction)
    {
        i_index = indexAction;
    }

    public void valideAction()
    {
        if (i_index != -1)
        {
            i_actions[i_index].InitPlayer(savePlayerSelectedUi.i_indexPlayer);
            i_actions[i_index].OnEndTimeButton();
            i_index = -1;
        }
    }
}
