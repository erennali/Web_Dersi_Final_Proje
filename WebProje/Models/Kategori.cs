using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models;

public class Kategori
{
    public int Id { get; set; }
    public string Ad { get; set; }
}