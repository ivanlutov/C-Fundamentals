using System;

namespace _15.DrawingTool
{
    public class Rectangle : Figure
    {
        protected int secondSide;

        public Rectangle(int side, int secondSide)
            : base(side)
        {
            this.secondSide = secondSide;
        }

        public override void Draw()
        {
            Console.WriteLine($"|{new string('-', this.secondSide)}|");
            for (int i = 0; i < side - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', this.secondSide)}|");
            }
            Console.WriteLine($"|{new string('-', this.secondSide)}|");
        }
    }
}