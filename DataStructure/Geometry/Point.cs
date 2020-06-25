namespace DataStructure.Geometry
{
    public class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Priority { get; set; }

        public Point()
        {
        }

        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }
    }
}
