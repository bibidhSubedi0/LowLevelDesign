using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.SOLID.SRP
{
    internal class SRP
    {
    }
}

// Single Responsibility Principle (SRP)

/*
    “A class (or module) should have only one reason to change.”



Bad Example:

public class Invoice
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    // Business logic
    public decimal CalculateTax()
    {
        return Amount * 0.13m;
    }

    // Persistence logic
    public void SaveToDatabase()
    {
        Console.WriteLine("Saving invoice to database...");
        // DB code here
    }

    // Presentation logic
    public void PrintInvoice()
    {
        Console.WriteLine($"Invoice {Id}, Amount: {Amount}");
    }
}

This class has 3 reasons to change
    -> To change the tax logic
    -> To change the database logic
    -> TO change the interface logic


// 1️ Invoice holds only invoice data + core business logic
public class Invoice
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    public decimal CalculateTax() => Amount * 0.13m;
}

// 2️ Handles persistence
public class InvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine($"Saving invoice {invoice.Id} to database...");
        // DB save code
    }
}

// 3️ Handles presentation / output
public class InvoicePrinter
{
    public void Print(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Id}, Amount: {invoice.Amount}");
    }
}




How does SRP relate to coupling and cohesion?
SRP reduces coupling (less dependence on unrelated concerns) and increases cohesion (class focuses on one job)


*/



