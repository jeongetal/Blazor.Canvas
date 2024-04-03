using Blazor.Canvas.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Canvas.Model
{
    internal class MyDbContext : DbContext
        {
        static MyDbContext()
        {
            using (var database = new MyDbContext())
            {
                database.Database.Migrate();
            }
        }
        internal DbSet<Model> _Model { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}