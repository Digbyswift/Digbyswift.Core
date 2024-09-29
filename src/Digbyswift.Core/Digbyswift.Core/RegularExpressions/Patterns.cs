using Digbyswift.Core.Constants;

namespace Digbyswift.Core.RegularExpressions;

public static class Patterns
{
    public static class Exact
    {
        public const string Email = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$";

        public const string UkPhoneNumber = @"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$";

        public const string Numeric = @"^-?\d+([,\.]\d+)?$";

        public const string WholeNumber = @"^-?\d+$";

        public const string Url = @"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";

        public const string Markup = @"^\s*(<.*?>)\s*$";

        public const string AlphaNumeric = @"^[a-zA-Z0-9]*$";

        // ReSharper disable once InconsistentNaming
        public const string IPv4 = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

        // ReSharper disable once InconsistentNaming
        public const string IPv6 = @"^(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))$";

        internal const string FileExtension = @"\.([a-zA-Z0-9]+)$";

        internal const string Guid = @"^([a-f\d]{4}(?:[a-f\d]{4}-?){4}[a-f\d]{12}|\{[a-f\d]{4}(?:[a-f\d]{4}-?){4}[a-f\d]{12}\})$";

        internal const string IsoRegionalLanguage = @"^[a-z]{2}\-[a-z]{2}$";

        internal const string HexColour = "^#(?:[0-9a-fA-F]{3}){1,2}$";

        public static class Dates
        {
            /// <summary>
            /// yyyy-MM-dd.
            /// </summary>
            public const string Universal = @"^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))$";

            /// <summary>
            /// dd-MM-yyyy, dd.MM.yyyy or dd/MM/yyyy.
            /// </summary>
            public const string UK = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
        }

        public static class Time
        {
            /// <summary>
            /// 12:59, 5:59 (must not have a leading zero).
            /// </summary>
            public const string TwelveHour = @"^(0?[1-9]|1[0-2]):[0-5][\d]$";

            /// <summary>
            /// 12:59 am, 5:59 AM (must not have a leading zero).
            /// </summary>
            public const string TwelveHourWithMeridiems = @"^((1[0-2]|?[1-9]):([0-5][\d]) ?([AaPp][Mm]))$";

            /// <summary>
            /// 23:59 or 05:59 (must have a leading zero).
            /// </summary>
            public const string TwentyFourHour = @"^(0[\d]|1[\d]|2[0-3]):[0-5][\d]$";

            /// <summary>
            /// 23:59:59 or 05:59:59.
            /// </summary>
            public const string TwentyFourHourWithSeconds = @"^(?:[01]\d|2[0123]):(?:[012345]\d):(?:[012345]\d)$";
        }
    }

    public static class Global
    {
        public const string Markup = "<.*?>";

        public static readonly string Email = Exact.Email.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string UkPhoneNumber = Exact.UkPhoneNumber.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string Numeric = Exact.Numeric.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string WholeNumber = Exact.WholeNumber.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string Url = Exact.Url.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string AlphaNumeric = Exact.AlphaNumeric.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string IPv4 = Exact.IPv4.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string IPv6 = Exact.IPv6.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string Guid = Exact.Guid.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string IsoRegionalLanguage = Exact.IsoRegionalLanguage.Trim(CharConstants.Hat, CharConstants.Dollar);

        public static readonly string HexColour = Exact.HexColour.Trim(CharConstants.Hat, CharConstants.Dollar);
    }
}
