#pragma warning disable SA1402
namespace Digbyswift.Core.Models;

public class Result<T>
{
    public bool Success { get; }
    public T Value { get; }

    public Result(T value, bool success = true)
    {
        Value = value;
        Success = success;
    }

    public static Result<T> NoSuccess(T value)
    {
        return new Result<T>(value, false);
    }
}

public class Result<T, TEnum> where TEnum : struct
{
    public TEnum Status { get; }
    public T Value { get; }

    public Result(T value, TEnum status = default)
    {
        Value = value;
        Status = status;
    }
}
