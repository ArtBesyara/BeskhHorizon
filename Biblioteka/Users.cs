using Librarysystem;

namespace polz {

public class User
{
    public string Name { get; set; }

    public User(string name)
    {
        Name = name;
    }
}


public class Librarian
{
    public string Name { get; set; }

    public Librarian(string name)
    {
        Name = name;
    }

    public void RegisterUser(string userName, List<User> users) // добавление пользователя в список библиотеки
    {
        User newUser = new User(userName);
        users.Add(newUser);
        Console.WriteLine($"Пользователь '{newUser.Name}' успешно зарегистрирован.");
    }

    public void LendBook(User user, string requestedBookTitle, List<Book> books) // доступность книги
    {
        Book requestedBook = books.Find(b => b.Title.Equals(requestedBookTitle, StringComparison.OrdinalIgnoreCase));

        if (requestedBook != null && requestedBook.IsAvailable())
        {
            requestedBook.Borrow();
            Console.WriteLine($"{user.Name} взял '{requestedBook.Title}'.");
        }
        else
        {
            Console.WriteLine($"'{requestedBookTitle}' в данный момент отсутствует. Выберите другую книгу.");
            OfferAlternativeBooks(books);
        }
    }

    public void OfferAlternativeBooks(List<Book> books) // предложение альтернативных книг
    {
        Console.WriteLine("Доступные книги:");
        foreach (var book in books)
        {
            if (book.IsAvailable())
            {
                Console.WriteLine($"- {book.Title} (Автор: {book.Author})");
            }
        }
    }
}
}