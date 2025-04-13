using System;

namespace Assignment1;

public abstract class Audio : IStreamable
{
     public int Id { get; }
    public string Title { get; }
    public string Genre { get; }
    public int Duration { get; }

    public Audio(int id, string title, string genre, int duration) {
        Id = id;
        Title = title;
        Genre = genre;
        Duration = duration;
}
public abstract void DisplayInfo();
public void StartStream(){
Console.WriteLine($"Starting to stream: '{Title}'.");
}
public void EndStream(){
Console.WriteLine($"Finished streaming: '{Title}'.");
}
}
