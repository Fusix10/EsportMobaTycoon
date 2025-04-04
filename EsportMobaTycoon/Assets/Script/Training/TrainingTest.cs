using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTest : Training
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TrainingSolo(Player player) 
    {
        player.LevelCharacter1 += 1;
    }

    public override void TrainingTeam(List<Player> players)
    {
        foreach (Player p in players) 
        {
            p.LevelCharacter1 += 1;
        }
    }
}
