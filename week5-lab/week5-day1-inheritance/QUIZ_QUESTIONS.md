# Oral Quiz Questions — Week 5 · Inheritance

---

**Q1.** What is the difference between `override` and `new` when a derived class re-declares a method that exists in the base class?

> `override` replaces the base method in the virtual dispatch table — a base-class reference calling the method will reach the derived version. `new` merely *hides* the method for derived-class references; a base-class reference still calls the original. `override` = true polymorphism. `new` = no polymorphism — just a name collision that the compiler lets you paper over.

---

**Q2.** When must you explicitly call `base(...)` in a derived constructor?

> Whenever the base class has no parameterless constructor. The compiler automatically inserts `base()` if you omit the call; if no parameterless constructor exists, the compiler emits an error. You must also call `base(...)` explicitly when you need to pass arguments up the chain (the normal case for well-designed classes).

---

**Q3.** What does `abstract` on a method mean, and what does it force on derived classes?

> An abstract method has no body — it is a *promise* that every concrete (non-abstract) derived class must provide an implementation. You cannot instantiate an abstract class directly. If a derived class does not override every inherited abstract method, it too must be declared abstract.

---

**Q4.** Why would you mark an override as `sealed`?

> To prevent any further subclass from overriding that method. Useful when the implementation is performance-critical or when correctness depends on the method never changing. Once sealed, the compiler can even devirtualize the call and inline it.

---

**Q5.** What is the difference between upcasting and downcasting, and which is safe?

> Upcasting: treating a derived-type reference as a base-type reference (e.g. `Animal a = new Dog(...)`). Always safe — a Dog is always an Animal. Downcasting: treating a base-type reference as a derived-type reference (e.g. `Dog d = (Dog)a`). Unsafe — throws `InvalidCastException` if the runtime type is wrong. Use the `is` pattern or `as` to check first.

---

**Q6.** What is the preferred way to downcast safely in modern C#?

> Pattern matching: `if (a is Dog d) { ... }`. This tests the type AND declares the variable in one expression, and runs the body only when the cast succeeds — no separate null-check needed. Alternatively, `Dog? d = a as Dog; if (d != null) ...` works but is more verbose.

---

**Q7.** Explain polymorphism in one sentence and give an example from this lab.

> Polymorphism lets you write code against a base type and have the runtime call the correct override for whatever concrete type is stored at runtime. Example: `shapes.Sum(s => s.Area())` works for `Circle`, `Rectangle`, and `Square` without knowing which type each element is.

---

**Q8.** Can an abstract class have concrete (non-abstract) methods? Can it have a constructor?

> Yes to both. Abstract classes regularly contain concrete methods that provide shared behaviour (like `AnnualSalary()` in the Employee exercise). They can also have constructors — which derived classes call via `base(...)`. You simply cannot instantiate the abstract class directly with `new`.
