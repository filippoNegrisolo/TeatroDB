using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeatroDB.Models;

namespace TeatroDB.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acquisto> Acquistos { get; set; }

    public virtual DbSet<Edizionespettacolo> Edizionespettacolos { get; set; }

    public virtual DbSet<Posto> Postos { get; set; }

    public virtual DbSet<Spettacolo> Spettacolos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Acquisto>(entity =>
        {
            entity.HasKey(e => e.IdAcquisto).HasName("PRIMARY");

            entity.ToTable("acquisto");

            entity.HasIndex(e => new { e.FkEdizioneSpettacoloA1, e.FkEdizioneSpettacoloA2 }, "fk_Acquisto_EdizioneSpettacolo1_idx");

            entity.HasIndex(e => e.FkUtente, "fk_Acquisto_Utente_idx");

            entity.Property(e => e.IdAcquisto)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Cvc).HasMaxLength(45);
            entity.Property(e => e.FkEdizioneSpettacoloA1).HasColumnType("datetime");
            entity.Property(e => e.FkEdizioneSpettacoloA2).HasColumnType("int(11)");
            entity.Property(e => e.FkUtente).HasColumnType("int(11)");
            entity.Property(e => e.NumeroCarta).HasColumnType("int(11)");

            entity.HasOne(d => d.FkUtenteNavigation).WithMany(p => p.Acquistos)
                .HasForeignKey(d => d.FkUtente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Acquisto_Utente");

            entity.HasOne(d => d.FkEdizioneSpettacoloA).WithMany(p => p.Acquistos)
                .HasForeignKey(d => new { d.FkEdizioneSpettacoloA1, d.FkEdizioneSpettacoloA2 })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Acquisto_EdizioneSpettacolo1");
        });

        modelBuilder.Entity<Edizionespettacolo>(entity =>
        {
            entity.HasKey(e => new { e.DataOra, e.FkSpettacolo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("edizionespettacolo");

            entity.HasIndex(e => e.FkSpettacolo, "fk_EdizioneSpettacolo_Spettacolo1_idx");

            entity.Property(e => e.DataOra).HasColumnType("datetime");
            entity.Property(e => e.FkSpettacolo).HasColumnType("int(11)");

            entity.HasOne(d => d.FkSpettacoloNavigation).WithMany(p => p.Edizionespettacolos)
                .HasForeignKey(d => d.FkSpettacolo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EdizioneSpettacolo_Spettacolo1");
        });

        modelBuilder.Entity<Posto>(entity =>
        {
            entity.HasKey(e => new { e.NumeroPoltrona, e.Settore, e.Fila, e.FkEdizioneSpettacoloP1, e.FkEdizioneSpettacoloP2 })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

            entity.ToTable("posto");

            entity.HasIndex(e => e.FkAcquisto, "fk_Posto_Acquisto1_idx");

            entity.HasIndex(e => new { e.FkEdizioneSpettacoloP1, e.FkEdizioneSpettacoloP2 }, "fk_Posto_EdizioneSpettacolo1_idx");

            entity.Property(e => e.NumeroPoltrona).HasColumnType("int(11)");
            entity.Property(e => e.Settore).HasColumnType("enum('platea','galleria')");
            entity.Property(e => e.Fila).HasColumnType("int(11)");
            entity.Property(e => e.FkEdizioneSpettacoloP1).HasColumnType("datetime");
            entity.Property(e => e.FkEdizioneSpettacoloP2).HasColumnType("int(11)");
            entity.Property(e => e.FkAcquisto).HasColumnType("int(11)");
            entity.Property(e => e.Prezzo).HasPrecision(4, 2);

            entity.HasOne(d => d.FkAcquistoNavigation).WithMany(p => p.Postos)
                .HasForeignKey(d => d.FkAcquisto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Posto_Acquisto1");

            entity.HasOne(d => d.FkEdizioneSpettacoloP).WithMany(p => p.Postos)
                .HasForeignKey(d => new { d.FkEdizioneSpettacoloP1, d.FkEdizioneSpettacoloP2 })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Posto_EdizioneSpettacolo1");
        });

        modelBuilder.Entity<Spettacolo>(entity =>
        {
            entity.HasKey(e => e.IdSpettacolo).HasName("PRIMARY");

            entity.ToTable("spettacolo");

            entity.Property(e => e.IdSpettacolo).HasColumnType("int(11)");
            entity.Property(e => e.Descrizione).HasMaxLength(45);
            entity.Property(e => e.Durata).HasMaxLength(45);
            entity.Property(e => e.Foto).HasMaxLength(45);
            entity.Property(e => e.Maggiorazione).HasMaxLength(45);
            entity.Property(e => e.PrezzoBase).HasMaxLength(45);
            entity.Property(e => e.Titolo).HasMaxLength(45);
            entity.Property(e => e.Video).HasMaxLength(45);
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.CodiceFiscale).HasName("PRIMARY");

            entity.ToTable("utente");

            entity.Property(e => e.CodiceFiscale)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Cap).HasColumnType("int(11)");
            entity.Property(e => e.Citta).HasMaxLength(45);
            entity.Property(e => e.Cognome).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Via).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
