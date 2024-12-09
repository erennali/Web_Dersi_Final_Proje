using Microsoft.AspNetCore.Identity;

namespace WebProje.Models;

public class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
}