using System;

namespace Assignment1;

public class PodcastEpisode : Audio
{
    public string PodcastName { get; }
    public int EpisodeNumber { get; }
     public PodcastEpisode(int id, string title, string genre, int duration, string podcastName, int episodeNumber)
        : base(id, title, genre, duration)  // Call the base class constructor
        {
            PodcastName = podcastName;
            EpisodeNumber = episodeNumber;
        }
          public override void DisplayInfo()
    {
        Console.WriteLine($"[Song] Title: {Title}, Genre: {Genre}, Duration: {Duration} secs, Podcast: {PodcastName}, Episode: {EpisodeNumber}, ID: {Id}");
    }
}
