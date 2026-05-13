/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W2.P3.Ex2 — MultiDimArrays.
 *           Tests cover rectangular 2D creation, row summing, transposition,
 *           jagged triangle creation, and per-row sum of a jagged array.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="MultiDimArrays"/> (W2.P3.Ex2).</summary>
public class StudentWeek2Part3_Ex2Tests
{
    // ── CreateMultiplicationTable ─────────────────────────────────────

    [Fact]
    public void MultiplicationTable_3x3_correct_values()
    {
        int[,] table = MultiDimArrays.CreateMultiplicationTable(3, 3);

        // Spot-check key positions
        Assert.Equal(1, table[0, 0]);    // 1×1
        Assert.Equal(6, table[1, 2]);    // 2×3
        Assert.Equal(9, table[2, 2]);    // 3×3
    }

    [Fact]
    public void MultiplicationTable_correct_dimensions()
    {
        int[,] table = MultiDimArrays.CreateMultiplicationTable(4, 2);
        Assert.Equal(4, table.GetLength(0));
        Assert.Equal(2, table.GetLength(1));
    }

    [Fact]
    public void MultiplicationTable_1x1_returns_one()
    {
        int[,] table = MultiDimArrays.CreateMultiplicationTable(1, 1);
        Assert.Equal(1, table[0, 0]);
    }

    // ── SumRow ───────────────────────────────────────────────────────

    [Fact]
    public void SumRow_returns_correct_row_sum()
    {
        int[,] m = { { 1, 2, 3 }, { 4, 5, 6 } };
        Assert.Equal(6,  MultiDimArrays.SumRow(m, 0));   // 1+2+3
        Assert.Equal(15, MultiDimArrays.SumRow(m, 1));   // 4+5+6
    }

    [Fact]
    public void SumRow_out_of_range_throws_ArgumentOutOfRangeException()
    {
        int[,] m = { { 1, 2 } };
        Assert.Throws<ArgumentOutOfRangeException>(() => MultiDimArrays.SumRow(m, 5));
    }

    [Fact]
    public void SumRow_negative_index_throws_ArgumentOutOfRangeException()
    {
        int[,] m = { { 1, 2 } };
        Assert.Throws<ArgumentOutOfRangeException>(() => MultiDimArrays.SumRow(m, -1));
    }

    [Fact]
    public void SumRow_null_throws_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MultiDimArrays.SumRow(null!, 0));
    }

    // ── Transpose ────────────────────────────────────────────────────

    [Fact]
    public void Transpose_2x3_becomes_3x2()
    {
        int[,] m = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] t = MultiDimArrays.Transpose(m);

        Assert.Equal(3, t.GetLength(0));
        Assert.Equal(2, t.GetLength(1));

        Assert.Equal(1, t[0, 0]);
        Assert.Equal(4, t[0, 1]);
        Assert.Equal(3, t[2, 0]);
        Assert.Equal(6, t[2, 1]);
    }

    [Fact]
    public void Transpose_square_matrix()
    {
        int[,] m = { { 1, 2 }, { 3, 4 } };
        int[,] t = MultiDimArrays.Transpose(m);

        Assert.Equal(2, t[1, 0]);   // was [0,1]
        Assert.Equal(3, t[0, 1]);   // was [1,0]
    }

    [Fact]
    public void Transpose_null_throws_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MultiDimArrays.Transpose(null!));
    }

    // ── CreateJaggedTriangle ──────────────────────────────────────────

    [Fact]
    public void CreateJaggedTriangle_correct_row_lengths()
    {
        int[][] tri = MultiDimArrays.CreateJaggedTriangle(4);

        Assert.Equal(4, tri.Length);
        Assert.Equal(1, tri[0].Length);
        Assert.Equal(2, tri[1].Length);
        Assert.Equal(3, tri[2].Length);
        Assert.Equal(4, tri[3].Length);
    }

    [Fact]
    public void CreateJaggedTriangle_all_elements_are_one()
    {
        int[][] tri = MultiDimArrays.CreateJaggedTriangle(3);
        foreach (int[] row in tri)
            Assert.All(row, v => Assert.Equal(1, v));
    }

    [Fact]
    public void CreateJaggedTriangle_zero_rows_returns_empty()
    {
        Assert.Empty(MultiDimArrays.CreateJaggedTriangle(0));
    }

    // ── JaggedRowSum ─────────────────────────────────────────────────

    [Fact]
    public void JaggedRowSum_returns_per_row_sums()
    {
        int[][] jagged = { new[] { 1, 2, 3 }, new[] { 10, 20 }, new[] { 5 } };
        Assert.Equal(new[] { 6, 30, 5 }, MultiDimArrays.JaggedRowSum(jagged));
    }

    [Fact]
    public void JaggedRowSum_empty_row_contributes_zero()
    {
        int[][] jagged = { new int[0], new[] { 7 } };
        Assert.Equal(new[] { 0, 7 }, MultiDimArrays.JaggedRowSum(jagged));
    }

    [Fact]
    public void JaggedRowSum_null_returns_empty_array()
    {
        Assert.Empty(MultiDimArrays.JaggedRowSum(null!));
    }
}
