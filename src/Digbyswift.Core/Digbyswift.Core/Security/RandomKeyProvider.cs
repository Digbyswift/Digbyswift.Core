using System;
using System.Security.Cryptography;

namespace Digbyswift.Core.Security;

public enum PassKeyFilter
{
    AlphaOnly,
    NumericOnly,
    AlphaLowerCase,
    AlphaNumeric,
    AlphaNumericLowerCase,
    AlphaNumericUpperCase,
    AlphaNumericAndSpecial
}

public interface IRandomKeyProvider
{
    string Generate(int length, PassKeyFilter filter = PassKeyFilter.AlphaNumericAndSpecial);

    string Generate(
        int minLength = RandomKeyProvider.DefaultMinPasskeyLength,
        int maxLength = RandomKeyProvider.DefaultMaxPasskeyLength,
        PassKeyFilter filter = PassKeyFilter.AlphaNumericAndSpecial
    );
}

/// <summary>
/// This class provides methods for generating random pass-keys using
/// case-sensitive, alpha-numeric characters (excluding those which would
/// cause confusion).
/// </summary>
public class RandomKeyProvider : IRandomKeyProvider
{
    // Define default min and max password lengths.
    internal const int DefaultMinPasskeyLength = 8;
    internal const int DefaultMaxPasskeyLength = 10;

    // Define supported password characters divided into groups.
    // You can add (or remove) characters to (from) these groups.
    private const string PasskeyCharsLowerCase = "abcdefgijkmnopqrstwxyz";
    private const string PasskeyCharsUpperCase = "ABCDEFGHJKLMNPQRSTWXYZ";
    private const string PasskeyCharsNumeric = "23456789";
    private const string PasskeyCharsNumericOnly = "0123456789";
    private const string PasskeyCharsSpecial = "!@.*$_^=@#:%-";

    /// <summary>
    /// Generates a random password of an exact length based upon the specified option
    /// </summary>
    /// <param name="length">Exact password length</param>
    /// <param name="filter">Option filtering the output of the key</param>
    public string Generate(int length, PassKeyFilter filter)
    {
        return Generate(length, length, filter);
    }

    /// <summary>
    /// Generates a random password.
    /// </summary>
    /// <param name="minLength">Minimum password length</param>
    /// <param name="maxLength">Maximum password length</param>
    /// <param name="filter">Option filtering the output of the key</param>
    public string Generate(int minLength = DefaultMinPasskeyLength, int maxLength = DefaultMaxPasskeyLength, PassKeyFilter filter = PassKeyFilter.AlphaNumericAndSpecial)
    {
        // Make sure that input parameters are valid.
        if (minLength <= 0)
            throw new ArgumentOutOfRangeException(nameof(minLength), "The minLength cannot be zero or less");

        if (minLength > maxLength)
            throw new ArgumentOutOfRangeException(nameof(minLength),
                "The minLength cannot be greater than the maxLength");

        // Create a local array containing supported passkey characters
        // grouped by types. You can remove character groups from this
        // array, but doing so will weaken the password strength.
        char[][] charGroups = GetCharacters(filter);
        int[] charsLeftInGroup = new int[charGroups.Length];

        // Initially, all characters in each group are not used.
        for (int i = 0; i < charsLeftInGroup.Length; i++)
        {
            charsLeftInGroup[i] = charGroups[i].Length;
        }

        // Use this array to track (iterate through) unused character groups.
        int[] leftGroupsOrder = new int[charGroups.Length];

        // Initially, all character groups are not used.
        for (int i = 0; i < leftGroupsOrder.Length; i++)
        {
            leftGroupsOrder[i] = i;
        }

        // This is real randomization ;)
        var random = new Random(GetSeed());

        // This array will hold passKey characters.
        // Allocate appropriate memory for the passKey.
        char[] passKey = minLength < maxLength
            ? new char[random.Next(minLength, maxLength + 1)]
            : new char[minLength];

        int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

        #region Generate passKey characters one at a time

        for (int i = 0; i < passKey.Length; i++)
        {
            // If only one character group remained unprocessed, process it.
            // Otherwise, pick a random character group from the unprocessed
            // group list. To allow a special character to appear in the
            // first position, increment the second parameter of the Next
            // function call by one, i.e. lastLeftGroupsOrderIdx + 1.
            var nextLeftGroupsOrderIdx = (lastLeftGroupsOrderIdx == 0) ? 0 : random.Next(0, lastLeftGroupsOrderIdx);


            // Get the actual index of the character group, from which we will
            // pick the next character.
            var nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

            // Get the index of the last unprocessed characters in this group.
            var lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

            // If only one unprocessed character is left, pick it; otherwise,
            // get a random character from the unused character list.
            var nextCharIdx = (lastCharIdx == 0) ? 0 : random.Next(0, lastCharIdx + 1);

            // Add this character to the passKey.
            passKey[i] = charGroups[nextGroupIdx][nextCharIdx];

            // If we processed the last character in this group, start over.
            if (lastCharIdx == 0)
            {
                charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
            }
            // There are more unprocessed characters left.
            else
            {
                // Swap processed character with the last unprocessed character
                // so that we don't pick it until we process all characters in
                // this group.
                if (lastCharIdx != nextCharIdx)
                {
                    char temp = charGroups[nextGroupIdx][lastCharIdx];
                    charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                    charGroups[nextGroupIdx][nextCharIdx] = temp;
                }

                // Decrement the number of unprocessed characters in
                // this group.
                charsLeftInGroup[nextGroupIdx]--;
            }

            // If we processed the last group, start all over.
            if (lastLeftGroupsOrderIdx == 0)
            {
                lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
            }
            // There are more unprocessed groups left.
            else
            {
                // Swap processed group with the last unprocessed group
                // so that we don't pick it until we process all groups.
                if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                {
                    int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                    leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                    leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                }

                // Decrement the number of unprocessed groups.
                lastLeftGroupsOrderIdx--;
            }
        }

        #endregion

        // Convert passKey characters into a string and return the result.
        return new String(passKey);
    }

