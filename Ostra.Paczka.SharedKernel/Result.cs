using System.Diagnostics.CodeAnalysis;

namespace Ostra.Paczka.SharedKernel;

public class Result<T>
{
    private Result(T result)
    {
        Value = result;
    }

    private Result(string error)
    {
        Error = error;
    }

    [MemberNotNullWhen(false, nameof(Error))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccessful => Error is null;

    public T? Value { get; }

    public string? Error { get; }

    public static implicit operator Result<T>(T result)
    {
        return new Result<T>(result);
    }

    public static implicit operator Result<T>(string error)
    {
        return new Result<T>(error);
    }
}