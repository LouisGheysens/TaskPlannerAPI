using Business.Interface;

namespace Business;
public class ServiceResponse<T> : IServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = null!;
    public int TotalRecords { get; set; }
}
