![logo](./assets/cs.png)

## Stack
The "stack" is a serially-addressed area of memory that is partially automatically managed for you by the CPU. Also a stack is an array or list structure of function calls and parameters used in modern computer programming and CPU architecture.

## Heap
The Heap is more or less responsible for keeping track of objects.

## Value types
A variable of a value type contains an **instance of the type**. This differs from a variable of a reference type, which contains a reference to an instance of the type. 
By default, on assignment, passing an argument to a method, and returning a method result, variable values are copied. In the case of value-type variables, the corresponding type instances are copied.

Built-in value types:
- intergral numeric types (sbyte, byte, short, ushort, int etc.)
- floating-point numeric types (float, double, decimal)
- bool
- char 
- enumerations
- tuples ? - decompiler shows that tuple is a class
- structures

## Reference types
Variables of reference types store **references to their instances**. With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable.

Built-in reference types:
- [class](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class)
- [interface](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface)
- [delegete](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
- [record](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
- [dynamic](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
- [object](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
- [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)

## Task and Task<TResult>
The Task class represents a single operation that usually executes asynchronously. Work performed by a Task object typically executes asynchronously on a thread pool thread rather than synchronously on the main application. thread. Task objects are one of the central components of the [task-based asynchronous pattern](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)

## Stackalloc
A stackalloc expression allocates a block of memory on the stack. A stack allocated memory block created during the method execution is **automatically discarded when that method returns**. You cannot explicitly free the memory allocated with stackalloc. A stack allocated memory block is not subject to garbage collection and doesn't have to be pinned with a fixed statement. The amount of memory available on the stack is limited. **If you allocate too much memory on the stack, a StackOverflowException is thrown**.
You don't have to use an unsafe context when you assign a stack allocated memory block to a Span<T> or ReadOnlySpan<T> variable.
```cs
Span<int> stackAllocatedMemory = stackalloc int[20];
```

## Operator overdload

## Custom type casting
A user-defined type can define a custom implicit or explicit conversion from or to another type. Implicit conversions don't require special syntax to be invoked and can occur in a variety of situations, for example, in assignments and methods invocations.
**Predefined C# implicit conversions always succeed and never throw an exception.** User-defined implicit conversions should **behave in that way** as well. If a custom conversion can throw an exception or lose information, define it as an explicit conversion.

```cs 
class Name
{
    public string? First { get; init; }
    public string? Last { get; init; }

    public Name(string fullName)
    {
        var splitted = fullName.Split(" ");
        First = splitted[0];
        Last = splitted[1];
    }

    public static implicit operator Name(string name) => new Name(name);
    public static explicit operator string(Name name) => $"{name.First} {name.Last}";
}
```
Implicit cast:
```cs
Name name = "Arek Piznal";
```
Explicit cast:
```cs
string name = (string)new Name("Arek Piznal");
```
