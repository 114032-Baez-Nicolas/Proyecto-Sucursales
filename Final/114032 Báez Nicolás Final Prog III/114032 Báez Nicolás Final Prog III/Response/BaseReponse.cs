namespace _114032_Báez_Nicolás_Final_Prog_III.Response;

public class BaseReponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
}
