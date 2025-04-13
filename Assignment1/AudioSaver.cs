namespace Assignment1;
public class AudioSaver
{
    public string FilePath { get; set; }

    public AudioSaver(string filePath)
    {
        FilePath = filePath;
    }

    public void Save(List<Audio> audios)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var audio in audios)
                {
                    writer.WriteLine($"{audio.Id}|{audio.Title}|{audio.Genre}|{audio.Duration}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

  public StreamingService Load()
{
    StreamingService service = new StreamingService();
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
                    string type = parts[0]; // "Song" or "Podcast"
                    int id = int.Parse(parts[1]);
                    string title = parts[2];
                    string genre = parts[3];
                    int duration = int.Parse(parts[4]);

                    if (type == "Song" && parts.Length == 6)
                    {
                        string artist = parts[5];
                        service.AddAudio(new Song(id, title, genre, duration, artist));
                    }
                    else if (type == "Podcast" && parts.Length == 7)
                    {
                        string podcastName = parts[5];
                        int episodeNumber = int.Parse(parts[6]);
                        service.AddAudio(new PodcastEpisode(id, title, genre, duration, podcastName, episodeNumber));
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

public class AudioNotFoundException : Exception
{
    public AudioNotFoundException(string message) : base(message) { }
}
