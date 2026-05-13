# OOP Design Scorecard — Week 7 · Exception Handling

Fill in each row after completing the lab.  
Rate yourself: **✓ done** · **△ partial** · **✗ not yet**

---

| # | Design principle | Self-rating | Notes |
|---|-----------------|-------------|-------|
| 1 | Exceptions communicate **what** went wrong, not just **that** something went wrong | | |
| 2 | Custom exceptions carry domain-specific **properties** (`Temperature`, `Min`, `Max`) | | |
| 3 | Custom exceptions provide the three **standard constructors** | | |
| 4 | `finally` is used only for **cleanup** that must always run | | |
| 5 | **TryXxx methods** never throw — they return `bool` + `out` param | | |
| 6 | `InvalidOperationException` is thrown for **invalid object state**, not for bad input | | |
| 7 | `ArgumentNullException` / `ArgumentException` guard public API entry points | | |
| 8 | Exception messages are **specific** and include the offending value | | |
| 9 | Exceptions are not used as **control flow** | | |
| 10 | Disposable resources are handled with `using` or `try`/`finally` | | |

---

## Reflection questions

1. In `SafeCalculator.Divide`, why is `ArgumentException` more appropriate than `DivideByZeroException`?

2. Why should `TemperatureOutOfRangeException` inherit from `Exception` directly rather than `ArgumentOutOfRangeException`? (Hint: `SetTemperature` is not a constructor argument.)

3. Describe a situation where `TryDequeue` is safer to call than `Dequeue`.
