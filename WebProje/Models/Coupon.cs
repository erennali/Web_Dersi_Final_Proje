namespace WebProje.Models;

public class Coupon
{
    public int Id { get; set; }
    public string CouponCode { get; set; }
    public decimal Discount { get; set; } // %20 indirim gibi
}