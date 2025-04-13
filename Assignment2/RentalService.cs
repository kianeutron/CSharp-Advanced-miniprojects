using System;

namespace Bookrental
{
    public class RentalService
    {
        private List<Book> bookLibrary;
        private Dictionary<int, bool> RentalStatus;

        public RentalService()
        {
            bookLibrary = new List<Book>();
            RentalStatus = new Dictionary<int, bool>();
        }

        public void AddBook(Book book)
        {
            bookLibrary.Add(book);
            RentalStatus[book.Id] = false;
        }

        public Book FindBookById(int id)
        {
            foreach (var book in bookLibrary)
            {
                if (book.Id == id)
                    return book;
            }
            throw new BookNotFoundException($"Book with ID {id} not found.");
        }

        public void RentBook(int id)
        {
            Book book = FindBookById(id);
            book.Rent();
            RentalStatus[id] = true;
            Console.WriteLine($"Successfully rented book: {book.Title}");
        }

        public void ReturnBook(int id)
        {
            Book book = FindBookById(id);
            book.ReturnBook();
            RentalStatus[id] = true;
        }

        public List<Book> GetBookByStatus(bool isRented)
        {
            List<Book> result = new List<Book>();
            foreach (var book in bookLibrary)
            {
                if (RentalStatus[book.Id] == isRented)
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public int DisplayReport(List<Book> books)
        {
            int DisplayReport = 0;
            foreach (var book in books)
            {
                DisplayReport += book.PageCount;
            }
            return DisplayReport;
        }

        public List<Book> GetAllBooks()
        {
            return bookLibrary;
        }
    }
}
