using System.ComponentModel.DataAnnotations;

namespace WebProje.Models;

public class Contact
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Ad alanı gereklidir")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Karakter sayısı Hatalı")]
    public string Name { get; set; }
    
    [EmailAddress]
    [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Telefon boş bırakılamaz!")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Karakter sayısı Hatalı")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Konu gereklidir")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Karakter sayısı Hatalı")]
    public string Subject { get; set; }
    
    [Required(ErrorMessage = "Mesaj gereklidir")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Karakter sayısı Hatalı")]
    public string Message { get; set; }

    public DateTime dateTime { get; set; }

    public bool Durum { get; set; } 
}