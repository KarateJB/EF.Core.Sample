using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Dal.Utils
{
    /// <summary>
    /// DbContext factory
    /// </summary>
    public static class DbContextFactory
    {
        public static Dictionary<string, string> ConnectionStrings { get; set; }

        public static void SetConnectionString(Dictionary<string, string> connStrs)
        {
            ConnectionStrings = connStrs;
        }

        public static MyDbContext Create(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                var connStr = ConnectionStrings[connid];
                var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                optionsBuilder.UseNpgsql(connStr);
                return new MyDbContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("ConnectionId");
            }
        }
    }
}
