namespace WebProje.Models;

public class Rezervasyon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
    public bool Durum { get; set; }
}