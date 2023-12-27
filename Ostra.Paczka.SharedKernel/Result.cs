using System.Text.Json.Serialization;

namespace Ostra.Paczka.SharedKernel;

public class Result<T>
{
    private readonly T? _result;
    private readonly string? _error;

    private Result(T result)
    {
        _result = result;
    }

    private Result(string error)
    {
        _error = error;
    }

    public bool IsSuccessful => _error is null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T Value => _result!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Error => _error!;
    public static implicit operator Result<T>(T result)
    {
        return new Result<T>(result);
    }

    public static implicit operator Result<T>(string error)
    {
        return new Result<T>(error);
    }
}