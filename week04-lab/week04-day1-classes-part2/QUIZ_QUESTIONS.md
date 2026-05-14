# Oral Quiz Questions — Week 4 · Classes in C# (Part 2)

---

**Q1.** Why must you override `GetHashCode()` whenever you override `Equals()`?

> The contract: if `a.Equals(b)` is true, `a.GetHashCode() == b.GetHashCode()` must also be true. `Dictionary<K,V>` and `HashSet<T>` use the hash code to locate the storage bucket. If two equal objects have different hash codes, the second object lands in a different bucket — the lookup finds nothing even though the key is "present." Violating the contract causes silent data loss, not a crash.

---

**Q2.** What is the difference between reference equality and value equality? Which does `==` use by default for classes?

> Reference equality compares memory addresses — two variables are equal only if they point to the exact same object. Value equality compares the data the objects hold — two different objects with identical field values are equal. By default, `==` for classes uses reference equality (inherited from `object`). You must overload `==` to get value equality.

---

**Q3.** You overload `operator *` for `Vector * double`. A colleague writes `2.0 * v` and gets a compile error. Why, and how do you fix it?

> C# does not automatically flip operands. `Vector * double` is a different method signature than `double * Vector`. You must define both overloads explicitly. Convention: the second overload delegates to the first: `return v * scalar;`

---

**Q4.** What is the rule about `==` and `!=` that the C# compiler enforces?

> They must always be defined in pairs — you cannot overload one without the other. Additionally, when you overload `==`, the compiler warns you to also override `Equals()` and `GetHashCode()`, because inconsistency between `==` and `Equals()` breaks contracts that the framework relies on.

---

**Q5.** When would you choose `implicit` over `explicit` for a conversion operator?

> Use `implicit` when the conversion is always safe, loses no information, and is semantically obvious — like `int` to `double`. The caller should not need to think about it. Use `explicit` when the conversion might throw, lose precision, or strip semantic meaning (like extracting a raw `double` from a `Weight` — the caller should consciously decide to do that). If in doubt, prefer `explicit`.

---

**Q6.** What does implementing `IComparable<T>` give you for free?

> `Array.Sort(T[])`, `List<T>.Sort()`, `SortedSet<T>`, `SortedDictionary<K,V>`, and LINQ's `OrderBy(x => x)` all call `CompareTo` under the hood. You implement one method and all sorting infrastructure in the .NET standard library works with your type automatically.

---

**Q7.** `Fraction(1, 2)` and `Fraction(2, 4)` should be equal. Your `==` operator checks `a.Numerator == b.Numerator && a.Denominator == b.Denominator`. Is this correct for fractions?

> Yes — **if** the constructor always reduces fractions to lowest terms. `Fraction(2, 4)` and `Fraction(1, 2)` both store `Numerator=1, Denominator=2` after GCD reduction, so the comparison is correct. The key requirement is that the normalisation happens in the constructor, not in `==`.

---

**Q8.** A student overrides `ToString()` in their class but notices that `Console.WriteLine(myObject)` still prints the type name. What is most likely wrong?

> They wrote `public new string ToString()` instead of `public override string ToString()`. The `new` keyword hides the base method rather than replacing it. `Console.WriteLine` calls `ToString()` through a reference of type `object`, so it sees the base `object.ToString()` — not the hidden version. The fix is to use `override`.
