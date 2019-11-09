using System;

namespace Cs7News
{
    class Cs7New
    {
        /// <summary>
        /// Zmienne out można deklarować w wywołaniu metody
        /// </summary>
        void OutVariables()
        {
            ReturnByOut(out string first, out string second, out var _);
        }

        void ReturnByOut(out string First, out string Second, out string IDontCare)
        {
            First = "First";
            Second = "Second";
            IDontCare = "";
        }

        /// <summary>
        /// Dopasowanie do wzorca, takie jak w językach funkcyjnych
        /// </summary>
        void PatternMatching(Object aObj)
        {
            switch (aObj)
            {
                case string s when String.IsNullOrEmpty(s):
                    Console.WriteLine("Empty string.");
                    break;
                case string s when s.Length > 10:
                    Console.WriteLine("It is long string.");
                    break;
                case int i when i % 2 == 0:
                    Console.WriteLine("It is even integer.");
                    break;
                default:
                    Console.WriteLine("OK. I don't know what it is.");
                    break;
            }
        }

        /// <summary>
        /// Funkcje mogą być deklarowane wewnątrz funkcji
        /// </summary>
        public void LocalFunctions()
        {
            var x = "test";
            print();

            void print()
            {
                Console.WriteLine($"{x}");
            }
        }
        
        /// <summary>
        /// Metoda może zwracać wiele parametrów jako tuple i nawet nadawać im nazwy
        /// </summary>
        void Tuples()
        {
            var version = GetVersion();
            Console.WriteLine($"Version {version.major}.{version.minor}.{version.other}");
        }

        /// <summary>
        /// Pozwala na "wybranie z obiektu jego składowych", min. elementów z Tuple
        /// </summary>
        public void Deconstruction()
        {
            var (ver1, ver2, ver3) = GetVersion();
            Console.WriteLine($"Version {ver1}.{ver2}.{ver3}");

            var point = new Point(10d, 10d, 0d);
            var (x, y, z) = point;
            Console.WriteLine($"Version {x} {y} {z}");
        }

        /// <summary>
        /// Żeby to zadziałalo dla .NET <= 4.6.2 lub Core trzeba zainstalować: Install-Package "System.ValueTuple"
        /// </summary>
        /// <returns></returns>
        (int major, int minor, int other) GetVersion()
        {
            return (7, 0, 2);
            //nazwy można również nadać w return (major: 7, minor: 0, other: 2); 
        }

        /// <summary>
        /// Każdy typ może posiadać dekonstruktor, może nawet to być extension method
        /// </summary>
        internal class Point
        {
            public Point(double x, double y, double z)
            {
                X = x; Y = y; Z = z;
            }
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public void Deconstruct(out double x, out double y, out double z) { x = X; y = Y; z = Z; }
        }

        /// <summary>
        /// w C# 7.0 wyjątki mogą być rzuane w nowych instrukcji
        /// </summary>
        /// <param name="aInput"></param>
        void Exceptions(string aInput)
        {
            var input = aInput ?? throw new ArgumentNullException(nameof(aInput));

            string GetName() => throw new NotImplementedException();
        }

        private string _value;
        /// <summary>
        /// Propercje mogą występować w wariancie expression bodied
        /// </summary>
        string ExpressionBodiedProperty
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// Konstruktor też może być w wariancie expression bodied
        /// </summary>
        public Cs7New() => _value = "Cs7New";
    }
}