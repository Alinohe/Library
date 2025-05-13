namespace Library.Data.Entities;

public class Book : EntityBase
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genere { get; set; }
    public string? Volume { get; set; }
    public string? Publisher { get; set; }
    public int? Year { get; set; }
    public string? ISBN { get; set; }
    public bool? IsAvailable { get; set; }
    public DateTime? DateOfBorrow { get; set; }
    public decimal? BuyPrice { get; set; }
    public decimal? SellPrice { get; set; }

    public int? NameLengh { get; set; }
    public decimal? SoldPrice { get; set; }
}
