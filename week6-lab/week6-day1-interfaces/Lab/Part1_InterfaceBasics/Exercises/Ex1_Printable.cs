/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: declare multiple interfaces and implement them on
 *           concrete classes. Practice interface contracts, multiple inheritance,
 *           and polymorphic method calls via interface-typed variables.
 */
namespace OopCsharp.Week6.Part1_InterfaceBasics.Exercises;

// ============================================================
// Exercise 1 — IPrintable and IPersistable
//
// Declare two interfaces and implement them on two concrete classes.
//
//   IPrintable   — defines  string ToPrintString()
//   IPersistable — defines  string Serialize()  and
//                           void   Deserialize(string data)  [stub only — not tested]
//
//   Contact  : implements IPrintable + IPersistable
//   Invoice  : implements IPrintable + IPersistable
//
// Do NOT change property names or interface method signatures.
// ============================================================

// TODO 1: Declare interface IPrintable
//   Member: string ToPrintString()
//           (returns a human-readable single-line summary)

// TODO 2: Declare interface IPersistable
//   Members:
//     string Serialize()              — returns a serialised representation
//     void   Deserialize(string data) — restores state from that string
//             (leave the body as throw new NotImplementedException() — not tested)

// TODO 3: Implement class Contact : IPrintable, IPersistable
//   Properties (get-only, set by constructor):
//     string FirstName
//     string LastName
//     string Email
//   Constructor: Contact(string firstName, string lastName, string email)
//
//   ToPrintString() →  "Contact: {FirstName} {LastName} <{Email}>"
//                       Example: "Contact: Ada Lovelace <ada@example.com>"
//
//   Serialize()     →  "{FirstName}|{LastName}|{Email}"
//                       Example: "Ada|Lovelace|ada@example.com"
//
//   Deserialize(string data) → throw new NotImplementedException()

public class Contact
{
    // Replace this stub with the full implementation described above.
    public string ToPrintString() => throw new NotImplementedException();
    public string Serialize()     => throw new NotImplementedException();
    public void   Deserialize(string data) => throw new NotImplementedException();
}

// TODO 4: Implement class Invoice : IPrintable, IPersistable
//   Properties (get-only, set by constructor):
//     string InvoiceNumber
//     string Client
//     double Amount
//   Constructor: Invoice(string invoiceNumber, string client, double amount)
//
//   ToPrintString() →  "Invoice #{InvoiceNumber} — {Client}: ${Amount:F2}"
//                       Example: "Invoice #INV-001 — Acme Corp: $1500.00"
//
//   Serialize()     →  "{InvoiceNumber}|{Client}|{Amount}"
//                       Example: "INV-001|Acme Corp|1500"
//
//   Deserialize(string data) → throw new NotImplementedException()

public class Invoice
{
    // Replace this stub with the full implementation described above.
    public string ToPrintString() => throw new NotImplementedException();
    public string Serialize()     => throw new NotImplementedException();
    public void   Deserialize(string data) => throw new NotImplementedException();
}
