using Microsoft.VisualBasic;
using System.Text;
namespace Library.Entities;

public class Books : EntityBase
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genere { get; set; }
    public string? Publisher { get; set; }
    public int? Year { get; set; }
    public string? ISBN { get; set; }
    public bool? IsAvailable { get; set; }
    public DateTime? DateOfBorrow { get; set; }
    public decimal? BuyPrice { get; set; }
    public decimal? SellPrice { get; set; }


    public int? NameLengh { get; set; }
    public decimal? SoldPrice { get; set; }
    //public Books()
    //{

    //}
    //public Books(string title)
    //{

    //}
    //public Books(string title, string author)
    //{

    //}
    #region ToString Override
    public override string ToString()
    {
        StringBuilder sb = new(1024);
        sb.AppendLine($"ID: {Id}");
        sb.AppendLine($"Title: {Title} Author: {Author} Genere: {(Genere ?? "n/a")}");
        sb.AppendLine($"Publisher: {Publisher}");
        sb.AppendLine($"Year: {Year.ToString()}");
        sb.AppendLine($"ISBN: {ISBN.ToString()}");
        sb.AppendLine($"IsAvailable: {IsAvailable.ToString()}");
        sb.AppendLine($"Borowed: {DateOfBorrow.ToString()}");
        sb.AppendLine($"Buy Price: {BuyPrice.ToString()}");
        sb.AppendLine($"SellPrice: {SellPrice.ToString()}");
        sb.AppendLine($"Sold Price: {SoldPrice.ToString()}");
        if (NameLengh.HasValue)
        {
            sb.AppendLine($"Name Lengh: {NameLengh}");
        }
        if (SoldPrice.HasValue)
        {
            sb.AppendLine($"Price: {SoldPrice}");
        }
        return sb.ToString();
    }
    #endregion
}


//{
//    sb.AppendLine($"ID: {Id}");
//    if (Title != null)
//    {
//        sb.AppendLine($"Title: {Title}");
//    }
//    if (Author != null)
//    {
//        sb.AppendLine($"Author: {Author}");
//    }
//    if (Genere != null)
//    {
//        sb.AppendLine($"Genere: {Genere}");
//    }
//    if (Publisher != null)
//    {
//        sb.AppendLine($"Publisher:{Publisher}");
//    }
//    if (Year != null)
//    {
//        sb.AppendLine($"Year: {Year}");
//    }
//    if (ISBN != null)
//    {
//        sb.AppendLine($"ISBN: {ISBN}");
//    }
//    if (IsAvailable != null)
//    {
//        sb.AppendLine($"IsAvailable: {IsAvailable}");
//    }
//    return sb.ToString();
//}