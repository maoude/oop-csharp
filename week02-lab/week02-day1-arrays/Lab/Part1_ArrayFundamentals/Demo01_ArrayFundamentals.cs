/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays in C#
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate the foundational array concepts: declaration,
 *           creation, indexing, the Length property, default values, and
 *           how IndexOutOfRangeException occurs and is avoided.
 *           Run live during lecture — ask students to predict output first.
 */
namespace OopCsharp.Week2.Part1_ArrayFundamentals;

/// <summary>
/// DEMO 01 — Array declaration, creation, indexing, and bounds.
/// </summary>
public static class Demo01_ArrayFundamentals
{
    /// <summary>Runs all sections of the demo.</summary>
    public static void Run()
    {
        SectionA_DeclarationAndCreation();
        SectionB_DefaultValues();
        SectionC_IndexingAndLength();
        SectionD_ArrayInitializer();
        SectionE_BoundsAndException();
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION A — Declaration and creation
    // ═════════════════════════════════════════════════════════════════
    private static void SectionA_DeclarationAndCreation()
    {
        Console.WriteLine("=== A: Declaration and Creation ===");

        // Step 1: declare the variable (no array exists yet — it is null).
        int[] scores;

        // Step 2: create the array with `new`.  This allocates a contiguous
        // block of memory for 5 integers and assigns the reference to `scores`.
        scores = new int[5];

        // Combine steps 1 and 2 on one line (most common style):
        double[] temperatures = new double[3];

        // The `var` keyword lets the compiler infer the type from the
        // right-hand side — useful when the type is obvious.
        var names = new string[4];   // compiler knows this is string[]

        Console.WriteLine($"scores     has {scores.Length} elements");
        Console.WriteLine($"temperatures has {temperatures.Length} elements");
        Console.WriteLine($"names      has {names.Length} elements");

        // MEMORY LAYOUT:
        // An array is a single contiguous block.
        // Element 0 is at the lowest address; element N-1 at the highest.
        // This is why random access (arr[i]) is O(1) — it is just base + i*size.
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION B — Default values
    // ═════════════════════════════════════════════════════════════════
    private static void SectionB_DefaultValues()
    {
        Console.WriteLine("\n=== B: Default Values ===");

        // When `new` creates an array, every element is initialised to its
        // TYPE'S DEFAULT VALUE — not garbage from memory.
        //
        //   int / long / byte / short  → 0
        //   double / float / decimal   → 0.0
        //   bool                       → false
        //   char                       → '\0'  (the null character)
        //   string / any reference     → null

        int[]    ints    = new int[3];
        double[] doubles = new double[3];
        bool[]   bools   = new bool[3];
        string[] strings = new string[3];

        Console.WriteLine($"int    default: {ints[0]}");        // 0
        Console.WriteLine($"double default: {doubles[0]}");     // 0
        Console.WriteLine($"bool   default: {bools[0]}");       // False
        Console.WriteLine($"string default: {strings[0]}");     // (empty line — null printed as "")
        Console.WriteLine($"string is null: {strings[0] is null}");  // True
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION C — Indexing and Length
    // ═════════════════════════════════════════════════════════════════
    private static void SectionC_IndexingAndLength()
    {
        Console.WriteLine("\n=== C: Indexing and Length ===");

        int[] primes = new int[5];

        // WRITING elements: arr[index] = value
        primes[0] = 2;
        primes[1] = 3;
        primes[2] = 5;
        primes[3] = 7;
        primes[4] = 11;

        // READING elements: variable = arr[index]
        Console.WriteLine($"First prime : {primes[0]}");   // 2
        Console.WriteLine($"Last  prime : {primes[4]}");   // 11

        // Length is a PROPERTY (no parentheses), not a method.
        // It always equals the number of elements created with `new`.
        Console.WriteLine($"Count of primes: {primes.Length}");  // 5

        // Last-element idiom: arr[arr.Length - 1]
        Console.WriteLine($"Last via Length: {primes[primes.Length - 1]}");  // 11

        // C# 8+ index-from-end operator ^1:
        Console.WriteLine($"Last via ^1    : {primes[^1]}");  // 11  (same result)
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION D — Array initializer syntax
    // ═════════════════════════════════════════════════════════════════
    private static void SectionD_ArrayInitializer()
    {
        Console.WriteLine("\n=== D: Array Initializer ===");

        // When you know the values up front, use an initializer.
        // The compiler counts the values and sets the size automatically.
        int[] evens = { 2, 4, 6, 8, 10 };          // type-inferred from declaration
        var   odds  = new[] { 1, 3, 5, 7, 9 };     // var + new[] — compiler infers int[]

        Console.WriteLine($"evens[2] = {evens[2]}");   // 6
        Console.WriteLine($"odds[4]  = {odds[4]}");    // 9
        Console.WriteLine($"Length   = {evens.Length}"); // 5

        // Initializer + explicit size is redundant — never write:
        //   int[] bad = new int[5] { 1, 2, 3 };   ← size and count must match
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION E — Bounds checking and IndexOutOfRangeException
    // ═════════════════════════════════════════════════════════════════
    private static void SectionE_BoundsAndException()
    {
        Console.WriteLine("\n=== E: Bounds Checking ===");

        int[] data = { 10, 20, 30 };   // valid indices: 0, 1, 2

        // SAFE access:
        Console.WriteLine($"data[2] = {data[2]}");   // 30

        // UNSAFE — would throw IndexOutOfRangeException at runtime:
        // Console.WriteLine(data[3]);   // ← index 3 does not exist!
        // Console.WriteLine(data[-1]);  // ← negative index is also invalid

        // HOW TO AVOID: always use the Length property in conditions.
        int requestedIndex = 5;
        if (requestedIndex >= 0 && requestedIndex < data.Length)
            Console.WriteLine($"data[{requestedIndex}] = {data[requestedIndex]}");
        else
            Console.WriteLine($"Index {requestedIndex} is out of range [0, {data.Length - 1}].");

        // The for loop pattern  for (int i = 0; i < arr.Length; i++)
        // is guaranteed safe because i is always in [0, Length-1].
    }
}
