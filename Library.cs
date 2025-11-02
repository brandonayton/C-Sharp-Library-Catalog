using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryCatalogSystem
{
    /// Manages the library's collection of books
    public class Library
    {
        private List<Book> books;

        // Constructor
        public Library()
        {
            books = new List<Book>();
        }

        /// Add a new book to the library
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Added book: {book.Title}");
        }

        /// Search for books by title
        public void SearchByTitle(string title)
        {
            Console.WriteLine($"\nSearch results for '{title}':");
            bool found = false;

            foreach (Book book in books)
            {
                if (book.Title.ToLower().Contains(title.ToLower()))
                {
                    book.DisplayInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No books found with that title.");
            }
        }

        /// Search for books by author
        public void SearchByAuthor(string author)
        {
            Console.WriteLine($"\nSearch results for author '{author}':");
            bool found = false;

            foreach (Book book in books)
            {
                if (book.Author.ToLower().Contains(author.ToLower()))
                {
                    book.DisplayInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No books found by that author.");
            }
        }

        /// Display all books in the library
        public void DisplayAllBooks()
        {
            Console.WriteLine("\n=== ALL BOOKS IN LIBRARY ===");
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the library.");
                return;
            }

            for (int i = 0; i < books.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                books[i].DisplayInfo();
            }
        }

        /// Borrow a book by ISBN
        public void BorrowBook(string isbn)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            if (book != null)
            {
                if (book.BorrowBook())
                {
                    Console.WriteLine($"Successfully borrowed: {book.Title}");
                }
                else
                {
                    Console.WriteLine($"Sorry, '{book.Title}' is already checked out.");
                }
            }
            else
            {
                Console.WriteLine("Book not found with that ISBN.");
            }
        }

        /// Return a book by ISBN
        public void ReturnBook(string isbn)
        {
            Book book = books.Find(b => b.ISBN == isbn);
            if (book != null)
            {
                if (book.ReturnBook())
                {
                    Console.WriteLine($"Successfully returned: {book.Title}");
                }
                else
                {
                    Console.WriteLine($"'{book.Title}' was already available.");
                }
            }
            else
            {
                Console.WriteLine("Book not found with that ISBN.");
            }
        }

        /// Display available books
        public void DisplayAvailableBooks()
        {
            Console.WriteLine("\n=== AVAILABLE BOOKS ===");
            var availableBooks = books.Where(b => b.IsAvailable).ToList();

            if (availableBooks.Count == 0)
            {
                Console.WriteLine("No available books at the moment.");
                return;
            }

            foreach (var book in availableBooks)
            {
                book.DisplayInfo();
            }
        }

        // STRETCH CHALLENGE: File I/O Methods

        /// Save library data to file
        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Book book in books)
                    {
                        writer.WriteLine($"{book.Title}|{book.Author}|{book.ISBN}|{book.IsAvailable}");
                    }
                }
                Console.WriteLine($"Library data saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        /// Load library data from file
        public void LoadFromFile(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found. Starting with empty library.");
                    return;
                }

                books.Clear(); // Clear existing books

                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        Book book = new Book(parts[0], parts[1], parts[2]);
                        book.IsAvailable = bool.Parse(parts[3]);
                        books.Add(book);
                    }
                }
                Console.WriteLine($"Library data loaded from {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }
}