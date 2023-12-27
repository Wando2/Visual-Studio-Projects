using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDotNet6.Models
{
  

    [Table("[Category]")]
    public class Category  
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }

        [Required]
        [Column("Name",TypeName = "varchar(50)")]

        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Slug", TypeName = "varchar(80)")]
        public string? Slug { get; set; }

        public IList<Post> Posts { get; set; }
        
    }
}