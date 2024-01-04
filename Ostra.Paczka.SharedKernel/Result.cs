using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public bool IsSuccessful => Error is null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Value { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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