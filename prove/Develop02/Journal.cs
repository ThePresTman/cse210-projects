using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet. Write one first!");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._time}|{entry._prompt}|{entry._response}|{entry._moodRating}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            if (parts.Length >= 5)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _time = parts[1],
                    _prompt = parts[2],
                    _response = parts[3],
                    _moodRating = int.Parse(parts[4])
                };
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully!");
    }
}
