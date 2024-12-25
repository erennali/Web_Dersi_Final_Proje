using System.ComponentModel.DataAnnotations;

namespace WebProje.Models;

public class Rezervasyon
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Ad Soyad gereklidir")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Karakter sayısı Hatalı")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Telefon gereklidir")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Karakter sayısı Hatalı")]
    public string Phone { get; set; }
    [EmailAddress]
    [Required(ErrorMessage = "Mail gereklidir")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Karakter sayısı Hatalı")]
    public string Mail { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
    public bool Durum { get; set; }
}