﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TiendaServicios.Api.CarritoCompra.Context;

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    [DbContext(typeof(ContextoCarrito))]
    [Migration("20211006223945_Migracion")]
    partial class Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Entities.CarritoSesion", b =>
                {
                    b.Property<int>("CarritoSesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CarritoSesionGuid")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CarritoSesionId");

                    b.ToTable("CarritoSesion");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Entities.CarritoSesionDetalle", b =>
                {
                    b.Property<int>("CarritoSesionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CarritoSesionDetalleGuid")
                        .HasColumnType("text");

                    b.Property<int?>("CarritoSesionId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductoSelecionado")
                        .HasColumnType("text");

                    b.HasKey("CarritoSesionDetalleId");

                    b.HasIndex("CarritoSesionId");

                    b.ToTable("CarritoSesionDetalle");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Entities.CarritoSesionDetalle", b =>
                {
                    b.HasOne("TiendaServicios.Api.CarritoCompra.Entities.CarritoSesion", "CarritoSesion")
                        .WithMany("ListaCarritoSesionDetalle")
                        .HasForeignKey("CarritoSesionId");
                });
#pragma warning restore 612, 618
        }
    }
}
