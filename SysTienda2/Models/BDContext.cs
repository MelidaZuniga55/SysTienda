using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class BDContext : DbContext
{
    public BDContext()
    {
    }

    public BDContext(DbContextOptions<BDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=BDTienda202.mssql.somee.com;packet size=4096;user id=meli_tepas_SQLLogin_1;pwd=myyn8xzlpy;data source=BDTienda202.mssql.somee.com;persist security info=False;initial catalog=BDTienda202;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.Property(e => e.IdDetalleFactura).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdDetalleFacturaNavigation).WithOne(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura1");

            entity.HasOne(d => d.Servicio).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Servicio1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.Property(e => e.IdFactura).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdFacturaNavigation).WithOne(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
