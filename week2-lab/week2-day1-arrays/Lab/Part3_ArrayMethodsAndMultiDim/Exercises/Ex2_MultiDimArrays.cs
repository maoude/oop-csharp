/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W2.P3.Ex2 — MultiDimArrays.
 *          Work with rectangular 2D arrays (int[,]) and jagged arrays
 *          (int[][]).  Understand the syntax differences, how to get row and
 *          column counts, and when each shape is appropriate.
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim.Exercises;

/// <summary>
/// Exercise W2.P3.Ex2 — MultiDimArrays.
///
/// Replace every  throw new NotImplementedException();
/// with working code.  Read the TODO comment above each method carefully.
/// </summary>
public static class MultiDimArrays
{
    // ────────────────────────────────────────────────────────────────────────
    //  Method 1 — CreateMultiplicationTable
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Creates and returns a <paramref name="rows"/> × <paramref name="cols"/>
    /// rectangular 2D array where element [r, c] = (r + 1) * (c + 1).
    /// (r and c are 0-based indices, so row 0 = "1×", row 1 = "2×", etc.)
    /// </summary>
    ///
    /// TODO Step 1 — Declare the 2D array.
    ///   int[,] table = new int[rows, cols];
    ///   Notice the comma inside the brackets — that is what makes it 2D.
    ///
    /// TODO Step 2 — Fill it with nested for loops.
    ///   for (int r = 0; r < rows; r++)
    ///       for (int c = 0; c < cols; c++)
    ///           table[r, c] = (r + 1) * (c + 1);
    ///
    /// TODO Step 3 — Return table.
    ///
    /// Example: CreateMultiplicationTable(2, 3) →
    ///   [0,0]=1  [0,1]=2  [0,2]=3
    ///   [1,0]=2  [1,1]=4  [1,2]=6
    public static int[,] CreateMultiplicationTable(int rows, int cols)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 2 — SumRow
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the sum of all elements in the specified row of a rectangular
    /// 2D array.
    /// </summary>
    /// <exception cref="ArgumentNullException">When matrix is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// When rowIndex is out of range.
    /// </exception>
    ///
    /// TODO Step 1 — Null guard.
    ///
    /// TODO Step 2 — Row bounds check.
    ///   For a 2D array named matrix:
    ///     matrix.GetLength(0)  →  number of rows
    ///     matrix.GetLength(1)  →  number of columns
    ///   If rowIndex < 0 or rowIndex >= matrix.GetLength(0), throw:
    ///     throw new ArgumentOutOfRangeException(nameof(rowIndex));
    ///
    /// TODO Step 3 — Sum the row.
    ///   int total = 0;
    ///   for (int c = 0; c < matrix.GetLength(1); c++)
    ///       total += matrix[rowIndex, c];
    ///   return total;
    public static int SumRow(int[,] matrix, int rowIndex)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 3 — Transpose
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the transpose of <paramref name="matrix"/>: a new array where
    /// result[c, r] = matrix[r, c].  Rows become columns, columns become rows.
    /// </summary>
    /// <exception cref="ArgumentNullException">When matrix is null.</exception>
    ///
    /// TODO Step 1 — Null guard.
    ///
    /// TODO Step 2 — Get dimensions.
    ///   int rows = matrix.GetLength(0);
    ///   int cols = matrix.GetLength(1);
    ///
    /// TODO Step 3 — Create result with dimensions SWAPPED.
    ///   int[,] result = new int[cols, rows];   ← note: cols first this time
    ///
    /// TODO Step 4 — Fill result.
    ///   for (int r = 0; r < rows; r++)
    ///       for (int c = 0; c < cols; c++)
    ///           result[c, r] = matrix[r, c];
    ///
    /// TODO Step 5 — Return result.
    public static int[,] Transpose(int[,] matrix)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 4 — CreateJaggedTriangle
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Creates a JAGGED array (int[][]) shaped like a left-aligned triangle
    /// of <paramref name="rows"/> rows.  Row 0 has 1 element, row 1 has 2, …
    /// row n has n+1 elements.  Every element is filled with 1.
    /// </summary>
    ///
    /// TODO Step 1 — Declare the jagged array (outer array only).
    ///   int[][] triangle = new int[rows][];
    ///   This creates an array of rows references, all null for now.
    ///   Each row is a SEPARATE inner array — that is the "jagged" part.
    ///
    /// TODO Step 2 — Allocate and fill each row independently.
    ///   for (int r = 0; r < rows; r++)
    ///   {
    ///       triangle[r] = new int[r + 1];   ← row r has r+1 elements
    ///       for (int c = 0; c <= r; c++)
    ///           triangle[r][c] = 1;
    ///   }
    ///   Notice the DIFFERENT indexing syntax:  triangle[r][c]  (two separate [])
    ///   vs the rectangular:                    matrix[r, c]    (comma inside [])
    ///
    /// TODO Step 3 — Return triangle.
    public static int[][] CreateJaggedTriangle(int rows)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 5 — JaggedRowSum
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns an array where element i is the sum of all elements in row i
    /// of the <paramref name="jagged"/> array.
    /// Returns an empty array when <paramref name="jagged"/> is null or empty.
    /// </summary>
    ///
    /// TODO Step 1 — Guard: return new int[0] for null or empty.
    ///
    /// TODO Step 2 — Allocate result.
    ///   int[] sums = new int[jagged.Length];
    ///
    /// TODO Step 3 — Sum each row.
    ///   for (int r = 0; r < jagged.Length; r++)
    ///   {
    ///       int rowTotal = 0;
    ///       if (jagged[r] != null)           // a row itself could be null
    ///           foreach (int val in jagged[r])
    ///               rowTotal += val;
    ///       sums[r] = rowTotal;
    ///   }
    ///
    /// TODO Step 4 — Return sums.
    public static int[] JaggedRowSum(int[][] jagged)
    {
        throw new NotImplementedException();
    }
}
