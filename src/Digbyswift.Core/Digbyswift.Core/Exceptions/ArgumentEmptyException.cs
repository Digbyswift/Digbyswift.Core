using System;

namespace Digbyswift.Core.Exceptions;

public class ArgumentEmptyException : ArgumentException
{
    public ArgumentEmptyException(string paramName) : base("Cannot be empty", paramName)
    {
    }
}