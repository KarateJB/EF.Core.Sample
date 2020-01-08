﻿// <auto-generated />
using System;
using EFCore.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFCore.Dal.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200108071942_CreateUsers")]
    partial class CreateUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EFCore.Dal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("CardNo")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(48)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<byte[]>("Phone")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardNo = new byte[] { 195, 13, 4, 7, 3, 2, 23, 228, 142, 107, 105, 230, 3, 77, 107, 210, 68, 1, 9, 155, 7, 10, 151, 40, 135, 160, 73, 83, 229, 33, 142, 216, 78, 100, 154, 4, 35, 70, 183, 174, 9, 53, 189, 200, 230, 29, 45, 125, 78, 78, 213, 183, 45, 109, 89, 75, 150, 3, 150, 18, 119, 225, 123, 135, 137, 186, 118, 163, 174, 31, 19, 25, 115, 91, 255, 39, 81, 184, 78, 105, 65, 61, 246, 174, 46 },
                            Name = "JB",
                            Password = "$1$9N5ops2d$8zRAsKIXPLpuQ967QLgeW.",
                            Phone = new byte[] { 195, 13, 4, 7, 3, 2, 158, 224, 142, 209, 110, 167, 114, 37, 120, 210, 59, 1, 89, 152, 28, 115, 50, 250, 217, 125, 113, 159, 237, 10, 127, 55, 104, 249, 167, 114, 237, 142, 4, 21, 120, 74, 115, 25, 54, 184, 143, 41, 120, 188, 195, 145, 201, 221, 16, 89, 246, 143, 81, 195, 158, 56, 238, 238, 202, 94, 154, 87, 86, 223, 235, 173, 4, 93, 74, 207 }
                        },
                        new
                        {
                            Id = 2,
                            CardNo = new byte[] { 195, 13, 4, 7, 3, 2, 95, 226, 246, 12, 226, 4, 14, 132, 108, 210, 68, 1, 190, 0, 33, 232, 185, 141, 103, 110, 83, 203, 251, 180, 223, 191, 174, 242, 9, 162, 69, 104, 241, 211, 123, 124, 36, 14, 8, 133, 109, 170, 164, 189, 1, 126, 66, 17, 171, 114, 37, 147, 150, 91, 6, 69, 73, 127, 31, 24, 25, 48, 19, 8, 176, 92, 46, 44, 247, 14, 239, 53, 178, 229, 116, 240, 94, 43, 192 },
                            Name = "Amy",
                            Password = "$1$xN.4OKpX$Eyys8/UDLM.I5W08/DU10/",
                            Phone = new byte[] { 195, 13, 4, 7, 3, 2, 16, 50, 221, 164, 8, 87, 156, 253, 111, 210, 59, 1, 109, 20, 58, 111, 124, 113, 203, 86, 0, 235, 217, 3, 192, 56, 192, 8, 63, 32, 163, 82, 131, 115, 143, 13, 140, 158, 244, 145, 215, 57, 181, 0, 199, 250, 10, 30, 171, 32, 11, 121, 180, 119, 245, 209, 27, 27, 169, 241, 202, 254, 126, 239, 152, 171, 118, 240, 118, 43 }
                        });
                });
#pragma warning restore 612, 618
        }
    }
}