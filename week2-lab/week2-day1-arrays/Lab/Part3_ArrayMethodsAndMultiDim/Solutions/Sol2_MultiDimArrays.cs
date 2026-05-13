/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W2.P3.Ex2 — MultiDimArrays.
 *          Do NOT share this file with students before the submission deadline.
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim.Solutions;

/// <summary>Reference solution for MultiDimArrays (W2.P3.Ex2).</summary>
public static class Sol2_MultiDimArrays
{
    public static int[,] CreateMultiplicationTable(int rows, int cols)
    {
        int[,] table = new int[rows, cols];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                table[r, c] = (r + 1) * (c + 1);

        return table;
    }

    public static int SumRow(int[,] matrix, int rowIndex)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));
        if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
            throw new ArgumentOutOfRangeException(nameof(rowIndex));

        int total = 0;
        for (int c = 0; c < matrix.GetLength(1); c++)
            total += matrix[rowIndex, c];

        return total;
    }

    public static int[,] Transpose(int[,] matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Dimensions are swapped: a rows×cols matrix transposes to cols×rows.
        int[,] result = new int[cols, rows];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                result[c, r] = matrix[r, c];

        return result;
    }

    public static int[][] CreateJaggedTriangle(int rows)
    {
        int[][] triangle = new int[rows][];

        for (int r = 0; r < rows; r++)
        {
            triangle[r] = new int[r + 1];      // row r has r+1 slots
            for (int c = 0; c <= r; c++)
                triangle[r][c] = 1;
        }

        return triangle;
    }

    public static int[] JaggedRowSum(int[][] jagged)
    {
        if (jagged == null || jagged.Length == 0) return new int[0];

        int[] sums = new int[jagged.Length];
        for (int r = 0; r < jagged.Length; r++)
        {
            int rowTotal = 0;
            if (jagged[r] != null)                  // guard against null rows
                foreach (int val in jagged[r])
                    rowTotal += val;
            sums[r] = rowTotal;
        }

        return sums;
    }
}
