public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Width
    {
        get { return this.width; }
        protected set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        protected set { this.height = value; }
    }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Width + this.Height);
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}