//Top level programs - no namespace or class is needed
using System;
using System.Collections.Generic;

//create instance of class with init only property
var person = new Person
{
    Name = "Arek",
    Age = 34
};

//person.Name = "Arek Piznal"; cause error because value can't be assigned to this property again
Console.WriteLine($"Hello {person.Name}");

//create instance of record
var personRecord = new Person2 { FirstName = "Arek", LastName ="P" };

//records are designed to be immutable "with" keyword is used to create copy of record with changed value like in F#
var personRecord2 = personRecord with {FirstName = "Arkadiusz" };
Console.WriteLine($"Hello {personRecord2.FirstName}");

//now personRecord3 have same values as personRecord but it's different record
var personRecord3 = personRecord2 with { FirstName = "Arek"};

//ReferenceEquals return false because they have different memory addresses but Equals retrurn true because they have same values
Console.WriteLine($"Reference equals {ReferenceEquals(personRecord, personRecord3)}, Equals {Equals(personRecord, personRecord3)}");

//create record using constructor 
var car = new Car("Skoda", "Fabia");

//and using it with deconstructor
var (producer, model) = car;

//target typed new expression, thanks to this speficy type after new kayword is not required :)
Car car2 = new("skoda", "fabia");

//this works also for classes
List<string> values = new();

//Types declaration below this line 

//Init-only properties - properties Name and Age are init only so it's vale can be set only during object creation
public class Person
{
    private readonly string name;
    public string Name
    {
        get => name;
        //init allows to modify private read only fields
        init => name = (value ?? throw new ArgumentNullException(nameof(Age)));
    }
    public int Age { get; init; }
}

//Records - immutable class that acts as struct (is reference type), but Equals(...) is comparing values instead of memory address.
/*MSDN explanation: "A record is still a class, but the record keyword imbues it with several additional value-like behaviors. 
Generally speaking, records are defined by their contents, not their identity. 
In this regard, records are much closer to structs, but records are still reference types."*/
public record Person2
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

//Records also supports positional constructors, then property declaration is not needed
public record Car(string Producer, string Model);