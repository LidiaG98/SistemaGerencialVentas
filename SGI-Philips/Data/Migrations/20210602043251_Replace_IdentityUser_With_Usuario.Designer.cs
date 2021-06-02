﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGI_Philips.Data;

namespace SGI_Philips.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210602043251_Replace_IdentityUser_With_Usuario")]
    partial class Replace_IdentityUser_With_Usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SGI_Philips.Models.CategoriaPhilips", b =>
                {
                    b.Property<int>("categoriaPhilipsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoriaPhilipsID");

                    b.ToTable("CategoriaPhilips");
                });

            modelBuilder.Entity("SGI_Philips.Models.Consolidado", b =>
                {
                    b.Property<int>("consolidadoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("anioConsolidado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mesID")
                        .HasColumnType("int");

                    b.Property<int>("productoID")
                        .HasColumnType("int");

                    b.Property<int>("ventasConsolidado")
                        .HasColumnType("int");

                    b.HasKey("consolidadoID");

                    b.HasIndex("mesID");

                    b.HasIndex("productoID");

                    b.ToTable("Consolidado");
                });

            modelBuilder.Entity("SGI_Philips.Models.Mes", b =>
                {
                    b.Property<int>("mesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreMes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("mesID");

                    b.ToTable("Mes");
                });

            modelBuilder.Entity("SGI_Philips.Models.Producto", b =>
                {
                    b.Property<int>("productoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("backOrder")
                        .HasColumnType("int");

                    b.Property<string>("codigoProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("costoP")
                        .HasColumnType("real");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rotacionID")
                        .HasColumnType("int");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("productoID");

                    b.HasIndex("rotacionID");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("SGI_Philips.Models.ProductoPhilips", b =>
                {
                    b.Property<int>("productoPhilipsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoriaPhilipsID")
                        .HasColumnType("int");

                    b.Property<string>("codigoPhillips")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcionPhillips")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<int>("productoID")
                        .HasColumnType("int");

                    b.HasKey("productoPhilipsID");

                    b.HasIndex("categoriaPhilipsID");

                    b.HasIndex("productoID")
                        .IsUnique();

                    b.ToTable("ProductoPhilips");
                });

            modelBuilder.Entity("SGI_Philips.Models.Proyeccion", b =>
                {
                    b.Property<int>("proyeccionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("anioProyeccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mesID")
                        .HasColumnType("int");

                    b.Property<int>("productoID")
                        .HasColumnType("int");

                    b.Property<int>("ventasProyeccion")
                        .HasColumnType("int");

                    b.HasKey("proyeccionID");

                    b.HasIndex("mesID");

                    b.HasIndex("productoID");

                    b.ToTable("Proyeccion");
                });

            modelBuilder.Entity("SGI_Philips.Models.Puesto", b =>
                {
                    b.Property<int>("puestoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombrePuesto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("puestoID");

                    b.ToTable("Puesto");
                });

            modelBuilder.Entity("SGI_Philips.Models.Rotacion", b =>
                {
                    b.Property<int>("rotacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("mesesInv")
                        .HasColumnType("real");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalrotacionID")
                        .HasColumnType("int");

                    b.HasKey("rotacionID");

                    b.HasIndex("totalrotacionID")
                        .IsUnique();

                    b.ToTable("Rotacion");
                });

            modelBuilder.Entity("SGI_Philips.Models.TotalRotacion", b =>
                {
                    b.Property<int>("totalRotacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("backOrderTotal")
                        .HasColumnType("float");

                    b.Property<double>("invCosto")
                        .HasColumnType("float");

                    b.Property<double>("invVenta")
                        .HasColumnType("float");

                    b.Property<double>("pedidoCompra")
                        .HasColumnType("float");

                    b.HasKey("totalRotacionID");

                    b.ToTable("TotalRotacion");
                });

            modelBuilder.Entity("SGI_Philips.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dui")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPuesto")
                        .HasColumnType("int");

                    b.Property<string>("nit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("puestoID")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("puestoID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SGI_Philips.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SGI_Philips.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGI_Philips.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SGI_Philips.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGI_Philips.Models.Consolidado", b =>
                {
                    b.HasOne("SGI_Philips.Models.Mes", "Mes")
                        .WithMany("Consolidados")
                        .HasForeignKey("mesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGI_Philips.Models.Producto", "Producto")
                        .WithMany("Consolidados")
                        .HasForeignKey("productoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGI_Philips.Models.Producto", b =>
                {
                    b.HasOne("SGI_Philips.Models.Rotacion", "rotacion")
                        .WithMany()
                        .HasForeignKey("rotacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGI_Philips.Models.ProductoPhilips", b =>
                {
                    b.HasOne("SGI_Philips.Models.CategoriaPhilips", "CategoriaPhilips")
                        .WithMany("ProductoPhilips")
                        .HasForeignKey("categoriaPhilipsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGI_Philips.Models.Producto", "Producto")
                        .WithOne("ProductoPhilips")
                        .HasForeignKey("SGI_Philips.Models.ProductoPhilips", "productoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGI_Philips.Models.Proyeccion", b =>
                {
                    b.HasOne("SGI_Philips.Models.Mes", "Mes")
                        .WithMany("Proyeccions")
                        .HasForeignKey("mesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGI_Philips.Models.Producto", "Producto")
                        .WithMany("Proyeccions")
                        .HasForeignKey("productoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGI_Philips.Models.Rotacion", b =>
                {
                    b.HasOne("SGI_Philips.Models.TotalRotacion", "totalRotacion")
                        .WithOne("rotacion")
                        .HasForeignKey("SGI_Philips.Models.Rotacion", "totalrotacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGI_Philips.Models.Usuario", b =>
                {
                    b.HasOne("SGI_Philips.Models.Puesto", "puesto")
                        .WithMany("usuario")
                        .HasForeignKey("puestoID");
                });
#pragma warning restore 612, 618
        }
    }
}
