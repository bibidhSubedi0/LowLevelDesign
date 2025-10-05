using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.OOP
{
    internal class Composition
    {
    }
}
/*
    Composition is an OOP principle where one class contains objects of other classes to build more complex behavior.
    “HAS-A” relationship

| Aspect            | Composition (HAS-A)                                   | Inheritance (IS-A)                                |
| ----------------- | ----------------------------------------------------- | ------------------------------------------------- |
| Relationship      | One class **uses/contains** another.                  | One class **is a kind of** another.               |
| Flexibility       | ✅ Highly flexible → can swap components easily.       | ⚠️ Less flexible → tightly bound to parent class. |
| Coupling          | ✅ Looser coupling.                                    | ⚠️ Tighter coupling.                              |
| Code Reuse        | ✅ Achieved by delegation.                             | ✅ Achieved by inheriting code.                    |
| Run-time Behavior | ✅ Can change dynamically at runtime.                  | ❌ Fixed at compile time.                          |
| LLD Preference    | ✅ Preferred (Composition over Inheritance Principle). | Use only for strict IS-A hierarchies.             |


“Favor composition over inheritance.”
Problems with Inheritance
Tight Coupling
Fragile Base Class Problem : A change in the base class can ripple down and break subclasses because subclasses inherit all base behavior — even what they don’t want.
Inflexibility (Single Inheritance in C#)
Code Bloat and Poor Reusability
*/