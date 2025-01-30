namespace Library.Entities;

public class Books : EntityBase
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public string? Publisher { get; set; }
    public int? Year { get; set; }
    public int? Pages { get; set; }
    public string? Language { get; set; }
    public string? ISBN { get; set; }
    public string? Format { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public bool? IsAvailable { get; set; }

    public Books()
    {

    }
    public Books(string title)
    {

    }
    public Books(string title, string author)
    {

    }

    public override string ToString() => $"ID: {Id}, Title: {Title}, Author: {Author}, Genre: {Genre}, Publisher: {Publisher}," +
        $" Year: {Year}, Pages: {Pages}, Language: {Language}, ISBN: {ISBN}, Format: {Format}, Description: {Description}," +
        $" Image: {Image};Available: {IsAvailable}";
}
