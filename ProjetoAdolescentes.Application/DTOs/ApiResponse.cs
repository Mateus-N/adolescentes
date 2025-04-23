namespace ProjetoAdolescentes.Application.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public required List<ApiError> Errors { get; set; }
}

public class ApiError
{
    public required string Key { get; set; }
    public required string Message { get; set; }
}