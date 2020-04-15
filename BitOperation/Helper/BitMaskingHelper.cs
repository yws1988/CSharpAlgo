namespace BitOperation.Helper
{
    public class BitMaskingHelper
    {
        public static int Set(int value, int i)
        {
            return value | (1 << i);
        }

        public static int Unset(int value, int i)
        {
           return value & ~(1 << i);
        }

        public static int Check(int value, int i)
        {
            return 1 & value >> i;
        }

        //count(mask) – the number of non-zero bits in mask
        public static int CountBit(int value)
        {
            int c = 0;
            do
            {
                if ((value & 1) == 1) c++;
            }
            while ((value >>= 1) > 0);

            return c;
        }
    }
}
