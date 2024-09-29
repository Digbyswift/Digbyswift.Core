namespace Digbyswift.Core.Models;

public struct Pair<TKey, TValue>
{
    public TKey Key { get; }
    public TValue Value { get; }

    public Pair(TKey key, TValue value) : this()
    {
        Key = key;
        Value = value;
    }
}
