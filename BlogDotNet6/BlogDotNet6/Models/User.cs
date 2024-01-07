using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet6.Models{
    
    [Table("[User]")]

    public class User{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }
        
        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? Name { get; set; }
        
        [Required]
        [Column("Email", TypeName = "nvarchar(100)")]
        [MaxLength(100)]
     
        public string? Email { get; set; }
        
        [Required]
        [Column("PasswordHash", TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string? PasswordHash { get; set; }
        [Required]
        [Column("Bio", TypeName = "text")]
        [MaxLength(2000)]
        public string? Bio { get; set; }


        [Required]
        [Column("Image", TypeName = "nvarchar(2000)")]
        public string Image { get; set; }
        
        [Required]
        [Column("Slug", TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string? Slug { get; set; }


        public ICollection<Role> Roles { get; set; } = new List<Role>();


    }
}

