﻿using System;
using System.Data;
using EFCore.Dal.Models;
using EFCore.Dal.Utils;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Dal
{
    public class MyDbContext : DbContext
    {
        private readonly DbContextOptions<MyDbContext> options = null;

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            this.options = options;
        }

        public DbSet<User> Users { get; set; }

        #region Functions
        [DbFunction(Name = "my_hash", Schema = "public")]
        public static string DbHash(string t) => throw new NotImplementedException();

        [DbFunction(Name = "my_hash_match", Schema = "public")]
        public static bool DbHashMatch(string t, string hashed) => throw new NotImplementedException();

        [DbFunction(Name = "my_sym_encrypt", Schema = "public")]
        public static byte[] DbSymEncrypt(string t) => throw new NotImplementedException();

        [DbFunction(Name = "my_sym_decrypt", Schema = "public")]
        public static string DbSymDecrypt(byte[] t) => throw new NotImplementedException();
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Password hash
            modelBuilder.Entity<User>().Property(p => p.Password).HasConversion(
                val => this.HashIt(val),
                val => val);

            // Encrypt / Decrypt Recipts: Phone
            modelBuilder.Entity<User>().Property(p => p.Phone).HasConversion(
                val => this.EncryptMe(val),
                val => this.DecryptMe(val));

            // Encrypt / Decrypt Recipts: CardNo
            // Notice that we cannot use the static method like "DbSymEncrypt" here
            modelBuilder.Entity<User>().Property(p => p.CardNo).HasConversion(
                val => this.EncryptMe(val),
                val => this.DecryptMe(val));

            ////modelBuilder.Entity<Receipt>().Property(p => p.CardNo).HasConversion(
            ////   val => MiniTisContext.DbSymEncrypt(val),
            ////   val => MiniTisContext.DbSymDecrypt(val));

            // Seed
            modelBuilder.Seed();
        }

        private string HashIt(string text)
        {
            using (var dbContext = new MyDbContext(this.options))
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "my_hash";
                command.Parameters.Add(new Npgsql.NpgsqlParameter("t", NpgsqlTypes.NpgsqlDbType.Text)
                { Value = text });
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                var hashed = (string)command.ExecuteScalar();
                return hashed;
            }
        }

        private byte[] EncryptMe(string text)
        {
            using (var dbContext = new MyDbContext(this.options))
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "my_sym_encrypt";
                command.Parameters.Add(
                    new Npgsql.NpgsqlParameter("t", NpgsqlTypes.NpgsqlDbType.Text) { Value = text });
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                var encrypted = (byte[])command.ExecuteScalar();
                return encrypted;
            }
        }

        private string DecryptMe(byte[] cipher)
        {
            var connectionstring = "Server=jb.com;Port=5432;Database=Demo;User Id=postgres;Password=1qaz2wsx!;";
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseNpgsql(connectionstring);

            using (var dbContext = new MyDbContext(optionsBuilder.Options))
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "my_sym_decrypt";
                command.Parameters.Add(
                    new Npgsql.NpgsqlParameter("t", NpgsqlTypes.NpgsqlDbType.Bytea) { Value = cipher });
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                var decrypted = (string)command.ExecuteScalar();
                return decrypted;
            }
        }
    }
}
