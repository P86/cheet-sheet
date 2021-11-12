//global using is applied to all files in the compilation - mainly in project
global using System.Runtime.CompilerServices;

//File - scoped namespace declaration that all declarations that follow are members of the declared namespace:
//namespace CS10;

var point = new Point(0, 0, 0);
//positional paremeters in record struct are mutable
point.x = 3;

var vector = new Vector(0, 0, 0);
//positional paremeters in record class are immutable - this is same record as in C# 9
//vector.x = 0; 

//natural type for lambda expression - compiler infer type of lamba expression instead forcing to declare delegate type
var parse = (string s) => int.Parse(s);

//declared return type for lambda - tells compiler how to interpret returned value
var choose = object (bool b) => b ? 1 : "two";

//assignment and declaration in same deconstruction
var x = 0d;
var z = 10d;
(x, double y, z) = point;

//record struct creates value type
public record struct Point(double x, double y, double z);

//record class creates reference type - class keyword can be ommited
public record class Vector(double x, double y, double z)
{
    //ToString() can be sealed to prevent the compiler from synthesizing a ToString method for any derived record types.
    public sealed override string ToString()
    {
        return $"X: {x}; Y: {y}, Z: {z}";
    }

    //Use CallerArgumentExpressionAttribute to specify a parameter that the compiler replaces with the text representation of another argument.
    public static void Validate(bool condition, [CallerArgumentExpression("condition")] string? message = null)
    {
        if (!condition)
        {
            throw new InvalidOperationException($"Argument failed validation: <{message}>");
        }
    }
}