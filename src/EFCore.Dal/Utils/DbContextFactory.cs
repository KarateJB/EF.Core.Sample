﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EFCore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Dal.Utils
{
    /// <summary>
    /// DbContext factory
    /// </summary>
    public static class DbContextFactory
    {
        private static readonly object enqueueLock;
        private static ConcurrentQueue<MyDbContext> dbContextQueue = null;

        public static int MaxConnections { get; private set; } = 0; // Max preserved connections
        public static Dictionary<string, string> ConnectionStrings { get; private set; } // Connection string store

        /// <summary>
        /// Intialize the configurations
        /// </summary>
        /// <param name="connStrs">Connection strings</param>
        /// <param name="maxConnections">Max connections</param>
        public static void Setup(Dictionary<string, string> connStrs, int? maxConnections = null)
        {
            ConnectionStrings = connStrs;
            MaxConnections = maxConnections.HasValue ? maxConnections.Value : DefaultConfigs.DefaultDbContextMaxConnections;
        }

        /// <summary>
        /// Enqueue ab idle connection
        /// </summary>
        /// <param name="dbContext">DB context</param>
        /// <returns>True(Enqueue successfully)/False(Exceeds the max connection and the connection will be disposed)</returns>
        public static bool Enqueue(MyDbContext dbContext)
        {
            lock (enqueueLock)
            {
                if (dbContextQueue.Count < MaxConnections)
                {
                    dbContextQueue.Enqueue(dbContext);
                    return true;
                }
                else
                {
                    if (dbContext != null)
                    {
                        dbContext.Database.CloseConnection();
                        dbContext.Dispose();
                        dbContext = null;
                    }

                    return false;
                }
            }
        }


        /// <summary>
        /// Dequeue a preserved connection or create a new one
        /// </summary>
        /// <param name="db">Database</param>
        /// <returns>DB context</returns>
        public static MyDbContext Dequeue(string dbName)
        {
            if (string.IsNullOrEmpty(dbName) || !ConnectionStrings.ContainsKey(dbName))
            {
                throw new ArgumentOutOfRangeException($"{dbName} does not have the connection string in {nameof(DbContextFactory)}");
            }

            if (dbContextQueue.TryDequeue(out MyDbContext output))
            {
                return output;
            }
            else
            {
                var connStr = ConnectionStrings[dbName];
                var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                optionsBuilder.UseNpgsql(connStr);
                return new MyDbContext(optionsBuilder.Options);
            }
        }
    }
}
