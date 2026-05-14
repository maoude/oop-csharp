/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays in C#
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate iterating arrays with for and foreach loops,
 *           computing sum/average/min/max in a single pass, and drawing
 *           a bar chart — all classic first uses of arrays in practice.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations;

/// <summary>
/// DEMO 02 — Iterating arrays and computing aggregate values.
/// </summary>
public static class Demo02_IterationAndOperations
{
    /// <summary>Runs all demo sections.</summary>
    public static void Run()
    {
        SectionA_ForLoop();
        SectionB_ForeachLoop();
        SectionC_SumAndAverage();
        SectionD_MinAndMax();
        SectionE_BarChart();
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION A — for loop with index
    // ═════════════════════════════════════════════════════════════════
    private static void SectionA_ForLoop()
    {
        Console.WriteLine("=== A: for Loop ===");

        int[] scores = { 85, 92, 78, 95, 60 };

        // The canonical for-loop pattern:
        //   i starts at 0        (first valid index)
        //   i < arr.Length       (stop BEFORE going out of bounds)
        //   i++                  (advance by 1 each iteration)
        //
        // Using i inside the loop gives you both the index and the value.
        for (int i = 0; i < scores.Length; i++)
        {
            // %2d is Console.Write formatting — not needed in C#,
            // but we use string interpolation padding here:
            Console.WriteLine($"  scores[{i}] = {scores[i],3}");
            //                                         ↑ ,3 = right-align in 3 chars
        }

        // WHEN to use for (vs foreach):
        //   • You need the index (to print "element 3 is X", to compare neighbours)
        //   • You need to WRITE to elements (foreach gives a read-only copy for value types)
        //   • You iterate backwards or in steps other than 1
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION B — foreach loop
    // ═════════════════════════════════════════════════════════════════
    private static void SectionB_ForeachLoop()
    {
        Console.WriteLine("\n=== B: foreach Loop ===");

        string[] fruits = { "apple", "banana", "cherry", "date" };

        // foreach abstracts away the index entirely.
        // On each iteration, `fruit` receives a COPY of the next element.
        // This is cleaner when you only need the value, not the position.
        foreach (string fruit in fruits)
        {
            Console.WriteLine($"  {fruit}");
        }

        // var works here too — the compiler infers string from the array type:
        Console.WriteLine("  (same with var)");
        foreach (var fruit in fruits)
            Console.WriteLine($"  {fruit}");

        // LIMITATION: you cannot modify elements through a foreach variable.
        // The following would be a compile error for value types:
        //   foreach (int n in numbers) n = 0;   ← CS1656
        // Use for when you need to write.
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION C — Sum and Average
    // ═════════════════════════════════════════════════════════════════
    private static void SectionC_SumAndAverage()
    {
        Console.WriteLine("\n=== C: Sum and Average ===");

        int[] grades = { 72, 88, 95, 61, 84, 77 };

        // Accumulator pattern: start at 0, add each element.
        int sum = 0;
        foreach (int grade in grades)
            sum += grade;   // shorthand for: sum = sum + grade

        // Cast to double BEFORE dividing to get a decimal result.
        // Without the cast: 477 / 6 = 79 (integer division, truncated).
        double average = (double)sum / grades.Length;

        Console.WriteLine($"  Sum     = {sum}");
        Console.WriteLine($"  Count   = {grades.Length}");
        Console.WriteLine($"  Average = {average:F2}");  // F2 = 2 decimal places
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION D — Minimum and Maximum
    // ═════════════════════════════════════════════════════════════════
    private static void SectionD_MinAndMax()
    {
        Console.WriteLine("\n=== D: Min and Max ===");

        int[] temps = { 23, 17, 31, 14, 28, 19, 33 };

        // Seed with the first element — the safest baseline.
        // Do NOT seed with 0 or int.MaxValue without a reason:
        // seeding with 0 fails if all values are negative.
        int min = temps[0];
        int max = temps[0];

        // Single pass: O(n) time, O(1) extra space.
        for (int i = 1; i < temps.Length; i++)  // start at 1 — we already seeded with [0]
        {
            if (temps[i] < min) min = temps[i];
            if (temps[i] > max) max = temps[i];
        }

        Console.WriteLine($"  Min temp = {min}°C");
        Console.WriteLine($"  Max temp = {max}°C");
        Console.WriteLine($"  Range    = {max - min}°C");
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION E — Bar chart
    // ═════════════════════════════════════════════════════════════════
    private static void SectionE_BarChart()
    {
        Console.WriteLine("\n=== E: Bar Chart ===");

        // Each value becomes a row of stars — a simple ASCII bar chart.
        // This shows how arrays drive visual output without any graphics library.
        int[] data = { 4, 7, 2, 9, 5, 3 };

        Console.WriteLine("  Bar chart of data:");
        for (int i = 0; i < data.Length; i++)
        {
            // new string('*', n) creates a string of n asterisks — see Week 1 Demo02.
            string bar = new string('*', data[i]);
            Console.WriteLine($"  [{i}] {bar} ({data[i]})");
        }
        // Output:
        //   [0] **** (4)
        //   [1] ******* (7)
        //   [2] ** (2)
        //   [3] ********* (9)
        //   [4] ***** (5)
        //   [5] *** (3)
    }
}
