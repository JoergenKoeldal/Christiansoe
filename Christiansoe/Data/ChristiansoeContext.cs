using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Christiansoe.Models;

namespace Christiansoe.Data
{
    public class ChristiansoeContext : DbContext
    {
        public ChristiansoeContext (DbContextOptions<ChristiansoeContext> options)
          
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=joergenkea.database.windows.net;Initial Catalog=Christiansoe;Persist Security Info=True;User ID=joergen;Password=Kea12345");
        }

        public DbSet<Route> Route { get; set; }

        public DbSet<Map> Map { get; set; }

        public DbSet<Field> Field { get; set; }

        public DbSet<BingoBoard> BingoBoard { get; set; }
    }



}
