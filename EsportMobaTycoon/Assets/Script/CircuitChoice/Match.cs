using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match
{
    private enum MatchStatus
    {
        NotPlayed,
        Won,
        Lost
    }

    private MatchStatus i_status;

    public Match()
    {
        i_status = MatchStatus.NotPlayed;
    }

    public void HasWon(bool win)
    {
        i_status = win ? MatchStatus.Won : MatchStatus.Lost;
    }
}
