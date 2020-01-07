using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Dal.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(48)")]
        public string Name  { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "bytea")]
        public string Phone { get; set; }

        [Column(TypeName = "bytea")]
        public string CardNo { get; set; }
    }
}
