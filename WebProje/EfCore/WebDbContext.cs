using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.EfCore;

public class WebDbContext : IdentityDbContext<AppUser , AppRole, Guid>
{
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Urun> Uruns { get; set; }
    
    public DbSet<Kategori> Kategoriler { get; set; }

    public WebDbContext(DbContextOptions options) : base(options)
    {
    }
}