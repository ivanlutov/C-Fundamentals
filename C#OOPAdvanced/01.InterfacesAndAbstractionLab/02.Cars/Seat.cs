using System.Text;

public class Seat : ICar
{
    public string Model { get; private set; }
    public string Color { get; private set; }

    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model}");
        sb.AppendLine(this.Start());
        sb.AppendLine(this.Stop());

        return sb.ToString().Trim();
    }
}
