using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Information.Repository.Interfaces;
using Information.Repository.Entity;

namespace Information.Context
{
    public class DataContext:DbContext,IContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }     
        public DbSet<Informations> Informations { get; set ; }
        public DbSet<Chaild> Chaildren { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InformationDB;Trusted_Connection=True;");
        public async Task<int> SaveChangesAsync()
        {
            int id = await base.SaveChangesAsync();
            return id;
        }
        
    }
}
