# Checklist — Week 7 · Exception Handling

---

## Part 1 — Try / Catch / Finally

- [ ] **W7.P1.Ex1 — SafeCalculator** · `StudentWeek7Part1_Ex1Tests` · 12 tests
  - [ ] `Divide()` returns correct quotient for valid inputs
  - [ ] `Divide()` throws `ArgumentException` when divisor is zero
  - [ ] `ParseAndAdd()` returns correct sum for two valid strings
  - [ ] `ParseAndAdd()` throws `FormatException` for invalid first operand
  - [ ] `ParseAndAdd()` throws `FormatException` for invalid second operand
  - [ ] `SafeRead()` returns element at valid index
  - [ ] `SafeRead()` returns `null` for out-of-range index (uses `try`/`catch`)
  - [ ] `ParseWithFinally()` returns parsed int and increments `attemptCount`
  - [ ] `ParseWithFinally()` increments `attemptCount` even when parsing fails
  - [ ] `ParseWithFinally()` throws `FormatException` for invalid input

---

## Part 2 — Custom Exceptions

- [ ] **W7.P2.Ex1 — Temperature** · `StudentWeek7Part2_Ex1Tests` · 13 tests
  - [ ] `TemperatureOutOfRangeException` inherits from `Exception`
  - [ ] Domain constructor sets `Temperature`, `Min`, `Max`
  - [ ] Exception message contains the temperature value
  - [ ] `Thermometer` starts at `20.0`
  - [ ] `SetTemperature()` updates value for valid input
  - [ ] `SetTemperature()` throws for value below `MinTemp`
  - [ ] `SetTemperature()` throws for value above `MaxTemp`
  - [ ] `ReadAverageOrDefault()` returns correct mean of valid readings
  - [ ] `ReadAverageOrDefault()` skips out-of-range readings
  - [ ] `ReadAverageOrDefault()` returns `defaultValue` when all readings are invalid
  - [ ] `ReadAverageOrDefault()` resets `Temperature` to `20.0` when done

---

## Part 3 — Best Practices

- [ ] **W7.P3.Ex1 — SafeQueue** · `StudentWeek7Part3_Ex1Tests` · 12 tests
  - [ ] New queue has `Count == 0` and `IsEmpty == true`
  - [ ] `Enqueue(null)` throws `ArgumentNullException`
  - [ ] `Enqueue()` increases `Count`
  - [ ] `Dequeue()` returns items in FIFO order
  - [ ] `Dequeue()` throws `InvalidOperationException` on empty queue
  - [ ] `TryDequeue()` returns `true` and the item when non-empty
  - [ ] `TryDequeue()` returns `false` and `default` when empty
  - [ ] `TryDequeue()` never throws
  - [ ] `Clear()` resets `Count` to zero

---

## Final check

- [ ] All 37 tests pass: `dotnet test Lab.Tests/`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in
- [ ] `QUIZ_QUESTIONS.md` read at least once