    #region Private methods

    private static Char[][] GetCharacters(PassKeyFilter filter)
    {
        switch (filter)
        {
            case PassKeyFilter.NumericOnly:
                return new[]
                {
                    PasskeyCharsNumericOnly.ToCharArray()
                };

            case PassKeyFilter.AlphaOnly:
                return new[]
                {
                    PasskeyCharsLowerCase.ToCharArray(),
                    PasskeyCharsUpperCase.ToCharArray()
                };

            case PassKeyFilter.AlphaLowerCase:
                return new[]
                {
                    PasskeyCharsLowerCase.ToCharArray()
                };

            case PassKeyFilter.AlphaNumeric:
                return new[]
                {
                    PasskeyCharsLowerCase.ToCharArray(),
                    PasskeyCharsUpperCase.ToCharArray(),
                    PasskeyCharsNumeric.ToCharArray()
                };

            case PassKeyFilter.AlphaNumericLowerCase:
                return new[]
                {
                    PasskeyCharsLowerCase.ToCharArray(),
                    PasskeyCharsNumeric.ToCharArray()
                };

            case PassKeyFilter.AlphaNumericUpperCase:
                return new[]
                {
                    PasskeyCharsUpperCase.ToCharArray(),
                    PasskeyCharsNumeric.ToCharArray()
                };
        }

        return new[]
        {
            PasskeyCharsLowerCase.ToCharArray(),
            PasskeyCharsUpperCase.ToCharArray(),
            PasskeyCharsNumeric.ToCharArray(),
            PasskeyCharsSpecial.ToCharArray()
        };
    }

    private static int GetSeed()
    {
        // Because we cannot use the default randomizer, which is based on the
        // current time (it will produce the same "random" number within a
        // second), we will use a random number generator to seed the
        // randomizer.

        // Use a 4-byte array to fill it with random bytes and convert it then
        // to an integer value.
        var randomBytes = new byte[4];

        // Generate 4 random bytes.
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(randomBytes);
        }

        // Convert 4 bytes into a 32-bit integer value.
        int seed = (randomBytes[0] & 0x7f) << 24 |
                   randomBytes[1] << 16 |
                   randomBytes[2] << 8 |
                   randomBytes[3];

        return seed;
    }

    #endregion
}