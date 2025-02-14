using System;
using System.Collections.Generic;

using Librarysystem;
using polz;
namespace Biblia {


public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<User> Users { get; set; } = new List<User>();
        public Librarian Librarian { get; set; }

        public Library(string librarianName)
        {
            Librarian = new Librarian(librarianName);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public Book FindBook(string title)
        {
            return Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void BorrowBook(string bookTitle)
        {
            Console.WriteLine("Введите ваше имя:");
            string userName = Console.ReadLine();

            User user = Users.Find(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                Librarian.RegisterUser(userName, Users);
                user = Users[Users.Count - 1]; // Получаем только что зарегистрированного пользователя
            }

            Book book = FindBook(bookTitle);
            if (book != null)
            {
                Librarian.LendBook(user, book.Title, Books); // Передаем название книги и список книг
            }
            else
            {
                Console.WriteLine($"Книги '{bookTitle}' не найдено в библиотеке.");
                Librarian.OfferAlternativeBooks(Books); // Предлагаем альтернативные книги
            }
        }
    }
}
