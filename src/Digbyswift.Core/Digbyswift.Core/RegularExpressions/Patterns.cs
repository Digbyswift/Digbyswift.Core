using SysRegex = System.Text.RegularExpressions.Regex;

namespace Digbyswift.Core.RegularExpressions;

public static class Patterns
{
	public static class Exact
	{
		public static readonly string Email = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$";
    
		public static readonly string UkPhoneNumber = @"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$";
		
		public static readonly string Numeric = @"^-?\d+([,\.]\d+)?$";

		public static readonly string WholeNumber = @"^-?\d+$";

		public static readonly string Url = @"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";

		public static readonly string Markup = @"^\s*(<.*?>)\s*$";

		public static readonly string AlphaNumeric = @"^[a-zA-Z0-9]*$";
		
		// ReSharper disable once InconsistentNaming
		public static readonly string IPv4 = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

		// ReSharper disable once InconsistentNaming
		public static readonly string IPv6 = @"^(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))$";

		internal static readonly string FileExtension = @"\.([a-zA-Z0-9]+)$";

		internal static readonly string Guid = @"^([a-f\d]{4}(?:[a-f\d]{4}-?){4}[a-f\d]{12}|\{[a-f\d]{4}(?:[a-f\d]{4}-?){4}[a-f\d]{12}\})$";
			
	
		public static class Dates
		{
			/// <summary>
			/// yyyy-MM-dd
			/// </summary>
			public static readonly string Universal = @"^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$";

			/// <summary>
			/// dd-MM-yyyy, dd.MM.yyyy or dd/MM/yyyy
			/// </summary>
			public static readonly string UK = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
		}

		public static class Time
		{
			/// <summary>
			/// 12:59, 5:59 (must not have a leading zero)
			/// </summary>
			public static readonly string TwelveHour = @"^(0?[1-9]|1[0-2]):[0-5][\d]$";

			/// <summary>
			/// 12:59 am, 5:59 AM (must not have a leading zero)
			/// </summary>
			public static readonly string TwelveHourWithMeridiems = @"^((1[0-2]|?[1-9]):([0-5][\d]) ?([AaPp][Mm]))$";
			
			/// <summary>
			/// 23:59 or 05:59 (must have a leading zero)
			/// </summary>
			public static readonly string TwentyFourHour = @"^(0[\d]|1[\d]|2[0-3]):[0-5][\d]$";
			
			/// <summary>
			/// 23:59:59 or 05:59:59
			/// </summary>
			public static readonly string TwentyFourHourWithSeconds = @"^(?:[01]\d|2[0123]):(?:[012345]\d):(?:[012345]\d)$";
		}
	}

	public static class Global
	{
		public static readonly string Email = Exact.Email.Trim('^', '$');
    
		public static readonly string UkPhoneNumber = Exact.UkPhoneNumber.Trim('^', '$');
		
		public static readonly string Numeric = Exact.Numeric.Trim('^', '$');

		public static readonly string WholeNumber = Exact.WholeNumber.Trim('^', '$');

		public static readonly string Url = Exact.Url.Trim('^', '$');
		
		public static readonly string Markup = "<.*?>";

		public static readonly string AlphaNumeric = Exact.AlphaNumeric.Trim('^', '$');
		
		public static readonly string IPv4 = Exact.IPv4.Trim('^', '$');
		
		public static readonly string IPv6 = Exact.IPv6.Trim('^', '$');
		
		public static readonly string Guid = Exact.Guid.Trim('^', '$');
	}
}
