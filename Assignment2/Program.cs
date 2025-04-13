using System;
using System.Collections.Generic;

namespace Bookrental
{
    class Program
    {
        static void Main()
        {
            RentalService rentalService = new RentalService();

            rentalService.AddBook(new FictionBook(1, "Bohemian Rhapsody", "Rock", 354, "Queen"));
            rentalService.AddBook(new FictionBook(2, "Bad Guy", "Pop", 194, "Billie Eilish"));
            rentalService.AddBook(new NonFictionBook(3, "AI Revolution", "Tech", 1200, "TechTalk"));
            rentalService.AddBook(new NonFictionBook(4, "History Deep Dive", "Education", 1800, "LearnMore"));

            rentalService.RentBook(1);
            rentalService.RentBook(3);

            Console.WriteLine("Available Books in Library:");
            foreach (var book in rentalService.GetAllBooks())
            {
                book.DisplayInfo();
            }
            Console.WriteLine("Total Pages of All Books: " + rentalService.DisplayReport(rentalService.GetAllBooks()));

            BookSaver bookSaver = new BookSaver("books.txt");
            List<Book> books = rentalService.GetAllBooks();
            bookSaver.Save(books);

            RentalService loadedRentalService = bookSaver.Load();
        }
    }
}
