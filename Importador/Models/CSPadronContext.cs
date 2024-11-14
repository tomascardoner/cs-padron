﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CS_Padron_Importador.Models;

public partial class CSPadronContext : DbContext
{
    public CSPadronContext(DbContextOptions<CSPadronContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Circuito> Circuito { get; set; }

    public virtual DbSet<Distrito> Distrito { get; set; }

    public virtual DbSet<DocumentoTipo> DocumentoTipo { get; set; }

    public virtual DbSet<NacionalidadTipo> NacionalidadTipo { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Seccion> Seccion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Circuito>(entity =>
        {
            entity.HasKey(e => new { e.IdDistrito, e.IdSeccion, e.IdCircuito });

            entity.HasIndex(e => new { e.IdDistrito, e.IdSeccion, e.Nombre }, "AK_Circuito_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Seccion).WithMany(p => p.Circuito)
                .HasForeignKey(d => new { d.IdDistrito, d.IdSeccion })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Circuito_Seccion");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDistrito);

            entity.HasIndex(e => e.Nombre, "AK_Distrito_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DocumentoTipo>(entity =>
        {
            entity.HasKey(e => e.IdDocumentoTipo);

            entity.HasIndex(e => e.Nombre, "AK_DocumentoTipo_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NacionalidadTipo>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidadTipo);

            entity.HasIndex(e => e.Nombre, "AK_NacionalidadTipo_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.Property(e => e.IdPersona).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Domicilio)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Localidad)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDocumentoTipoNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.IdDocumentoTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_DocumentoTipo");

            entity.HasOne(d => d.IdNacionalidadTipoNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.IdNacionalidadTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_NacionalidadTipo");

            entity.HasOne(d => d.Circuito).WithMany(p => p.Persona)
                .HasForeignKey(d => new { d.IdDistrito, d.IdSeccion, d.IdCircuito })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Circuito");
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => new { e.IdDistrito, e.IdSeccion });

            entity.HasIndex(e => new { e.IdDistrito, e.Nombre }, "AK_Seccion_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Seccion)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seccion_Distrito");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}