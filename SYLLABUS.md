# Syllabus — Introduction to Object-Oriented Programming with C#

**Instructor:** Dr. Mohamad Aoude
**Institution:** Lebanese University, Faculty of Engineering
**Language:** C# / .NET
**Term length:** 14 weeks (10 lecture topics + labs + assessments)
**Audience:** Undergraduate, 2nd-year students with prior exposure to procedural programming

---

## Course Philosophy

> *Code reads more than it is written. Design for the reader, not the writer.*

This course teaches **principles of object design** using C# as the vehicle.
The syntax will fade; the design instincts will not. Students learn to read
broken code, name the problem, fix it, and defend the fix in writing.

---

## Course Promise

By the end of this course, students will be able to **design, implement,
and defend small object-oriented programs** that are correct, readable, and
testable. They will know when *not* to use inheritance, when *not* to add a
property, and when *not* to write a base class.

---

## Learning Outcomes

By the end of the course, students will be able to:

- Write and reason about C# programs involving methods, arrays, and classes
- Apply the four pillars of OOP (encapsulation, inheritance, polymorphism, abstraction) consciously
- Design class hierarchies using both inheritance and interfaces
- Override methods correctly and understand dynamic binding and polymorphism
- Use operator overloading and `ToString()` to make types expressive
- Handle errors robustly using C#'s exception hierarchy
- Manipulate strings efficiently using `String` and `StringBuilder`
- Perform file I/O using the `System.IO` class hierarchy and streams
- Choose between inheritance and composition based on a "has-a / is-a" analysis
- Produce defensible written explanations using the Explanation Quality Rubric

---

## Semester Roadmap

```
Phase 1  Foundations              (L01–L04)  ← Checkpoint 1
Phase 2  Object Relationships     (L05–L06)  ← Midterm
Phase 3  Practical OOP            (L07–L10)  ← Checkpoint 2 + Final
```

---

## Core Framework: The OOP Design Scorecard (Used Weekly)

Every lab submission must include a completed scorecard:

```
[ ] Encapsulated?           (fields private, behaviour exposed via methods/properties)
[ ] Single Responsibility?  (class has one reason to change)
[ ] Named clearly?          (names describe purpose, not implementation)
[ ] Testable?               (public API exercised by tests)
[ ] Documented?             (public surface has XML doc comments)
[ ] Immutable where possible? (readonly / init when state shouldn't change)
```

See `OOP_DESIGN_SCORECARD.md` for the editable template.

---

## Explanation Quality Rubric

- **Poor:** "I made it a class."
- **Good:** "I extracted state behind a property so callers can't put it into an invalid state."
- **Excellent:** "`Balance` is a read-only property; mutation goes through `Deposit`/`Withdraw`,
  which enforce the non-negative invariant. The invariant is unit-tested.
  Trade-off: one extra method call per access."

---

## Policies

- **Late policy:** −10% per day, max 3 days unless approved.
- **Revision policy:** Each checkpoint can be revised once after feedback, due 7 days after graded return.
- **Collaboration:** Discuss ideas freely; code and reports must be original.

---

## Phase 1 — Foundations (L01–L04)

### Lecture 01 — Introduction to C# · Methods · Console I/O

**Environment setup** (covered in the setup session before Lecture 01):
- Installing VS Code and the .NET SDK
- Creating and running the first console project (`dotnet new console`, `dotnet run`)
- Project structure: `.csproj`, `Program.cs`, `bin/`, `obj/`

**C# first look:**
- Basic program anatomy: `using`, `namespace`, `class`, `Main`
- `Console.Write` / `Console.WriteLine` / `Console.ReadLine` / `Console.ReadKey`
- Reading and parsing user input (`int.Parse`, `Convert.ToInt32`, etc.)

**Methods and behaviors:**
- Method declaration: return type, name, parameter list, body
- `void` vs value-returning methods
- Calling methods; passing arguments
- Optional parameters and default values
- Method body rules and scope

**Access modifiers:**
- `public`, `private`, `protected`, `internal` — visibility rules
- `static` modifier: static methods vs instance methods

**Parameters:**
- Pass-by-value (default)
- `ref`, `out`, `in` parameters and their semantics
- Method naming guidelines (PascalCase, verbs)

**Type system basics:**
- Primitive types (`int`, `double`, `bool`, `char`)
- Implicit and explicit type conversions
- `var` for local type inference

