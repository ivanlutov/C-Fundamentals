namespace _01.ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        protected double Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        protected double Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        protected double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}