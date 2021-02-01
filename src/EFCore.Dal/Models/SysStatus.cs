using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Dal.Models
{
    /// <summary>
    /// MapStatus
    /// </summary>
    [Table("MapStatuses", Schema = "system")]
    public class MapStatus
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }
    }
}
