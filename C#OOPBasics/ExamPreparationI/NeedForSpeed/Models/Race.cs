using System.Collections.Generic;
public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public string Route
    {
        get { return route; }
        set { route = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }

    public Dictionary<int, Car> Participants
    {
        get { return participants; }
        set { participants = value; }
    }
}
