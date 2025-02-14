using System;
using Librarysystem;
using polz;
using Biblia;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Установка кодировки

        Library library = new Library("Анна");

        // Добавление книг в библиотеку
        library.AddBook(new Book("1984", "George Orwell", 1949, 3));
        library.AddBook(new Book("2517", "Harper Lee", 1960, 0)); // Книга недоступна
        library.AddBook(new Book("4667", "F. Scott Fitzgerald", 1925, 1));

        // Приветственное сообщение
        Console.WriteLine($"Добро пожаловать в библиотеку! Я библиотекарь {library.Librarian.Name}.");


           
        

     

        // Запрос книги
        string requestedBookTitle;
        bool bookBorrowed = false;

        while (!bookBorrowed)
        {
            Console.WriteLine("Какую книгу вы бы хотели взять?");
            requestedBookTitle = Console.ReadLine();

            // Проверка доступности книги
            Book requestedBook = library.Books.Find(b => b.Title.Equals(requestedBookTitle, StringComparison.OrdinalIgnoreCase));
            if (requestedBook != null && requestedBook.Copies > 0)
            {
                library.BorrowBook(requestedBookTitle); // Вызываем метод, который не возвращает значение
                Console.WriteLine("Книга успешно получена. Всего доброго!");
                bookBorrowed = true; // Выход из цикла, если книга успешно получена
            }
            else
            {
                Console.WriteLine("Выберите другую книгу, она недоступна.");
            }
        }
    }
}
