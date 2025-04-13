using System;

namespace Assignment1;
class Program
{
    static void Main()
    {
        // Create a list that holds both Songs and PodcastEpisodes
        List<Audio> audioLibrary = new List<Audio>
        {
            new Song(1, "Bohemian Rhapsody", "Rock", 354, "Queen"),
            new Song(2, "Bad Guy", "Pop", 194, "Billie Eilish"),
            new PodcastEpisode(3, "AI Revolution", "Tech", 1200, "TechTalk", 7),
            new PodcastEpisode(4, "History Deep Dive", "Education", 1800, "LearnMore", 10)
        };

        // Loop over the list and display information for each audio item
        foreach (var audio in audioLibrary)
        {
            audio.DisplayInfo();
        }
    }
}
