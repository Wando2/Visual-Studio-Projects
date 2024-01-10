namespace BlogDotNet6.ViewModels;

public class PostViewModel
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    
    public DateTime LastUpdateDate { get; set; }
}