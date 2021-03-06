﻿using System;
using System.Collections.Generic;
using EFCore.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Dal.Utils
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var metadataIds = new List<Guid> {
                 new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86307"),
                new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b3")
              };

            modelBuilder.Entity<SysMetadata>().HasData(new SysMetadata
            {
                Id = metadataIds[0],
                CreateBy = "System",
                CreateOn = DateTimeOffset.UtcNow
            }); ;

            modelBuilder.Entity<SysMetadata>().HasData(new SysMetadata
            {
                Id = metadataIds[1],
                CreateBy = "System",
                CreateOn = DateTimeOffset.UtcNow
            });

            modelBuilder.Entity<User>()
              .HasData(new User
              {
                  Id = new Guid("ce32bd49-7a7c-4bd1-b2b9-7e960ad86306"),
                  Name = "JB",
                  Password = "123456!@#$%^",
                  Phone = "0912345678",
                  CardNo = "XXXX-YYYY-1234-5678",
                  MetadataId = metadataIds[0]
              }); ;

            modelBuilder.Entity<User>()
              .HasData(new User
              {
                  Id = new Guid("3e177c71-f84e-4c23-9bf4-b322b350c8b2"),
                  Name = "Amy",
                  Password = "123456!@#$%^",
                  Phone = "0933333333",
                  CardNo = "1234-5678-ZZZZ-WWWW",
                  MetadataId = metadataIds[1]
              });
        }
    }
}
