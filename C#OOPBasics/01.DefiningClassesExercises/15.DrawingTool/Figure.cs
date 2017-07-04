namespace _15.DrawingTool
{
    public abstract class Figure
    {
        protected int side;

        protected Figure(int side)
        {
            this.side = side;
        }

        public abstract void Draw();
    }
}