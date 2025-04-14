using System.Text.Json;
using System.Text.Json.Serialization;

namespace HalaqatManagmentSystem_API.Models;

public class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Errors { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Data { get; set; }

    //public BaseResponse(bool success, string message, T? data, List<string>? errors = null)
    //{
    //    Data = data;
    //    Message = message;
    //    Errors = errors;
    //    Success = success;
    //}

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
