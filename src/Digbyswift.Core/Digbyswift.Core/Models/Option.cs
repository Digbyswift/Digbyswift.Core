namespace Digbyswift.Core.Models;

public struct Option
{
    public readonly string Label;
    public readonly string Alias;

    public Option(string label, string alias)
    {
        Label = label;
        Alias = alias;
    }
}

public struct Option<T>
{
    public readonly string Label;
    public readonly T Alias;

    public Option(string label, T alias)
    {
        Label = label;
        Alias = alias;
    }
}
