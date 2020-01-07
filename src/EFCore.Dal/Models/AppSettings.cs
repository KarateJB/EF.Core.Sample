using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dal.Models
{
    /// <summary>
    /// AppSettings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// ConnectionStrings
        /// </summary>
        public ConnectionStringOptions ConnectionStrings { get; set; }
    }

    /// <summary>
    /// Connection strings
    /// </summary>
    public class ConnectionStringOptions
    {
        /// <summary>
        /// Database's connection string
        /// </summary>
        public string DB { get; set; }
    }
}
