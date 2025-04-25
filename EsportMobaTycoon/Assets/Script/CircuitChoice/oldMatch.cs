public class oldMatch
{
    private enum MatchStatus
    {
        NotPlayed,
        Won,
        Lost
    }

    private MatchStatus i_status;

    public oldMatch()
    {
        i_status = MatchStatus.NotPlayed;
    }

    public void HasWon(bool win)
    {
        i_status = win ? MatchStatus.Won : MatchStatus.Lost;
    }
}
