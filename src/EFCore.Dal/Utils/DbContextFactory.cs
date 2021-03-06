﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using EFCore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Dal.Utils
{
    /// <summary>
    /// DbContext factory
    /// </summary>
    public static class DbContextFactory
    {
        private static readonly object enqueueLock = new object();
        private static ConcurrentQueue<PgDbContext> dbContextQueue = null;

        public static int MaxConnections { get; private set; } = 0; // Max preserved connections
        public static Dictionary<string, string> ConnectionStrings { get; private set; } // Connection string store

        /// <summary>
        /// Constructor
        /// </summary>
        static DbContextFactory()
        {
            dbContextQueue = new ConcurrentQueue<PgDbContext>();
        }

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
        public static bool Enqueue(PgDbContext dbContext)
        {
            lock (enqueueLock)
            {
                if (dbContextQueue.Count < MaxConnections)
                {
                    dbContextQueue.Enqueue(dbContext);
                    Debug.WriteLine($"[DbContextFactory] Enqueue succeed, current stored connections: {dbContextQueue.Count}");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"[DbContextFactory] Enqueue failed, current stored connections: {dbContextQueue.Count}");

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
        public static PgDbContext Dequeue(string dbName)
        {
            if (string.IsNullOrEmpty(dbName))
            {
                throw new ArgumentNullException("dbName");
            }

            if (ConnectionStrings == null || !ConnectionStrings.ContainsKey(dbName))
            {
                // Warning log
                //Debug.WriteLine($"{dbName} does not have the connection string in {nameof(DbContextFactory)}");
                return null;
            }

            if (dbContextQueue.TryDequeue(out PgDbContext output))
            {
                Debug.WriteLine($"[DbContextFactory] Dequeue succeed, current stored connections: {dbContextQueue.Count}");
                return output;
            }
            else
            {
                Debug.WriteLine($"[DbContextFactory] Dequeue failed, current stored connections: {dbContextQueue.Count}");

                // Create new DB context
                var connStr = ConnectionStrings[dbName];
                var optionsBuilder = new DbContextOptionsBuilder<PgDbContext>();
                optionsBuilder.UseNpgsql(connStr);
                var newDbContext = new PgDbContext(optionsBuilder.Options);
                // newDbContext.ChangeTracker.AutoDetectChangesEnabled = false; // Optional

                return newDbContext;
            }
        }
    }
}
