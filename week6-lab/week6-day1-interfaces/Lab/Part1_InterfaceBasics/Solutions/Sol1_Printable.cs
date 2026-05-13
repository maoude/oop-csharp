/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for multiple interface implementation.
 *           Students compare their design against this model answer.
 */
namespace OopCsharp.Week6.Part1_InterfaceBasics.Solutions;

public interface IPrintable
{
    string ToPrintString();
}

public interface IPersistable
{
    string Serialize();
    void   Deserialize(string data);
}

public class Contact : IPrintable, IPersistable
{
    public string FirstName { get; }
    public string LastName  { get; }
    public string Email     { get; }

    public Contact(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName  = lastName;
        Email     = email;
    }

    public string ToPrintString() => $"Contact: {FirstName} {LastName} <{Email}>";
    public string Serialize()     => $"{FirstName}|{LastName}|{Email}";
    public void   Deserialize(string data) => throw new NotImplementedException();
}

public class Invoice : IPrintable, IPersistable
{
    public string InvoiceNumber { get; }
    public string Client        { get; }
    public double Amount        { get; }

    public Invoice(string invoiceNumber, string client, double amount)
    {
        InvoiceNumber = invoiceNumber;
        Client        = client;
        Amount        = amount;
    }

    public string ToPrintString() => $"Invoice #{InvoiceNumber} — {Client}: ${Amount:F2}";
    public string Serialize()     => $"{InvoiceNumber}|{Client}|{Amount}";
    public void   Deserialize(string data) => throw new NotImplementedException();
}
