using System;

namespace Bookrental
{
    public class NonFictionBook : Book
    {
        public string Subject { get; }

        public NonFictionBook(int id, string title, string genre, int pageCount, string subject) 
            : base(id, title, genre, pageCount)
        {
            Subject = subject;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Fiction] Title: {Title}, Genre: {Genre}, PageCount: {PageCount} pages, Subject: {Subject}, ID: {Id}");
        }
    }
}
