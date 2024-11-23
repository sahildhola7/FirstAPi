using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class NZwalkdbcontext : DbContext
    { 
        public NZwalkdbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
        
    }
}