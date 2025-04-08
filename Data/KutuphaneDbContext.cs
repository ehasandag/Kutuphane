using Microsoft.EntityFrameworkCore;
using Kutuphane.Models;

namespace Kutuphane.Data
{
    public class KutuphaneDbContext : DbContext
    {
        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sinif>()
            .HasData(
                new Sinif{ Id = 1 , SinifAdi = "9-A"},
                new Sinif{ Id = 5 , SinifAdi = "9-B"},
                new Sinif{ Id = 2 , SinifAdi = "10-A"},
                new Sinif{ Id = 3 , SinifAdi = "11-A"},
                new Sinif{ Id = 4 , SinifAdi = "12-A"}
            );
            base.OnModelCreating(modelBuilder);
        }
    }

}