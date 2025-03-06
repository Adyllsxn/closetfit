namespace ClosetFit.Domain.Response;
public class ResponseModel<TData>
{
    private int _Code = 200;
    public string? Message { get; set; }
    public TData? Data { get; set; }
    public bool IsSuccess => _Code is >= 200 and <= 299;

    [JsonConstructor]
    public ResponseModel() => _Code = 200;
    public ResponseModel(TData? data, int code = 200, string? message = null)
    {
        Data = data;
        _Code = code;
        Message = message;
    }
}
