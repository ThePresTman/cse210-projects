using System;

public class Entry
{
    public string _date;
    public string _time;
    public string _prompt;
    public string _response;
    public int _moodRating;

    public void Display()
    {
        Console.WriteLine($"{_date} ({_time}) - Mood: {_moodRating}/10");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }
}
