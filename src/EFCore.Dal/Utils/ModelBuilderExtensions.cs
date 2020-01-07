using EFCore.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Dal.Utils
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasData(new User
              {
                  Id = 1,
                  Name = "JB",
                  Phone = "0912345678",
                  CardNo = "XXXX-YYYY-1234-5678"
              });

            modelBuilder.Entity<User>()
              .HasData(new User
              {
                  Id = 2,
                  Name = "Amy",
                  Phone = "0933333333",
                  CardNo = "1234-5678-ZZZZ-WWWW"
              });
        }
    }
}
