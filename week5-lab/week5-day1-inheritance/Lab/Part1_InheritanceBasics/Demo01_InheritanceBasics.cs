/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate inheritance basics, constructor chaining, base.Method() calls, and member hiding patterns.
 */

namespace OopCsharp.Week5.Part1_InheritanceBasics;

// ============================================================
// DEMO 01 — Inheritance Basics
// Topics: class Child : Parent, "is-a" relationship,
//         base() constructor call, base.Method(), member hiding
// ============================================================

// ----------------------------------------------------------
// Section 1: The "is-a" relationship
// ----------------------------------------------------------
// Inheritance models an "is-a" relationship.
// A Dog IS-A Animal.  A SavingsAccount IS-A BankAccount.
// Use it only when that sentence is genuinely true.
//
// Syntax:  class Child : Parent { }
//
// Every class implicitly inherits from object if no parent is named.

public class Animal
{
    public string Name { get; }
    public int    Age  { get; }

    public Animal(string name, int age)
    {
        Name = name;
        Age  = age;
    }

    // A method defined in the base class is inherited by all derived classes.
    public string Describe() => $"{Name} (age {Age})";

    // ToString override so Console.WriteLine prints something useful.
    public override string ToString() => $"Animal: {Name}";
}

public class Dog : Animal
{
    public string Breed { get; }

    // ----------------------------------------------------------
    // Section 2: base() constructor call
    // ----------------------------------------------------------
    // The derived constructor MUST call a base constructor.
    // If not written explicitly, the compiler tries base() — the
    // parameterless constructor.  Animal has no parameterless ctor,
    // so we must call base(name, age) explicitly.
    public Dog(string name, int age, string breed)
        : base(name, age)          // delegates name + age to Animal
    {
        Breed = breed;
    }

    // Dog inherits Describe() from Animal — no need to re-write it.

    public override string ToString() => $"Dog: {Name} ({Breed})";
}

public class GuideDog : Dog
{
    public string Owner { get; }

    public GuideDog(string name, int age, string breed, string owner)
        : base(name, age, breed)   // delegates up to Dog, which delegates to Animal
    {
        Owner = owner;
    }

    // ----------------------------------------------------------
    // Section 3: base.Method() — calling the parent's implementation
    // ----------------------------------------------------------
    // We can call the parent version of any method with base.Method().
    public string FullDescription()
        => base.Describe() + $", breed: {Breed}, guides: {Owner}";
}

// ----------------------------------------------------------
// Section 4: Member hiding with 'new' (discouraged)
// ----------------------------------------------------------
// If a derived class declares a method with the same name WITHOUT
// 'override', the compiler warns and the method merely *hides*
// the base version — it does NOT participate in polymorphism.
//
// The correct solution is virtual + override (see Demo 02).
// 'new' is shown here only so you recognise it.

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    // 'new' hides the base Describe() for Cat references only.
    // Animal-typed references still call the original.
    public new string Describe() => $"{Name} says meow";
}

// ----------------------------------------------------------
// Section 5: Access modifiers in inheritance
// ----------------------------------------------------------
// public    — visible everywhere
// protected — visible inside the class AND all derived classes
// private   — visible ONLY inside the declaring class (never inherited)
// internal  — visible inside the same assembly

public class Vehicle
{
    public    string Brand   { get; }
    protected int    Speed   { get; set; }   // derived classes can read/write
    private   int    _secret = 42;            // derived classes cannot touch this

    public Vehicle(string brand) => Brand = brand;

    public string GetInfo() => $"{Brand} at {Speed} km/h";
}

public class Car : Vehicle
{
    public Car(string brand) : base(brand)
    {
        Speed = 120;  // OK — protected
        // _secret = 0;  // compile error — private
    }
}

// ----------------------------------------------------------
// Section 6: Inheritance chain demo
// ----------------------------------------------------------
internal static class Demo01Runner
{
    internal static void Run()
    {
        var animal = new Animal("Leo", 3);
        Console.WriteLine(animal.Describe());   // "Leo (age 3)"

        var dog = new Dog("Rex", 5, "Labrador");
        Console.WriteLine(dog.Describe());      // inherited: "Rex (age 5)"
        Console.WriteLine(dog);                 // overridden ToString

        var guide = new GuideDog("Buddy", 4, "Golden Retriever", "Alice");
        Console.WriteLine(guide.FullDescription());

        // ------ Member hiding illustration ------
        var cat    = new Cat("Whiskers", 2);
        Animal catAsAnimal = cat;
        Console.WriteLine(cat.Describe());          // Cat's hidden version
        Console.WriteLine(catAsAnimal.Describe());  // Animal's original — hiding ≠ polymorphism!

        // ------ Upcast ------
        Animal a = dog;            // implicit — always safe
        Console.WriteLine(a.Describe());   // "Rex (age 5)"

        // ------ Downcast ------
        if (a is Dog d)            // safe pattern-based downcast
            Console.WriteLine(d.Breed);
    }
}
