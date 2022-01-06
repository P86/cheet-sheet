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