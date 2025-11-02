using System;

namespace LibraryCatalogSystem
{
    /// Represents a book in the library catalog
    public class Book
    {
        // Properties
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        // Constructor
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true; // Books are available by default
        }

        /// Display book information
        public void DisplayInfo()
        {
            string status = IsAvailable ? "Available" : "Checked Out";
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Status: {status}");
            Console.WriteLine("-------------------");
        }

        /// Borrow this book
        /// True if successful, false if already checked out
        public bool BorrowBook()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                return true;
            }
            return false;
        }

        /// Return this book
        /// True if successful, false if already available
        public bool ReturnBook()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                return true;
            }
            return false;
        }
    }
}