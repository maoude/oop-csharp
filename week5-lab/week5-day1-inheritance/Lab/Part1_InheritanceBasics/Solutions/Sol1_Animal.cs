/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Animal hierarchy with Dog and Cat implementations.
 */

namespace OopCsharp.Week5.Part1_InheritanceBasics.Solutions;

public class Animal
{
    public string Name { get; }
    public int    Age  { get; }

    public Animal(string name, int age)
    {
        Name = name;
        Age  = age;
    }

    public override string ToString() => $"Animal: {Name}, age {Age}";

    public virtual string Speak() => "...";

    public bool IsAdult() => Age >= 3;
}

public class Dog : Animal
{
    public string Breed { get; }

    public Dog(string name, int age, string breed)
        : base(name, age)
    {
        Breed = breed;
    }

    public override string Speak() => "Woof!";

    public override string ToString() => $"Dog: {Name} ({Breed}), age {Age}";
}

public class Cat : Animal
{
    public bool IsIndoor { get; }

    public Cat(string name, int age, bool isIndoor)
        : base(name, age)
    {
        IsIndoor = isIndoor;
    }

    public override string Speak() => "Meow!";

    public string Lifestyle() => IsIndoor ? "Indoor cat" : "Outdoor cat";
}
