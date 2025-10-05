using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.OOP
{
    public interface ISendNotification
    {
        void SendNotification(string to, string message);
    }

    public class EmailServiceCP : ISendNotification
    {
        public void SendNotification(string to, string message)
        {
            Console.WriteLine($"Sending email to {to}: {message}");
        }
    }

    public class SMSServiceCP : ISendNotification
    {
        public void SendNotification(string to, string message)
        {
            Console.WriteLine($"Sending SMS to {to}: {message}");
        }
    }

    public class UserManager
    {
        private readonly ISendNotification _notificationService;

        // Dependecy Injecion
        public UserManager(ISendNotification notificationService)
        {
            _notificationService = notificationService;
        }

        public void RegisterUser(string method)
        {
            Console.WriteLine("User registered.");
            _notificationService.SendNotification(method, "Welcome to our app!");
        }
    }
}



/*
Coupling refers to the degree of interdependence between two modules/classes/components.
“How much one class knows about, depends on, or interacts directly with another class.”

High coupling: Classes are tightly bound to each other’s implementation details.
Low coupling: Classes only depend on abstractions or minimal details, so changing one has little impact on the other.

We always aim for low coupling to improve maintainability, testability, and extensibility.


| Type of Coupling        | Description & Example                                                                        | Strength       |
| ----------------------- | -------------------------------------------------------------------------------------------- | -------------- |
|   Content Coupling      | One class modifies another class’s internal data directly (worst kind).                      | ❌ High         |
|   Common Coupling       | Classes share   global variables   or static data.                                           | ❌ High         |
|   Control Coupling      | One class   controls the flow   of another by passing it flags or conditions.                | ⚠️ Medium-High |
|   Stamp/Data Coupling   | Classes share   structured data   (like passing a whole object when only a field is needed). | ⚠️ Medium      |
|   Message Coupling      | Classes interact only via   well-defined interfaces / messages  .                            | ✅ Low          |
|   No Coupling           | Completely independent (rare in real apps).                                                  | ✅ Best         |

High coupling:

Breaks the Single Responsibility Principle (SRP).
Makes code hard to test because you can’t isolate modules.
Leads to ripple effects → a change in one class forces changes in many others.
Harder to reuse components.

Low coupling:
Improves reusability and maintainability.
Encourages dependency injection.
Supports Open/Closed Principle (OCP).

public class EmailService
{
    public void SendEmail(string to, string message)
    {
        Console.WriteLine($"Sending email to {to}: {message}");
    }
}

public class UserManager
{
    // HIGH COUPLING: directly creates EmailService
    private EmailService _emailService = new EmailService();

    public void RegisterUser(string email)
    {
        Console.WriteLine("User registered.");
        _emailService.SendEmail(email, "Welcome to our app!");
    }
}
UserManager is tightly dependent on the concrete EmailService class.
If we later want to send SMS or push notifications, we have to modify UserManager.


Example of low copupling is given above using dependency injection

*/