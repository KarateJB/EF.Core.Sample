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
        /// <param name="app"></param>
        /// <param name="options"></param>
        public static void ConfigureDbContextFactory(this IApplicationBuilder app, AppSettings options)
        {
            var connStrs = new Dictionary<string, string>();
            connStrs.Add("MyPostgres", options.ConnectionStrings.DB);
            DbContextFactory.SetConnectionString(connStrs);
        }
    }
}
