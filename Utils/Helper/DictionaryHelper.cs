namespace Utils.Helper
{
    using System.Collections.Generic;

    public static class DictionaryHelper
    {
        public class VDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        {
            public new TValue this[TKey key]
            {
                get
                {
                    if (!ContainsKey(key))
                    {
                        base[key] = default(TValue);
                    }

                    return base[key];
                }
                set { base[key] = value; }
            }
        }

        public class RDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TValue : new()
        {
            public new TValue this[TKey key]
            {
                get
                {
                    if (!ContainsKey(key))
                    {
                        base[key] = new TValue();
                    }
                    return base[key];
                }
                set { base[key] = value; }
            }
        }
    }
}
