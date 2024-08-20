using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace manage.Database;

public partial class WeltecdatabaseContext : DbContext
{
    public WeltecdatabaseContext()
    {
    }

    public WeltecdatabaseContext(DbContextOptions<WeltecdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CourseWeltac> CourseWeltacs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VISAL\\MSSQLSERVER02;Database=weltecdatabase;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseWeltac>(entity =>
        {
            entity.ToTable("Course_weltac");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
