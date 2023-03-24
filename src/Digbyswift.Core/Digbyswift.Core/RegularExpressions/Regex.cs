using System;
using System.Text.RegularExpressions;
using SysRegex = System.Text.RegularExpressions.Regex;

namespace Digbyswift.Core.RegularExpressions;

public static class Regex
{
	public static readonly Lazy<SysRegex> IsEmail = new(() => new SysRegex(Patterns.Exact.Email, RegexOptions.IgnoreCase));
    
	public static readonly Lazy<SysRegex> IsUkPhoneNumber = new(() => new SysRegex(Patterns.Exact.UkPhoneNumber, RegexOptions.IgnoreCase));

	public static readonly Lazy<SysRegex> IsNumeric = new(() => new SysRegex(Patterns.Exact.Numeric, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> IsWholeNumber = new(() => new SysRegex(Patterns.Exact.WholeNumber, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> IsUrl = new(() => new SysRegex(Patterns.Exact.Url, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> IsMarkup = new(() => new SysRegex(Patterns.Exact.Markup, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> IsAlphaNumeric = new(() => new SysRegex(Patterns.Exact.AlphaNumeric, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> IsIPv4 = new(() => new SysRegex(Patterns.Exact.IPv4, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> IsIPv6 = new(() => new SysRegex(Patterns.Exact.IPv6, RegexOptions.IgnoreCase));
    
	public static readonly Lazy<SysRegex> HasFileExtension = new(() => new SysRegex(Patterns.Exact.FileExtension, RegexOptions.IgnoreCase));

	public static readonly Lazy<SysRegex> IsGuid = new(() => new SysRegex(Patterns.Exact.Guid, RegexOptions.IgnoreCase));

	
	public static readonly Lazy<SysRegex> ContainsEmail = new(() => new SysRegex(Patterns.Global.Email, RegexOptions.IgnoreCase));
    
	public static readonly Lazy<SysRegex> ContainsUkPhoneNumber = new(() => new SysRegex(Patterns.Global.UkPhoneNumber, RegexOptions.IgnoreCase));

	public static readonly Lazy<SysRegex> ContainsNumeric = new(() => new SysRegex(Patterns.Global.Numeric, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> ContainsWholeNumber = new(() => new SysRegex(Patterns.Global.WholeNumber, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> ContainsUrl = new(() => new SysRegex(Patterns.Global.Url, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> ContainsIPv4 = new(() => new SysRegex(Patterns.Global.IPv4, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> ContainsIPv6 = new(() => new SysRegex(Patterns.Global.IPv6, RegexOptions.IgnoreCase));
	
	public static readonly Lazy<SysRegex> ContainsMarkup = new(() => new SysRegex(Patterns.Global.Markup, RegexOptions.IgnoreCase));

	public static readonly Lazy<SysRegex> ContainsGuid = new(() => new SysRegex(Patterns.Global.Guid, RegexOptions.IgnoreCase));
}
