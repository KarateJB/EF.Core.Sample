using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Dal.Models
{
    /// <summary>
    /// SysMetadata
    /// </summary>
    [Table("SysMetadatas", Schema = "system")]
    public class SysMetadata: BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order =1)]
        public int  Id { get; set; }

        /// <summary>
        /// Status ID
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// FK: Status
        /// </summary>
        [ForeignKey("StatusId")]
        public MapStatus Status { get; set; }
    }
}
