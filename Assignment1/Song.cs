using System;

namespace Assignment1;

public class Song : Audio
{
    public string Artist { get; }
    public Song(int id, string title, string genre, int duration, string artist)
        : base(id, title, genre, duration)  // Call the base class constructor
        {
            Artist = artist;
        }
        public override void DisplayInfo()
    {
        Console.WriteLine($"[Song] Title: {Title}, Genre: {Genre}, Duration: {Duration} secs, Artist: {Artist}, ID: {Id}");
    }
}
