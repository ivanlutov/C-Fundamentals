namespace _09.RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double topLeftX;
        private double topLeftY;

        public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public double TopLeftX
        {
            get
            {
                return this.topLeftX;
            }

            set
            {
                this.topLeftX = value;
            }
        }

        public double TopLeftY
        {
            get
            {
                return this.topLeftY;
            }

            set
            {
                this.topLeftY = value;
            }
        }

        public bool Intersect(Rectangle rectangle)
        {
            if (rectangle.topLeftX + rectangle.width >= this.topLeftX &&
                rectangle.topLeftX <= this.topLeftX + this.width &&
                rectangle.topLeftY >= this.topLeftY - this.height &&
                rectangle.topLeftY - rectangle.height <= this.topLeftY)
            {
                return true;
            }

            return false;
        }
    }
}