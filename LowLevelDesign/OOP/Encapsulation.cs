using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LowLevelDesign.OOP.GoodClass;

namespace LowLevelDesign.OOP
{
    public class Encapsulation
    {
        public void runner()
        {
            BankAccount bank = new BankAccount(0);
            bank.Deposite(100);
            Console.WriteLine(bank.GetBalance());
            bank.Withdraw(20);
            Console.WriteLine(bank.GetBalance());
            bank.Withdraw(100);
        }
    }
}

namespace LowLevelDesign.OOP.GoodClass
{
    class BankAccount
    {
        private decimal balance { get; set; }
        public BankAccount(decimal balance)
        {
            Deposite(balance);
        }

        public void Deposite(decimal amount) { 
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            this.balance += amount;
        }
        
        public decimal GetBalance()
        {
            return this.balance;
        }


        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawl Amount must be positive");
            }
            if(amount > balance)
            {
                throw new InvalidOperationException("Insufficient Amount");
            }

            this.balance -= amount;
        }
    }
}

/*
Notes
-> bundling of data (fields) and the operations that work on that data (methods) into a single logical unit
    — typically a class — and restricting outside access to the internal representation.

-> security & maintainability

-> internal class => even within the same soltion, different projects cant access each other internal class

-> Encapsulation itself adds no algorithmic complexity.

-> Might add negligible overhead due to method calls (usually optimized by JIT/compilers)

-> Performance trade-off is negligible compared to the safety & maintainability benefits.

-> Common Mistakes
    -> Exposing all fields through public getters/setters
    -> Breaking invariants: Allowing setBalance(-500) externally without validation.
    -> Leaking references: Returning internal mutable objects (e.g., returning a mutable List that callers can modify).
    -> Over-encapsulation
 */