**Standard library methods:**
- `Console` class methods in depth
- `Math` class: `Sqrt`, `Pow`, `Abs`, `Round`, `Floor`, `Ceiling`, `Max`, `Min`
- Method overloading in the standard library

**Namespaces:**
- .NET namespace hierarchy; `using` directives
- Common namespaces: `System`, `System.IO`, `System.Collections.Generic`

**Method overloading:**
- Defining multiple methods with the same name, different signatures
- Compiler disambiguation rules

---

### Lecture 02 — Arrays in C#

**Array fundamentals:**
- What is an array? `System.Array` as the base type
- Array declaration syntax: `int[] arr;`
- Creating arrays: `new int[N]` and array initializers `{ 1, 2, 3 }`
- Memory layout: contiguous block, zero-based indexing
- Default values per type (0, false, null)

**Indexing and bounds:**
- Accessing elements: `arr[i]`
- `Length` property
- `IndexOutOfRangeException` — what it is and how to avoid it

**Iterating arrays:**
- `for` loop with index
- `foreach` loop — when to prefer it
- Implicitly typed variables inside `foreach`

**Common array operations:**
- Summing elements; computing averages
- Finding min/max
- Building a bar chart from data
- Sorting: `Array.Sort()`
- Searching: `Array.BinarySearch()`, `Array.IndexOf()`

**Multi-dimensional arrays:**
- Rectangular arrays: `int[,] grid = new int[3, 4];`
- Jagged arrays: `int[][] jagged;`
- Accessing rows and columns

**Common `Array` class methods:**
- `Array.Copy`, `Array.Reverse`, `Array.Clear`
- `Array.Exists`, `Array.Find`, `Array.FindAll`

**Implicitly typed arrays:**
- `var nums = new[] { 1, 2, 3 };` — compiler infers element type

---

### Lecture 03 — Classes in C# (Part 1)

**Introduction to classes:**
- The `class` keyword; objects as instances of classes
- Instance vs static members
- Fields, properties, methods — what belongs where

**Instance variables and properties:**
- Private fields with public properties (full property pattern)
- Auto-implemented properties: `public int Age { get; set; }`
- `init`-only setters for immutable construction
- Choosing between auto-properties and full properties with validation

**The `this` reference:**
- Disambiguating field vs parameter names
- Calling instance methods via `this`
- Constructor chaining with `this(...)`

**Constructors:**
- Default constructor; parameterized constructor
- Constructor overloading — multiple constructors in one class
- Constructor chaining: calling one constructor from another
- Object initializer syntax: `new Person { Name = "Alice", Age = 30 }`

**`readonly` modifier:**
- `readonly` fields — set only in declaration or constructor
- Difference between `readonly` and `const`
- Why `readonly` promotes immutability

**Default values in C#:**
- Value types default to zero, `bool` to `false`, reference types to `null`

**Method overloading (in the context of classes):**
- Overloading instance methods
- Compiler resolution: parameter count and type matching
- Common pitfall: overloads that differ only in return type (illegal)

---

### Lecture 04 — Classes in C# (Part 2)

**Operator overloading:**
- Why operator overloading: making user-defined types feel natural
- Syntax: `public static T operator +(T a, T b)`
- Overloadable vs non-overloadable operators
- Binary operator overloading (e.g., `+`, `-`, `*`, `/`, `==`, `!=`)
- Unary operator overloading (e.g., `++`, `--`, `!`, `-`)
- Prefix vs postfix `++`/`--` — the `int` dummy parameter convention
- Commutative operators: must define both `T + scalar` and `scalar + T`
- Limitations: cannot overload `&&`, `||`, `?:`, `=`, etc.

**Special operators:**
- Conversion operators: `implicit` and `explicit`
- Equality: overloading `==` and `!=` requires overriding `Equals` and `GetHashCode`

**The `ToString()` method:**
- Every type inherits `ToString()` from `object`
- Overriding `ToString()` for human-readable output
- Using `ToString()` with format specifiers (`"F2"`, `"C"`, etc.)
- Automatic invocation in string interpolation and `Console.WriteLine`

**Floating-point and the `decimal` type:**
- `float` vs `double` vs `decimal` — precision and range
- When to use `decimal`: financial calculations requiring exact decimal arithmetic
- Formatting floating-point output: `ToString("F2")`, `String.Format`

**Worked examples:**
- `Vector` class with overloaded `+`, scalar `*`, and `ToString()`
- `Counter` class with overloaded prefix and postfix `++`

