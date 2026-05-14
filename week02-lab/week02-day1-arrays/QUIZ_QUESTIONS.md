# Oral Quiz Questions — Week 2 · Arrays

Your instructor may ask any of these questions at the start of the next session. There are 8 questions. Spend five minutes reading them before you leave — you already know the answers from doing the exercises.

---

**Q1.** What is the default value of every element in a freshly created `int[]` in C#? What about `bool[]`? What about `string[]`?

> `int[]` → all 0. `bool[]` → all false. `string[]` → all null. C# zero-initialises value-type arrays; reference types get the null reference.

---

**Q2.** Explain why the following code does NOT double the elements of the array:

```csharp
int[] nums = { 1, 2, 3 };
foreach (int n in nums)
    n = n * 2;
```

> `foreach` gives you a local copy of each element. Assigning to `n` modifies the copy, not the slot in the array. You must use a `for` loop with `nums[i] = nums[i] * 2` to write back through the index.

---

**Q3.** Why should you seed `min` from `numbers[0]` rather than from `0` or `int.MaxValue`?

> Seeding from `0` fails when all elements are negative — `0` is never in the array but ends up as the result. Seeding from `int.MaxValue` is technically safe but obscure and error-prone. Seeding from `numbers[0]` always picks a real data value, handles all-negative arrays correctly, and is the most readable choice.

---

**Q4.** You want to compute the average of `new int[] { 1, 2 }`. What does `(1 + 2) / 2` evaluate to in C#, and why is that wrong? How do you fix it?

> `3 / 2` in C# is integer division and gives `1`, not `1.5`. Fix: cast one operand to double before dividing: `(double)(1 + 2) / 2` → `1.5`.

---

**Q5.** What does `Array.BinarySearch` return when the target is not found? How do you normalise that to the conventional -1?

> It returns a negative value (the bitwise complement of the insertion point). Normalise with: `int idx = Array.BinarySearch(arr, target); return idx >= 0 ? idx : -1;`

---

**Q6.** `Array.Find` returns `0` both when it finds the number `0` and when no match exists. How do you distinguish the two cases?

> Use `Array.Exists` first: `if (!Array.Exists(numbers, n => n % 2 == 0)) return null; return Array.Find(...);`

---

**Q7.** What is the difference between a rectangular 2D array (`int[,]`) and a jagged array (`int[][]`) in C#? Give one situation where you would prefer each.

> Rectangular: all rows have the same number of columns, single allocation, accessed as `m[r, c]`. Jagged: each row is an independent array with its own length, accessed as `j[r][c]`. Prefer rectangular for grids and matrices with fixed dimensions. Prefer jagged for triangle-shaped data or when rows have variable lengths.

---

**Q8.** What does `Array.Sort` do to the array it receives? Why does `SortedCopy` make a copy BEFORE calling `Array.Sort`?

> `Array.Sort` sorts the array it receives IN PLACE — it changes the order of elements in the original. `SortedCopy` must return a sorted copy without destroying the caller's data, so it copies first and sorts only the copy.
