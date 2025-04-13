using System;
using System.Collections.Generic;
using System.IO;

namespace Bookrental
{
    public class BookSaver
    {
        public string FilePath { get; set; }

        public BookSaver(string filePath)
        {
            FilePath = filePath;
        }

        public void Save(List<Book> books)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.Id}|{book.Title}|{book.Genre}|{book.PageCount}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public RentalService Load()
        {
            RentalService service = new RentalService();

            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length >= 5)
                        {
                            string type = parts[0];
                            int id = int.Parse(parts[1]);
                            string title = parts[2];
                            string genre = parts[3];
                            int pageCount = int.Parse(parts[4]);

                            if (type == "Fiction" && parts.Length == 6)
                            {
                                string author = parts[5];
                                service.AddBook(new FictionBook(id, title, genre, pageCount, author));
                            }
                            else if (type == "NonFiction" && parts.Length == 7)
                            {
                                string subject = parts[5];
                                service.AddBook(new NonFictionBook(id, title, genre, pageCount, subject));
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }

            return service;
        }
    }
}
