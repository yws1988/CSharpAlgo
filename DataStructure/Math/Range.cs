namespace DataStructure.Math
{
    using System;

    public class Range<T> where T : IComparable
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
}
