using System.ComponentModel.DataAnnotations;

namespace WebProje.Models;

public class Kullanici
{
    public int KullaniciId { get; set; }
    
    [Required(ErrorMessage = "Ad boş bırakılamaz")]
    [StringLength(20, MinimumLength = 2 , ErrorMessage = "Karakter sayısı hatalı")]
    public string KullaniciAd { get; set; }
    
    [Required(ErrorMessage = "Soyad boş bırakılamaz")]
    [StringLength(20)]
    public string KullaniciSoyad { get; set; }
    [Required(ErrorMessage = "Şifre boş bırakılamaz")]
    [DataType(DataType.Password)]
    [StringLength(30,MinimumLength = 6 , ErrorMessage = "6-30 karakter arası olmalıdır!")]
    public string Sifre { get; set; }
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email boş bırakılamaz")]
    public string Email { get; set; }
    
    
}