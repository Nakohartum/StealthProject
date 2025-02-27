using System;

namespace _Root.Code.EditorHelpers
{
    [Serializable]
    public struct KeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }
}