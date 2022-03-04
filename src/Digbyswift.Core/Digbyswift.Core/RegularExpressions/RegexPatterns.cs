using System.Text.RegularExpressions;

namespace Digbyswift.Core.RegularExpressions
{
	public static class RegexPatterns
	{
        public const string Email = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$";

        public const string Url = @"http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?";

        public const string Markup = "<.*?>";

        public const string LocaleIsoCode = "^[a-z]{2}-[a-z]{2}$";

        public const string PathWithLocaleIsoCodeRoot = "^/?([a-z]{2}-[a-z]{2})(/.*)?";

        public const string FileExtension = @"\.([a-z0-9]+)$";

        public const string UkPhoneNumber = @"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$";

        public const string UkPostCode = @"(GIR ?0AA|(?:[a-pr-uwyzA-PR-UWYZ](?:\d|\d{2}|[a-hk-yA-HK-Y]\d|[a-hk-yA-HK-Y]\d\d|\d[a-hjkstuwA-HJKSTUW]|[a-hk-yA-HK-Y]\d[abehmnprv-yABEHMNPRV-Y])) ?\d[abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2})";

        public const string IrishPostCode = @"(D6W|d6w|[ac-fhknprtv-yAC-FHKNPRTV-Y][0-9]{2}) ?([ac-fhknprtv-yAC-FHKNPRTV-Y0-9]{4})";

        public const string UkOrIrishPostCode = "(" + UkPostCode + "|" + IrishPostCode + ")";

        public const string ContainsUrl = @"^(?!.*(http|href|www)).*$";

        public static readonly Regex EmailRegex = new Regex(Email, RegexOptions.IgnoreCase);
        public static readonly Regex LocaleIsoCodeRegex = new Regex(LocaleIsoCode, RegexOptions.IgnoreCase);
        public static readonly Regex PathWithLocaleIsoCodeRootRegex = new Regex(PathWithLocaleIsoCodeRoot, RegexOptions.IgnoreCase);
        public static readonly Regex MarkupRegex = new Regex(Markup, RegexOptions.IgnoreCase);
        public static readonly Regex FileExtensionRegex = new Regex(FileExtension, RegexOptions.IgnoreCase);
        public static readonly Regex UkPhoneNumberRegex = new Regex(UkPhoneNumber, RegexOptions.IgnoreCase);
        public static readonly Regex UkPostCodeRegex = new Regex(UkPostCode, RegexOptions.IgnoreCase);
        public static readonly Regex IrishPostCodeRegex = new Regex(IrishPostCode, RegexOptions.IgnoreCase);
        public static readonly Regex UkOrIrishPostCodeRegex = new Regex(UkOrIrishPostCode, RegexOptions.IgnoreCase);
        public static readonly Regex UrlFriendlyUnfriendlyFlankingCharactersRegex = new Regex(@"^\W+|\W+$", RegexOptions.IgnoreCase);
        public static readonly Regex UrlFriendlyCharactersRegex = new Regex(@"\W+", RegexOptions.IgnoreCase);
        public static readonly Regex ContainsUrlRegex = new Regex(ContainsUrl, RegexOptions.IgnoreCase);
    }
}
