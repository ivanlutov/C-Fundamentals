using System;

public class Card : IComparable<Card>
{
    private Rank rank;
    private Suit suit;

    public Card(Rank rank, Suit suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    public int GetCardPower()
    {
        return (int)this.rank + (int)this.suit;
    }

    public override string ToString()
    {
        return $"Card name: {this.rank} of {this.suit}; Card power: {this.GetCardPower()}";
    }

    public int CompareTo(Card other)
    {
        return this.GetCardPower().CompareTo(other.GetCardPower());
    }
}