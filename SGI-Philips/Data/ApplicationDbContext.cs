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
        public DbSet<SGI_Philips.Models.TotalRotacion> TotalRotacion { get; set; }
        public DbSet<SGI_Philips.Models.Rotacion> Rotacion { get; set; }
        public DbSet<SGI_Philips.Models.Proyeccion> Proyeccion { get; set; }
        public DbSet<SGI_Philips.Models.ProductoPhilips> ProductoPhilips { get; set; }
        public DbSet<SGI_Philips.Models.Consolidado> Consolidado { get; set; }
        public DbSet<SGI_Philips.Models.HistorialDeActividad> HistorialDeActividad { get; set; }
        public DbSet<SGI_Philips.Models.Producto> Producto { get; set; }
    }
}
