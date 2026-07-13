# Digbyswift.Core

[![NuGet version (Digbyswift.Core)](https://img.shields.io/nuget/v/Digbyswift.Core.svg)](https://www.nuget.org/packages/Digbyswift.Core/)
[![Build and publish package](https://github.com/Digbyswift/Digbyswift.Core/actions/workflows/dotnet-build-publish.yml/badge.svg)](https://github.com/Digbyswift/Digbyswift.Core/actions/workflows/dotnet-build-publish.yml)

A library of general-use classes and extensions for everyday .NET coding.

This includes:

## Models

- `Pair<TKey, TValue>`
- `Option`
- `Option<T>`
- `Result<T>`
- `Result<T, TEnum>`
- `SystemTime`
- `ShortGuid` (Based upon the work of https://github.com/damon-e-drake/short-guid)
- `IsoCountry`
- `IsoCountryCollection`
- `ForwardedHttpRequest`

## Constants

- `CharConstants`, e.g. `'@'`, `'.'`
- `StringConstants`, e.g. `"@"`, `"."`
- `NumericConstants`
- `MimeTypeConstants`
- `FileExtensions`
- `AppEnvironment`
- `NonStandardHeaderNames`

## Regular expressions

- Email
- UkPhoneNumber
- AlphaNumeric
- Numeric
- Decimal
- WholeNumber
- Url
- Guid
- Markup
- IPv4
- IPv6
- FileExtension
- IsoRegionalLanguage
- HexColour
- Dates
    - Universal format
    - UK format
- Time
    - 12 hour
    - 12 hour with meridiem (am/pm)
    - 24 hour
    - 24 hour with seconds

## Comparers

- `DateTimeComparer`
- `NaturalStringComparer`

## Enums

- `DateTimeComparePrecision`
- `NumericMatchType`
- `TimePrecision`

## Serialization

- `NumericBooleanConverter`

## IO

- `Utf8StringWriter`

## Exceptions

- `ArgumentEmptyException`

## Extensions

### Enumerable

- `CountIs<T>(int count)`
- `CountIs<T>(int count, Func<T, bool> predicate)`
- `CountIsLe<T>(int count)`
- `CountIsLe<T>(int count, Func<T, bool> predicate)`
- `CountIsLt<T>(int count)`
- `CountIsLt<T>(int count, Func<T, bool> predicate)`
- `CountIsGt<T>(int count)`
- `CountIsGt<T>(int count, Func<T, bool> predicate)`
- `FindFirstIndex<T>(Func<T, bool> predicate)`
- `FindIndexes<T>(Func<T, bool> predicate)`
- `FindLastIndex<T>(Func<T, bool> predicate)`
- `IsEmpty<T>()`
- `MaxOrDefault<T>()`
- `MinOrDefault<T>()`
- `None<T>(Func<T, bool> func)`
- `NotContains<T>(T item)`
- `SkipLast<T>()`
- `WhereNotNull<T>()`

### List

- `Any<T>()`
- `Crop<T>(int toSize)`

### Dictionary

- `ContainsKeyAndValue<TKey, TValue>(TKey key, TValue value)`
- `ContainsKeyAndValue<TKey>(TKey key, string value, StringComparison stringComparison = StringComparison.CurrentCulture)`
- `GetValueOrDefault<TKey, TValue>(TKey key, TValue defaultValue)` (.NET 4.8 only)
- `GetValueOrNull<TKey, TValue>(TKey key)` (.NET 4.8 only)
- `Set<TKey, TValue>(TKey key, TValue value)`

### NameValueCollection

- `CopyTo(IDictionary<string, string?> dict)`
- `Dictionary<string, string?> ToDictionary()`
- `ToQueryString()`

### String

- `Base64Encode()`
- `Base64Decode()`
- `CapitalizeWords()`
- `Coalesce(string fallback)`
- `Coalesce(string? optionalFallback, string requiredFallback)`
- `Contains(string toCheck, StringComparison comp)` (.NET 4.8 only)
- `ContainsIgnoreCase(string toCheck)`
- `ContainsIgnoreCase(IEnumerable<string> value, string toCheck)`
- `ContainsUppercaseAscii()`
- `CollapseSlashes()`
- `EndsWithIgnoreCase(string withValue)`
- `EqualsIgnoreCase(string toCheck)`
- `MaskRight(int numberOfVisibleCharacter, char maskingCharacter = CharConstants.Asterisk)`
- `MaskLeft(int numberOfVisibleCharacter, char maskingCharacter = CharConstants.Asterisk)`
- `RemoveNonWordCharacters()`
- `RemoveWhitespace()`
- `ReplaceExcess(char characterToReplace, char characterToReplaceWith, int minimumOccurrences = 2)`
- `SplitAndTrim(params char[] separator)`
- `StartsWithIgnoreCase(string withValue)`
- `StripMarkup()`
- `ToBool(bool? defaultValue)`
- `ToEnum<TEnum>()`
- `ToUrlFriendly()`
- `ToUrlFriendly(Encoding outputEncoding)`
- `TrimToDefault(string? defaultValue = null)`
- `TrimToNull()`
- `TrimWithin()`
- `Truncate(int length)`
- `Truncate(int length, string suffix)`
- `TruncateAtWord(int length)`
- `TruncateAtWord(int length, string suffix)`

### String validation

- `ContainsEmail()`
- `ContainsIPv4()`
- `ContainsIPv6()`
- `ContainsMarkup()`
- `ContainsUkTelephone()`
- `ContainsUrl()`
- `HasFileExtension()`
- `HasFileExtension(int minLength, int maxLength = Int32.MaxValue)`
- `HasUkMobileNumberPrefix()`
- `IsAlphaNumeric()`
- `IsEmail()`
- `IsHexColor()`
- `IsIsoRegionalLanguage()`
- `IsIPv4()`
- `IsIPv6()`
- `IsJson()`
- `IsMarkup()`
- `IsNumeric(NumericMatchType matchType = NumericMatchType.Any)`
- `IsUrl()`
- `IsWholeNumber()`
- `IsUkTelephone()`

### String compression

- `Compress()`
- `Decompress()`

### Boolean

- `AsYesNo()`
- `AsYesNo(string valueWhenNull)`

### DateTime

- `Age()`
- `AgeNextBirthday()`
- `AsKind(DateTimeKind kind)`
- `DaysUntil()`
- `IsAfter(DateTime otherDate)`
- `IsBefore(DateTime otherDate)`
- `SubtractDays(int days)`
- `SubtractMonths(int months)`
- `SubtractYears(int years)`
- `ToInvariantString()`
- `ToSortableString()`
- `ToUnixTimeSeconds()`
- `TruncateTime(TimePrecision precision)`

### Guid

- `Segments()`
- `FirstSegment()`

### Numeric

#### Int

- `AsPercentageOf(int total)`
- `IsEven()`
- `ToInvariantString()`

#### Decimal

- `AsPercentageOf(decimal total)`
- `ToInvariantString()`

#### Double

- `AsPercentageOf(double total)`
- `Equals(double compareTo, double decimalPlaces)`
- `IsZero()`
- `Truncate(int decimalPlaces)`
- `ToInvariantString()`

#### Short

- `ToInvariantString()`

#### UShort

- `ToInvariantString()`

#### UInt

- `ToInvariantString()`

#### Long

- `ToInvariantString()`

#### ULong

- `ToInvariantString()`

### Encryption

#### RSA

- `RSAEncrypt()`
- `RSAEncrypt(string publicKeyXml)`
- `RSADecrypt()`
- `RSADecrypt(string privateKeyXml)`

#### SHA

- `ToSHA1Hash()`
- `ToSHA256Hash()`
- `ToSHA384Hash()`
- `ToSHA512Hash()`

### StringBuilder

- `EnsureTrailingCharacter(char character)`
- `TrimEnd(char? character = null)`
- `Truncate(int maxLength)`

### Assembly

- `GetTypesAssignableFrom<T>()`
- `GetTypesAssignableFrom(Type compareType)`

### Enum

- `Parse<T>(string value, T defaultValue = default)` (.NET 4.8 only)

### HttpContent (.NET Standard 2.0 & .NET 8 only)

- `ReadAsJsonAsync<T>(JsonSerializerSettings? options = null)`

### HttpContext (.NET Standard 2.0 & .NET 8 only)

- `IsAuthenticated()`

### HttpRequest (.NET Standard 2.0 & .NET 8 only)

- `AcceptsWebP()`
- `AsForwarded()`
- `GetAbsoluteBaseUri()`
- `GetAbsoluteBaseUrl()`
- `GetAbsoluteUri()`
- `GetAbsoluteUrl()`
- `GetClientIp()`
- `GetDomainInfo()`
- `GetRawReferrer()`
- `GetReferrer()`
- `GetSameHostReferrer(bool allowSubDomains = false)`
- `GetSameHostReferrerOrDefault(bool allowSubDomains = false, string? defaultReferrer = null)`
- `GetUserAgent()`
- `HasReferrer()`
- `HasUserAgent(string? specificUserAgent = null)`
- `IsAjaxRequest()`
- `IsGetMethod()`
- `IsHeadMethod()`
- `IsInternetExplorer11()`
- `IsPngOrJpeg()`
- `IsPostMethod()`
- `IsSvg()`
- `PathAndQueryKeyOnly(string key, string? defaultValue)`
- `PathAndQueryReplaceValueOfKey(string replaceKey, object value)`
- `PathAndQueryWithoutKey(string excludeKey)`
- `PathAndQueryWithoutKeys(params string[] excludeKeys)`
- `PathFileExtension()`
- `PathHasFileExtension()`
- `TryGetReferrer(out Uri? referringUri)`
- `TryGetSameHostReferrer(out Uri? referringUri)`

### HttpResponse (.NET Standard 2.0 & .NET 8 only)

- `SetNoCacheHeaders()`

### HttpResponseMessage (.NET Standard 2.0 & .NET 8 only)

- `IsStatusCodeSuitableForRetry()`

### PathString (.NET Standard 2.0 & .NET 8 only)

- `SegmentAt(int index)`
- `SegmentAtOrDefault(int index, string? defaultSegment = null)`
- `Segments()`

### Uri (.NET Standard 2.0 & .NET 8 only)

- `GetDomainInfo()`
- `ToBareUri()`
- `ToBareUrl()`
- `ToBaseUri()`

### Third-party

#### Loqate

- `IsLoqateAddressId()`
- `IsLoqateContainerId()`

#### Youtube

- `IsYouTubeUrl()`
- `ExtractYouTubeVideoId()`
- `ToYouTubeThumbnailUrl()`
- `ToYouTubeEmbedUrl()`

#### Vimeo

- `IsVimeoUrl()`
- `IsVimeoEventUrl()`
- `ExtractVimeoVideoId()`
- `ToVimeoEmbedUrl()`

#### Twitter

- `IsTweetUrl()`
- `ExtractIdFromTweetUrl()`
