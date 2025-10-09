using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Behavioural.Strategy
{
    public interface IAttack
    {
        void Attack();
    }

    class SwordAttack : IAttack
    {
        public void Attack() {
            Console.WriteLine("Damage dealt with sowrd: -20 Hp");
        }
    }

    class BowAttack : IAttack
    {
        public void Attack() => Console.WriteLine("Damage dealt with Bow: -10 Hp");
    }

    class MagicAttack : IAttack
    {
        public void Attack() => Console.WriteLine("Damage dealt with Magic: -50 Hp");
    }

    class MeeleAttack : IAttack
    {
        public void Attack()=> Console.WriteLine("Damage dealt with Meele: -5 Hp");
    }


    class Character
    {
        // So many other properties

        private IAttack _attack;

        public Character()
        {
            _attack = new MeeleAttack();
        }

        public Character(IAttack attack)
        {
            _attack = attack;
        }

        public void Emote() => Console.WriteLine("xOx");
        public void SetAttack(IAttack attack)=> _attack = attack;
        public void Attack()=> _attack.Attack();
    }

}

/*
The Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable.
It lets the algorithm vary independently from the clients that use it.

Intent

Separate what an object does from how it does it.
Allow objects to change their behavior dynamically at runtime.
Replace long chains of if or switch statements with polymorphism.

Without Strategy Pattern:
The class (Character, PaymentProcessor, etc.) has many possible behaviors inside.
Behavior is chosen using conditionals (if (type == X) ...).

With Strategy Pattern:
Each behavior is extracted into its own class (called a strategy).
The main class (context) holds a reference to a strategy and delegates work to it.
You can switch the strategy object at runtime to change behavior.


| Context           | Strategies                               |
| ----------------- | ---------------------------------------- |
| Character attacks | Sword, Bow, Magic                        |
| Payment system    | CreditCard, PayPal, Crypto               |
| Sorting algorithm | QuickSort, MergeSort, HeapSort           |
| Compression       | ZIP, RAR, TAR                            |
| Route finding     | Shortest path, Fastest path, Scenic path |


| Aspect                    |   Strategy Pattern                                         |   State Pattern                                                       |
| ------------------------- | ---------------------------------------------------------- | --------------------------------------------------------------------- |
|   Intent                  | Lets you choose an *algorithm or behavior* dynamically.    | Lets an object *change its behavior when its internal state changes.* |
|   Who decides behavior?   | The   client   decides which strategy to use.              | The   object itself   decides which state it’s in.                    |
|   Focus                   | Selecting *how* something is done.                         | Representing *what condition* the object is in.                       |
|   Change trigger          | External (user or system chooses strategy).                | Internal (object transitions itself).                                 |
|   Awareness               | Strategies are usually unaware of each other.              | States often know each other and decide transitions.                  |
|   Example                 | Choose between different attack types (Sword, Bow, Magic). | Character behaves differently when Healthy, Injured, or Dead.         |




Strategy: “I’ll choose how I do something.”
State: “I’ll change what I do based on my current condition.”

 
 
 
IAttack attack = new SwordAttack(); // chosen by player
character.SetAttack(attack);
character.Attack();



// states: Normal, Stunned, Dead
character.Move();   // works if Normal
character.TakeHit(100);
character.Move();   // no movement if Dead

The object itself (Character) changes what it can do internally — the client doesn’t choose.
 
 */