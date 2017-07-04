using System;

namespace _15.DrawingTool
{
    public class Square : Figure
    {
        public Square(int side)
            : base(side)
        {
        }

        public override void Draw()
        {
            Console.WriteLine($"|{new string('-', this.side)}|");
            for (int i = 0; i < this.side - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', this.side)}|");
            }
            Console.WriteLine($"|{new string('-', this.side)}|");
        }
    }
}