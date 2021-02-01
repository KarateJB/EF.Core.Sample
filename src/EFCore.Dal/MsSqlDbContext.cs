using EFCore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCore.Dal
{
    /// <summary>
    /// MS SQL Server Dbcontext
    /// </summary>
    public class MsSqlDbContext : DbContext
    {
        private readonly DbContextOptions<MsSqlDbContext> options = null;
        private readonly AppSettings appsettings = null;

        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
            this.options = options;
        }
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options, IOptions<AppSettings> configuration) : base(options)
        {
            this.options = options;
            this.appsettings = configuration.Value;
        }
    }
}
