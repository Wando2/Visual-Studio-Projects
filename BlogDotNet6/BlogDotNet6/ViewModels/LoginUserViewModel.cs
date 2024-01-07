using System.ComponentModel.DataAnnotations;

namespace BlogDotNet6.ViewModels;

public class LoginUserViewModel
{
    [Required(ErrorMessage = "O campo  é obrigatorio")]
    [EmailAddress(ErrorMessage = "o email é invalido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo  é obrigatorio")]
    [MinLength(6, ErrorMessage = "A senha deve ter no minimo 6 caracteres")]
    public string Password { get; set; }

    
}