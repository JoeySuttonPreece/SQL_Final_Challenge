using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class FinalContext : DbContext
    {
        public FinalContext()
        {
        }

        public FinalContext(DbContextOptions<FinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Interest> Interest { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNumber);

                entity.Property(e => e.CustomerNumber).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InterestCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.HasOne(d => d.InterestCodeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.InterestCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Intere__29572725");
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.HasKey(e => e.InterestCode);

                entity.Property(e => e.InterestCode)
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.RecordId)
                    .HasColumnName("RecordID")
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Performer)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.CustomerNumber, e.RecordId });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.RecordId)
                    .HasColumnName("RecordID")
                    .HasMaxLength(5);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.CustomerNumberNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CustomerNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sale__CustomerNu__2A4B4B5E");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sale__RecordID__2B3F6F97");
            });
        }
    }
}
