using System.Text.RegularExpressions;

namespace Digbyswift.Core.RegularExpressions
{
	public static class RegexPatterns
	{
        public const string Email = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$";
        
        public const string UkPhoneNumber = @"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$";
		
        public const string Url = @"http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?";
		
        public const string Markup = "<.*?>";
        
        public const string FileExtension = @"\.([a-zA-Z0-9]+)$";

        public static readonly Regex EmailRegex = new Regex(Email, RegexOptions.IgnoreCase);
        
        public static readonly Regex UkPhoneNumberRegex = new Regex(UkPhoneNumber, RegexOptions.IgnoreCase);
		
        public static readonly Regex MarkupRegex = new Regex(Markup, RegexOptions.IgnoreCase);
        
        public static readonly Regex FileExtensionRegex = new Regex(FileExtension, RegexOptions.IgnoreCase);
	}
}
