using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinLensAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLensAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

    }
}