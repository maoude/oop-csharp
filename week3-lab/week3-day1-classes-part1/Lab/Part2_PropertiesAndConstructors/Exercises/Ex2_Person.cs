/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W3.P2.Ex2 — Person.
 *          Practise auto-implemented properties, constructor overloading,
 *          constructor chaining with this(...), object initialiser syntax,
 *          and computed (expression-body) properties.
 */
namespace OopCsharp.Week3.Part2_PropertiesAndConstructors.Exercises;

/// <summary>
/// Exercise W3.P2.Ex2 — Person.
///
/// Implement the Person class below.  Read every TODO carefully.
/// </summary>
public class Person
{
    // ── TODO 1 — Auto-implemented properties ─────────────────────────────────
    //
    // These three are already declared.  Make sure you understand them:
    //
    // FirstName / LastName: { get; set; } — anyone can read and write
    // Age: { get; private set; } — anyone reads, only Person writes
    //
    // Leave these declarations as they are.
    public string FirstName { get; set; } = string.Empty;
    public string LastName  { get; set; } = string.Empty;
    public int    Age       { get; private set; }

    // ── TODO 2 — Computed property FullName ──────────────────────────────────
    //
    // Replace throw in the getter with:
    //   return $"{FirstName} {LastName}";
    //
    // OR use an expression-body property (cleaner):
    //   public string FullName => $"{FirstName} {LastName}";
    //
    // If you use the expression-body form, delete the property below and
    // add the one-liner instead.
    //
    // KEY INSIGHT: this must be a PROPERTY (computed each time it is read),
    // NOT a field set in the constructor.  If it were a field, changing
    // FirstName would not update FullName.
    public string FullName
    {
        get { throw new NotImplementedException(); }
    }

    // ── TODO 3 — Primary constructor (all three parameters) ──────────────────
    //
    // Replace throw with:
    //   if (age < 0)
    //       throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative.");
    //   FirstName = firstName;
    //   LastName  = lastName;
    //   Age       = age;
    public Person(string firstName, string lastName, int age)
    {
        throw new NotImplementedException();
    }

    // ── TODO 4 — Convenience constructor (firstName, lastName only) ───────────
    //
    // Replace ": this(...)" with the correct chaining call:
    //   : this(firstName, lastName, 0)
    //
    // Constructor chaining means this constructor delegates to the
    // three-parameter constructor above.  The body is empty because the
    // chained constructor does all the work.
    //
    // WHY chain? So the age < 0 validation in TODO 3 always runs.
    // Never duplicate constructor logic.
    public Person(string firstName, string lastName)
        : this(firstName, lastName, 0)   // ← chaining — keep this line
    {
        // Body intentionally empty — the chained constructor handles everything.
    }

    // ── TODO 5 — HaveBirthday() ───────────────────────────────────────────────
    //
    // Replace throw with:
    //   Age++;
    //
    // Because Age has 'private set', this method can write Age even though
    // external code cannot.
    public void HaveBirthday()
    {
        throw new NotImplementedException();
    }

    // ── TODO 6 — IsAdult property ─────────────────────────────────────────────
    //
    // Replace throw with:
    //   return Age >= 18;
    //
    // OR convert to an expression-body property:
    //   public bool IsAdult => Age >= 18;
    public bool IsAdult
    {
        get { throw new NotImplementedException(); }
    }

    // ── TODO 7 — Greet(Person other) ─────────────────────────────────────────
    //
    // Replace throw with:
    //   return $"Hi {other.FullName}, I'm {FullName}!";
    //
    // 'other' is a reference to a different Person object.
    // You access its properties the same way you access your own.
    //
    // Example:
    //   alice.Greet(bob) → "Hi Bob Smith, I'm Alice Jones!"
    public string Greet(Person other)
    {
        throw new NotImplementedException();
    }
}
