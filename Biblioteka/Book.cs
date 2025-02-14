
namespace Librarysystem
{
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Copies { get; set; }

    public Book(string title, string author, int year, int copies)
    {
        Title = title;
        Author = author;
        Year = year;
        Copies = copies;
    }

    public bool IsAvailable() => Copies > 0;

    public void Borrow()
    {
        if (IsAvailable())
        {
            Copies--;
        }
    }
}
}