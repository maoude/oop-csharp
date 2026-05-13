# Troubleshooting — Week 7 · Exception Handling

---

## Build errors

### CS0115 — method marked `override` but no matching virtual/abstract method

**Cause:** you typed `override` on a new method that does not exist in the base.  
**Fix:** remove `override`, or check the exact method signature in the base class / interface.

### CS0161 — not all code paths return a value

**Cause:** your method has a `try`/`catch` block but the `catch` path may fall through without returning.  
**Fix:** add a `return` or `throw` at the end of every branch, including after `catch`.

---

## Test failures

### "Expected: ... Actual: NotImplementedException"

All tests fail immediately with `NotImplementedException`.  
**Fix:** replace `throw new NotImplementedException()` with your implementation.

### `ParseAndAdd` — wrong `FormatException` message

The test checks `Assert.Contains("bad", ex.Message)` (or similar).  
Make sure the message includes the **original string** that failed to parse: `$"Not a valid number: '{a}'"`.

### `ParseWithFinally` — `attemptCount` not incremented on exception

**Cause:** you incremented `attemptCount` in the `try` block, not `finally`.  
**Fix:** move the increment into the `finally` block — it must run whether or not an exception is thrown.

### `ReadAverageOrDefault` — returns wrong value when some readings are invalid

**Cause:** invalid readings are being counted in the divisor.  
**Fix:** only add a reading to `sum` (and increment `count`) *after* `SetTemperature` succeeds without throwing.

### `TryDequeue` — test says method throws

**Cause:** your `TryDequeue` calls `Dequeue()` internally (which throws on empty).  
**Fix:** check `_queue.Count` or use `Queue<T>.TryDequeue` directly instead of calling your `Dequeue()`.

### `Enqueue(null)` — `ArgumentNullException` not thrown

**Cause:** the null-check is missing, or you wrote `if (item == null)` on a generic `T` — this doesn't work for value types.  
**Fix:** use `if (item is null)` which is safe for all types, or check `typeof(T).IsValueType` first.

---

## Runtime behaviour

### `TemperatureOutOfRangeException` — `Temperature` property is `0` after construction

**Cause:** you forgot to set `Temperature = temperature;` in the domain constructor body.  
**Fix:** assign all three properties (`Temperature`, `Min`, `Max`) after calling `base(message)`.

### `Thermometer.ReadAverageOrDefault` — `Temperature` not reset to 20.0 after the call

**Cause:** `Temperature = 20.0;` is only in the `try` path.  
**Fix:** move the reset to *after* the loop (it should always execute regardless of exceptions).
