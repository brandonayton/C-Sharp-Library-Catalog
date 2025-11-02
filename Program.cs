/*
 * Author: Brandon Ayton
 * Date: 10-20-2025
 * Description: A console application in C# for managing book inventory with features to
 * add books, search by title/author, borrow/return books, and 
 * save/load data to file for storage.
 * 
*/





using System;

namespace LibraryCatalogSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create library instance
            Library library = new Library();

            // Load existing data if available
            library.LoadFromFile("library_data.txt");

            Console.WriteLine("=== WELCOME TO LIBRARY CATALOG SYSTEM ===");

            // Main program loop
            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewBook(library);
                        break;
                    case "2":
                        DisplayAllBooks(library);
                        break;
                    case "3":
                        SearchBooks(library);
                        break;
                    case "4":
                        BorrowBook(library);
                        break;
                    case "5":
                        ReturnBook(library);
                        break;
                    case "6":
                        DisplayAvailableBooks(library);
                        break;
                    case "7":
                        library.SaveToFile("library_data.txt");
                        break;
                    case "8":
                        library.LoadFromFile("library_data.txt");
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Thank you for using Library Catalog System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); // Empty line for readability
            }
        }

        /// Display the main menu
        static void DisplayMenu()
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Display all books");
            Console.WriteLine("3. Search books");
            Console.WriteLine("4. Borrow a book");
            Console.WriteLine("5. Return a book");
            Console.WriteLine("6. Display available books");
            Console.WriteLine("7. Save library data to file");
            Console.WriteLine("8. Load library data from file");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
        }

        /// Add a new book to the library
        static void AddNewBook(Library library)
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            Book newBook = new Book(title, author, isbn);
            library.AddBook(newBook);
        }

        /// Display all books in the library
        static void DisplayAllBooks(Library library)
        {
            library.DisplayAllBooks();
        }

        /// Search for books by title or author
        static void SearchBooks(Library library)
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Author");
            Console.Write("Enter choice: ");
            string searchChoice = Console.ReadLine();

            Console.Write("Enter search term: ");
            string term = Console.ReadLine();

            if (searchChoice == "1")
            {
                library.SearchByTitle(term);
            }
            else if (searchChoice == "2")
            {
                library.SearchByAuthor(term);
            }
            else
            {
                Console.WriteLine("Invalid search option.");
            }
        }

        /// Borrow a book from the library
        static void BorrowBook(Library library)
        {
            Console.Write("Enter ISBN of book to borrow: ");
            string isbn = Console.ReadLine();
            library.BorrowBook(isbn);
        }

        /// Return a book to the library
        static void ReturnBook(Library library)
        {
            Console.Write("Enter ISBN of book to return: ");
            string isbn = Console.ReadLine();
            library.ReturnBook(isbn);
        }
        
        /// Display only available books
        static void DisplayAvailableBooks(Library library)
        {
            library.DisplayAvailableBooks();
        }
    }
}