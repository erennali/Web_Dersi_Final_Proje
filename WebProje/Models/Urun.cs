using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models;

public class Urun
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    
    public int KategoriId { get; set; }

    [ForeignKey("KategoriId")]
    public Kategori KategoriFk { get; set; }
}