using System.Collections.Generic;

public class oldCircuit
{
    private int i_id;
    private List<oldTournament> i_tournaments;

    public oldCircuit(int circuitId)
    {
        i_id = circuitId;

        i_tournaments = new List<oldTournament>();
    }

    public void AddTournament(oldTournament tournament)
    {
        i_tournaments.Add(tournament);
    }

    public List<oldTournament> GetTournaments()
    {
        return i_tournaments;
    }

}
