# Oral Quiz Questions — Week 3 · Classes in C# (Part 1)

Your instructor may ask any of these questions at the start of the next session. Eight questions — five minutes to read them now saves embarrassment later.

---

**Q1.** What is the difference between a *class* and an *object*?

> A class is a blueprint (a type definition). An object is a specific instance created from that blueprint with `new`. You can have thousands of objects, but only one class definition. The class describes *what* an object can hold and do; the object *is* the actual thing with actual data.

---

**Q2.** What does `static` mean on a field? What is the consequence if two objects share a static field?

> A static field belongs to the class, not to any instance. There is exactly ONE copy, regardless of how many objects exist. If two objects both modify a static field, each sees the other's changes — they are modifying the same memory location. This is intentional for counters and shared configuration, but a bug if you meant per-object data.

---

**Q3.** What is the difference between a full property and an auto-implemented property? When would you choose a full property?

> An auto-implemented property (`public int Age { get; set; }`) has the compiler generate the backing field. A full property has an explicit backing field and a getter/setter you write yourself. Choose a full property when the setter needs validation (e.g. rejecting negative ages) or the getter needs to compute something from the backing field.

---

**Q4.** Explain the difference between `{ get; set; }`, `{ get; private set; }`, and `{ get; init; }`.

> `{ get; set; }` — anyone can read and write. `{ get; private set; }` — anyone can read, but only code inside the class can write. `{ get; init; }` — can be set during object construction (in a constructor or object initialiser), then becomes read-only permanently.

---

**Q5.** What does constructor chaining (`: this(...)`) accomplish? Why is it preferable to duplicating the constructor body?

> Constructor chaining calls one constructor from another, so validation and assignment logic lives in one place. If you need to add a new validation rule later, you change it in one constructor rather than searching for every constructor that duplicates the logic. It follows the DRY (Don't Repeat Yourself) principle.

---

**Q6.** What is the difference between a `readonly` field and a `const`?

> `const` must be a compile-time literal value (a number or string known before the program runs). It is implicitly static. `readonly` can be set at runtime — in the declaration or in the constructor — and can hold any type, including objects. Use `readonly` when the value is computed at startup (e.g. sequential IDs, Golden Ratio via `Math.Sqrt`).

---

**Q7.** In `BankAccount`, why does `Withdraw` return `bool` instead of throwing an exception for insufficient funds?

> Insufficient funds is a *normal business event*, not a programming error. Exceptions should signal unexpected failures, not routine outcomes that calling code needs to handle. Returning `bool` lets the caller check the result with a simple `if` instead of a try/catch block, which is cleaner when the failure is expected and recoverable.

---

**Q8.** A student writes `public string FullName; ` as a field, assigns it in the constructor with `FullName = $"{FirstName} {LastName}";`, then wonders why changing `FirstName` doesn't update `FullName`. What is the mistake and how do you fix it?

> A field is assigned once. After `new Person("Alice", "Jones", 20)` runs, `FullName` is forever `"Alice Jones"` even if `FirstName` changes. Fix: make `FullName` a computed expression-body property:
>
> ```csharp
> public string FullName => $"{FirstName} {LastName}";
> ```
>
> A property re-evaluates its expression every time it is read, so it always reflects the current values.
