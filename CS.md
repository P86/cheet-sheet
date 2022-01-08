![logo](./assets/cs.png)

# Table of contents
- [Stack](#stack)
- [Heap](#heap)
- [Value types](#value-types)
- [Reference types](#reference-types)
- [Task](#task)
- [Stackalloc](#stackalloc)
- [Custom type casting](#custom-type-casting)
- [Value equality for class](#value-equality-for-class)
- [Operator overdload](#operator-overdload)

## Stack
The "stack" is a serially-addressed area of memory that is partially automatically managed for you by the CPU. Also a stack is an array or list structure of function calls and parameters used in modern computer programming and CPU architecture.

## Heap
The Heap is more or less responsible for keeping track of objects.

## Value types
**A variable of a value type contains an instance of the type**. This differs from a variable of a reference type, which contains a reference to an instance of the type. 
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
**Variables of reference types store references to their instances**. With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable.

Built-in reference types:
- [class](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class)
- [interface](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface)
- [delegete](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
- [record](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
- [dynamic](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
- [object](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
- [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)

## Task
The Task class represents a single operation that usually executes asynchronously. Work performed by a Task object typically executes asynchronously on a thread pool thread rather than synchronously on the main application. thread. Task objects are one of the central components of the [task-based asynchronous pattern](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)

## Stackalloc
A stackalloc expression **allocates a block of memory on the stack**. A stack allocated memory block created during the method execution is **automatically discarded when that method returns**. You cannot explicitly free the memory allocated with stackalloc. A stack allocated memory block is not subject to garbage collection and doesn't have to be pinned with a fixed statement. The amount of memory available on the stack is limited. **If you allocate too much memory on the stack, a StackOverflowException is thrown**.
You don't have to use an unsafe context when you assign a stack allocated memory block to a Span<T> or ReadOnlySpan<T> variable.
```cs
Span<int> stackAllocatedMemory = stackalloc int[20];
```

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

## Value equality for class
[Records](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records) automatically implement value equality. **Consider defining a record instead of a class when your type models data and should implement value equality.** When you define a class or struct, you decide whether it makes sense to create a custom definition of value equality (or equivalence) for the type. Typically, you implement value equality when you expect to add objects of the type to a collection, or when their primary purpose is to store a set of fields or properties. You can base your definition of value equality on a comparison of all the fields and properties in the type, or you can base the definition on a subset.

Any **struct** that you define already **has a default implementation of value equality** that it inherits from the System.ValueType override of the Object.Equals(Object) method. 
This implementation **uses reflection** to examine all the fields and properties in the type. Although this implementation produces correct results, it **is relatively slow compared to a custom implementation** that you write specifically for the type.

This require the same basic steps for implementing equality:
- **Override the virtual Object.Equals(Object) method**. In most cases, your implementation of bool Equals( object obj ) should just call into the type-specific Equals method that is the implementation of the System.IEquatable<T> interface. (See step 2.)
- **Implement the System.IEquatable<T> interface** by providing a type-specific Equals method. This is where the actual equivalence comparison is performed. For example, you might decide to define equality by comparing only one or two fields in your type. Don't throw exceptions from Equals. For classes that are related by inheritance:

    - This method should examine only fields that are declared in the class. It should call base.Equals to examine fields that are in the base class. (Don't call base.Equals if the type inherits directly from Object, because the Object implementation of Object.Equals(Object) performs a reference equality check.)

    - Two variables should be deemed equal only if the run-time types of the variables being compared are the same. Also, make sure that the IEquatable implementation of the Equals method for the run-time type is used if the run-time and compile-time types of a variable are different. One strategy for making sure run-time types are always compared correctly is to implement IEquatable only in sealed classes. For more information, see the class example later in this article.

- Optional but recommended: **Overload the == and != operators**.
- **Override Object.GetHashCode** so that two objects that have value equality produce the same hash code.
- Optional: To support definitions for "greater than" or "less than," implement the IComparable<T> interface for your type, and also overload the <= and >= operators.
```cs
class Name : IEquatable<Name>
{
    public string? First { get; set; }
    public string? Last { get; init; }
    public override int GetHashCode() => (First, Last).GetHashCode();
    public override bool Equals(object? obj) => Equals(obj as Name);
    public bool Equals(Name? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false; // If run-time types are not exactly the same, return false.

        return (First == other.First) && (Last == other.Last);
    }

    public static bool operator == (Name lhs, Name rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                return true;
            }
            return false;
        }
        return lhs.Equals(rhs);// Equals handles case of null on right side.
    }

    public static bool operator !=(Name lhs, Name rhs) => !(lhs == rhs);
}
```

## Operator overdload
A **user-defined type can overload a predefined C# operator**. That is, a type can provide the custom implementation of an operation in case one or both of the operands are of that type. 
Use the operator keyword to declare an operator. 
An operator declaration must satisfy the following rules:
- It includes both a public and a static modifier.
- A unary operator has one input parameter. A binary operator has two input parameters. In each case, at least one parameter must have type T or T? where T is the type that contains the operator declaration.

For an example see example of [Value equality for class](#value-equality-for-class)
