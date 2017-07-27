using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private readonly WeekDay weekDay;

    public WeeklyEntry(string weekday, string notes)
    {
        this.weekDay = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Notes = notes;
    }

    public WeekDay WeekDay => this.weekDay;
    public string Notes { get; private set; }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var weekDayComparison = weekDay.CompareTo(other.weekDay);
        if (weekDayComparison != 0)
        {
            return weekDayComparison;
        }

        return string.Compare(Notes, other.Notes, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }
}