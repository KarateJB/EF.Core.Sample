using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Dal.Models
{
    [Table("Users",Schema = "public")]
    public class User
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(48)")]
        public string Name  { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "bytea")]
        public string Phone { get; set; }

        [Column(TypeName = "bytea")]
        public string CardNo { get; set; }

        [Column(TypeName = "bytea")]
        public byte[] Secret { get; set; } // This column wont apply Value Conversions

        public Guid? MetadataId { get; set; }

        [ForeignKey("MetadataId")]
        public virtual SysMetadata Metadata { get; set; }
    }
}
