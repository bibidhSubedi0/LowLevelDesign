using LowLevelDesign.OOP.Payment;

class EmailService
{
    public void sendEmail()
    {
        System.Console.WriteLine("Sending email...");
        connect();
        authenticate();
        disconnect();
    }

    // ALL THE BELOW METHODS ARE PRIVATE -- THEY ARE NOT EXPOSED TO OTHER CLASSES. OTHER CLASSES JUST WANT TO SEND EMAILS, NO NEED FOR THEM TO SEE ALL THE COMPLEX DETAILS OF CONNECTING TO MAIL SERVER, AUTHENTICATING, DISCONNECTING.

    private void connect()
    {
        System.Console.WriteLine("Connecting to email server...");
    }

    private void authenticate()
    {
        System.Console.WriteLine("Authenticating...");
    }

    private void disconnect()
    {
        System.Console.WriteLine("Disconnecting from email server...");
    }
}


namespace LowLevelDesign.OOP.Payment
{
    public interface IPayment
    {
        void process(decimal amount);
    }

    public class CreditCard : IPayment
    {
        public void process(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void process(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
            // Connect to PayPal API, verify, complete transaction
        }
    }

}

namespace LowLevelDesign.OOP.Checout
{
    public class CheckoutService
    {
        private readonly IPayment _paymentProcessor;

        public CheckoutService(IPayment paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void CompleteOrder(decimal orderAmount)
        {
            _paymentProcessor.process(orderAmount);
            Console.WriteLine("Order completed successfully!");
        }
    }
}

/*
    hiding irrelevant details and exposing only the essential characteristics and behaviors

    We define abstract types (classes, interfaces) that specify what an object can do, not how it does it.
    Concrete classes then implement the details.

    Abstract class: A class that cannot be instantiated; can contain abstract (unimplemented) methods as well as implemented ones.

+------------------------------+
| <<interface>> IPayment       |
+------------------------------+
| + Process(amount: decimal)   |
+------------------------------+

      ▲
      |
+------------------------------+
| CreditCardPayment            |
+------------------------------+
| + Process(amount: decimal)   |
+------------------------------+

      ▲
      |
+------------------------------+
| PayPalPayment                |
+------------------------------+
| + Process(amount: decimal)   |
+------------------------------+

CheckoutService knows only about IPayment → high-level module depends on abstraction → Dependency Inversion Principle.
You can add BankTransferPayment later without modifying CheckoutService.

It allows us to obtain Strategy Pattern: Choose behavior at runtime by injecting different implementations.
 
 */