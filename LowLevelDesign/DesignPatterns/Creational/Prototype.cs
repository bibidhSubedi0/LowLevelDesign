using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Creational.Prototype
{
    public interface ITroop
    {
        ITroop Clone();
    }

    public class Troop : ITroop
    {

        // Shallow copy is only dangerous when your class has MUTABLE reference types
        public string Name { get; set; }
        public int Health { get; set; }
        public string Weapon { get; set; }
        public Troop(string name, int health, string weapon)
        {
            Name = name;
            Health = health;
            Weapon = weapon;
        }


        // Shallow copy
        public ITroop Clone()
        {
            return (ITroop)this.MemberwiseClone();
        }

        public void Show()
        {
            Console.WriteLine($"Name: {Name}, Health: {Health}, Weapon: {Weapon}");
        }
    }
}


/*
Imporatant notes about references

Basics:
Memory: program has stack (local variables, return addresses) and heap (dynamically allocated memory).
Value types: variable directly contains its data (e.g., int, double, struct in C when not containing pointers).
Reference types (in general): variable refers to memory elsewhere — in C/C++ that’s pointers or C++ references.
Pointer: a variable that stores a memory address. You can change it to point elsewhere.
Reference (C++): an alias for another object; once bound, cannot be reseated.
Shallow copy: copies immediate fields (including pointer values) — pointers still point to same memory.
Deep copy: duplicates everything the original points at, so clones are independent.

// file: basics_c.c
#include <stdio.h>
#include <stdlib.h>

int main() {
    int x = 10;            // 'x' stored on the stack
    int *p = &x;          // p holds the address of x
    printf("x=%d, *p=%d\n", x, *p);   // 10, 10

    // allocate on heap
    int *h = malloc(sizeof(int));
    *h = 20;
    printf("heap *h=%d\n", *h);      // 20

    // copying pointer - shallow aliasing
    int *alias = h;
    *alias = 30;
    printf("*h after alias change=%d\n", *h); // 30

    free(h); // now alias is a dangling pointer! using alias -> UB
    // printf("%d\n", *alias); // DON'T do this; UB

    return 0;
}




// file: shallow_deep_c.c
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    char *name; // pointer to heap string
    int hp;
} Troop;

// shallow copy: copies pointer value
Troop shallow_copy(Troop src) {
    Troop t = src;
    return t;
}

// deep copy: duplicate pointed-to data
Troop deep_copy(Troop src) {
    Troop t;
    t.hp = src.hp;
    if (src.name) {
        t.name = malloc(strlen(src.name) + 1);
        strcpy(t.name, src.name);
    } else t.name = NULL;
    return t;
}

int main() {
    Troop base;
    base.hp = 50;
    base.name = malloc(8); strcpy(base.name, "Barbar");
    // shallow
    Troop s = shallow_copy(base);
    s.name[0] = 'X';
    printf("base.name after shallow change: %s\n", base.name); // shows change

    // deep
    Troop d = deep_copy(base);
    d.name[0] = 'Y';
    printf("base.name after deep change: %s\n", base.name); // unchanged
    printf("d.name = %s\n", d.name);

    free(base.name);
    free(d.name);
    return 0;
}









Summary (in simplest terms)

Value copy (like int a = 10; int b = a;)
→ Actual value (10) is copied → two separate variables → changing one does NOT affect the other.

Shallow copy (class/object)
→ Only the memory address is copied, not the actual object → both variables point to the same object → changing one also changes the original.

Deep copy (class/object)
→ A FULL NEW object is created in memory, with same data → two independent objects → changing one does NOT affect the original.

 
 */