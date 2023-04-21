using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleEFConsole.Models;

public partial class Kanini23Context : DbContext
{
    public Kanini23Context()
    {
    }

    public Kanini23Context(DbContextOptions<Kanini23Context> options)
        : base(options)
    {
    }

   

    public virtual DbSet<Customer> Customers { get; set; }

   
   

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=LAPTOP-BQF0DTHQ\\SQLEXPRESS;initial catalog=kanini23;trusted_connection=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("PK_CID");

            entity.ToTable("Customer");

            entity.Property(e => e.Custid)
                .ValueGeneratedNever()
                .HasColumnName("custid");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Mumbai')")
                .HasColumnName("city");
            entity.Property(e => e.Custname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("custname");
        });

      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
