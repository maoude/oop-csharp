# Oral Quiz Questions — Week 6 · Interfaces & Abstract Classes

---

**Q1.** What are the key differences between an interface and an abstract class in C#?

> An interface defines a pure contract — no instance fields, no constructor, all members public by default. A class can implement multiple interfaces. An abstract class can have fields, a constructor, protected members, and concrete (implemented) methods. A class can inherit only one abstract class. Rule of thumb: use an interface for "can-do" capabilities shared across unrelated types; use an abstract class when related types share state or common logic.

---

**Q2.** Can a class implement more than one interface? Can it inherit more than one class?

> Yes to the first, no to the second. C# allows multiple interface implementation (`class Foo : IBar, IBaz`) but single-class inheritance only. This is intentional: multiple class inheritance causes the "diamond problem" (ambiguous base method resolution) which C# avoids by prohibiting it.

---

**Q3.** What is an explicit interface implementation, and when would you use it?

> An explicit implementation prefixes the member with the interface name: `string IPrintable.Format() => ...`. It is only accessible through an interface-typed reference, not through the class directly. Use it when two interfaces define a member with the same name and you need different behaviours for each, or to hide a member from the class's public surface while still satisfying the contract.

---

**Q4.** What does `OfType<T>()` do in LINQ?

> It filters a sequence to include only elements whose runtime type is `T` (or a subtype), returning an `IEnumerable<T>`. It is the safe LINQ equivalent of `is T` filtering — elements that are not `T` are silently skipped rather than throwing. Example: `items.OfType<IShippable>()` gives only the shippable items.

---

**Q5.** What is a default interface method (introduced in C# 8)? What is its primary use case?

> A default interface method has a body inside the interface. Implementing classes don't need to provide one unless they want to override it. The primary use case is backward compatibility: you can add a new member to an existing interface without breaking every class that already implements it — the new member gets a sensible default.

---

**Q6.** Explain the Strategy pattern using an interface.

> The Strategy pattern replaces a conditional (`if/switch`) with a polymorphic call through an interface. You define an interface (e.g. `IDiscountStrategy`) with a method (`Apply(double price)`). At runtime, you inject the concrete strategy object. Adding a new strategy requires only a new class — no change to the calling code. This is the Open/Closed Principle in action.

---

**Q7.** Your `LoggerBase` abstract class implements `ILogger`. A student forgets to declare `LoggerBase : ILogger`. What breaks?

> The concrete classes `ConsoleLogger` and `MemoryLogger` will no longer be `ILogger` (unless they declare it individually). Any code that stores a logger in an `ILogger` variable will fail to compile. Also, the default interface method `LogError` won't automatically be available. The fix: add `: ILogger` to `LoggerBase`.

---

**Q8.** Why does `GetEntries()` return `IReadOnlyList<string>` instead of `List<string>`?

> Returning `List<string>` would expose the internal collection and let callers call `.Add()` or `.Clear()` directly, bypassing `Log()` and corrupting `EntryCount`. `IReadOnlyList<string>` provides index access and Count but no mutation methods. This is the principle of encapsulation: expose the minimum API needed.
