namespace WebProje.Models;

public class Basket
{
    public int Id { get; set; }
    public Guid MasaId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
   
    public bool Status { get; set; }
    public Masa Masa { get; set; }
    public bool IsCouponApplied { get; set; }
}