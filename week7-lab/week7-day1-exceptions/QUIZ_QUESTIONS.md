# Quiz Questions — Week 7 · Exception Handling

---

## Part 1 — Try / Catch / Finally

**Q1.** What is the difference between `catch (Exception e)` and `catch (Exception e) when (e.Message.Contains("timeout"))`?

**Q2.** Does a `finally` block execute when an exception is not caught? Explain.

**Q3.** You have code that calls `int.Parse(s)` inside a `try` block. The `finally` block increments a counter. If `Parse` throws, does the counter still increment?

**Q4.** When should you use `throw;` instead of `throw ex;`? What is the difference?

**Q5.** Name two situations in which catching `Exception` (the base class) is acceptable.

---

## Part 2 — Custom Exceptions

**Q6.** What are the three constructors that a well-designed custom exception should provide in addition to its domain constructor?

**Q7.** Why should domain exceptions inherit from a more specific class (like `InvalidOperationException`) rather than `Exception` directly, in large codebases?

**Q8.** You catch `TemperatureOutOfRangeException` and want to wrap it in a higher-level `DataProcessingException`. How do you preserve the original exception?

**Q9.** What is the purpose of the `InnerException` property?

**Q10.** True or False: you should throw `Exception` directly when your validation fails.

---

## Part 3 — Best Practices

**Q11.** Explain the TryXxx pattern. Give a real example from the .NET standard library.

**Q12.** Why is "swallowing" exceptions (empty `catch` blocks) considered a bad practice?

**Q13.** What does it mean to use exceptions as control flow? Why is this discouraged?

**Q14.** `Dequeue()` throws `InvalidOperationException` when the queue is empty. `TryDequeue()` returns `false`. When would you use each?

**Q15.** How does `using (var r = new StreamReader(...))` relate to exception safety?

---

## Answers (instructor key)

> Hide or remove this section before distributing to students.

1. The `when` clause is evaluated without unwinding the stack; only if it returns `true` does the handler execute.  
2. Yes — `finally` always runs regardless of whether an exception is caught or not (barring `Environment.FailFast`).  
3. Yes — `finally` runs before the exception propagates up the call stack.  
4. `throw;` preserves the original stack trace; `throw ex;` resets it to the current line.  
5. Logging infrastructure; top-level unhandled-exception handlers.  
6. `()`, `(string message)`, `(string message, Exception innerException)`.  
7. Callers can catch more general or more specific exceptions depending on how much they know; it enables meaningful catch hierarchies.  
8. `throw new DataProcessingException("...", caughtEx);` — pass `caughtEx` as `innerException`.  
9. It links chained exceptions so the full causal chain is visible in logs and diagnostics.  
10. False — throw an appropriate, more specific exception type.  
11. Method returns `bool`; result via `out` parameter; never throws. Example: `int.TryParse`, `Dictionary.TryGetValue`.  
12. Errors are silently ignored, making bugs invisible and extremely hard to diagnose.  
13. Using `throw`/`catch` to branch logic instead of `if`/`else`; exceptions are slow and the intent is unclear.  
14. `Dequeue()` when you expect the queue to be non-empty (bug if empty); `TryDequeue()` when empty is a normal, expected state.  
15. `using` calls `Dispose()` in a `finally` block, ensuring the resource is released even if an exception is thrown inside the block.
