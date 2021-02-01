using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Dal.Models
{
    /// <summary>
    /// SysMetadata
    /// </summary>
    [Table("SysMetadatas", Schema = "system")]
    public class SysMetadata : BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public Guid Id { get; set; }
    }
}
