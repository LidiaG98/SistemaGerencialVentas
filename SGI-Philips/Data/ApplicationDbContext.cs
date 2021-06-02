using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SGI_Philips.Models;

namespace SGI_Philips.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SGI_Philips.Models.Mes> Mes { get; set; }
        public DbSet<SGI_Philips.Models.CategoriaPhilips> CategoriaPhilips { get; set; }
        public DbSet<SGI_Philips.Models.Puesto> Puesto { get; set; }
    }
}
