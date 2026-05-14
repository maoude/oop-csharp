/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays in C#
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate the System.Array static methods (Sort, Reverse,
 *           Copy, IndexOf, Find, Exists) and multi-dimensional arrays
 *           (rectangular and jagged).
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim;

/// <summary>
/// DEMO 03 — Array class methods and multi-dimensional arrays.
/// </summary>
public static class Demo03_ArrayMethodsAndMultiDim
{
    /// <summary>Runs all demo sections.</summary>
    public static void Run()
    {
        SectionA_SortAndReverse();
        SectionB_CopyAndClear();
        SectionC_SearchMethods();
        SectionD_RectangularArray();
        SectionE_JaggedArray();
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION A — Sort and Reverse
    // ═════════════════════════════════════════════════════════════════
    private static void SectionA_SortAndReverse()
    {
        Console.WriteLine("=== A: Sort and Reverse ===");

        int[] nums = { 5, 2, 8, 1, 9, 3 };
        PrintArray("Before sort  :", nums);

        // Array.Sort MODIFIES the array in place — the original is changed.
        // It uses an efficient algorithm (introsort) — O(n log n) average.
        Array.Sort(nums);
        PrintArray("After Sort   :", nums);

        // Array.Reverse also modifies in place.
        Array.Reverse(nums);
        PrintArray("After Reverse:", nums);

        // For strings, Sort uses lexicographic (alphabetical) order.
        string[] words = { "banana", "apple", "cherry", "date" };
        Array.Sort(words);
        PrintArray("Sorted words :", words);
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION B — Copy and Clear
    // ═════════════════════════════════════════════════════════════════
    private static void SectionB_CopyAndClear()
    {
        Console.WriteLine("\n=== B: Copy and Clear ===");

        int[] source = { 10, 20, 30, 40, 50 };

        // Array.Copy(src, dst, count) copies `count` elements from src to dst.
        // The destination must already exist and be large enough.
        int[] dest = new int[5];
        Array.Copy(source, dest, source.Length);
        PrintArray("Copied array :", dest);

        // IMPORTANT: this is a SHALLOW copy — for value types (int, double, struct)
        // it copies the actual values.  For reference types (classes), it copies
        // references, not the objects themselves.

        // Array.Clear sets elements to their default value (0 for int).
        Array.Clear(dest, 1, 3);   // clear 3 elements starting at index 1
        PrintArray("After Clear  :", dest);   // [10, 0, 0, 0, 50]
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION C — Search methods
    // ═════════════════════════════════════════════════════════════════
    private static void SectionC_SearchMethods()
    {
        Console.WriteLine("\n=== C: Search Methods ===");

        int[] sorted = { 1, 3, 5, 7, 9, 11, 13 };

        // Array.IndexOf — linear search O(n), works on any array.
        int idx = Array.IndexOf(sorted, 7);
        Console.WriteLine($"IndexOf(7)  = {idx}");    // 3
        Console.WriteLine($"IndexOf(99) = {Array.IndexOf(sorted, 99)}");  // -1 (not found)

        // Array.BinarySearch — O(log n) but the array MUST be sorted.
        // Returns the index if found, or a negative number if not found.
        int bIdx = Array.BinarySearch(sorted, 9);
        Console.WriteLine($"BinarySearch(9) = {bIdx}");    // 4

        // Array.Exists — returns true if any element satisfies the predicate.
        // The lambda n => n > 10 is a function that takes an int and returns bool.
        bool hasLarge = Array.Exists(sorted, n => n > 10);
        Console.WriteLine($"Any element > 10? {hasLarge}");  // True

        // Array.Find — returns the FIRST element that satisfies the predicate,
        // or the default value (0 for int) if none found.
        int firstEven = Array.Find(sorted, n => n % 2 == 0);
        Console.WriteLine($"First even: {firstEven}");       // 0 (none found — all odd)

        int[] mixed = { 1, 4, 7, 2, 9, 6 };
        int fe = Array.Find(mixed, n => n % 2 == 0);
        Console.WriteLine($"First even in mixed: {fe}");     // 4

        // Array.FindAll — returns ALL matching elements as a new array.
        int[] evens = Array.FindAll(mixed, n => n % 2 == 0);
        PrintArray("All evens    :", evens);   // 4, 2, 6
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION D — Rectangular (2-D) arrays
    // ═════════════════════════════════════════════════════════════════
    private static void SectionD_RectangularArray()
    {
        Console.WriteLine("\n=== D: Rectangular (2D) Array ===");

        // Declaration: type[,]  — the comma indicates 2 dimensions.
        // Creation: new type[rows, columns]
        int[,] grid = new int[3, 4];   // 3 rows × 4 columns = 12 elements

        // Populate with (row * 10 + col) so we can see the structure.
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 4; col++)
                grid[row, col] = row * 10 + col;

        // Print the grid — using GetLength(dimension):
        //   GetLength(0) = number of rows
        //   GetLength(1) = number of columns
        Console.WriteLine("  grid:");
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            Console.Write("  ");
            for (int col = 0; col < grid.GetLength(1); col++)
                Console.Write($"{grid[row, col],4}");
            Console.WriteLine();
        }
        // Output:
        //      0   1   2   3
        //     10  11  12  13
        //     20  21  22  23
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION E — Jagged arrays
    // ═════════════════════════════════════════════════════════════════
    private static void SectionE_JaggedArray()
    {
        Console.WriteLine("\n=== E: Jagged Array ===");

        // A jagged array is an ARRAY OF ARRAYS.
        // Each inner array can have a DIFFERENT length — unlike rectangular.
        // Declaration: type[][]
        int[][] triangle = new int[4][];   // 4 rows, each length defined separately

        // Each row is independently allocated:
        for (int i = 0; i < triangle.Length; i++)
            triangle[i] = new int[i + 1];   // row 0 has 1 element, row 3 has 4

        // Populate: element at [row][col] = row + col
        for (int row = 0; row < triangle.Length; row++)
            for (int col = 0; col < triangle[row].Length; col++)
                triangle[row][col] = row + col;

        Console.WriteLine("  Jagged triangle:");
        foreach (int[] row in triangle)
        {
            Console.Write("  ");
            foreach (int val in row)
                Console.Write($"{val} ");
            Console.WriteLine();
        }
        // Row 0: 0
        // Row 1: 1 2
        // Row 2: 2 3 4
        // Row 3: 3 4 5 6

        // ACCESS: triangle[row][col]  — TWO separate [] operators
        // vs rectangular: grid[row, col] — ONE [] with a comma
    }

    // ─────────────────────────────────────────────────────────────────
    // Helper: print a 1-D array on one line
    // ─────────────────────────────────────────────────────────────────
    private static void PrintArray<T>(string label, T[] arr)
    {
        // string.Join inserts a separator between elements — cleaner than a manual loop.
        Console.WriteLine($"  {label} [{string.Join(", ", arr)}]");
    }
}
