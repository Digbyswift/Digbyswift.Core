using System;

namespace Digbyswift.Core.Globalization;

public record IsoCountry
{

#if NET48
    private readonly string _shortName;

    public string Name { get; }
    public string ShortName => _shortName ?? Name;
    public string Abbreviation { get; }
    public string Alpha2 { get; }
    public string Alpha3 { get; }
    public int NumericCode { get; }
    
    internal IsoCountry(string name, string alpha2, string alpha3, int numericCode, string shortName = null, string abbreviation = null)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Cannot be null or empty", nameof(name));
        
        if (shortName != null && String.IsNullOrWhiteSpace(shortName))
            throw new ArgumentException("Cannot be empty", nameof(shortName));
        
        if (abbreviation != null && String.IsNullOrWhiteSpace(abbreviation))
            throw new ArgumentException("Cannot be empty", nameof(abbreviation));
        
        if (String.IsNullOrWhiteSpace(alpha2))
            throw new ArgumentException("Cannot be null or empty", nameof(alpha2));
        
        if (alpha2.Length != 2)
            throw new ArgumentException("Is not 2 characters in length", nameof(alpha2));
        
        if (String.IsNullOrWhiteSpace(alpha3))
            throw new ArgumentException("Cannot be null or empty", nameof(alpha3));
        
        if (alpha3.Length != 3)
            throw new ArgumentException("Is not 3 characters in length", nameof(alpha3));
        
        if (numericCode <= 0)
            throw new ArgumentOutOfRangeException(nameof(numericCode), "Cannot be zero or less");
        
        _shortName = shortName;
        Name = name;
        Abbreviation = abbreviation;
        Alpha2 = alpha2;
        Alpha3 = alpha3;
        NumericCode = numericCode;
    }
#else
    private readonly string? _shortName;

    public string Name { get; }
    public string ShortName => _shortName ?? Name;
    public string? Abbreviation { get; }
    public string Alpha2 { get; }
    public string Alpha3 { get; }
    public int NumericCode { get; }
    
    internal IsoCountry(string name, string alpha2, string alpha3, int numericCode, string? shortName = null, string? abbreviation = null)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Cannot be null or empty", nameof(name));
        
        if (shortName != null && String.IsNullOrWhiteSpace(shortName))
            throw new ArgumentException("Cannot be empty", nameof(shortName));
        
        if (abbreviation != null && String.IsNullOrWhiteSpace(abbreviation))
            throw new ArgumentException("Cannot be empty", nameof(abbreviation));
        
        if (String.IsNullOrWhiteSpace(alpha2))
            throw new ArgumentException("Cannot be null or empty", nameof(alpha2));
        
        if (alpha2.Length != 2)
            throw new ArgumentException("Is not 2 characters in length", nameof(alpha2));
        
        if (String.IsNullOrWhiteSpace(alpha3))
            throw new ArgumentException("Cannot be null or empty", nameof(alpha3));
        
        if (alpha3.Length != 3)
            throw new ArgumentException("Is not 3 characters in length", nameof(alpha3));
        
        if (numericCode <= 0)
            throw new ArgumentOutOfRangeException(nameof(numericCode), "Cannot be zero or less");
        
        _shortName = shortName;
        Name = name;
        Abbreviation = abbreviation;
        Alpha2 = alpha2;
        Alpha3 = alpha3;
        NumericCode = numericCode;
    }
#endif
}