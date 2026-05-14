# Troubleshooting — Week 2 · Arrays

Consult this file before asking for help. It covers the errors students encounter most often.

---

## Build errors

### "Cannot implicitly convert type 'int' to 'double'"

You are returning an `int` from a method declared as `double`. Cast explicitly:

```csharp
// Method returns double, but this returns int:
return total / numbers.Length;   // ← integer division, then int returned

// Fix — cast before dividing:
return (double)total / numbers.Length;
```

### "Use of unassigned local variable 'min'"

You declared `int min;` without initialising it. For min/max, always initialise from `numbers[0]`:

```csharp
int min = numbers[0];   // must come AFTER the null/empty guard
```

### "The name 'ArrayBasics' does not exist in the current context"

Check the namespace. The exercise file must have `namespace OopCsharp.Week2.Part1_ArrayFundamentals.Exercises;` and the test file must reference the same namespace. Do not change either file's namespace.

---

## Test failures

### Average test fails with a whole number result

Integer division is truncating. See the "My average is always a whole number" section in README.md.

### ReverseArray test `does_not_modify_original` fails

You modified `source` in place (e.g. with `Array.Reverse(source)`). Create a new array and copy elements in reverse:

```csharp
int[] result = new int[source.Length];
for (int i = 0; i < source.Length; i++)
    result[source.Length - 1 - i] = source[i];
return result;
```

### SortedCopy test `does_not_modify_source` fails

You sorted `source` directly. Copy it first, then sort the copy:

```csharp
int[] copy = new int[source.Length];
Array.Copy(source, copy, source.Length);
Array.Sort(copy);
return copy;
```

### FirstEven test `returns_null_when_zero_is_NOT_in_array` passes but `returns_zero_when_zero_IS_first_even` fails

You are checking `if (found == 0) return null` — but 0 itself is an even number. Use `Array.Exists`:

```csharp
if (!Array.Exists(numbers, n => n % 2 == 0)) return null;
return Array.Find(numbers, n => n % 2 == 0);
```

### Transpose dimensions are wrong

Remember: a matrix with `rows` rows and `cols` columns transposes to `cols` rows and `rows` columns.

```csharp
int[,] result = new int[cols, rows];   // NOTE: cols first
```

### MultiplyInPlace test passes but array is unchanged

You used `foreach`. Replace with `for`:

```csharp
for (int i = 0; i < numbers.Length; i++)
    numbers[i] *= factor;
```

### BinarySearch returns a large negative number instead of -1

Normalise any negative result:

```csharp
int idx = Array.BinarySearch(sortedArray, target);
return idx >= 0 ? idx : -1;
```

### "IndexOutOfRangeException" in CreateJaggedTriangle

You tried to access `triangle[r][c]` before allocating row `r`. Allocate each row before filling it:

```csharp
for (int r = 0; r < rows; r++)
{
    triangle[r] = new int[r + 1];   // allocate row r first
    for (int c = 0; c <= r; c++)
        triangle[r][c] = 1;
}
```

### SumRow throws ArgumentOutOfRangeException unexpectedly

Check how you get the row count. For `int[,]` you must use `GetLength(0)`, not `.Length`:

```csharp
// WRONG — .Length gives total element count (rows × cols):
if (rowIndex >= matrix.Length) ...

// CORRECT — GetLength(0) gives the number of rows:
if (rowIndex >= matrix.GetLength(0)) ...
```

---

## "dotnet test" command not found

You are not inside the `week2-day1-arrays/` folder. Run:

```powershell
cd path\to\week2-lab\week2-day1-arrays
dotnet test Lab.Tests/
```

## All tests show as "Not run"

The test filter string is case-sensitive. Use exactly:

```powershell
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2"
```

Make sure your class and namespace names match the test files exactly.
