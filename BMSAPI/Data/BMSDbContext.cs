using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMSAPI.Model.Domains;
using Microsoft.EntityFrameworkCore;

namespace BMSAPI.Data
{
    
    public class BMSDbContext: DbContext
    {
        public BMSDbContext(DbContextOptions<BMSDbContext> options):base(options)
        {
           
        }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
    }
}
