/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_BinaryRecordStore.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week10.Part3_BinaryIO.Solutions;

public class Sol1_BinaryRecordStore
{
    /// <summary>Saves records to a count-prefixed binary file.</summary>
    public void SaveRecords(
        string path,
        IEnumerable<(string Name, int Age, double Score)> records)
    {
        var list = records.ToList();
        using var writer = new BinaryWriter(File.Open(path, FileMode.Create));
        writer.Write(list.Count);
        foreach (var (name, age, score) in list)
        {
            writer.Write(name);
            writer.Write(age);
            writer.Write(score);
        }
    }

    /// <summary>Loads all records from a count-prefixed binary file.</summary>
    public IReadOnlyList<(string Name, int Age, double Score)> LoadRecords(string path)
    {
        using var reader = new BinaryReader(File.Open(path, FileMode.Open));
        int count = reader.ReadInt32();
        var records = new List<(string, int, double)>(count);
        for (int i = 0; i < count; i++)
        {
            string name  = reader.ReadString();
            int    age   = reader.ReadInt32();
            double score = reader.ReadDouble();
            records.Add((name, age, score));
        }
        return records;
    }

    /// <summary>Returns the record count stored in the file header.</summary>
    public int CountRecords(string path)
    {
        using var reader = new BinaryReader(File.Open(path, FileMode.Open));
        return reader.ReadInt32();
    }
}
