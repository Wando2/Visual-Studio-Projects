using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogEntity.Models
{
    

    [Table("[Tag]")]
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]   public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name",TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Slug", TypeName = "varchar(100)")]
        public string? Slug { get; set; } 
    }
}
