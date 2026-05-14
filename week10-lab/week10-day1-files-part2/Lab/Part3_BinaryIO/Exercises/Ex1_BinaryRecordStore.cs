/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: typed binary I/O with BinaryWriter/BinaryReader.
 *           Practice: count-prefix format, write/read order, round-trip.
 */
namespace OopCsharp.Week10.Part3_BinaryIO.Exercises;

// ============================================================
// Exercise 1 — BinaryRecordStore
//
// Implement three methods using BinaryWriter and BinaryReader.
//
// File format (MUST be consistent across all three methods):
//   [int32  — record count]
//   for each record:
//       [string — name  (BinaryWriter.Write(string))]
//       [int32  — age   (BinaryWriter.Write(int))]
//       [double — score (BinaryWriter.Write(double))]
// ============================================================

public class BinaryRecordStore
{
    // TODO 1a: SaveRecords(string path, IEnumerable<(string Name, int Age, double Score)> records)
    //   Open with FileMode.Create (creates or overwrites).
    //   Write the record count as int32, then each record (string, int32, double).
    public void SaveRecords(
        string path,
        IEnumerable<(string Name, int Age, double Score)> records) =>
        throw new NotImplementedException();

    // TODO 1b: LoadRecords(string path)
    //   Open with FileMode.Open.
    //   Read the count, then read that many records (string, int32, double).
    //   Return as IReadOnlyList.
    //   Throws FileNotFoundException when the file does not exist.
    public IReadOnlyList<(string Name, int Age, double Score)> LoadRecords(string path) =>
        throw new NotImplementedException();

    // TODO 1c: CountRecords(string path)
    //   Open with FileMode.Open, read and return just the first int32.
    //   Throws FileNotFoundException when the file does not exist.
    //   Hint: you do NOT need to read the records themselves.
    public int CountRecords(string path) => throw new NotImplementedException();
}
