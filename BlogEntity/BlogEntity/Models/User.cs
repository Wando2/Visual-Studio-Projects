using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogEntity.Models{
    
    [Table("[User]")]

    public class User{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Bio { get; set; }


        [Required]
        [Column("Image", TypeName = "varchar(2000)")]
        public string Image { get; set; }
        public string? Slug { get; set; }

        
    }
}

