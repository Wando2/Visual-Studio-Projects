

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogEntity.Models{

 

    [Table("[Post]")]

    public class Post{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
         [Key] public int Id { get; set; }

         [Required]
         [MaxLength(100)]
         [Column("Title",TypeName = "varchar(100)")]
        public string? Title { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Slug", TypeName = "varchar(50)")]    
        public string? Slug { get; set; }

        [Required]
        [MaxLength(2000)]
        [Column("Body", TypeName = "text")]
        public string? Body { get; set; }

        
        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }


        
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Summary", TypeName = "varchar(100)")]
        public string? Summary { get; set; }

        
        

    }
}