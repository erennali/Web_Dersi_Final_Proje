using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models;


    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [StringLength(20, MinimumLength = 2 , ErrorMessage = "Karakter sayısı hatalı")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30 , ErrorMessage = "30 karakterden büyük olamaz")]
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }

    }
