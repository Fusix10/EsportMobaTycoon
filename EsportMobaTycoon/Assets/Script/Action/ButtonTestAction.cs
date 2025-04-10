using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTestAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void OnTimeDurationButton(Player player)
    {
        TestTimeDuration testTimeDuration = new TestTimeDuration();
        testTimeDuration.InitPlayer(player);
        testTimeDuration.setTimer(5);
        GameManager.Instance.AddAction(testTimeDuration);
    }

    public static void OnEndTimeButton(Player player)
    {
        TestTimeEnd testTimeEnd = new TestTimeEnd();
        testTimeEnd.InitPlayer(player);
        testTimeEnd.setTimer(5);
        GameManager.Instance.AddAction(testTimeEnd);
    }
}
