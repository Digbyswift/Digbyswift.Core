# Digbyswift.Core

[![NuGet version (Digbyswift.Core)](https://img.shields.io/nuget/v/Digbyswift.Core.svg)](https://www.nuget.org/packages/Digbyswift.Core/)
![Build status](https://dev.azure.com/digbyswift/Digbyswift%20-%20OSS%20Packages/_apis/build/status/Build%20Digbyswift.Core)

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

- `IsEmpty()`
- `WhereNotNull()`
- `NotContains(T item)`
- `None(Func<T, bool> func)`
- `MinOrDefault()`
- `MaxOrDefault()`
- `CountIs(int count)`
- `CountIsGt(int count)`
- `CountIsGe(int count)`
- `CountIsLt(int count)`
- `CountIsLe(int count)`
- `SkipLast()`

### List

- `Crop(int toSize)`
- `Any()`

### Dictionary

- `Set(TKey key, TValue value)`
- `ContainsKeyAndValue(TKey key, TValue value)`
- `ContainsKeyAndValue(TKey key, string value, StringComparison stringComparison)`
- `GetOrDefault(TKey key, TValue defaultValue)`
- `GetOrNull(TKey key)`

### NameValueCollection

- `ToDictionary()`
- `CopyTo(IDictionary<string, string?> dict)`
- `ToQueryString()`

### String

- `Coalesce(string valueWhenNullOrEmpty)`
- `EqualsIgnoreCase(string toCheck)`
- `Contains(string toCheck, StringComparison comp)`
- `ContainsIgnoreCase(string toCheck)`
- `ContainsIgnoreCase(string toCheck)`
- `RemoveWhitespace()`
- `ToBool()`
- `CapitalizeWords()`
- `Truncate(int length)`
- `Truncate(int length, string suffix)`
- `TruncateAtWord(int length)`
- `TruncateAtWord(int length, string suffix)`
- `ToUrlFriendly()`
- `TrimWithin()`
- `TrimToDefault(string? defaultValue)`
- `SplitAndTrim(params char[]? separator)`
- `StripMarkup()`
- `ReplaceExcess()`
- `Base64Encode()`
- `Base64Decode()`
- `MaskRight(int numberOfVisibleCharacter)`
- `MaskLeft(int numberOfVisibleCharacter)`
- `ToEnum()`

### String validation

- `IsEmail()`
- `IsUrl()`
- `IsGuid()`
- `IsHexColour()`
- `IsIsoRegionalLanguage()`
- `IsIPv4()`
- `IsIPv6()`
- `IsWholeNumber()`
- `IsNumeric()`
- `IsAlphaNumeric()`
- `IsUkTelephone()`
- `IsMarkup()`
- `IsJson()`
- `HasFileExtension()`
- `ContainsEmail()`
- `ContainsUrl()`
- `ContainsGuid()`
- `ContainsHexColour()`
- `ContainsIPv4()`
- `ContainsIPv6()`
- `ContainsUkTelephone()`
- `ContainsMarkup()`

### String compression

- `Compress()`
- `Decompress()`

### Boolean

- `AsYesNo()`
- `AsYesNo(string nullDefault)`

### DateTime

- `GetDaysUntil()`
- `GetAgeNextBirthday()`
- `GetAge()`
- `IsBefore()`
- `IsAfter()`
- `SubtractDays()`
- `SubtractMonths()`
- `SubtractYears()`
- `AsKind()`

### Guid

- `Segments()`
- `FirstSegment()`

### Numeric

- `IsZero()`
- `IsEven()`
- `AsPercentageOf(int total)`
- `AsPercentageOf(decimal total)`
- `AsPercentageOf(double total)`
- `Equals(double compareTo, double decimalPlaces)`
- `Truncate(int decimalPlaces)`

### Encryption

- `RSAEncrypt()`
- `RSAEncrypt(string publicKeyXml)`
- `RSADecrypt()`
- `RSADecrypt(string privateKeyXml)`

### StringBuilder

- `TrimEnd(char? character = null)`
- `EnsureTrailingCharacter(char character)`

### Assembly

- `GetTypesAssignableFrom<T>()`
- `GetTypesAssignableFrom(Type compareType)`

### Third-party

#### Youtube

- `IsYouTubeUrl()`
- `ExtractYouTubeVideoId()`
- `ToYouTubeThumbnailUrl()`
- `ToYouTubeEmbedUrl()`
- `ParseYoutubeQueryString()`

#### Vimeo

- `IsVimeoUrl()`
- `IsVimeoEventUrl()`
- `ExtractVimeoVideoId()`
- `ToVimeoEmbedUrl()`

#### Twitter

- `IsTweetUrl()`
- `ExtractIdFromTweetUrl()`
