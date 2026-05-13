/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W3.P2.Ex2 — Person.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week3.Part2_PropertiesAndConstructors.Solutions;

/// <summary>Reference solution for Person (W3.P2.Ex2).</summary>
public class Sol2_Person
{
    public string FirstName { get; set; }
    public string LastName  { get; set; }
    public int    Age       { get; private set; }

    // Computed property — derives FullName from the two name properties.
    public string FullName => $"{FirstName} {LastName}";

    // Primary constructor with validation.
    public Sol2_Person(string firstName, string lastName, int age)
    {
        if (age < 0)
            throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative.");
        FirstName = firstName;
        LastName  = lastName;
        Age       = age;
    }

    // Convenience constructor — chains to the primary to reuse validation.
    public Sol2_Person(string firstName, string lastName)
        : this(firstName, lastName, 0) { }

    public void HaveBirthday() => Age++;

    public bool IsAdult => Age >= 18;

    public string Greet(Sol2_Person other)
        => $"Hi {other.FullName}, I'm {FullName}!";
}