---

## Phase 2 — Object Relationships (L05–L06)

### Lecture 05 — Inheritance

**Inheritance fundamentals:**
- The `class Child : Parent` syntax
- "Is-a" relationship: when inheritance is appropriate
- What is inherited: fields, methods, properties (not constructors)
- `base()` to call the parent constructor
- `base.Method()` to call a parent method from an override

**Inheritance terminology:**
- Base class / derived class (superclass / subclass)
- Single inheritance in C# (one direct parent only)
- Hierarchical structures: shape hierarchy, university community, vehicle taxonomy

**Polymorphism:**
- Treating derived-class objects as base-class references
- `virtual` methods: declaring a method overridable in the base class
- `override` in the derived class: providing a new implementation
- Dynamic (late) binding: the actual method called is determined at runtime

**Hiding vs overriding:**
- `new` keyword: hiding a base method (static binding — dangerous)
- `override` keyword: true polymorphic dispatch (dynamic binding)
- Why hiding is almost always wrong

**`abstract` members and classes:**
- `abstract` method: declared but not implemented in the base class
- `abstract` class: cannot be instantiated directly
- Forcing derived classes to provide implementations

**`sealed` keyword:**
- `sealed class`: cannot be subclassed
- `sealed override`: no further overriding allowed in the chain

**Access modifiers in inheritance:**
- `protected`: accessible in the class and all derived classes
- Why fields should still be `private` even with inheritance (use `protected` properties)

**The `object` class:**
- Every class implicitly inherits from `System.Object`
- `GetType()` — runtime type information
- `ToString()` — overriding for meaningful output
- Implicit reference conversions up the hierarchy

**Composition vs inheritance:**
- "Has-a" vs "is-a" — diagnosing the right relationship
- When composition is the better choice

**Worked examples:**
- `Employee` / `Manager` hierarchy
- `Vehicle` / `Car` / `Truck` hierarchy
- `Student` / `ScholarshipStudent` with protected access

---

### Lecture 06 — Interfaces · Abstract Classes

**The multiple inheritance problem:**
- C# allows only single class inheritance
- The diamond problem: why multiple class inheritance is dangerous
- How interfaces solve this

**Interfaces in C#:**
- `interface` keyword: a pure contract — no implementation state
- Members of an interface: methods, properties, events, indexers (all implicitly `public abstract`)
- Implementing an interface: `class Foo : IBar`
- A class can implement multiple interfaces simultaneously

**Implicit vs explicit implementation:**
- Implicit: `public void Draw() { ... }` — accessible directly on the class
- Explicit: `void IShape.Draw() { ... }` — only accessible through the interface reference

**Multiple interface inheritance:**
- An interface can extend other interfaces: `interface IC : IA, IB`
- A class implementing `IC` must satisfy all members from `IA`, `IB`, and `IC`

**Common built-in interfaces:**
- `IComparable<T>`: natural ordering via `CompareTo`
- `IEnumerable<T>`: support for `foreach`
- `IDisposable`: deterministic resource cleanup
- `ICloneable`: object copying

