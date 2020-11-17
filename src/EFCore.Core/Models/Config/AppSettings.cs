using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Core.Models
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

        /// <summary>
        /// DB context factory
        /// </summary>
        public DbContextFactoryOptions DbContextFactory  { get; set; }
    }

    /// <summary>
    /// Connection strings
    /// </summary>
    public class ConnectionStringOptions
    {
        /// <summary>
        /// Database's connection string
        /// </summary>
        public string Demo { get; set; }
    }
    
    /// <summary>
    /// DB context factory options
    /// </summary>
    public class DbContextFactoryOptions 
    {
        /// <summary>
        /// Max connections
        /// </summary>
        public int MaxConnections { get; set; } = 10;
    }
}
