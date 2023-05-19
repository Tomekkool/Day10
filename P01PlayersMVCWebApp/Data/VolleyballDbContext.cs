using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01PlayersMVCWebApp.Models;

    public class VolleyballDbContext : DbContext
    {
        public VolleyballDbContext (DbContextOptions<VolleyballDbContext> options)
            : base(options)
        {
        }

        public DbSet<P01PlayersMVCWebApp.Models.VolleyballPlayer> VolleyballPlayer { get; set; } = default!;
    }
