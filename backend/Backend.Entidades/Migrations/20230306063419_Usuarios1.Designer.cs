﻿// <auto-generated />
using System;
using Backend.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Entidades.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230306063419_Usuarios1")]
    partial class Usuarios1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Entidades.ActividadesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_actividades")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actividad")
                        .IsRequired()
                        .HasColumnName("actividad")
                        .HasColumnType("VARCHAR(25)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("create_date")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdUsuario")
                        .HasColumnName("id_usuario")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("actividades","dbo");
                });

            modelBuilder.Entity("Backend.Entidades.UsuariosModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_usuario")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnName("apellido")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("Contacto")
                        .HasColumnName("contacto")
                        .HasColumnType("BIT");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnName("correo_electronico")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnName("fecha_nacimiento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("PaisResidencia")
                        .IsRequired()
                        .HasColumnName("pais_residencia")
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("Telefono")
                        .HasColumnName("telefono")
                        .HasColumnType("VARCHAR(8)");

                    b.HasKey("Id");

                    b.ToTable("usuarios","dbo");
                });

            modelBuilder.Entity("Backend.Entidades.ActividadesModel", b =>
                {
                    b.HasOne("Backend.Entidades.UsuariosModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
