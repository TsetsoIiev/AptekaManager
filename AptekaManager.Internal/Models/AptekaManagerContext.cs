using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Models
{
    public partial class AptekaManagerContext : DbContext
    {
        public AptekaManagerContext()
        {
        }

        public AptekaManagerContext(DbContextOptions<AptekaManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<PharmacyProduct> PharmacyProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ////TODO: move to appSettings
               optionsBuilder.UseSqlServer("Server=DESKTOP-EV2EGE3;Database=AptekaManager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.ToTable("MeasurementUnit");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.ToTable("Pharmacy");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Pharmacies)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pharmacy_Address");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_MeasurementUnit");
            });

            modelBuilder.Entity<PharmacyProduct>(entity =>
            {
                entity.ToTable("Pharmacy_Product");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(pp => new { pp.PharmacyId, pp.ProductId });

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.PharmacyProducts)
                    .HasForeignKey(d => d.PharmacyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pharmacy_Product_Pharmacy");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PharmacyProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pharmacy_Product_Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
