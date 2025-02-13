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
    public Books()
    {

    }
    public Books(string title)
    {

    }
    public Books(string title, string author)
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new();
        {
            sb.AppendLine($"ID: {Id}");
            if (Title != null)
            {
                sb.AppendLine($"Title: {Title}");
            }
            if (Author != null)
            {
                sb.AppendLine($"Author: {Author}");
            }
            if (Genere != null)
            {
                sb.AppendLine($"Genere: {Genere}");
            }
            if (Publisher != null)
            {
                sb.AppendLine($"Publisher:{Publisher}");
            }
            if (Year != null)
            {
                sb.AppendLine($"Year: {Year}");
            }
            if (ISBN != null)
            {
                sb.AppendLine($"ISBN: {ISBN}");
            }
            if (IsAvailable != null)
            {
                sb.AppendLine($"IsAvailable: {IsAvailable}");
            }
            return sb.ToString();

        }
    }

    //public override string ToString() => $"ID: {Id}, Title: {Title}, Author: {Author}, Genre: {Genre}, Publisher: {Publisher}," +
    //    $" Year: {Year}, Pages: {Pages}, Language: {Language}, ISBN: {ISBN}, Format: {Format}, Description: {Description}," +
    //    $" Image: {Image};Available: {IsAvailable}";
}
