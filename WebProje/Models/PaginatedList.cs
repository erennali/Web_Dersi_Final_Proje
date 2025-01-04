namespace WebProje.Models;

public class PaginatedList<T>
{
    public List<T> Items { get; set; }
    public int PageNumber { get; set; } //sayfa numaarası
    public int TotalPages { get; set; } //toplam sayfa sayısı
    public int TotalItems { get; set; } //item sayısı
    public bool HasPreviousPage => PageNumber > 1; //öncesinde sayfa var mı yok mu
    public bool HasNextPage => PageNumber < TotalPages; //sonrasında sayfa var mı yok mu

    //constr
    public PaginatedList(List<T> items, int totalItems, int pageNumber, int pageSize)
    {
        Items = items;
        PageNumber = pageNumber;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}