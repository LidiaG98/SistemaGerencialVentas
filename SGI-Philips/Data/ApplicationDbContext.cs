using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SGI_Philips.Models;

namespace SGI_Philips.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mes> Mes { get; set; }
        public DbSet<CategoriaPhilips> CategoriaPhilips { get; set; }
        public DbSet<Puesto> Puesto { get; set; }     
    }
}
