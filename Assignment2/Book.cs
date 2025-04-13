using System;

namespace Bookrental
{
    public abstract class Book : IRentable
    {
        public int Id { get; }
        public string Title { get; }
        public string Genre { get; }
        public int PageCount { get; }

        public Book(int id, string title, string genre, int pageCount)
        {
            Id = id;
            Title = title;
            Genre = genre;
            PageCount = pageCount;
        }

        public abstract void DisplayInfo();

        public void Rent()
        {
            Console.WriteLine($"Rent book: '{Title}'.");
        }

        public void ReturnBook()
        {
            Console.WriteLine($"Return book: '{Title}'.");
        }
    }
}
