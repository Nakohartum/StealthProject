using System;

namespace _Root.Code.EditorHelpers
{
    [Serializable]
    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }
}