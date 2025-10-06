using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.SOLID.OCP
{
    internal class OCP
    {
    }
}

/*
“A class should be open for extension but closed for modification.”

Prevents regressions
Makes your code flexible for change in requirements.
Improves maintainability and scalability.


public class DiscountCalculator
{
    public double CalculateDiscount(string customerType, double amount)
    {
        if (customerType == "Regular")
        {
            return amount * 0.1;
        }
        else if (customerType == "Premium")
        {
            return amount * 0.2;
        }
        else
        {
            return 0;
        }
    }
}

Every time we add a new customer type (VIP, Student, etc.), we have to modify this class.


// Step 1: Define abstraction
public interface IDiscount
{
    double Calculate(double amount);
}

// Step 2: Implement different strategies
public class RegularDiscount : IDiscount
{
    public double Calculate(double amount) => amount * 0.1;
}

public class PremiumDiscount : IDiscount
{
    public double Calculate(double amount) => amount * 0.2;
}

// Step 3: Calculator depends on abstraction
public class DiscountCalculator
{
    private readonly IDiscount _discount;

    public DiscountCalculator(IDiscount discount)
    {
        _discount = discount;
    }

    public double GetDiscount(double amount) => _discount.Calculate(amount);
}



Strategies to Achieve OCP
Polymorphism: Replace if-else or switch statements with subclassing.
Interfaces & Abstract Classes: Depend on abstractions instead of concretes.
Dependency Injection (DI): Pass dependencies at runtime.
Composition over Inheritance: Inject new behaviors via objects.
Design Patterns: Strategy, Factory Method, Decorator, and Template Method


Real-World Examples in C#
ASP.NET Core Middleware: You add new middleware by registering it, not modifying the pipeline core.
Logging (ILogger): Add new log providers without changing existing logging code.
Payment Gateway: Add new payment methods (PayPal, Stripe, etc.) by implementing a new interface.



Cheat Sheet

Definition: “Open for extension, closed for modification.”
Key Tool: Abstraction & Polymorphism.
Smell: Growing if-else / switch for new behavior.
Goal: Add new features without breaking existing code.
Patterns: Strategy, Decorator, Factory.
 */