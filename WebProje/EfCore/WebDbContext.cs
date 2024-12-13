using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.EfCore;

public class WebDbContext : IdentityDbContext<AppUser , AppRole, Guid>
{
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Urun> Uruns { get; set; }
    
    public DbSet<Kategori> Kategoriler { get; set; }
    
    public DbSet<Contact> Contacts { get; set; }
    
    public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
    public DbSet<Masa> Masalar { get; set; }

    public WebDbContext(DbContextOptions options) : base(options)
    {
    }
}