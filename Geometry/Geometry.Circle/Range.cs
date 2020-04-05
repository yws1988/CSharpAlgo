using System;

namespace Maths.Geometric
{
    public class Range<T> where T : IComparable
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public bool IsOverlapped(Range<T> other)
        {
            T min = this.Min.CompareTo(other.Min) > 0 ? this.Min : other.Min;
            T max = this.Max.CompareTo(other.Max) < 0 ? this.Max : other.Max;
            if (min.CompareTo(max) <= 0)
            {
                return true;
            }

            return false;
        }

        public Range<T> Intersect(Range<T> other)
        {
            T min = this.Min.CompareTo(other.Min) > 0 ? this.Min : other.Min;
            T max = this.Max.CompareTo(other.Max) < 0 ? this.Max : other.Max;
            if (min.CompareTo(max) <= 0)
            {
                return new Range<T>(min, max) ;
            }

            return null;
        }
     }
}
