using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.OOP
{
    internal class Inheritance
    {
    }
}


/*
    Avoid inheritance if: The relationship is not genuinely “is-a” → prefer composition for “has-a” relationships.
  
           +----------------+
           |   Vehicle      |  <-- Base class
           +----------------+
           | -speed: int    |
           | +Start()       |
           | +Stop()        |
           | +Drive()       |
           +----------------+
                 ▲
     ┌───────────┴─────────────┐
     │                         │
+------------+          +------------+
|   Car      |          |  Truck     |  <-- Derived classes
+------------+          +------------+
| +Drive()   |          | +Drive()   |
+------------+          +------------+

Inheritance doesn’t add algorithmic complexity; just a minor virtual-call dispatch at runtime.
Abstract base class: Use if the base class should not be instantiated directly.


Liskov Substitution Principle (L in SOLID): Subclasses should be usable in place of the base class without altering correctness.


The Fragile Base Class Problem occurs in object-oriented programming when changes to a base (parent) class unintentionally break the behavior of derived (child)

*/