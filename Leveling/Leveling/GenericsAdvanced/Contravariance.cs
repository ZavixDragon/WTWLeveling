namespace Leveling.GenericsAdvanced
{
    public class Contravariance
    {
        public Contravariance(Square square) : this((Rectangle)square) { }

        public Contravariance(Rectangle rectangle)
        {
            //here we are using contravariance to get at the overriden properties within square while we only know that we are using a rectangle
            rectangle.Width = 10;
            //here we are doing again
            var area = rectangle.Width * rectangle.Height;
        }
    }

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }

    public class Square : Rectangle
    {
        private int _sideLength;
        public override int Width { get { return _sideLength; } set { _sideLength = value; } }
        public override int Height { get { return _sideLength; } set { _sideLength = value; } }
    }
}
