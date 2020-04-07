namespace DataStructure.Models.Geometry
{
    public class Point3D<T>
    {
        public T X;
        public T Y;
        public T Z;

        public Point3D()
        {
        }

        public Point3D(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
