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
- [Disposing objects](#disposing-objects)

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

Characteristics:
- Value equality
- Allocated on [stack](#stack)
- Copied when passed to method and returned from method

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

Example:
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

Example: 
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

## Disposing objects
Implementing the Dispose method is primarily for **releasing unmanaged resources**. There are additional reasons for implementing Dispose, for example, to free memory that was allocated, remove an item that was added to a collection, or signal the release of a lock that was acquired. The pattern for disposing an object, referred to as the **dispose pattern**, imposes order on the lifetime of an object. The dispose pattern is used for objects that implement the **IDisposable interface**, and is common when interacting with **file and pipe handles, registry handles, wait handles, or pointers to blocks of unmanaged memory**. This is because the garbage collector is unable to reclaim unmanaged objects. To help ensure that resources are always cleaned up appropriately, a **Dispose method should be idempotent**, such that it is callable multiple times **without throwing an exception**. Furthermore, subsequent invocations of Dispose should do nothing.

**Dispose** method is called when it is no longer needed (**by a consumer** of the type), its purpose is to **free unmanaged resources, perform general cleanup, and to indicate that the finalizer, if one is present, doesn't have to run**. The Dispose method performs all object cleanup, so the garbage collector no longer needs to call the objects' Object.Finalize override. Therefore, the call to the SuppressFinalize method prevents the garbage collector from running the finalizer. If the type has no finalizer, the call to GC.SuppressFinalize has no effect. Note that the actual cleanup is performed by the Dispose(bool) method overload.

In **Dispose(bool) method** the disposing parameter is a Boolean that indicates whether the method call comes from a **Dispose method (its value is true) or from a finalizer (its value is false)**.
The body of the method consists of three blocks of code:
- A block for conditional return if object is already disposed.
- A block that **frees unmanaged resources**. This block executes regardless of the value of the disposing parameter.
- A conditional block that frees managed resources. This block executes if the value of disposing is true. The managed resources that it frees can include:
    - Managed objects that implement IDisposable. The conditional block can be used to call their Dispose implementation (cascade dispose). 
    - Managed objects that consume large amounts of memory or consume scarce resources. Assign large managed object references to null to make them more likely to be unreachable. This releases them faster than if they were reclaimed non-deterministically.

**If the method call comes from a finalizer, only the code that frees unmanaged resources should execute**. The implementer is responsible for ensuring that the false path doesn't interact with managed objects that may have been disposed. This is important because the order in which the garbage collector disposes managed objects during finalization is non-deterministic.

```
The disposing parameter should be false when called from a finalizer, and true when called from the IDisposable.Dispose method. In other words, it is true when deterministically called and false when non-deterministically called.
```

Example:
```cs
class DisposableType : IDisposable
{
    private bool _disposed;

    ~DisposableType() => Dispose(false); //finalizer - always call Dispose with false

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            //dispose managed state (managed objects).
        }

        //free unmanaged resources (unmanaged objects) and override a finalizer below.
        //set large fields to null.
        _disposed = true;
    }
}
```


## ref, in, out keywords

## exceptions

## Garbage collector

## Generics

## Boxing