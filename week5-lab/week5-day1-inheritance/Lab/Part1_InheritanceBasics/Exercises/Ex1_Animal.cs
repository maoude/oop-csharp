/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise on inheritance chains with Speak() virtual method and IsAdult() behavior.
 */

namespace OopCsharp.Week5.Part1_InheritanceBasics.Exercises;

// ============================================================
// Exercise 1 — Animal hierarchy
//
// Build a small inheritance chain:
//   Animal (base)
//     ├─ Dog   : Animal
//     └─ Cat   : Animal
//
// Requirements are listed as TODO comments inside each class.
// Do NOT change the constructor signatures or property names —
// the tests depend on them.
// ============================================================

public class Animal
{
    // TODO 1a: Add a public string property  Name  (get-only, set in constructor)
    // TODO 1b: Add a public int    property  Age   (get-only, set in constructor)

    // TODO 1c: Implement the constructor Animal(string name, int age)

    // TODO 1d: Override ToString() to return  "Animal: {Name}, age {Age}"
    //          Example: "Animal: Leo, age 3"

    // TODO 1e: Implement  virtual string Speak()
    //          Base implementation returns  "..."
    //          (derived classes will override this)
    public virtual string Speak() => throw new NotImplementedException();

    // TODO 1f: Implement  bool IsAdult()
    //          Returns true when Age >= 3
    public bool IsAdult() => throw new NotImplementedException();
}

public class Dog : Animal
{
    // TODO 2a: Add a public string property  Breed  (get-only, set in constructor)

    // TODO 2b: Implement the constructor Dog(string name, int age, string breed)
    //          Call base(name, age) — do not duplicate that logic.

    // TODO 2c: Override Speak() to return  "Woof!"

    // TODO 2d: Override ToString() to return  "Dog: {Name} ({Breed}), age {Age}"
    //          Example: "Dog: Rex (Labrador), age 5"
    public override string ToString() => throw new NotImplementedException();
}

public class Cat : Animal
{
    // TODO 3a: Add a public bool property  IsIndoor  (get-only, set in constructor)

    // TODO 3b: Implement the constructor Cat(string name, int age, bool isIndoor)
    //          Call base(name, age).

    // TODO 3c: Override Speak() to return  "Meow!"

    // TODO 3d: Implement  string Lifestyle()
    //          Returns "Indoor cat" when IsIndoor is true, otherwise "Outdoor cat"
    public string Lifestyle() => throw new NotImplementedException();
}
