# Digbyswift.Core

[![NuGet version (Digbyswift.Core)](https://img.shields.io/nuget/v/Digbyswift.Core.svg)](https://www.nuget.org/packages/Digbyswift.Core/)
[![Build and publish package](https://github.com/Digbyswift/Digbyswift.Core/actions/workflows/dotnet-build-publish.yml/badge.svg)](https://github.com/Digbyswift/Digbyswift.Core/actions/workflows/dotnet-build-publish.yml)

A library of general-use classes and extensions for everyday coding.

This includes:

## Models

- `Pair<TKey, TValue>`
- `Option`
- `Option<T>`
- `Result<T>`
- `Result<T, TEnum>`
- `SystemTime`
- `ShortGuid` (Based upon the work of https://github.com/damon-e-drake/short-guid)

## Constants

- `CharConstants`, e.g. `'@'`, `'.'`
- `StringConstants`, e.g. `"@"`, `"."`
- `NumericConstants`
- `MimeTypeConstants`
- `FileExtensions`
- `AppEnvironments`

## Regular expressions

- Email
- UkPhoneNumber
- AlphaNumeric
- Numeric
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
- `NaturalComparer`


## Extensions

### Enumerable

- `CountIs<T>(int count)`
- `CountIsLe<T>(int count)`
- `CountIsLt<T>(int count)`
- `CountIsGe<T>(int count)`
- `CountIsGt<T>(int count)`
- `FindFirstIndex<T>(Func<T, bool> func)`
- `FindIndexes<T>(Func<T, bool> func)`
- `FindLastIndex<T>(Func<T, bool> func)`
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
- `ContainsKeyAndValue<TKey>(TKey key, string value, StringComparison stringComparison)`
- `GetOrDefault<TKey, TValue>(TKey key, TValue defaultValue)`
- `GetOrNull<TKey, TValue>(TKey key)`
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
- `Contains(string toCheck, StringComparison comp)`
- `ContainsIgnoreCase(string toCheck)`
- `EqualsIgnoreCase(string toCheck)`
- `MaskRight(int numberOfVisibleCharacter)`
- `MaskLeft(int numberOfVisibleCharacter)`
- `RemoveWhitespace()`
- `ReplaceExcess(char character, int maxRepeats)`
- `SplitAndTrim(params char[]? separator)`
- `StripMarkup()`
- `ToBool()`
- `ToEnum<TEnum>()`
- `ToUrlFriendly()`
- `TrimWithin()`
- `TrimToDefault(string? defaultValue)`
- `Truncate(int length)`
- `Truncate(int length, string suffix)`
- `TruncateAtWord(int length)`
- `TruncateAtWord(int length, string suffix)`

### String validation

- `ContainsEmail()`
- `ContainsGuid()`
- `ContainsHexColour()`
- `ContainsIPv4()`
- `ContainsIPv6()`
- `ContainsMarkup()`
- `ContainsUkTelephone()`
- `HasUkMobileNumberPrefix()`
- `ContainsUrl()`
- `HasFileExtension()`
- `IsAlphaNumeric()`
- `IsEmail()`
- `IsGuid()`
- `IsHexColour()`
- `IsIsoRegionalLanguage()`
- `IsIPv4()`
- `IsIPv6()`
- `IsJson()`
- `IsMarkup()`
- `IsNumeric(NumericMatchType numericMatchType = NumericMatchType.Real)`
- `IsUrl()`
- `IsWholeNumber()`
- `IsUkTelephone()`

### String compression

- `Compress()`
- `Decompress()`

### Boolean

- `AsYesNo()`
- `AsYesNo(string nullDefault)`

### DateTime

- `AsKind(DateTimeKind kind)`
- `GetDaysUntil()`
- `GetAgeNextBirthday()`
- `GetAge()`
- `IsAfter(DateTime otherDate)`
- `IsBefore(DateTime otherDate)`
- `SubtractDays(int days)`
- `SubtractMonths(int months)`
- `SubtractYears(int years)`
- `TruncateTime(TimePrecision precision)`
- `ToInvariantString()`
- `ToSortableString()`
- `ToUnixTimeSeconds()`

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

- `ToSHA1()`
- `ToSHA256()`
- `ToSHA384()`
- `ToSHA512()`

### StringBuilder

- `EnsureTrailingCharacter(char character)`
- `TrimEnd(char? character = null)`
- `Truncate(int maxLength)`

### Assembly

- `GetTypesAssignableFrom<T>()`
- `GetTypesAssignableFrom(Type compareType)`

### Third-party

#### Loqate

- `IsLoqateAddressId()`
- `IsLoqateContainerId()`

#### Youtube

- `IsYouTubeUrl()`
- `ExtractYouTubeVideoId()`
- `ToYouTubeThumbnailUrl(YouTubeThumbnailSize thumbnailSize = YouTubeThumbnailSize.Default)`
- `ToYouTubeEmbedUrl()`
- `NameValueCollection? ParseYoutubeQueryString()`

#### Vimeo

- `IsVimeoUrl()`
- `IsVimeoEventUrl()`
- `ExtractVimeoVideoId()`
- `ToVimeoEmbedUrl()`

#### Twitter

- `IsTweetUrl()`
- `ExtractIdFromTweetUrl()`
