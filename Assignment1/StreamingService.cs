using System;

namespace Assignment1;

public class StreamingService
{
       // Private fields
    private List<Audio> Library;  // Holds Song or PodcastEpisode objects
    private Dictionary<int, bool> ListenStatus;  // Tracks if an audio item has been listened to
     // Constructor
    public StreamingService()
    {
        Library = new List<Audio>();  // Initialize the Library list
        ListenStatus = new Dictionary<int, bool>();  // Initialize the ListenStatus dictionary
    }

    // Add an audio item to the Library
    public void AddAudio(Audio audio)
    {
        Library.Add(audio);
        ListenStatus[audio.Id] = false; // Mark as not listened
    }
     // Find an audio item by ID
    public Audio FindAudioById(int id)
    {
        foreach (var audio in Library)
        {
            if (audio.Id == id)
                return audio;
        }
        throw new Exception($"Audio with ID {id} not found.");
    }
     // Listen to an audio item by ID
    public void ListenAudio(int id)
    {
        Audio audio = FindAudioById(id); // Find the audio
        audio.StartStream();
        audio.EndStream();
        ListenStatus[id] = true; // Mark as listened
    }

    // Get a list of audio items based on listen status
    public List<Audio> GetAudioByStatus(bool isListened)
    {
        List<Audio> result = new List<Audio>();
        foreach (var audio in Library)
        {
            if (ListenStatus[audio.Id] == isListened)
            {
                result.Add(audio);
            }
        }
        return result;
    }

    // Calculate total duration of given audio list
    public int GetTotalDuration(List<Audio> audios)
    {
        int totalDuration = 0;
        foreach (var audio in audios)
        {
            totalDuration += audio.Duration;
        }
        return totalDuration;
    }

    // Display a list of audio items
    public void DisplayAudio(List<Audio> audios)
    {
        foreach (var audio in audios)
        {
            audio.DisplayInfo();
        }
    }

    // Display a detailed streaming report
    public void DisplayReport()
    {
        Console.WriteLine("\nStreaming Service Report:");

        List<Audio> listened = GetAudioByStatus(true);
        List<Audio> unlistened = GetAudioByStatus(false);

        Console.WriteLine($"Total minutes listened: {GetTotalDuration(listened) / 60}");

        Console.WriteLine("\nListened Audio:");
        DisplayAudio(listened);

        Console.WriteLine("\nUnlistened Audio:");
        DisplayAudio(unlistened);
    }
}

