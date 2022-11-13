// By default C# strings are hardcoded to UTF-16, whereas the prevailing string encoding on the internet is UTF-8.
// To minimize the hassle and performance overhead of converting, you can now simply append a u8 suffix to your string literals to get them in UTF-8 right away:
ReadOnlySpan<byte> u8 = "This is a UTF-8 string!"u8;


// You can match an array or a list against a sequence of patterns.
// See more: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#list-patterns
int[] numbers = { 1, 2, 3 };
Console.WriteLine(numbers is [1, 2, 3]); //is true

// To match elements only at the start or/and the end of an input sequence, use the slice pattern ..
Console.WriteLine(new[] { 1, 2, 3, 4, 5 } is [> 0, > 0, ..]);  // True
Console.WriteLine(new[] { 1, 1 } is [_, _, ..]);  // True
Console.WriteLine(new[] { 0, 1, 2, 3, 4 } is [> 0, > 0, ..]);  // False
Console.WriteLine(new[] { 1 } is [1, 2, ..]);  // False


// Raw literal strings are strings that does not have escape characters. Everything is content.
// See more: https://learn.microsoft.com/en-gb/dotnet/csharp/programming-guide/strings/#raw-string-literals
string rawString = """Friends say "hello" as they \pass\ by.""";
string multiLineRawString = """
    "Hello World!" is typically the first program someone writes.
    """;
string jsonRawString = """
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "DatesAvailable": [
    "2019-08-01T00:00:00-07:00",
    "2019-08-02T00:00:00-07:00"
  ],
  "TemperatureRanges": {
    "Cold": {
      "High": 20,
      "Low": -10
    },
    "Hot": {
      "High": 60,
      "Low": 20
    }
            },
  "SummaryWords": [
    "Cool",
    "Windy",
    "Humid"
  ]
}
""";


// Pattern matching supports comparing string to Span<T> and ReadOnlySpan<T>
bool PerformMatchOnSpan(ReadOnlySpan<char> command) =>
       command switch
       {
           "Start" => true,
           "Stop" => false,
           _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
       };


// Beginning with C# 11, you can use a nameof expression with a method parameter inside an attribute on a method or its parameter.
// AP - IMHO this is a great feature. You can pass to attribute used in middleware name of parameter that should be validated. 
[SomeAttribute(nameof(msg))]
void Method(string msg)
{
    [SomeAttribute(nameof(T))]
    void LocalFunction<T>(T param)
    { }

    var lambdaExpression = ([SomeAttribute(nameof(aNumber))] int aNumber) => aNumber.ToString();
}


// You can add the required modifier to properties and fields to enforce constructors and callers to initialize those values.
// Properties FirstName and LastName must be initialized during construction instance of Person class.
var person = new Person()
{
    LastName = "test", 
    FirstName = "test",
};

public class Person
{
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
}


// The file modifier restricts a top-level type's scope and visibility to the file in which it's declared.
// The file modifier will generally be applied to types written by a source generator
file class FileScopedClass { }


// Generic atributes. Finally! :)
class GenericAttribute<T> : Attribute { }

[GenericAttribute<string>]
class Test { }


// C# 11 allows to define static abstract members in interfaces.
// This is mainly done to allow abstract over operators.
public interface IMonoid<TSelf> where TSelf : IMonoid<TSelf>
{
    public static abstract TSelf operator +(TSelf a, TSelf b);
    public static abstract TSelf Zero { get; }
}

public struct MyInt : IMonoid<MyInt>
{
    int value;
    public MyInt(int i) => value = i;
    public static MyInt operator +(MyInt a, MyInt b) => new MyInt(a.value + b.value);
    public static MyInt Zero => new MyInt(0);
}


# region helpers
class SomeAttribute : Attribute
{
    public SomeAttribute(string name) { }
}

#endregion

//Source:
// https://devblogs.microsoft.com/dotnet/welcome-to-csharp-11/
// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#extended-nameof-scope