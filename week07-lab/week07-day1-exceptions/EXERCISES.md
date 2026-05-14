# Exercises — Week 7 · Exception Handling

---

## Part 1 · Try / Catch / Finally — `Ex1_SafeCalculator.cs`

Build a `SafeCalculator` class that wraps arithmetic operations with proper exception handling.

**SafeCalculator**

`int Divide(int a, int b)`
- Throws `ArgumentException("Cannot divide by zero.")` when `b == 0`
- Returns `a / b` otherwise

`double ParseAndAdd(string a, string b)`
- Parses both strings as `double` (use `double.TryParse`)
- Throws `FormatException($"Not a valid number: '{a}'")`  if `a` cannot be parsed
- Throws `FormatException($"Not a valid number: '{b}'")`  if `b` cannot be parsed
- Returns `a + b` otherwise

`string? SafeRead(string[] data, int index)`
- Catches `IndexOutOfRangeException` and returns `null`
- Returns `data[index]` for valid indices
- **Rule:** use `try`/`catch` — not a bounds check

`int ParseWithFinally(string input, ref int attemptCount)`
- Increments `attemptCount` in a `finally` block (always runs)
- Returns the parsed `int` on success
- Throws `FormatException($"Bad input: {input}")` when parsing fails

---

## Part 2 · Custom Exceptions — `Ex1_Temperature.cs`

Build a domain exception and a thermometer class that uses it.

**TemperatureOutOfRangeException : Exception**

| Member | Description |
|--------|-------------|
| `double Temperature` | the rejected value (get-only) |
| `double Min` | lower bound of valid range (get-only) |
| `double Max` | upper bound of valid range (get-only) |

Standard constructors: parameterless, `(string message)`, `(string message, Exception inner)`

Domain constructor: `(double temperature, double min, double max)`  
→ message: `$"Temperature {temperature:F1}°C is outside the valid range [{min:F1}, {max:F1}]."`

**Thermometer**

| Member | Description |
|--------|-------------|
| `const double MinTemp` | `-273.15` |
| `const double MaxTemp` | `1000.0` |
| `double Temperature` | current reading (starts at `20.0`) |
| `void SetTemperature(double value)` | throws `TemperatureOutOfRangeException` if out of range |
| `double ReadAverageOrDefault(double[] readings, double defaultValue)` | average of valid readings, or `defaultValue` if none; resets `Temperature` to `20.0` after |

---

## Part 3 · Best Practices — `Ex1_SafeQueue.cs`

Build a generic queue wrapper that demonstrates `InvalidOperationException` and the TryXxx pattern.

**SafeQueue\<T\>**

| Member | Description |
|--------|-------------|
| `int Count` | number of items |
| `bool IsEmpty` | `true` when `Count == 0` |
| `void Enqueue(T item)` | throws `ArgumentNullException` when `item` is `null` |
| `T Dequeue()` | throws `InvalidOperationException("Queue is empty.")` when empty |
| `bool TryDequeue(out T? item)` | returns `false`/`default` when empty; **must not throw** |
| `void Clear()` | removes all items |
