namespace BlogDotNet6.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("[Role]")]


    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]  public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Column("Name",TypeName = "varchar(50)")]
        public string? Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Column("Slug", TypeName = "varchar(50)")]
        public string? Slug { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

    }

}