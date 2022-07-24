namespace Business.Interface;

public interface IServiceResponse<T>
{
    T? Data { get; set; }
    string Message { get; set; }
    bool Success { get; set; }
    int TotalRecords { get; set; }
}