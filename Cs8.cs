using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CS8
{
    //https://docs.microsoft.com/pl-pl/dotnet/csharp/whats-new/csharp-8
    class CS8
    {
        struct ReadOnlyMember
        {
            public readonly string Name => "CS8";
            public readonly override string ToString() => $"{Name}";  /* Compiler will generate warrning if you will try access rw member from ro member */
        }

        #region Pattern matching
        public enum Direction
        {
            North,
            East,
            South,
            West
        }

        public static string SwitchExpression(Direction direction) => direction switch
        {
            Direction.North => "North", /* case: replaced by => */
            Direction.East => "East",
            Direction.South => "South",
            Direction.West => "West",
            _ => throw new InvalidOperationException() /* default replaced by _*/
        };

        public static string PropertyPatterns(FileInfo info) => info switch
        {
            { Extension: "cs" } => "goood!",
            { Extension: "rs" } => "better!!",
            { Extension: "js" } => "OMG why?",
            _ => throw new NotSupportedException($"Unknown file with extension { info.Extension }")
        };

        public static string TuplePatterns(string a, string b) => (a, b) switch
        {
            ("C#", "Linux") => "Not bad",
            ("C#", "Windows") => "Quite good",
            ("JavaScript", "Windows") => "Uhh...",
            _ => "I don't know"
        };

        public class Point
        {
            public int X { get; }
            public int Y { get; }
            public Point(int x, int y) => (X, Y) = (x, y);
            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        public static string PositionalPatterns(Point point) => point switch
        {
            (0, 0) => "Origin",
            var (x, y) when x > 0 && y > 0 => "Both positive",
            var (x, y) when x < 0 && y > 0 => "X negative, Y positive",
            var (x, y) when x < 0 && y < 0 => "Both negative",
            var (x, y) when x > 0 && y < 0 => "X positive, Y negatvie",
            var (_, _) => "On Border",
            _ => "Unknown"
        };
        #endregion

        #region Default interface implementation
        public interface IPrintable
        {
            public void Print() /*Interface can contain implementation - why not just use abstract class?*/
            {
                Console.WriteLine("Interface method");
            }
        }

        public class Printable : IPrintable
        {
        }
        #endregion

        #region Using declaration
        public static void WriteToFile(string message)
        {
            using var file = new StreamWriter("test.txt"); /* equivalent to using(var file = new StreamWriter("test.txt") {..} */
            file.WriteLine(message);
        }
        #endregion

        #region Static local functions 
        public static void Print()
        {
            static string GetMessage()
            {
                return "some message";
            }

            Console.WriteLine(GetMessage());
        }
        #endregion

        #region Nullable reference types
        /*nullable refs has to be used with annotations or with <Nullable>enable</Nullable> in project defined */
#nullable enable 
        public void NullableReference()
        {
            Point message = null; /*Generates warning here*/
            Console.WriteLine(message.X); /*Here also*/
        }
#nullable disable
        #endregion

        #region Asynchronous streams
        public async IAsyncEnumerable<int> GetSequence()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
                await Task.Delay(100);
            }
        }

        public async void ConsumeSequence()
        {
            await foreach (var number in GetSequence()) /*for each can be preceeded by await if it enumerates by IAsyncEnumerable*/
            {
                Console.WriteLine(number);
            }
        }
        #endregion

        #region Indices and ranges
        public static void Ranges()
        {
            var sentence = new[] { "Ala", "ma", "kota" };
            var kota = sentence[^1]; /*^ allows to access items from end, be carefoul with ^0 (which is equvalent to sentence.Length) it will throw*/
            var alaMa = sentence[0..2]; /*beginning is inclusive but end is exclusive*/

            var range = 1..;
            var maKota = sentence[range];
        }
        #endregion

        #region Null-coalescing assignment
        public static void NullCoalescing()
        {
            int? value = null;
            value ??= 10;

            /*equivalent to: 
            if(value == null)
            {
                value = 10;
            }*/
        }
        #endregion

        #region Unmanaged constructed types
        struct Coords<T>
        {
            public T X;
            public T Y;
        }
        public static void UnmanagedConstructedTypes()
        {
            /*Generic struct can be allocated on stack but only if all fields are of unmanaged types.*/
            Span<Coords<int>> coordinates = stackalloc[]{ new Coords<int> { X = 0, Y = 0 }, };
        }
        
        #endregion
    }
}
