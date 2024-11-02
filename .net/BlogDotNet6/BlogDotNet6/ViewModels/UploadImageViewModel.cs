using System.ComponentModel.DataAnnotations;

namespace BlogDotNet6.ViewModels;

public class UploadImageViewModel
{
    [Required(ErrorMessage = "Image invalid")]
    
    public string ImageBase64 { get; set; }
}