**Default interface methods (C# 8.0+):**
- Adding a method with a default body to an interface without breaking implementors
- Careful use: does not replace abstract classes; has surprising dispatch rules

**Interface best practices:**
- Name interfaces with an `I` prefix (`IShape`, `ILogger`)
- Keep interfaces small and focused (Interface Segregation Principle)
- Design the interface before writing the implementation
- Prefer interface references in method signatures over concrete types

**Abstract classes vs interfaces:**

| Feature | Abstract Class | Interface |
|---|---|---|
| Can have fields | Yes | No |
| Can have constructors | Yes | No |
| Implementation state | Yes | No (default methods only) |
| Multiple inheritance | No | Yes |
| Use when | Shared base behaviour + state | Contract only; multiple implementors |

**Polymorphism via interfaces:**
- Assigning any implementing class to an interface variable
- Runtime dispatch through the interface — same as virtual dispatch

**Worked examples:**
- `IWorkable` interface with `abstract class Worker` and concrete subclasses
- Replacing an inheritance hierarchy with an interface + composition

---

## Phase 3 — Practical OOP (L07–L10)

### Lecture 07 — Exception Handling

**Why exceptions?**
- Errors at runtime that cannot be caught at compile time
- Separating normal logic from error-handling logic

**Basics of exception handling:**
- `try` block: code that might throw
- `catch` block: code that handles a specific exception type
- `finally` block: code that always runs (cleanup, closing resources)
- Exception filters: `catch (IOException ex) when (ex.Message.Contains("denied"))`

**Throwing exceptions:**
- `throw new ExceptionType("message");`
- Re-throwing with `throw;` (preserves stack trace) vs `throw ex;` (loses it)
- Throwing from inside a `catch` block

**The .NET exception hierarchy:**
- `System.Exception` — base of all exceptions
- `System.SystemException` — system-level issues
  - `NullReferenceException`, `IndexOutOfRangeException`, `InvalidCastException`,
    `OverflowException`, `StackOverflowException`, `OutOfMemoryException`
- `System.IO.IOException` and derived types:
  - `FileNotFoundException`, `DirectoryNotFoundException`, `EndOfStreamException`
- Other common exceptions: `ArgumentException`, `ArgumentNullException`,
  `ArgumentOutOfRangeException`, `FormatException`, `DivideByZeroException`

**Custom exception classes:**
- Deriving from `Exception` or a more specific base
- Providing constructors that chain to the base (`base(message)`, `base(message, inner)`)
- Adding domain-specific properties to the exception

**Advanced patterns:**
- Catching multiple exception types
- Exception hierarchy: catching a base type catches all derived types
- Unhandled exceptions: `AppDomain.UnhandledException` event
- Exception handling combined with file I/O

**Object-oriented exception design:**
- When *not* to throw: `bool TryParse(string s, out int result)` pattern
- Fail fast vs defensive programming

**Best practices:**
- Never swallow exceptions with an empty `catch` block
- Always log or rethrow; never silently discard
- Clean up resources in `finally` or use the `using` statement
- Prefer specific exception types over catching the base `Exception`

---

### Lecture 08 — Strings and StringBuilder

**Characters in C#:**
- `char` type: a single Unicode character (UTF-16 code unit)
- Character literals: `'A'`, `'\n'`, `'\t'`, `'\\'`
- `char` methods via `System.Char`: `IsLetter`, `IsDigit`, `IsWhiteSpace`, `ToUpper`, `ToLower`

**String fundamentals:**
- `string` is an alias for `System.String`
- Strings are **immutable** reference types
- String literals: `"hello"`, verbatim strings `@"C:\path\to\file"`, multiline verbatim strings
- String interning: identical literals share the same object in memory

**String construction:**
- Constructors: from `char[]`, from a repeated character, from a substring of `char[]`
- String indexer: `s[i]` returns the `char` at index `i`
- `Length` property

**String search methods:**
- `IndexOf(char)`, `IndexOf(string)`, `LastIndexOf`
- `Contains`, `StartsWith`, `EndsWith`
- `IndexOfAny`

**Substring extraction:**
- `Substring(startIndex)`, `Substring(startIndex, length)`
- `Split(separator)` — splitting into an array

**String manipulation:**
- `ToUpper()`, `ToLower()`
- `Trim()`, `TrimStart()`, `TrimEnd()`
- `Replace(old, new)`
- `Insert(index, value)`, `Remove(startIndex, count)`
- String comparison: `==`, `Equals`, `Compare`, `CompareOrdinal`
- String formatting: `String.Format("Hello {0}", name)`, interpolation `$"Hello {name}"`

**`StringBuilder` — mutable string building:**
- Why `StringBuilder`: avoids creating many intermediate `string` objects
- `StringBuilder(initialCapacity)` constructor; capacity grows automatically
- `Length` and `Capacity` properties; `EnsureCapacity(min)`
- Character indexer: `sb[i]` — readable and writable
- `Append`, `AppendLine`, `AppendFormat` — adding to the end
- `Insert(index, value)` — inserting in the middle
- `Remove(startIndex, count)` — deleting characters
- `Replace(old, new)` — in-place replacement
- `ToString()` — convert back to an immutable `string`

**Performance tips:**
- Use `string` for values that rarely change; `StringBuilder` for repeated concatenation in loops
- String concatenation in a loop is O(n²); `StringBuilder.Append` is O(1) amortised

---

### Lecture 09 — Files in C# (Part 1) · File and Directory Classes

**What is a computer file?**
- Persistent named collection of data on secondary storage
- File organisation: characters → fields → records → files
- Sequential vs random access files

**`System.IO` class hierarchy:**
- `File` (static methods) vs `FileInfo` (instance, one object per file)
- `Directory` (static methods) vs `DirectoryInfo` (instance)
- When to use the static class vs the instance class

**The `File` class (static methods):**
- `File.Exists(path)` — check existence
- `File.Create(path)`, `File.Delete(path)`, `File.Copy(src, dst)`, `File.Move(src, dst)`
- `File.ReadAllText(path)`, `File.WriteAllText(path, text)`
- `File.ReadAllLines(path)`, `File.WriteAllLines(path, lines)`
- `File.AppendAllText(path, text)`

**The `Directory` class (static methods):**
- `Directory.Exists(path)`, `Directory.CreateDirectory(path)`, `Directory.Delete(path)`
- `Directory.GetFiles(path, pattern)`, `Directory.GetDirectories(path)`
- `Directory.GetCurrentDirectory()`, `Directory.SetCurrentDirectory(path)`

**`FileInfo` and `DirectoryInfo` (instance classes):**
- Properties: `Name`, `FullName`, `Extension`, `Length`, `CreationTime`, `LastWriteTime`
- Methods mirror the static classes but operate on the instance's path
- Efficient for repeated operations on the same file (avoids repeated path parsing)

**Handling file paths:**
- Hard-coded paths are fragile — use `Path.Combine` and relative paths
- `Path.GetFileName`, `Path.GetExtension`, `Path.GetDirectoryName`
- Debug vs Release output directories: why paths differ in the IDE vs production

**Best practices:**
- Always check `File.Exists` before reading
- Wrap file operations in `try`/`catch` to handle `IOException`, `UnauthorizedAccessException`
- Prefer `using` statement for streams (Lecture 10)

---

### Lecture 10 — Files in C# (Part 2) · Streams and File I/O

**The data hierarchy revisited:**
- Characters → Fields → Records → Files — how text files map to this model

**What is a stream?**
- A stream is a sequence of bytes flowing from a source to a destination
- Abstraction: the application does not need to know whether the source is a file,
  a network socket, or memory

**Stream direction:**
- Input stream: data flows *into* the program (reading)
- Output stream: data flows *out of* the program (writing)
- Some streams are bidirectional

**Standard streams:**
- `Console.In` — standard input (`TextReader`)
- `Console.Out` — standard output (`TextWriter`)
- `Console.Error` — standard error (`TextWriter`)

**`System.IO` stream class hierarchy:**
- `Stream` (abstract base): `Read`, `Write`, `Seek`, `Flush`, `Close`
- `FileStream`: raw byte access to a file
- `MemoryStream`: in-memory byte buffer
- `BufferedStream`: adds a buffer over another stream
- Text adapters: `StreamReader` / `StreamWriter` wrap a `Stream` and handle encoding

**`FileStream` class:**
- Constructor: `new FileStream(path, FileMode, FileAccess, FileShare)`
- `FileMode` values: `Create`, `Open`, `OpenOrCreate`, `Append`, `Truncate`
- `FileAccess` values: `Read`, `Write`, `ReadWrite`
- Reading bytes: `Read(buffer, offset, count)` — returns bytes actually read
- Writing bytes: `Write(buffer, offset, count)`
- `Seek(offset, SeekOrigin)` for random access
- Always call `Close()` or wrap in `using`

**`StreamReader` / `StreamWriter` (text-oriented):**
- `StreamReader sr = new StreamReader(path, Encoding.UTF8)`
- `sr.ReadLine()`, `sr.ReadToEnd()`
- `StreamWriter sw = new StreamWriter(path, append: false)`
- `sw.WriteLine(text)`, `sw.Flush()`

**The `using` statement for streams:**
- Guarantees `Dispose()` (and therefore `Close()`) is called even if an exception is thrown
- `using (var sr = new StreamReader(path)) { ... }`
- C# 8+ `using` declaration: `using var sr = new StreamReader(path);`

**File-processing patterns:**
- Read all lines with `StreamReader` in a `while` loop
- Write a CSV file with `StreamWriter`
- Binary files with `BinaryReader` / `BinaryWriter` (overview)

**Best practices:**
- Always use `using` — never leave streams open
- Prefer `StreamReader`/`StreamWriter` over raw `FileStream` for text
- Specify encoding explicitly (`Encoding.UTF8`) to avoid platform surprises
- Buffer large reads/writes for performance

---

### Lecture 11 — Tokenizers · Semi-Structured Data · JSON

#### Part A — What is a Tokenizer?

**The problem tokenizers solve:**
- A plain text file is just a stream of characters; programs need *meaning*, not characters
- A **tokenizer** (also called a *lexer*) reads a stream of characters and groups them into
  meaningful units called **tokens**: numbers, words, punctuation, strings, etc.
- Example: the string `"age": 25` is four tokens: `"age"` (string), `:` (colon), `25` (number)

**Token types:**
- A token has two parts: a **kind** (what type of thing it is) and a **value** (the raw text)
- Common token kinds: `StringLiteral`, `NumberLiteral`, `Colon`, `Comma`,
  `LeftBrace`, `RightBrace`, `LeftBracket`, `RightBracket`, `BooleanLiteral`, `Null`

**How a simple tokenizer works — step by step:**
1. Start at position 0 in the input string
2. Skip whitespace (spaces, tabs, newlines — they are not tokens)
3. Look at the current character to decide what comes next:
   - `{` or `}` → emit a brace token; advance one character
   - `[` or `]` → emit a bracket token; advance one character
   - `:` or `,` → emit a punctuation token; advance one character
   - `"` → enter string mode: read until the closing `"`, emit a `StringLiteral`
   - `0`–`9` or `-` → enter number mode: read digits (and `.` for decimals), emit a `NumberLiteral`
   - `t`, `f` → try to read `true` or `false`, emit a `BooleanLiteral`
   - `n` → try to read `null`, emit a `Null` token
4. Repeat until the end of the input

**Designing a `Token` class:**
```csharp
public enum TokenKind
{
    LeftBrace, RightBrace, LeftBracket, RightBracket,
    Colon, Comma,
    StringLiteral, NumberLiteral, BooleanLiteral, Null
}

public class Token
{
    public TokenKind Kind  { get; init; }
    public string   Value  { get; init; }

    public Token(TokenKind kind, string value)
    {
        Kind  = kind;
        Value = value;
    }

    public override string ToString() => $"[{Kind}] \"{Value}\"";
}
```

**Designing a `Tokenizer` class:**
- Fields: the input string, current position index
- Method `Tokenize()` returns `List<Token>`
- Private helpers: `SkipWhitespace()`, `ReadString()`, `ReadNumber()`, `ReadKeyword()`
- Uses `string` indexer and `Length` from Lecture 08
- Throws a custom `TokenizerException` (Lecture 07) on unexpected characters

**Why this matters for OOP:**
- `Token` is a small immutable value object (init-only properties, `readonly`)
- `Tokenizer` has a single responsibility: convert text to tokens
- The `TokenKind` enum replaces magic strings — applying the pitfall fix from P1.3

---

#### Part B — Semi-Structured Data and JSON

**What is structured data?**
- **Structured data**: rigid schema fixed in advance (e.g., a C# class with known fields,
  a database table with fixed columns)
- **Unstructured data**: no schema at all (e.g., a plain paragraph of text)
- **Semi-structured data**: has *some* structure, but the schema is embedded in the data itself
  and can vary between records — no rigid columns required

**JSON — JavaScript Object Notation:**
- A widely used text format for semi-structured data
- Human-readable, language-independent
- Used everywhere: web APIs, configuration files, data storage, inter-service communication

**JSON value types (the complete list):**

| JSON type | Example | C# equivalent |
|---|---|---|
| String | `"hello"` | `string` |
| Number | `42`, `3.14`, `-7` | `int`, `double`, `decimal` |
| Boolean | `true`, `false` | `bool` |
| Null | `null` | `null` |
| Object | `{ "key": value }` | dictionary / class |
| Array | `[ 1, 2, 3 ]` | list / array |

**JSON objects:**
- Delimited by `{` and `}`
- A comma-separated list of key–value pairs
- Every key is a **string** (always quoted with `"`)
- The value can be any JSON value type

```json
{
  "name": "Alice",
  "age": 30,
  "isStudent": false,
  "score": 97.5
}
```

**JSON arrays:**
- Delimited by `[` and `]`
- A comma-separated ordered list of values (any type, can be mixed)

```json
[ "apple", "banana", "cherry" ]
[ 1, 2, 3 ]
```

**Nesting — the key feature of semi-structured data:**
- Objects and arrays can be nested inside each other to arbitrary depth

```json
{
  "student": {
    "name": "Bob",
    "grades": [ 85, 92, 78 ],
    "address": {
      "city": "Beirut",
      "country": "Lebanon"
    }
  }
}
```

**How to read JSON manually (before using a library):**
- The tokenizer (Part A) produces a flat list of tokens
- A **parser** then reads that list of tokens and builds a tree structure:
  - Sees `{` → start of an object, read key–value pairs until `}`
  - Sees `[` → start of an array, read values until `]`
  - Sees a string followed by `:` → this is a key; what follows is its value
- This tree is called a **parse tree** or **abstract syntax tree (AST)**

**The `System.Text.Json` library (C# built-in):**
- `JsonDocument.Parse(jsonString)` — parse JSON into a navigable tree
- `JsonElement` — represents one node in the JSON tree
- `element.GetProperty("name")` — get a child by key
- `element.GetString()`, `element.GetInt32()`, `element.GetDouble()`, `element.GetBoolean()`
- `element.EnumerateArray()` — iterate over a JSON array
- `element.EnumerateObject()` — iterate over all key–value pairs in an object
- `element.ValueKind` — returns `JsonValueKind.Object`, `.Array`, `.String`, `.Number`, etc.

```csharp
using System.Text.Json;

string json = """
{
  "name": "Alice",
  "age": 30,
  "scores": [85, 92, 78]
}
""";

using JsonDocument doc = JsonDocument.Parse(json);
JsonElement root = doc.RootElement;

string name   = root.GetProperty("name").GetString();
int    age    = root.GetProperty("age").GetInt32();

foreach (JsonElement score in root.GetProperty("scores").EnumerateArray())
{
    Console.WriteLine(score.GetInt32());
}
```

**Deserializing JSON into C# objects (`JsonSerializer`):**
- `JsonSerializer.Deserialize<T>(jsonString)` — map JSON directly onto a C# class
- The class must have public properties whose names match the JSON keys (case-insensitive by default)
- `[JsonPropertyName("some_key")]` attribute — override the name mapping

```csharp
public class Student
{
    public string Name   { get; set; }
    public int    Age    { get; set; }
    public int[]  Scores { get; set; }
}

Student student = JsonSerializer.Deserialize<Student>(json);
Console.WriteLine(student.Name);   // Alice
```

**Serializing C# objects to JSON:**
- `JsonSerializer.Serialize(obj)` — convert an object back to a JSON string
- `JsonSerializerOptions` — control formatting: `WriteIndented = true` for pretty-print

**Common mistakes with JSON (pitfalls):**
- Forgetting that JSON keys are always strings (never unquoted)
- Using a trailing comma after the last element (JSON does not allow it)
- Confusing `null` (the JSON value) with an absent key
- Assuming the order of keys in an object is significant (it is not)
- Forgetting to dispose `JsonDocument` — always use `using`

**Lab exercise outline:**
1. Write a `Tokenizer` by hand and run it on a small JSON string; print every token
2. Use `JsonDocument` to navigate a nested JSON structure and extract specific values
3. Deserialize a JSON array of student records into `List<Student>` and sort by score
4. Serialize a list of objects to a JSON file and read it back

---

## Checkpoints and Portfolio Weighting

| Assessment | Weight | Topics Covered |
|---|---:|---|
| Checkpoint 1 — Class design refactor | 10% | L01–L04 |
| Midterm — Inheritance & interfaces design | 25% | L01–L06 |
| Checkpoint 2 — File I/O mini-project | 15% | L07–L10 |
| Final project — Complete OOP system | 30% | All lectures |
| Design Decision Memo | 20% | Submitted with Final |

Portfolio sub-weights sum to 80%; the Design Decision Memo is the remaining 20%.

---

## Progressive Visual Requirements

- **Checkpoint 1:** UML class diagram for the class hierarchy you designed
- **Midterm:** UML class diagram showing the inheritance/interface relationships
- **Final:** Sequence diagram for one end-to-end workflow in the final project

---

## Case Studies (10-minute class discussion)

- **After L04 (Checkpoint 1):** Therac-25 — what happens when class invariants are not enforced
- **After L06 (Midterm):** Java's old `Date` API — broken polymorphism and the lessons learned;
  parallel C# example with `DateTime` vs `DateTimeOffset`
- **After L10 (Final):** C++ `std::vector<bool>` — the cost of breaking an abstraction's contract

---

## Rule of the Course

> *Code reads more than it is written. Design for the reader, not the writer.*
