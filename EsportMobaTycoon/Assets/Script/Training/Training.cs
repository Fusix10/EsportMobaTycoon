using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TrainingSolo(Player player)
    {

    }

    public virtual void TrainingTeam(List<Player> players)
    {

    }
}

public class Player
{
    public int LevelCharacter1 = 0;
}
