namespace BlogDotNet6.ViewModels;

public class ResultViewModel<T>
{
    public ResultViewModel(T data)
    {
        this.Data = data;
    }
    
    public ResultViewModel(string error)
    {
       Errors.Add(error);
    }
    
    public ResultViewModel(List<string> errors)
    {
        this.Errors = errors;
    }
    
    public ResultViewModel(T data, List<string> errors)
    {
        this.Data = data;
        this.Errors = errors;
    }
    
    public T Data { get; private set; }

    public List<string> Errors { get; private set; } = new();
}