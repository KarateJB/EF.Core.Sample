using System;

namespace EFCore.Dal.Models
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Is disabled
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Create On
        /// </summary>
        public DateTimeOffset? CreateOn { get; set; }

        /// <summary>
        /// Create By
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Update On
        /// </summary>
        public DateTimeOffset? UpdateOn { get; set; }

        /// <summary>
        /// Update By
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// Remove On
        /// </summary>
        public DateTimeOffset? RemoveOn { get; set; }

        /// <summary>
        /// Remove By
        /// </summary>
        public string RemoveBy { get; set; }
    }
}