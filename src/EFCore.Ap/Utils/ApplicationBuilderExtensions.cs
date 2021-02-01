using System.Collections.Generic;
using EFCore.Core.Models;
using EFCore.Dal.Utils;
using Microsoft.AspNetCore.Builder;

namespace EFCore.Ap.Utils
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure DbContext factory
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="options">AppSettings</param>
        public static void ConfigureDbContextFactory(this IApplicationBuilder app, AppSettings options)
        {
            var connStrs = new Dictionary<string, string>();
            connStrs.Add(Databases.Demo, options.ConnectionStrings.Demo_PG);

            // Add more connection strings here ...

            // Initialize the DbContextFactory
            DbContextFactory.Setup(connStrs, maxConnections: options.DbContextFactory.MaxConnections);
        }
    }
}
