using System;

namespace Bookrental
{
    public class FictionBook : Book
    {
        public string Author { get; set; }

        public FictionBook(int id, string title, string genre, int pageCount, string author) 
            : base(id, title, genre, pageCount)
        {
            Author = author;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Fiction] Title: {Title}, Genre: {Genre}, PageCount: {PageCount} pages, Author: {Author}, ID: {Id}");
        }
    }
}
