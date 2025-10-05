using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.OOP
{
    public class Vehicle
    {
        public int Id { get; set; }

        //public virtual void Idf()
        //{
        //    Console.WriteLine(Id + " from base");
        //}

        public virtual void greet()
        {
            Console.WriteLine("Heelo");
        }
    }

    public class Vech1 : Vehicle
    {
        public Vech1(int i)
        {
            this.Id = i;
        }
        public void Idf()
        {
            Console.WriteLine(Id + " from home");
        }
    }

    public class Vech2 : Vehicle
    {
        public Vech2(int i)
        {
            this.Id = i;
        }
        public void Idf()
        {
            Console.WriteLine(Id + " from home");
        }
    }




}

/*
    You can call the same method name on objects of different types,

| Type                      | Description                                                                                                         | Example Keyword / Mechanism                          |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------- |
|   Compile-time (Static)   | The compiler decides which method to call based on the signature.                                                   |   Method Overloading                                 |
|   Run-time (Dynamic)      | The decision of which method implementation to invoke is made at   runtime   based on the   object’s actual type  . |   Virtual / Override  ,   Interface Implementation   |

Static:
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

Run-Time
    public virtual void Speak()
    {
        Console.WriteLine($"{Name} makes a generic sound.");
    }

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void Speak()  // Overrides base implementation
    {
        Console.WriteLine($"{Name} barks: Woof!");
    }
}


Abstract Classes:
Can define both abstract methods (without implementation) and concrete methods (with implementation).
Provide a base class with shared functionality or state that other classes can inherit and extend.

| Feature                            | Interface                                                 | Abstract Class                                                            |
| ---------------------------------- | --------------------------------------------------------- | ------------------------------------------------------------------------- |
|   Purpose                          | Define a contract                                         | Provide shared functionality and base behavior                            |
|   Multiple Inheritance             | Yes, a class can implement multiple interfaces            | No, a class can inherit from only one abstract class                      |
|   Implementation                   | No implementation (except for default methods in C# 8.0+) | Can have both abstract and concrete methods                               |
|   Fields/Properties/Constructors   | No fields, properties, or constructors                    | Can have fields, properties, constructors, and more                       |
|   Access Modifiers                 | Members are implicitly public                             | Can have various access modifiers (public, protected, etc.)               |
|   Best Use Case                    | When you want to define a contract or capability          | When you want to provide a base class with shared implementation or state |

new vs override in C#
public class Base
{
    public virtual void Show() => Console.WriteLine("Base.Show");
}

public class Derived : Base
{
    public new void Show() => Console.WriteLine("Derived.Show");
}

class Program
{
    static void Main()
    {
        Base obj = new Derived();
        obj.Show(); // Output: Base.Show (not overridden)
    }
}


Why use   

public virtual void greet()
        {
            Console.WriteLine("Heelo");
        }

List<Vehicle> vehicles = new List<Vehicle>();

foreach(Vehicle vh in vehicles)
{
    Console.WriteLine(vh.Id);
    vh.greet(); // this will exsist
    vh.Idf(); // this is obviously not exsist
}

*/