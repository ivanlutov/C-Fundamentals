using System;

public class Card : IComparable<Card>
{
    private Rank rank;
    private Suit suit;

    public Card(Rank rank, Suit suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public Rank Rank
    {
        get { return rank; }
        set { rank = value; }
    }

    public Suit Suit
    {
        get { return suit; }
        set { suit = value; }
    }

    public int GetCardPower()
    {
        return (int)this.Rank + (int)this.Suit;
    }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }

    public int CompareTo(Card other)
    {
        return this.GetCardPower().CompareTo(other.GetCardPower());
    }
}