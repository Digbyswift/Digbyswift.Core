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

- `CountIs(int count)`
- `CountIsLe(int count)`
- `CountIsLt(int count)`
- `CountIsGe(int count)`
- `CountIsGt(int count)`
- `IsEmpty()`
- `MaxOrDefault()`
- `MinOrDefault()`
- `None(Func<T, bool> func)`
- `NotContains(T item)`
- `SkipLast()`
- `WhereNotNull()`

### List

- `Any()`
- `Crop(int toSize)`

### Dictionary

- `ContainsKeyAndValue(TKey key, TValue value)`
- `ContainsKeyAndValue(TKey key, string value, StringComparison stringComparison)`
- `GetOrDefault(TKey key, TValue defaultValue)`
- `GetOrNull(TKey key)`
- `Set(TKey key, TValue value)`

### NameValueCollection

- `CopyTo(IDictionary<string, string?> dict)`
- `ToDictionary()`
- `ToQueryString()`

### String

- `Base64Encode()`
- `Base64Decode()`
- `CapitalizeWords()`
- `Coalesce(string valueWhenNullOrEmpty)`
- `Contains(string toCheck, StringComparison comp)`
- `ContainsIgnoreCase(string toCheck)`
- `ContainsIgnoreCase(string toCheck)`
- `EqualsIgnoreCase(string toCheck)`
- `MaskRight(int numberOfVisibleCharacter)`
- `MaskLeft(int numberOfVisibleCharacter)`
- `RemoveWhitespace()`
- `ReplaceExcess()`
- `SplitAndTrim(params char[]? separator)`
- `StripMarkup()`
- `ToBool()`
- `ToEnum()`
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
- `IsNumeric()`
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
- `GetDaysUntil(DateTime value)`
- `GetAgeNextBirthday(DateTime dob)`
- `GetAge(DateTime dob)`
- `IsAfter(DateTime otherDate)`
- `IsBefore(DateTime otherDate)`
- `SubtractDays(int days)`
- `SubtractMonths(int months)`
- `SubtractYears(int years)`
- `TruncateTime(TimePrecision precision)`
 
### Guid

- `Segments()`
- `FirstSegment()`

### Numeric

- `AsPercentageOf(int total)`
- `AsPercentageOf(decimal total)`
- `AsPercentageOf(double total)`
- `Equals(double compareTo, double decimalPlaces)`
- `IsZero()`
- `IsEven()`
- `Truncate(int decimalPlaces)`

### Encryption

- `RSAEncrypt()`
- `RSAEncrypt(string publicKeyXml)`
- `RSADecrypt()`
- `RSADecrypt(string privateKeyXml)`

### StringBuilder

- `EnsureTrailingCharacter(char character)`
- `TrimEnd(char? character = null)`

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
