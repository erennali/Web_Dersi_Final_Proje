using System.ComponentModel.DataAnnotations;

namespace WebProje.MyValidators;

public class MyDenemeValidator : ValidationAttribute

{
     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
     {
          var deger = value as string;

          if (deger is null)
          {
               return new ValidationResult("Boş bırakılamaz");
          }

          if (!deger.ToLower().StartsWith("admin"))
          {
               return new ValidationResult("kullanıcı adı böyle başlayamaz");
          }
          return ValidationResult.Success;
     }
}